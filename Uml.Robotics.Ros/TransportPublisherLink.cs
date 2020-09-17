using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Xamla.Robotics.Ros.Async;

namespace Uml.Robotics.Ros
{
    /// <summary>
    /// Establishes a connection to a publisher and reads messages from it.
    /// </summary>
    internal class TransportPublisherLink
        : PublisherLink
    {
        private static readonly TimeSpan BASE_RETRY_DELAY = TimeSpan.FromMilliseconds(50);
        private static readonly TimeSpan MAX_RETRY_DELAY = TimeSpan.FromSeconds(2);

        private readonly ILogger logger = ApplicationLogging.CreateLogger<TransportPublisherLink>();

        Connection connection;
        volatile bool connected; // set to true for first time after successful header handshake
        volatile bool dropping;

        string host;
        int port;

        CancellationTokenSource cts;
        CancellationToken cancel;
        Task receiveLoop;
        TimeSpan retryDelay;

        public TransportPublisherLink(Subscription parent, string xmlRpcUri)
            : base(parent, xmlRpcUri)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            retryDelay = BASE_RETRY_DELAY;
            cts = new CancellationTokenSource();
            cancel = cts.Token;
        }

        public override void Dispose()
        {
            dropping = true;
            cts.Cancel();
            if (receiveLoop != null)
            {
                receiveLoop.WhenCompleted().Wait(); // wait for publisher loop to terminate
            }
        }

        public override bool IsConnected =>
            connected;

        private async Task WriteHeader()
        {
            var header = new Dictionary<string, string>
            {
                ["topic"] = Parent.Name,
                ["md5sum"] = Parent.Md5Sum,
                ["callerid"] = ThisNode.Name,
                ["type"] = Parent.DataType,
                ["tcp_nodelay"] = "1"
            };
            await connection.WriteHeader(header, cancel).ConfigureAwait(false);
        }

        private async Task HandleConnection()
        {
            // establish connection
            using (var client = new TcpClient())
            {
                await client.ConnectAsync(host, port).ConfigureAwait(false);
                client.NoDelay = true;

                try
                {
                    this.connection = new Connection(client);

                    // write/read header handshake
                    await WriteHeader().ConfigureAwait(false);

                    var headerFields = await connection.ReadHeader(cancel).ConfigureAwait(false);
                    SetHeader(new Header(headerFields));

                    // connection established
                    this.connected = true;

                    while (!cancel.IsCancellationRequested)
                    {
                        // read message length
                        int length = await connection.ReadInt32(cancel).ConfigureAwait(false);
                        if (length > Connection.MESSAGE_SIZE_LIMIT)
                        {
                            var message =
                                $"Message received in TransportPublisherLink exceeds length limit of {Connection.MESSAGE_SIZE_LIMIT}. Dropping connection";
                            throw new RosException(message);
                        }

                        // read message
                        var messageBuffer = await connection.ReadBlock(length, cancel).ConfigureAwait(false);

                        // deserialize message
                        RosMessage msg = RosMessage.Generate(Parent.DataType);
                        msg.Serialized = messageBuffer;
                        msg.connection_header = this.Header.Values;
                        HandleMessage(msg);

                        // reset retry delay after first successfully processed message
                        retryDelay = BASE_RETRY_DELAY;
                    }

                    client.Close();
                }
                catch (System.IO.EndOfStreamException ex)
                {
                    ROS.Debug()("EndOfStreamException during connection handling to a publisher. Message: {0}, Stacktrace : {1}",
                        ex.ToString(), ex.StackTrace);
                }
                catch (System.IO.IOException ex)
                {
                    ROS.Debug()("IOException during connection handling to a publisher. Message: {0}, Stacktrace : {1}",
                        ex.ToString(), ex.StackTrace);
                }
                catch (Exception ex)
                {
                    ROS.Error()("Error during connection handling to a publisher. Error: {0}, Stacktrace: {1}",
                        ex.ToString(),
                        ex.StackTrace);
                }
                finally
                {
                    this.connected = false;
                    this.connection = null;
                }
            }
        }

        public async Task RunReceiveLoopAsync()
        {
            await Task.Yield(); // do not block the thread starting the loop

            while (true)
            {
                cancel.ThrowIfCancellationRequested();

                try
                {
                    await HandleConnection().ConfigureAwait(false);
                }
                catch (HeaderErrorException e)
                {
                    logger.LogError(e, $"Error in the Header: {Parent?.Name ?? "unknown"}");
                    return; // no retry in case of header error
                }
                catch (Exception e)
                {
                    if (dropping || cancel.IsCancellationRequested)
                    {
                        return; // no retry when disposing
                    }

                    logger.LogError(e, e.Message);

                    retryDelay = retryDelay + retryDelay;
                    if (retryDelay > MAX_RETRY_DELAY)
                    {
                        retryDelay = MAX_RETRY_DELAY;
                    }

                    // wait abortable for retry
                    await Task.Delay(retryDelay, cancel).ConfigureAwait(false);
                }
            }
        }

        public void Initialize(string host, int port)
        {
            logger.LogDebug("Init transport publisher link: {0}", Parent.Name);

            this.host = host;
            this.port = port;

            receiveLoop = RunReceiveLoopAsync();
        }

        public void HandleMessage<T>(T m)
            where T : RosMessage, new()
        {
            Stats.BytesReceived += m.Serialized.Length;
            Stats.MessagesReceived++;
            m.connection_header = this.Header.Values;
            Stats.Drops += Parent.HandleMessage(m, true, false, connection.Header.Values, this);
        }
    }
}