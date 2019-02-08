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
    public class GetPositionIK : RosService
    {
        public override string ServiceType { get { return "moveit_msgs/GetPositionIK"; } }
        public override string ServiceDefinition() { return @"PositionIKRequest ik_request
---
RobotState solution
MoveItErrorCodes error_code"; }
        public override string MD5Sum() { return "0661ea3324398c69f5a971d0ec55657e"; }

        public GetPositionIK()
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
				public Messages.moveit_msgs.PositionIKRequest ik_request = new Messages.moveit_msgs.PositionIKRequest();


            public override string MD5Sum() { return "a67dc7e99d15c1dca32a77c22bc2d93b"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"PositionIKRequest ik_request"; }
			public override string MessageType { get { return "moveit_msgs/GetPositionIK__Request"; } }
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
                
                //ik_request
                ik_request = new Messages.moveit_msgs.PositionIKRequest(serializedMessage, ref currentIndex);
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
                
                //ik_request
                if (ik_request == null)
                    ik_request = new Messages.moveit_msgs.PositionIKRequest();
                pieces.Add(ik_request.Serialize(true));
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
                
                //ik_request
                ik_request = new Messages.moveit_msgs.PositionIKRequest();
                ik_request.Randomize();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                moveit_msgs.GetPositionIK.Request other = (Messages.moveit_msgs.GetPositionIK.Request)____other;

                ret &= ik_request.Equals(other.ik_request);
                return ret;
            }
        }

        public class Response : RosMessage
        {
				public Messages.moveit_msgs.RobotState solution = new Messages.moveit_msgs.RobotState();
				public Messages.moveit_msgs.MoveItErrorCodes error_code = new Messages.moveit_msgs.MoveItErrorCodes();



            public override string MD5Sum() { return "a67dc7e99d15c1dca32a77c22bc2d93b"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"RobotState solution
MoveItErrorCodes error_code"; }
			public override string MessageType { get { return "moveit_msgs/GetPositionIK__Response"; } }
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
                
                //solution
                solution = new Messages.moveit_msgs.RobotState(serializedMessage, ref currentIndex);
                //error_code
                error_code = new Messages.moveit_msgs.MoveItErrorCodes(serializedMessage, ref currentIndex);
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
                
                //solution
                if (solution == null)
                    solution = new Messages.moveit_msgs.RobotState();
                pieces.Add(solution.Serialize(true));
                //error_code
                if (error_code == null)
                    error_code = new Messages.moveit_msgs.MoveItErrorCodes();
                pieces.Add(error_code.Serialize(true));
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
                
                //solution
                solution = new Messages.moveit_msgs.RobotState();
                solution.Randomize();
                //error_code
                error_code = new Messages.moveit_msgs.MoveItErrorCodes();
                error_code.Randomize();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                moveit_msgs.GetPositionIK.Response other = (Messages.moveit_msgs.GetPositionIK.Response)____other;

                ret &= solution.Equals(other.solution);
                ret &= error_code.Equals(other.error_code);
                // for each SingleType st:
                //    ret &= {st.Name} == other.{st.Name};
                return ret;
            }
        }
    }
}
