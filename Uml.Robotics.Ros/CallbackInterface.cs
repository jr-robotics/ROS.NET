using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Uml.Robotics.Ros
{
    internal class Callback
        : CallbackInterface
    {
        private readonly ILogger logger = ApplicationLogging.CreateLogger<Callback>();
        private volatile bool callbackState;

        private readonly bool allowConcurrentCallbacks;
        private readonly Queue<Item> queue = new Queue<Item>();
        private int queueSize;

        public static Callback Create<M>(CallbackDelegate<M> f) where M : RosMessage, new()
        {
            return new Callback(msg => f(msg as M));
        }

        public Callback(CallbackDelegate f, string topic, int queueSize, bool allowConcurrentCallbacks)
            : this(f)
        {
            this.allowConcurrentCallbacks = allowConcurrentCallbacks;
            this.queueSize = queueSize;
        }

        public Callback(CallbackDelegate f)
        {
            base.Event += f;
        }

        public override void AddToCallbackQueue(ISubscriptionCallbackHelper helper, RosMessage message,
            bool nonconst_need_copy, ref bool was_full, TimeData receipt_time)
        {
            if (was_full)
                was_full = false;

            var i = new Item
            {
                helper = helper,
                message = message,
                nonconst_need_copy = nonconst_need_copy,
                receiptTime = receipt_time
            };

            lock (queue)
            {
                if (this.IsFullNoLock)
                {
                    queue.Dequeue();
                    was_full = true;
                }

                queue.Enqueue(i);
            }
        }

        public override void Clear()
        {
            queue.Clear();
        }

        public virtual bool Ready =>
            true;

        private bool IsFullNoLock =>
            queueSize > 0 && queue.Count >= queueSize;

        public bool IsFull
        {
            get
            {
                lock (queue)
                {
                    return this.IsFullNoLock;
                }
            }
        }

        public class Item
        {
            public ISubscriptionCallbackHelper helper;
            public RosMessage message;
            public bool nonconst_need_copy;
            public TimeData receiptTime;
        }

        internal override CallResult Call()
        {
            Item i = null;
            try
            {
                lock (queue)
                {
                    if (!allowConcurrentCallbacks)
                    {
                        if (callbackState)
                            return CallResult.TryAgain;

                        callbackState = true;
                    }

                    if (queue.Count == 0)
                        return CallResult.Invalid;
                    i = queue.Dequeue();
                }

                i.helper.Call(i.message);
            }
            finally
            {
                if (!allowConcurrentCallbacks)
                {
                    callbackState = false;
                }
            }

            return CallResult.Success;
        }
    }


    public abstract class CallbackInterface
    {
        public delegate void CallbackDelegate(RosMessage msg);

        public event CallbackDelegate Event;

        private readonly ILogger logger = ApplicationLogging.CreateLogger<CallbackInterface>();

        public CallbackInterface()
        {
        }

        public CallbackInterface(CallbackDelegate f)
            : this()
        {
            Event += f;
        }

        public enum CallResult
        {
            Success,
            TryAgain,
            Invalid
        }

        public void SendEvent(RosMessage msg)
        {
            if (Event != null)
            {
                Event(msg);
            }
            else
            {
                logger.LogError($"{nameof(Event)} is null");
            }
        }

        public abstract void AddToCallbackQueue(ISubscriptionCallbackHelper helper, RosMessage msg,
            bool nonconst_need_copy, ref bool was_full, TimeData receipt_time);

        public abstract void Clear();
        internal abstract CallResult Call();
    }
}