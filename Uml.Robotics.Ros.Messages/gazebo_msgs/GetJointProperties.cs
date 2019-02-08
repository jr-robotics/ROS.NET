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

namespace Messages.gazebo_msgs
{
    public class GetJointProperties : RosService
    {
        public override string ServiceType { get { return "gazebo_msgs/GetJointProperties"; } }
        public override string ServiceDefinition() { return @"string joint_name
---
uint8 type
uint8 REVOLUTE=0
uint8 CONTINUOUS=1
uint8 PRISMATIC=2
uint8 FIXED=3
uint8 BALL=4
uint8 UNIVERSAL=5
float64[] damping
float64[] position
float64[] rate
bool success
string status_message"; }
        public override string MD5Sum() { return "7b30be900f50aa21efec4a0ec92d91c9"; }

        public GetJointProperties()
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
				public string joint_name = "";


            public override string MD5Sum() { return "0be1351618e1dc030eb7959d9a4902de"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return false; }
            public override string MessageDefinition() { return @"string joint_name"; }
			public override string MessageType { get { return "gazebo_msgs/GetJointProperties__Request"; } }
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
                
                //joint_name
                joint_name = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                joint_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
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
                
                //joint_name
                if (joint_name == null)
                    joint_name = "";
                scratch1 = Encoding.ASCII.GetBytes((string)joint_name);
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
                
                //joint_name
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                joint_name = Encoding.ASCII.GetString(strbuf);
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                gazebo_msgs.GetJointProperties.Request other = (Messages.gazebo_msgs.GetJointProperties.Request)____other;

                ret &= joint_name == other.joint_name;
                return ret;
            }
        }

        public class Response : RosMessage
        {
				public byte type;
				public const byte REVOLUTE    = 0;
				public const byte CONTINUOUS  = 1;
				public const byte PRISMATIC   = 2;
				public const byte FIXED       = 3;
				public const byte BALL        = 4;
				public const byte UNIVERSAL   = 5;
				public double[] damping;
				public double[] position;
				public double[] rate;
				public bool success;
				public string status_message = "";



            public override string MD5Sum() { return "0be1351618e1dc030eb7959d9a4902de"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return false; }
            public override string MessageDefinition() { return @"uint8 type
uint8 REVOLUTE=0
uint8 CONTINUOUS=1
uint8 PRISMATIC=2
uint8 FIXED=3
uint8 BALL=4
uint8 UNIVERSAL=5
float64[] damping
float64[] position
float64[] rate
bool success
string status_message"; }
			public override string MessageType { get { return "gazebo_msgs/GetJointProperties__Response"; } }
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
                
                //type
                type=serializedMessage[currentIndex++];
                //damping
                hasmetacomponents |= false;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (damping == null)
                    damping = new double[arraylength];
                else
                    Array.Resize(ref damping, arraylength);
// Start Xamla
                    //damping
                    piecesize = Marshal.SizeOf(typeof(double)) * damping.Length;
                    if (currentIndex + piecesize > serializedMessage.Length) {
                        throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                    }
                    Buffer.BlockCopy(serializedMessage, currentIndex, damping, 0, piecesize);
                    currentIndex += piecesize;
// End Xamla

                //position
                hasmetacomponents |= false;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (position == null)
                    position = new double[arraylength];
                else
                    Array.Resize(ref position, arraylength);
// Start Xamla
                    //position
                    piecesize = Marshal.SizeOf(typeof(double)) * position.Length;
                    if (currentIndex + piecesize > serializedMessage.Length) {
                        throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                    }
                    Buffer.BlockCopy(serializedMessage, currentIndex, position, 0, piecesize);
                    currentIndex += piecesize;
// End Xamla

                //rate
                hasmetacomponents |= false;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (rate == null)
                    rate = new double[arraylength];
                else
                    Array.Resize(ref rate, arraylength);
// Start Xamla
                    //rate
                    piecesize = Marshal.SizeOf(typeof(double)) * rate.Length;
                    if (currentIndex + piecesize > serializedMessage.Length) {
                        throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                    }
                    Buffer.BlockCopy(serializedMessage, currentIndex, rate, 0, piecesize);
                    currentIndex += piecesize;
// End Xamla

                //success
                success = serializedMessage[currentIndex++]==1;
                //status_message
                status_message = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                status_message = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
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
                
                //type
                pieces.Add(new[] { (byte)type });
                //damping
                hasmetacomponents |= false;
                if (damping == null)
                    damping = new double[0];
                pieces.Add(BitConverter.GetBytes(damping.Length));
// Start Xamla
                    //damping
                    x__size = Marshal.SizeOf(typeof(double)) * damping.Length;
                    scratch1 = new byte[x__size];
                    Buffer.BlockCopy(damping, 0, scratch1, 0, x__size);
                    pieces.Add(scratch1);
// End Xamla

                //position
                hasmetacomponents |= false;
                if (position == null)
                    position = new double[0];
                pieces.Add(BitConverter.GetBytes(position.Length));
// Start Xamla
                    //position
                    x__size = Marshal.SizeOf(typeof(double)) * position.Length;
                    scratch1 = new byte[x__size];
                    Buffer.BlockCopy(position, 0, scratch1, 0, x__size);
                    pieces.Add(scratch1);
// End Xamla

                //rate
                hasmetacomponents |= false;
                if (rate == null)
                    rate = new double[0];
                pieces.Add(BitConverter.GetBytes(rate.Length));
// Start Xamla
                    //rate
                    x__size = Marshal.SizeOf(typeof(double)) * rate.Length;
                    scratch1 = new byte[x__size];
                    Buffer.BlockCopy(rate, 0, scratch1, 0, x__size);
                    pieces.Add(scratch1);
// End Xamla

                //success
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)success ? 1 : 0 );
                pieces.Add(thischunk);
                //status_message
                if (status_message == null)
                    status_message = "";
                scratch1 = Encoding.ASCII.GetBytes((string)status_message);
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
                int arraylength = -1;
                Random rand = new Random();
                int strlength;
                byte[] strbuf, myByte;
                
