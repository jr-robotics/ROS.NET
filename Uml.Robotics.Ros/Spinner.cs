using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Uml.Robotics.Ros
{
    public class SingleThreadSpinner
    {
        ICallbackQueue callbackQueue;
        private ILogger Logger { get; } = ApplicationLogging.CreateLogger<SingleThreadSpinner>();

        /// <summary>
        /// Creats a spinner for the global ROS callback queue
        /// </summary>
        public SingleThreadSpinner()
        {
            this.callbackQueue = ROS.GlobalCallbackQueue;
        }

        /// <summary>
        /// Creates a spinner for the given callback queue
        /// </summary>
        /// <param name="callbackQueue"></param>
        public SingleThreadSpinner(ICallbackQueue callbackQueue)
        {
            this.callbackQueue = callbackQueue;
        }

        public void Spin()
        {
            Spin(CancellationToken.None);
            Logger.LogCritical("CallbackQueue thread broke out! This only can happen if ROS.ok is false.");
        }

        public void Spin(CancellationToken cancel = default(CancellationToken))
        {
            Logger.LogInformation("Start spinning");
            while (ROS.OK)
            {
                callbackQueue.CallAvailable(ROS.WallDuration);

                if (cancel.IsCancellationRequested)
                    break;

                Thread.Yield();
            }
        }

        public void SpinOnce()
        {
            callbackQueue.CallAvailable(ROS.WallDuration);
        }
    }

    public class AsyncSpinner : IDisposable
    {
        private readonly ICallbackQueue callbackQueue;
        private Task spinTask;
        private CancellationTokenSource cts = new CancellationTokenSource();

        /// <summary>
        /// Creates a spinner for the global ROS callback queue
        /// </summary>
        public AsyncSpinner()
            : this(ROS.GlobalCallbackQueue)
        {
        }

        /// <summary>
        /// Create a spinner for the given callback queue
        /// </summary>
        /// <param name="callbackQueue"></param>
        public AsyncSpinner(ICallbackQueue callbackQueue)
        {
            this.callbackQueue = callbackQueue;
        }

        public void Dispose()
        {
            Stop(true);
            cts.Dispose();
        }

        public void Start()
        {
            spinTask = Task.Factory.StartNew(() =>
            {
                var cancel = cts.Token;
                var spinner = new SingleThreadSpinner(callbackQueue);
                spinner.Spin(cancel);
            }, TaskCreationOptions.LongRunning);
        }

        public void Stop(bool wait = true)
        {
            if (spinTask != null)
            {
                cts.Cancel();
                if (wait)
                    spinTask.Wait();
                spinTask = null;
            }
        }
    }
}
