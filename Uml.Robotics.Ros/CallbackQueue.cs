using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using Xamla.Robotics.Ros.Async;

namespace Uml.Robotics.Ros
{
    public class CallbackQueue : ICallbackQueue
    {
        private readonly ILogger logger = ApplicationLogging.CreateLogger<CallbackQueue>();
        private readonly object gate = new object();

        private volatile bool enabled = true;       // queue is enabled by default
        private int calling;
        private Deque<CallbackInfo> callbacks = new Deque<CallbackInfo>();

        public CallbackQueue()
        {
        }

        public void Dispose()
        {
            Disable();
        }

        /// <summary>
        /// Returns whether or not this queue is enabled.
        /// </summary>
        public bool IsEnabled =>
            enabled;

        /// <summary>
        /// Returns whether or not the queue is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                lock (gate)
                {
                    return callbacks.Count == 0 && calling == 0;
                }
            }
        }

        public void AddCallback(CallbackInterface cb, object owner = null)
        {
            if (cb == null)
                throw new ArgumentNullException(nameof(cb));

            lock (gate)
            {
                if (!enabled)
                    return;

                callbacks.Add(new CallbackInfo { Callback = cb, Owner = owner });
                NotifyOne();
            }
        }

        public void RemoveByOwner(object owner)
        {
            if (owner == null)
                return;

            lock (gate)
            {
                callbacks.RemoveAll(x => object.Equals(x.Owner, owner));
            }
        }

        public void CallAvailable(int timeout = ROS.WallDuration)
        {
            int maxCalls = WaitForCalls(timeout);
            for (int i = 0; i < maxCalls; ++i)
            {
                var result = CallOne();
                if (result == CallOneResult.Empty || result == CallOneResult.Disabled)
                    return;
            }
        }

        /// <summary>
        /// Removes all callbacks from the queue. Does not wait for calls currently in progress to finish.
        /// </summary>
        public void Clear()
        {
            lock (gate)
            {
                callbacks.Clear();
            }
        }

        /// <summary>
        /// Disable the queue, meaning any calls to addCallback() will have no effect.
        /// </summary>
        public void Disable()
        {
            lock (gate)
            {
                enabled = false;
                NotifyAll();
            }
        }

        /// <summary>
        /// Enable the queue (queue is enabled by default).
        /// </summary>
        public void Enable()
        {
            lock (gate)
            {
                enabled = true;
                NotifyAll();
            }
        }

        private int WaitForCalls(int timeout)
        {
            lock (gate)
            {
                if (enabled && callbacks.Count == 0 && timeout > 0)
                {
                    Monitor.Wait(gate, timeout);
                }

                return callbacks.Count;
            }
        }

        public CallOneResult CallOne()
        {
            CallbackInfo call;

            lock (gate)
            {
                if (!enabled)
                    return CallOneResult.Disabled;

                if (callbacks.Count == 0)
                    return CallOneResult.Empty;

                call = callbacks.Front;
                callbacks.PopFront();

                calling += 1;
            }

            var owner = call.Owner;

            try
            {
                CallbackInterface cb = call.Callback;
                var result = CallbackInterface.CallResult.Invalid;

                if (owner != null)
                {
                    Monitor.Enter(owner);
                }

                try
                {
                    result = cb.Call();
                }
                catch (Exception ex)
                {
                    ROS.Error()("Error during callback. Error: {0}, Stacktrace: {1}", ex.ToString(), ex.StackTrace);
                }

                if (result == CallbackInterface.CallResult.TryAgain)
                {
                    lock (gate)
                    {
                        callbacks.PushBack(call);
                    }
                    return CallOneResult.TryAgain;
                }

                return CallOneResult.Called;
            }
            finally
            {
                if (owner != null)
                {
                    Monitor.Exit(owner);
                }

                lock (gate)
                {
                    calling -= 1;
                }
            }
        }

        public CallOneResult CallOne(int timeout = ROS.WallDuration)
        {
            WaitForCalls(timeout);
            return CallOne();
        }

        private void NotifyOne() =>
            Monitor.Pulse(gate);

        private void NotifyAll() =>
             Monitor.PulseAll(gate);
    }

    class CallbackInfo
    {
        public CallbackInterface Callback;
        public object Owner;
    }
}
