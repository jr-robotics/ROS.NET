using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamla.Robotics.Ros.Async;

namespace Uml.Robotics.Ros
{
    internal class ServiceServerLink
        : IServiceServerLink
    {
        const int MAX_CALL_QUEUE_LENGTH = 8096;

        class CallInfo
        {
            public TaskCompletionSource<bool> Tcs { get; } = new TaskCompletionSource<bool>();
            public Task<bool> AsyncResult => this.Tcs.Task;
            public RosMessage Request { get; set; }
            public RosMessage Response { get; set; }
            public string ErrorMessage { get; set; }
        }

        private readonly ILogger logger = ApplicationLogging.CreateLogger<ServiceServerLink>();

        private Connection connection;
        private AsyncQueue<CallInfo> callQueue = new AsyncQueue<CallInfo>(MAX_CALL_QUEUE_LENGTH, true);

        private readonly string name;
        private readonly bool persistent;

        private readonly CancellationTokenSource cancellationTokenSource;
        private readonly CancellationToken cancel;

        private IDictionary<string, string> headerValues;
        Task connectionTask;

        public ServiceServerLink(
            Connection connection,
            string name,
            bool persistent,
            string requestMd5Sum,
            string responseMd5Sum,
            IDictionary<string, string> headerValues
        )
        {
            this.connection = connection;
            this.name = name;
            this.persistent = persistent;
            this.RequestMd5Sum = requestMd5Sum;
            this.ResponseMd5Sum = responseMd5Sum;
            this.headerValues = headerValues;

            this.cancellationTokenSource = new CancellationTokenSource();
            this.cancel = cancellationTokenSource.Token;
        }

        public Socket Socket =>
            connection?.Socket;

        public NetworkStream Stream =>
            connection?.Stream;

        public bool IsValid =>
            !cancellationTokenSource.IsCancellationRequested && connection != null && !connectionTask.IsCompleted && !callQueue.IsCompleted;

        public string RequestMd5Sum { get; private set; }
        public string RequestType { get; private set; }
        public string ResponseMd5Sum { get; private set; }
        public string ResponseType { get; private set; }
        public string ServiceMd5Sum { get; private set; }

        public void Dispose()
        {
            FlushCallQueue(null);
            callQueue.Dispose();
            cancellationTokenSource.Cancel();
            connection?.Dispose();
            connection = null;
        }

        public void Initialize<MSrv>()
            where MSrv : RosService, new()
        {
            MSrv srv = new MSrv();
            RequestMd5Sum = srv.RequestMessage.MD5Sum();
            ResponseMd5Sum = srv.ResponseMessage.MD5Sum();
            RequestType = srv.RequestMessage.MessageType;
            ResponseType = srv.ResponseMessage.MessageType;
            ServiceMd5Sum = srv.MD5Sum();

            this.connectionTask = HandleConnection();
        }

        public void Initialize<MReq, MRes>()
            where MReq : RosMessage, new() where MRes : RosMessage, new()
        {
            MReq req = new MReq();
            MRes res = new MRes();
            RequestMd5Sum = req.MD5Sum();
            ResponseMd5Sum = res.MD5Sum();
            RequestType = req.MessageType;
            ResponseType = res.MessageType;

            this.connectionTask = HandleConnection();
        }

        private async Task WriteHeader()
        {
            var header = new Dictionary<string, string>
            {
                ["service"] = name,
                ["md5sum"] = RosService.Generate(RequestType.Replace("__Request", "").Replace("__Response", "")).MD5Sum(),
                ["callerid"] = ThisNode.Name,
                ["persistent"] = persistent ? "1" : "0"
            };

            if (headerValues != null)
            {
                foreach (string o in headerValues.Keys)
                {
                    header[o] = headerValues[o];
                }
            }

            await this.connection.WriteHeader(header, cancel).ConfigureAwait(false);
        }

        private async Task<IDictionary<string, string>> ReadHeader()
        {
            var remoteHeader = await this.connection.ReadHeader(cancel).ConfigureAwait(false);

            if (!remoteHeader.TryGetValue("md5sum", out string md5sum))
            {
                string errorMessage = "TcpRos header from service server did not have required element: md5sum";
                ROS.Error()(errorMessage);
                throw new ConnectionError(errorMessage);
            }

            if (!string.IsNullOrEmpty(ServiceMd5Sum))
            {
                // TODO check md5sum
            }

            return remoteHeader;
        }

        private async Task<IDictionary<string, string>> Handshake()
        {
            await WriteHeader().ConfigureAwait(false);
            return await ReadHeader().ConfigureAwait(false);
        }

        private async Task ProcessCall(CallInfo call)
        {
            RosMessage request = call.Request;

            // serialize and send request
            request.Serialized = request.Serialize();

            await connection.WriteBlock(BitConverter.GetBytes(request.Serialized.Length), 0, 4, cancel).ConfigureAwait(false);
            await connection.WriteBlock(request.Serialized, 0, request.Serialized.Length, cancel).ConfigureAwait(false);

            // read response header
            var receiveBuffer = await connection.ReadBlock(5, cancel).ConfigureAwait(false);

            bool success = receiveBuffer[0] != 0;
            int responseLength = BitConverter.ToInt32(receiveBuffer, 1);

            if (responseLength < 0 || responseLength > Connection.MESSAGE_SIZE_LIMIT)
            {
                var errorMessage = $"Message length exceeds limit of {Connection.MESSAGE_SIZE_LIMIT}. Dropping connection.";
                ROS.Error()(errorMessage);
                throw new ConnectionError(errorMessage);
            }

            if (responseLength > 0)
            {
                logger.LogDebug($"Reading message with length of {responseLength}.");
                receiveBuffer = await connection.ReadBlock(responseLength, cancel).ConfigureAwait(false);
            }
            else
            {
                receiveBuffer = new byte[0];
            }

            if (success)
            {
                call.Response.Serialized = receiveBuffer;
                call.Tcs.TrySetResult(true);
            }
            else
            {
                if (receiveBuffer.Length > 0)
                {
                    // call failed with reason
                    call.Tcs.TrySetException(new Exception(Encoding.UTF8.GetString(receiveBuffer)));
                }

                call.Tcs.TrySetResult(false);
            }
        }

        async Task HandleConnection()
        {
            try
            {
                await Handshake().ConfigureAwait(false);

                while (await callQueue.MoveNext(cancel).ConfigureAwait(false))
                {
                    var call = callQueue.Current;
                    await ProcessCall(call).ConfigureAwait(false);
                }

                connection.Socket.Shutdown(SocketShutdown.Send);
                connection.Close(50);
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
            catch (Exception e)
            {
                if (!(e is OperationCanceledException))
                {
                    logger.LogDebug($"Service client for [{name}] dropped: {e.Message}");
                }

                FlushCallQueue(e);
                callQueue = new AsyncQueue<CallInfo>(MAX_CALL_QUEUE_LENGTH, true);

                throw;
            }
            finally
            {
                logger.LogDebug($"Removing service client for [{name}] from ServiceManager.");
                ServiceManager.Instance.RemoveServiceServerLinkAsync(this);
            }
        }

        private void FlushCallQueue(Exception e)
        {
            // mark queue as completed to ensure no further inserts can happen
            callQueue.OnCompleted();

            // cancel all other calls
            var remainingCalls = callQueue.Flush();

            if (callQueue.Current != null)
            {
                remainingCalls.Add(callQueue.Current);
            }

            foreach (var call in remainingCalls)
            {
                if (e != null)
                    call.Tcs.TrySetException(e);
                else
                    call.Tcs.TrySetCanceled();
            }
        }

        public async Task<bool> Call(RosService srv)
        {
            (bool result, RosMessage response) = await Call(srv.RequestMessage).ConfigureAwait(false);
            srv.ResponseMessage = response;
            return result;
        }

        public async Task<(bool, RosMessage)> Call(RosMessage request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            RosMessage response = RosMessage.Generate(request.MessageType.Replace("__Request", "__Response"));
            if (response == null)
                throw new Exception("Response message generation failed.");

            var queue = callQueue;
            try
            {
                var call = new CallInfo { Request = request, Response = response };
                await queue.OnNext(call, cancel).ConfigureAwait(false);

                bool success = await call.AsyncResult.ConfigureAwait(false);
                if (success)
                {
                    // response is only sent on success
                    response.Deserialize(response.Serialized);
                }

                return (success, response);
            }
            catch (Exception e)
            {
                ROS.Error()($"Service call failed: service [{name}] responded with an error: {e}");
                return (false, null);
            }
            finally
            {
                if (!persistent)
                {
                    queue.OnCompleted();
                }
            }
        }
    }
}
