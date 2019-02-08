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
    public class GetPlannerParams : RosService
    {
        public override string ServiceType { get { return "moveit_msgs/GetPlannerParams"; } }
        public override string ServiceDefinition() { return @"string planner_config
string group
---
PlannerParams params"; }
        public override string MD5Sum() { return "b3ec1aca2b1471e3eea051c548c69810"; }

        public GetPlannerParams()
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
				public string planner_config = "";
				public string @group = "";


            public override string MD5Sum() { return "f548a13784550d510d791867af53ef40"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return false; }
            public override string MessageDefinition() { return @"string planner_config
string group"; }
			public override string MessageType { get { return "moveit_msgs/GetPlannerParams__Request"; } }
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
                
                //planner_config
                planner_config = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                planner_config = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //@group
                @group = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                @group = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
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
                
                //planner_config
                if (planner_config == null)
                    planner_config = "";
                scratch1 = Encoding.ASCII.GetBytes((string)planner_config);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //@group
                if (@group == null)
                    @group = "";
                scratch1 = Encoding.ASCII.GetBytes((string)@group);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
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
                
                //planner_config
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                planner_config = Encoding.ASCII.GetString(strbuf);
                //@group
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                @group = Encoding.ASCII.GetString(strbuf);
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                moveit_msgs.GetPlannerParams.Request other = (Messages.moveit_msgs.GetPlannerParams.Request)____other;

                ret &= planner_config == other.planner_config;
                ret &= @group == other.@group;
                return ret;
            }
        }

        public class Response : RosMessage
        {
				public Messages.moveit_msgs.PlannerParams @params = new Messages.moveit_msgs.PlannerParams();



            public override string MD5Sum() { return "f548a13784550d510d791867af53ef40"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"PlannerParams params"; }
			public override string MessageType { get { return "moveit_msgs/GetPlannerParams__Response"; } }
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
                
                //@params
                @params = new Messages.moveit_msgs.PlannerParams(serializedMessage, ref currentIndex);
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
                
                //@params
                if (@params == null)
                    @params = new Messages.moveit_msgs.PlannerParams();
                pieces.Add(@params.Serialize(true));
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
                
                //@params
                @params = new Messages.moveit_msgs.PlannerParams();
                @params.Randomize();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                moveit_msgs.GetPlannerParams.Response other = (Messages.moveit_msgs.GetPlannerParams.Response)____other;

                ret &= @params.Equals(other.@params);
                // for each SingleType st:
                //    ret &= {st.Name} == other.{st.Name};
                return ret;
            }
        }
    }
}
