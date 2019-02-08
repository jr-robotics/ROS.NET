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

namespace Messages.object_recognition_msgs
{
    public class GetObjectInformation : RosService
    {
        public override string ServiceType { get { return "object_recognition_msgs/GetObjectInformation"; } }
        public override string ServiceDefinition() { return @"object_recognition_msgs/ObjectType type
---
object_recognition_msgs/ObjectInformation information"; }
        public override string MD5Sum() { return "dd7d344324fd86c32836f4fe1bc7b322"; }

        public GetObjectInformation()
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
				public Messages.object_recognition_msgs.ObjectType type = new Messages.object_recognition_msgs.ObjectType();


            public override string MD5Sum() { return "0d72b69e80da0fe473b0bdcdd7a28d4d"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"object_recognition_msgs/ObjectType type"; }
			public override string MessageType { get { return "object_recognition_msgs/GetObjectInformation__Request"; } }
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
                
                //type
                type = new Messages.object_recognition_msgs.ObjectType(serializedMessage, ref currentIndex);
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
                
                //type
                if (type == null)
                    type = new Messages.object_recognition_msgs.ObjectType();
                pieces.Add(type.Serialize(true));
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
                
                //type
                type = new Messages.object_recognition_msgs.ObjectType();
                type.Randomize();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                object_recognition_msgs.GetObjectInformation.Request other = (Messages.object_recognition_msgs.GetObjectInformation.Request)____other;

                ret &= type.Equals(other.type);
                return ret;
            }
        }

        public class Response : RosMessage
        {
				public Messages.object_recognition_msgs.ObjectInformation information = new Messages.object_recognition_msgs.ObjectInformation();



            public override string MD5Sum() { return "0d72b69e80da0fe473b0bdcdd7a28d4d"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"object_recognition_msgs/ObjectInformation information"; }
			public override string MessageType { get { return "object_recognition_msgs/GetObjectInformation__Response"; } }
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
                
                //information
                information = new Messages.object_recognition_msgs.ObjectInformation(serializedMessage, ref currentIndex);
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
                
                //information
                if (information == null)
                    information = new Messages.object_recognition_msgs.ObjectInformation();
                pieces.Add(information.Serialize(true));
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
                
                //information
                information = new Messages.object_recognition_msgs.ObjectInformation();
                information.Randomize();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                object_recognition_msgs.GetObjectInformation.Response other = (Messages.object_recognition_msgs.GetObjectInformation.Response)____other;

                ret &= information.Equals(other.information);
                // for each SingleType st:
                //    ret &= {st.Name} == other.{st.Name};
                return ret;
            }
        }
    }
}