                //type
                myByte = new byte[1];
                rand.NextBytes(myByte);
                type= myByte[0];
                //damping
                arraylength = rand.Next(10);
                if (damping == null)
                    damping = new double[arraylength];
                else
                    Array.Resize(ref damping, arraylength);
                for (int i=0;i<damping.Length; i++) {
                    //damping[i]
                    damping[i] = (rand.Next() + rand.NextDouble());
                }
                //position
                arraylength = rand.Next(10);
                if (position == null)
                    position = new double[arraylength];
                else
                    Array.Resize(ref position, arraylength);
                for (int i=0;i<position.Length; i++) {
                    //position[i]
                    position[i] = (rand.Next() + rand.NextDouble());
                }
                //rate
                arraylength = rand.Next(10);
                if (rate == null)
                    rate = new double[arraylength];
                else
                    Array.Resize(ref rate, arraylength);
                for (int i=0;i<rate.Length; i++) {
                    //rate[i]
                    rate[i] = (rand.Next() + rand.NextDouble());
                }
                //success
                success = rand.Next(2) == 1;
                //status_message
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                status_message = Encoding.ASCII.GetString(strbuf);
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                gazebo_msgs.GetJointProperties.Response other = (Messages.gazebo_msgs.GetJointProperties.Response)____other;

                ret &= type == other.type;
                if (damping.Length != other.damping.Length)
                    return false;
                for (int __i__=0; __i__ < damping.Length; __i__++)
                {
                    ret &= damping[__i__] == other.damping[__i__];
                }
                if (position.Length != other.position.Length)
                    return false;
                for (int __i__=0; __i__ < position.Length; __i__++)
                {
                    ret &= position[__i__] == other.position[__i__];
                }
                if (rate.Length != other.rate.Length)
                    return false;
                for (int __i__=0; __i__ < rate.Length; __i__++)
                {
                    ret &= rate[__i__] == other.rate[__i__];
                }
                ret &= success == other.success;
                ret &= status_message == other.status_message;
                // for each SingleType st:
                //    ret &= {st.Name} == other.{st.Name};
                return ret;
            }
        }
    }
}
