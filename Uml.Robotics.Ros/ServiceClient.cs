using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamla.Robotics.Ros.Async;

namespace Uml.Robotics.Ros
{
    public class ServiceClient<MReq, MRes>
        : ServiceClientBase
        where MReq : RosMessage, new() where MRes : RosMessage, new()
    {
        internal ServiceClient(string serviceName, bool persistent, IDictionary<string, string> headerValues, string md5sum)
            : base(serviceName, persistent, headerValues, md5sum)
        {
            if (persistent)
            {
                this.Init().WhenCompleted().Wait();
            }
        }

        protected override async Task<IServiceServerLink> CreateLink()
        {
            return await ServiceManager.Instance.CreateServiceServerLinkAsync<MReq, MRes>(serviceName, persistent, md5sum, md5sum, headerValues).ConfigureAwait(false);
        }

        public (bool, MRes) Call(MReq request) =>
            CallAsync(request).Result;

        public async Task<(bool, MRes)> CallAsync(MReq request)
        {
            string md5 = request.MD5Sum();
            return await Call(request, md5).ConfigureAwait(false);
        }

        public async Task<(bool, MRes)> Call(MReq request, string serviceMd5Sum)
        {
            try
            {
                EnterCall();

                if (!await PreCall(serviceMd5Sum).ConfigureAwait(false) || serverLink == null || !serverLink.IsValid)
                {
                    return (false, null);
                }

                (bool result, RosMessage response) = await serverLink.Call(request).ConfigureAwait(false);

                var responseMessage = (MRes) response;
                return (result, responseMessage);
            }
            catch(Exception ex)
            {
                ROS.Error()("Error during service call. Error: {0}, Stacktrace: {1}", ex.ToString(), ex.StackTrace);
                return (false, new MRes());
            }
            finally
            {
                ExitCall();
            }
        }
    }

    public class ServiceClient<MSrv>
        : ServiceClientBase
        where MSrv : RosService, new()
    {
        internal ServiceClient(string serviceName, bool persistent, IDictionary<string, string> headerValues, string md5sum)
            : base(serviceName, persistent, headerValues, md5sum)
        {
            if (persistent)
            {
                this.Init().WhenCompleted().Wait();
            }
        }

        protected override Task<IServiceServerLink> CreateLink()
        {
            return ServiceManager.Instance.CreateServiceServerLinkAsync<MSrv>(serviceName, persistent, md5sum, md5sum, headerValues);
        }

        public bool Call(MSrv srv) =>
           CallAsync(srv).Result;

        public async Task<bool> CallAsync(MSrv srv)
        {
            string md5 = srv.RequestMessage.MD5Sum();
            return await CallAsync(srv, md5).ConfigureAwait(false);
        }

        public async Task<bool> CallAsync(MSrv srv, string serviceMd5Sum)
        {
            try
            {
                EnterCall();

                if (!await PreCall(serviceMd5Sum).ConfigureAwait(false) || serverLink == null || !serverLink.IsValid)
                {
                    return false;
                }

                bool result = await serverLink.Call(srv).ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                ROS.Error()("Error during async service call. Error: {0}, Stacktrace: {1}", e.ToString(), e.StackTrace);
                return false;
            }
            finally
            {
                ExitCall();
            }
        }
    }
}
