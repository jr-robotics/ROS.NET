using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Uml.Robotics.Ros
{
    public class IServiceClientLink
    {
        private readonly ILogger logger = ApplicationLogging.CreateLogger<IServiceClientLink>();
        private Connection connection;
        private IServicePublication parent;
        private bool persistent;
        private CancellationTokenSource cts;
        private CancellationToken cancel;
        private Task serviceLoop;

        public IServiceClientLink()
        {
            this.cts = new CancellationTokenSource();
            this.cancel = cts.Token;
        }

        public virtual void Dispose()
        {
            cts.Cancel();
            UnregisterServiceLink();
        }

        private void UnregisterServiceLink()
        {
            parent.RemoveServiceClientLink(this);
            connection?.Dispose();
        }

        public void Initialize(Connection connection, Header header)
        {
            this.connection = connection;
            serviceLoop = RunServiceLoopAsync(header);
        }

        public Connection Connection =>
            connection;

        private async Task RunServiceLoopAsync(Header header)
        {
            await Task.Yield();

            try
            {
                try
                {
                    await HandleHeader(header).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    if (ROS.shuttingDown)
                    {
                        await connection.SendHeaderError("ROS node shutting down", cancel).ConfigureAwait(false);
                    }
                    else
                    {
                        ROS.Error()(e.Message);
                        await connection.SendHeaderError(e.Message, cancel).ConfigureAwait(false);
                    }

                    connection.Close(50);

                    throw;
                }

                while (true)
                {
                    cancel.ThrowIfCancellationRequested();

                    // read request
                    int requestLength = await connection.ReadInt32(cancel).ConfigureAwait(false);
                    if (requestLength < 0 || requestLength > Connection.MESSAGE_SIZE_LIMIT)
                    {
                        var errorMessage =
                            $"Message length exceeds limit of {Connection.MESSAGE_SIZE_LIMIT}. Dropping connection.";
                        ROS.Error()(errorMessage);
                        throw new ConnectionError(errorMessage);
                    }

                    byte[] requestBuffer = await connection.ReadBlock(requestLength, cancel).ConfigureAwait(false);

                    try
                    {
                        // process
                        var (result, success) = await parent.ProcessRequest(requestBuffer, this).ConfigureAwait(false);
                        await ProcessResponse(result, success).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        string errorMessage = "Exception thrown while processing service call: " + e.Message;
                        ROS.Error()(errorMessage);
                        await ProcessResponse(errorMessage, false).ConfigureAwait(false);
                    }

                    if (!persistent)
                        break;
                }
            }
            catch (System.IO.EndOfStreamException ex)
            {
                ROS.Debug()("EndOfStreamException during connection handling. Message: {0}, Stacktrace : {1}",
                    ex.ToString(), ex.StackTrace);
            }
            catch (System.IO.IOException ex)
            {
                ROS.Debug()("IOException during connection handling. Message: {0}, Stacktrace : {1}",
                    ex.ToString(), ex.StackTrace);
            }
            catch (Exception ex)
            {
                ROS.Error()("Error during service loop. Error: {0}, Stacktrace: {1}", ex.ToString(), ex.StackTrace);
            }
            finally
            {
                UnregisterServiceLink();
            }
        }

        private async Task HandleHeader(Header header)
        {
            if (!header.Values.ContainsKey("md5sum") || !header.Values.ContainsKey("service") || !header.Values.ContainsKey("callerid"))
            {
                throw new RosException("Error in TcpRos header. Required elements (md5sum, service, callerid) are missing"); ;
            }

            string md5sum = header.Values["md5sum"];
            string service = header.Values["service"];
            string clientCallerid = header.Values["callerid"];

            if (header.Values.ContainsKey("persistent") && (header.Values["persistent"] == "1" || header.Values["persistent"] == "true"))
            {
                persistent = true;
            }

            logger.LogDebug($"Service client [{clientCallerid}] wants service [{service}] with md5sum [{md5sum}]" );
            IServicePublication publication = ServiceManager.Instance.LookupServicePublication(service);
            if (publication == null)
            {
                throw new RosException($"Received a TcpRos connection for a nonexistent service [{service}]");
            }

            if (publication.md5sum != md5sum && md5sum != "*" && publication.md5sum != "*")
            {
                throw new RosException($"Client wants service {service} to have md5sum {md5sum} but it has {publication.md5sum}. Dropping connection");
            }

            if (publication.isDropped)
            {
                throw new RosException($"Received a TcpRos connection for a nonexistent service [{service}]");
            }

            parent = publication;
            IDictionary<string, string> m = new Dictionary<string, string>
            {
                ["request_type"] = publication.req_datatype,
                ["response_type"] = publication.res_datatype,
                ["type"] = publication.dataType,
                ["md5sum"] = publication.md5sum,
                ["callerid"] = ThisNode.Name
            };

            await connection.WriteHeader(m, cancel).ConfigureAwait(false);

            publication.AddServiceClientLink(this);
        }

        public virtual async Task ProcessResponse(string error, bool success)
        {
            var msg = new Messages.std_msgs.String(error);
            msg.Serialized = msg.Serialize();
            byte[] buf;
            if (success)
            {
                buf = new byte[msg.Serialized.Length + 1 + 4];
                buf[0] = (byte) (success ? 0x01 : 0x00);
                msg.Serialized.CopyTo(buf, 5);
                Array.Copy(BitConverter.GetBytes(msg.Serialized.Length),0, buf, 1,4);
            }
            else
            {
                buf = new byte[1 + 4];
                buf[0] = (byte) (success ? 0x01 : 0x00);
                Array.Copy(BitConverter.GetBytes(0),0, buf, 1,4);
            }

            await connection.WriteBlock(buf, 0, buf.Length, cancel).ConfigureAwait(false);
        }

        public virtual async Task ProcessResponse(RosMessage msg, bool success)
        {
            byte[] buf;
            if (success)
            {
                msg.Serialized = msg.Serialize();
                buf = new byte[msg.Serialized.Length + 1 + 4];
                buf[0] = (byte) (success ? 0x01 : 0x00);
                msg.Serialized.CopyTo(buf, 5);
                Array.Copy(BitConverter.GetBytes(msg.Serialized.Length),0, buf, 1,4);
            }
            else
            {
                buf = new byte[1 + 4];
                buf[0] = (byte) (success ? 0x01 : 0x00);
                Array.Copy(BitConverter.GetBytes(0),0, buf, 1,4);
            }
            await connection.WriteBlock(buf, 0, buf.Length, cancel).ConfigureAwait(false);
        }
    }
}
