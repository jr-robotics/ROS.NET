using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using uint8 = System.Byte;
using Uml.Robotics.Ros;


using Messages.std_msgs;
using String=System.String;
using Messages.geometry_msgs;

namespace Messages.moveit_msgs
{
    public class GetMotionPlan : RosService
    {
        public override string ServiceType { get { return "moveit_msgs/GetMotionPlan"; } }
        public override string ServiceDefinition() { return @"MotionPlanRequest motion_plan_request
---
MotionPlanResponse motion_plan_response"; }
        public override string MD5Sum() { return "657e571ceabcb225c850c02c2249a1e1"; }

        public GetMotionPlan()
        {
            InitSubtypes(new Request(), new Response());
        }

        public Response Invoke(Func<Request, Response> fn, Request req)
        {
            RosServiceDelegate rsd = (m)=>{
                Request r = m as Request;
                if (r == null)
                    throw new Exception("Invalid Service Request Type");
                return fn(r);
            };
            return (Response)GeneralInvoke(rsd, (RosMessage)req);
        }

        public Request req { get { return (Request)RequestMessage; } set { RequestMessage = (RosMessage)value; } }
        public Response resp { get { return (Response)ResponseMessage; } set { ResponseMessage = (RosMessage)value; } }

        public class Request : RosMessage
        {
				public Messages.moveit_msgs.MotionPlanRequest motion_plan_request = new Messages.moveit_msgs.MotionPlanRequest();


            public override string MD5Sum() { return "9dcb82c5daeb2ff8a7ab1a98b642871d"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"MotionPlanRequest motion_plan_request"; }
			public override string MessageType { get { return "moveit_msgs/GetMotionPlan__Request"; } }
            public override bool IsServiceComponent() { return true; }

            public Request()
            {
                
            }

            public Request(byte[] serializedMessage)
            {
                Deserialize(serializedMessage);
            }

            public Request(byte[] serializedMessage, ref int currentIndex)
            {
                Deserialize(serializedMessage, ref currentIndex);
            }

    

            public override void Deserialize(byte[] serializedMessage, ref int currentIndex)
            {
                int arraylength=-1;
                bool hasmetacomponents = false;
                byte[] thischunk, scratch1, scratch2;
                object __thing;
                int piecesize=0;
                IntPtr h;
                
                //motion_plan_request
                motion_plan_request = new Messages.moveit_msgs.MotionPlanRequest(serializedMessage, ref currentIndex);
            }

            public override byte[] Serialize(bool partofsomethingelse)
            {
                int currentIndex=0, length=0;
                bool hasmetacomponents = false;
                byte[] thischunk, scratch1, scratch2;
                List<byte[]> pieces = new List<byte[]>();
                GCHandle h;
                IntPtr ptr;
                int x__size;
                
                //motion_plan_request
                if (motion_plan_request == null)
                    motion_plan_request = new Messages.moveit_msgs.MotionPlanRequest();
                pieces.Add(motion_plan_request.Serialize(true));
                //combine every array in pieces into one array and return it
                int __a_b__f = pieces.Sum((__a_b__c)=>__a_b__c.Length);
                int __a_b__e=0;
                byte[] __a_b__d = new byte[__a_b__f];
                foreach(var __p__ in pieces)
                {
                    Array.Copy(__p__,0,__a_b__d,__a_b__e,__p__.Length);
                    __a_b__e += __p__.Length;
                }
                return __a_b__d;
            }

            public override void Randomize()
            {
                int arraylength=-1;
                Random rand = new Random();
                int strlength;
                byte[] strbuf, myByte;
                
                //motion_plan_request
                motion_plan_request = new Messages.moveit_msgs.MotionPlanRequest();
                motion_plan_request.Randomize();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                moveit_msgs.GetMotionPlan.Request other = (Messages.moveit_msgs.GetMotionPlan.Request)____other;

                ret &= motion_plan_request.Equals(other.motion_plan_request);
                return ret;
            }
        }

        public class Response : RosMessage
        {
				public Messages.moveit_msgs.MotionPlanResponse motion_plan_response = new Messages.moveit_msgs.MotionPlanResponse();



            public override string MD5Sum() { return "9dcb82c5daeb2ff8a7ab1a98b642871d"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"MotionPlanResponse motion_plan_response"; }
			public override string MessageType { get { return "moveit_msgs/GetMotionPlan__Response"; } }
            public override bool IsServiceComponent() { return true; }

            public Response()
            {
                
            }

            public Response(byte[] serializedMessage)
            {
                Deserialize(serializedMessage);
            }

            public Response(byte[] serializedMessage, ref int currentIndex)
            {
                Deserialize(serializedMessage, ref currentIndex);
            }

	

            public override void Deserialize(byte[] serializedMessage, ref int currentIndex)
            {
                int arraylength = -1;
                bool hasmetacomponents = false;
                int piecesize = 0;
                byte[] thischunk, scratch1, scratch2;
                IntPtr h;
                object __thing;
                
                //motion_plan_response
                motion_plan_response = new Messages.moveit_msgs.MotionPlanResponse(serializedMessage, ref currentIndex);
            }

            public override byte[] Serialize(bool partofsomethingelse)
            {
                int currentIndex=0, length=0;
                bool hasmetacomponents = false;
                byte[] thischunk, scratch1, scratch2;
                List<byte[]> pieces = new List<byte[]>();
                GCHandle h;
                IntPtr ptr;
                int x__size;
                
                //motion_plan_response
                if (motion_plan_response == null)
                    motion_plan_response = new Messages.moveit_msgs.MotionPlanResponse();
                pieces.Add(motion_plan_response.Serialize(true));
                //combine every array in pieces into one array and return it
                int __a_b__f = pieces.Sum((__a_b__c)=>__a_b__c.Length);
                int __a_b__e=0;
                byte[] __a_b__d = new byte[__a_b__f];
                foreach(var __p__ in pieces)
                {
                    Array.Copy(__p__,0,__a_b__d,__a_b__e,__p__.Length);
                    __a_b__e += __p__.Length;
                }
                return __a_b__d;
            }

            public override void Randomize()
            {
                int arraylength = -1;
                Random rand = new Random();
                int strlength;
                byte[] strbuf, myByte;
                
                //motion_plan_response
                motion_plan_response = new Messages.moveit_msgs.MotionPlanResponse();
                motion_plan_response.Randomize();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                moveit_msgs.GetMotionPlan.Response other = (Messages.moveit_msgs.GetMotionPlan.Response)____other;

                ret &= motion_plan_response.Equals(other.motion_plan_response);
                // for each SingleType st:
                //    ret &= {st.Name} == other.{st.Name};
                return ret;
            }
        }
    }
}
