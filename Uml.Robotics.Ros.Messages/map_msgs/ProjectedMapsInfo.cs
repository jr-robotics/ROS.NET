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

namespace Messages.map_msgs
{
    public class ProjectedMapsInfo : RosService
    {
        public override string ServiceType { get { return "map_msgs/ProjectedMapsInfo"; } }
        public override string ServiceDefinition() { return @"map_msgs/ProjectedMapInfo[] projected_maps_info"; }
        public override string MD5Sum() { return "d7980a33202421c8cd74565e57a4d229"; }

        public ProjectedMapsInfo()
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
				public Messages.map_msgs.ProjectedMapInfo[] projected_maps_info;


            public override string MD5Sum() { return "d7980a33202421c8cd74565e57a4d229"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"map_msgs/ProjectedMapInfo[] projected_maps_info"; }
			public override string MessageType { get { return "map_msgs/ProjectedMapsInfo__Request"; } }
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
                
                //projected_maps_info
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (projected_maps_info == null)
                    projected_maps_info = new Messages.map_msgs.ProjectedMapInfo[arraylength];
                else
                    Array.Resize(ref projected_maps_info, arraylength);
                for (int i=0;i<projected_maps_info.Length; i++) {
                    //projected_maps_info[i]
                    projected_maps_info[i] = new Messages.map_msgs.ProjectedMapInfo(serializedMessage, ref currentIndex);
                }
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
                
                //projected_maps_info
                hasmetacomponents |= true;
                if (projected_maps_info == null)
                    projected_maps_info = new Messages.map_msgs.ProjectedMapInfo[0];
                pieces.Add(BitConverter.GetBytes(projected_maps_info.Length));
                for (int i=0;i<projected_maps_info.Length; i++) {
                    //projected_maps_info[i]
                    if (projected_maps_info[i] == null)
                        projected_maps_info[i] = new Messages.map_msgs.ProjectedMapInfo();
                    pieces.Add(projected_maps_info[i].Serialize(true));
                }
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
                
                //projected_maps_info
                arraylength = rand.Next(10);
                if (projected_maps_info == null)
                    projected_maps_info = new Messages.map_msgs.ProjectedMapInfo[arraylength];
                else
                    Array.Resize(ref projected_maps_info, arraylength);
                for (int i=0;i<projected_maps_info.Length; i++) {
                    //projected_maps_info[i]
                    projected_maps_info[i] = new Messages.map_msgs.ProjectedMapInfo();
                    projected_maps_info[i].Randomize();
                }
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                map_msgs.ProjectedMapsInfo.Request other = (Messages.map_msgs.ProjectedMapsInfo.Request)____other;

                if (projected_maps_info.Length != other.projected_maps_info.Length)
                    return false;
                for (int __i__=0; __i__ < projected_maps_info.Length; __i__++)
                {
                    ret &= projected_maps_info[__i__].Equals(other.projected_maps_info[__i__]);
                }
                return ret;
            }
        }

        public class Response : RosMessage
        {



            public override string MD5Sum() { return "d7980a33202421c8cd74565e57a4d229"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return false; }
            public override string MessageDefinition() { return @""; }
			public override string MessageType { get { return "map_msgs/ProjectedMapsInfo__Response"; } }
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
                
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                map_msgs.ProjectedMapsInfo.Response other = (Messages.map_msgs.ProjectedMapsInfo.Response)____other;

                // for each SingleType st:
                //    ret &= {st.Name} == other.{st.Name};
                return ret;
            }
        }
    }
}
