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

namespace Messages.nav_msgs
{
    public class GetPlan : RosService
    {
        public override string ServiceType { get { return "nav_msgs/GetPlan"; } }
        public override string ServiceDefinition() { return @"geometry_msgs/PoseStamped start
geometry_msgs/PoseStamped goal
float32 tolerance
---
nav_msgs/Path plan"; }
        public override string MD5Sum() { return "421c8ea4d21c6c9db7054b4bbdf1e024"; }

        public GetPlan()
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
				public Messages.geometry_msgs.PoseStamped start = new Messages.geometry_msgs.PoseStamped();
				public Messages.geometry_msgs.PoseStamped goal = new Messages.geometry_msgs.PoseStamped();
				public Single tolerance;


            public override string MD5Sum() { return "e25a43e0752bcca599a8c2eef8282df8"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"geometry_msgs/PoseStamped start
geometry_msgs/PoseStamped goal
float32 tolerance"; }
			public override string MessageType { get { return "nav_msgs/GetPlan__Request"; } }
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
                
                //start
                start = new Messages.geometry_msgs.PoseStamped(serializedMessage, ref currentIndex);
                //goal
                goal = new Messages.geometry_msgs.PoseStamped(serializedMessage, ref currentIndex);
                //tolerance
                piecesize = Marshal.SizeOf(typeof(Single));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                tolerance = (Single)Marshal.PtrToStructure(h, typeof(Single));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
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
                
                //start
                if (start == null)
                    start = new Messages.geometry_msgs.PoseStamped();
                pieces.Add(start.Serialize(true));
                //goal
                if (goal == null)
                    goal = new Messages.geometry_msgs.PoseStamped();
                pieces.Add(goal.Serialize(true));
                //tolerance
                scratch1 = new byte[Marshal.SizeOf(typeof(Single))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(tolerance, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
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
                
                //start
                start = new Messages.geometry_msgs.PoseStamped();
                start.Randomize();
                //goal
                goal = new Messages.geometry_msgs.PoseStamped();
                goal.Randomize();
                //tolerance
                tolerance = (float)(rand.Next() + rand.NextDouble());
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                nav_msgs.GetPlan.Request other = (Messages.nav_msgs.GetPlan.Request)____other;

                ret &= start.Equals(other.start);
                ret &= goal.Equals(other.goal);
                ret &= tolerance == other.tolerance;
                return ret;
            }
        }

        public class Response : RosMessage
        {
				public Messages.nav_msgs.Path plan = new Messages.nav_msgs.Path();



            public override string MD5Sum() { return "e25a43e0752bcca599a8c2eef8282df8"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"nav_msgs/Path plan"; }
			public override string MessageType { get { return "nav_msgs/GetPlan__Response"; } }
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
                
                //plan
                plan = new Messages.nav_msgs.Path(serializedMessage, ref currentIndex);
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
                
                //plan
                if (plan == null)
                    plan = new Messages.nav_msgs.Path();
                pieces.Add(plan.Serialize(true));
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
                
                //plan
                plan = new Messages.nav_msgs.Path();
                plan.Randomize();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                nav_msgs.GetPlan.Response other = (Messages.nav_msgs.GetPlan.Response)____other;

                ret &= plan.Equals(other.plan);
                // for each SingleType st:
                //    ret &= {st.Name} == other.{st.Name};
                return ret;
            }
        }
    }
}
