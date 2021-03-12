using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Uml.Robotics.Ros
{
    public class ServicePublication<MReq, MRes> : IServicePublication
        where MReq : RosMessage, new()
        where MRes : RosMessage, new()
    {
        public ServiceCallbackHelper<MReq, MRes> helper;

        public ServicePublication(string name, string md5Sum, string datatype, string reqDatatype, string resDatatype, ServiceCallbackHelper<MReq, MRes> helper, ICallbackQueue callback)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            this.name = name;
            this.md5sum = md5Sum;
            this.dataType = datatype;
            this.req_datatype = reqDatatype;
            this.res_datatype = resDatatype;
            this.helper = helper;
            this.callback = callback;
        }

        public override Task<(RosMessage, bool)> ProcessRequest(byte[] buf, IServiceClientLink link)
        {
            var cb = new ServiceCallback(this, helper, buf, link);
            callback.AddCallback(cb, gate);
            return cb.ResultTask;
        }

        internal override void AddServiceClientLink(IServiceClientLink iServiceClientLink)
        {
            lock (gate)
            {
                clientLinks.Add(iServiceClientLink);
            }
        }

        internal override void RemoveServiceClientLink(IServiceClientLink iServiceClientLink)
        {
            lock (gate)
            {
                clientLinks.Remove(iServiceClientLink);
            }
        }

        public class ServiceCallback : CallbackInterface
        {
            private readonly ILogger logger = ApplicationLogging.CreateLogger<ServiceCallback>();
            private readonly byte[] buffer;
            private ServicePublication<MReq, MRes> isp;
            private IServiceClientLink link;
            private TaskCompletionSource<(RosMessage, bool)> resultTask = new TaskCompletionSource<(RosMessage, bool)>(TaskCreationOptions.RunContinuationsAsynchronously);

            public ServiceCallback(ServiceCallbackHelper<MReq, MRes> _helper, byte[] buf, IServiceClientLink link)
                : this(null, _helper, buf, link)
            {
            }

            public ServiceCallback(ServicePublication<MReq, MRes> sp, ServiceCallbackHelper<MReq, MRes> _helper, byte[] buf, IServiceClientLink link)
            {
                this.isp = sp;
                if (this.isp != null && _helper != null)
                    this.isp.helper = _helper;
                this.buffer = buf;
                this.link = link;
            }

            public Task<(RosMessage, bool)> ResultTask =>
                resultTask.Task;

            internal override CallResult Call()
            {
                if (!link.Connection.IsValid)
                {
                    resultTask.SetCanceled();
                    return CallResult.Invalid;
                }

                try
                {
                    ServiceCallbackHelperParams<MReq, MRes> parms = new ServiceCallbackHelperParams<MReq, MRes>
                    {
                        Request = new MReq(),
                        Response = new MRes(),
                        ConnectionHeader = link.Connection.Header.Values
                    };

                    parms.Request.Deserialize(buffer);
                    bool ok = isp.helper.Call(parms);
                    resultTask.SetResult((parms.Response, ok));
                }
                catch (Exception e)
                {
                    resultTask.TrySetException(e);
                    return CallResult.Invalid;
                }

                return CallResult.Success;
            }

            public override void AddToCallbackQueue(ISubscriptionCallbackHelper helper, RosMessage msg, bool nonconst_need_copy, ref bool was_full, TimeData receipt_time)
            {
                throw new NotImplementedException();
            }

            public override void Clear()
            {
                throw new NotImplementedException();
            }
        }
    }

    public abstract class IServicePublication
    {
        protected ICallbackQueue callback;
        protected List<IServiceClientLink> clientLinks = new List<IServiceClientLink>();
        protected readonly object gate = new object();

        internal string dataType;
        internal bool isDropped;
        internal string md5sum;
        internal string name;
        internal string req_datatype;
        internal string res_datatype;

        internal void Drop()
        {
            lock (gate)
            {
                isDropped = true;
            }
            DropAllConnections();
            callback.RemoveByOwner(gate);
        }

        private void DropAllConnections()
        {
            List<IServiceClientLink> links;
            lock (gate)
            {
                links = new List<IServiceClientLink>(clientLinks);
                clientLinks.Clear();
            }

            foreach (IServiceClientLink iscl in links)
            {
                iscl.Connection.Dispose();
            }
        }

        internal abstract void AddServiceClientLink(IServiceClientLink serviceClientLink);
        internal abstract void RemoveServiceClientLink(IServiceClientLink serviceClientLink);
        public abstract Task<(RosMessage, bool)> ProcessRequest(byte[] buffer, IServiceClientLink serviceClientLink);
    }
}
