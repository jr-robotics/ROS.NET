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
    public class GetPositionFK : RosService
    {
        public override string ServiceType { get { return "moveit_msgs/GetPositionFK"; } }
        public override string ServiceDefinition() { return @"Header header
string[] fk_link_names
RobotState robot_state
---
geometry_msgs/PoseStamped[] pose_stamped
string[] fk_link_names
MoveItErrorCodes error_code"; }
        public override string MD5Sum() { return "03d4858215085d70e74807025d68dc4c"; }

        public GetPositionFK()
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
				public Header header = new Header();
				public string[] fk_link_names;
				public Messages.moveit_msgs.RobotState robot_state = new Messages.moveit_msgs.RobotState();


            public override string MD5Sum() { return "1d1ed72044ed56f6246c31b522781797"; }
            public override bool HasHeader() { return true; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"Header header
string[] fk_link_names
RobotState robot_state"; }
			public override string MessageType { get { return "moveit_msgs/GetPositionFK__Request"; } }
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
                
                //header
                header = new Header(serializedMessage, ref currentIndex);
                //fk_link_names
                hasmetacomponents |= false;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (fk_link_names == null)
                    fk_link_names = new string[arraylength];
                else
                    Array.Resize(ref fk_link_names, arraylength);
                for (int i=0;i<fk_link_names.Length; i++) {
                    //fk_link_names[i]
                    fk_link_names[i] = "";
                    piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                    currentIndex += 4;
                    fk_link_names[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                    currentIndex += piecesize;
                }
                //robot_state
                robot_state = new Messages.moveit_msgs.RobotState(serializedMessage, ref currentIndex);
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
                
                //header
                if (header == null)
                    header = new Header();
                pieces.Add(header.Serialize(true));
                //fk_link_names
                hasmetacomponents |= false;
                if (fk_link_names == null)
                    fk_link_names = new string[0];
                pieces.Add(BitConverter.GetBytes(fk_link_names.Length));
                for (int i=0;i<fk_link_names.Length; i++) {
                    //fk_link_names[i]
                    if (fk_link_names[i] == null)
                        fk_link_names[i] = "";
                    scratch1 = Encoding.ASCII.GetBytes((string)fk_link_names[i]);
                    thischunk = new byte[scratch1.Length + 4];
                    scratch2 = BitConverter.GetBytes(scratch1.Length);
                    Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                    Array.Copy(scratch2, thischunk, 4);
                    pieces.Add(thischunk);
                }
                //robot_state
                if (robot_state == null)
                    robot_state = new Messages.moveit_msgs.RobotState();
                pieces.Add(robot_state.Serialize(true));
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
                
                //header
                header = new Header();
                header.Randomize();
                //fk_link_names
                arraylength = rand.Next(10);
                if (fk_link_names == null)
                    fk_link_names = new string[arraylength];
                else
                    Array.Resize(ref fk_link_names, arraylength);
                for (int i=0;i<fk_link_names.Length; i++) {
                    //fk_link_names[i]
                    strlength = rand.Next(100) + 1;
                    strbuf = new byte[strlength];
                    rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                    for (int __x__ = 0; __x__ < strlength; __x__++)
                        if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                            strbuf[__x__] = (byte)(rand.Next(254) + 1);
                    strbuf[strlength - 1] = 0; //null terminate
                    fk_link_names[i] = Encoding.ASCII.GetString(strbuf);
                }
                //robot_state
                robot_state = new Messages.moveit_msgs.RobotState();
                robot_state.Randomize();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                moveit_msgs.GetPositionFK.Request other = (Messages.moveit_msgs.GetPositionFK.Request)____other;

                ret &= header.Equals(other.header);
                if (fk_link_names.Length != other.fk_link_names.Length)
                    return false;
                for (int __i__=0; __i__ < fk_link_names.Length; __i__++)
                {
                    ret &= fk_link_names[__i__] == other.fk_link_names[__i__];
                }
                ret &= robot_state.Equals(other.robot_state);
                return ret;
            }
        }

        public class Response : RosMessage
        {
				public Messages.geometry_msgs.PoseStamped[] pose_stamped;
				public string[] fk_link_names;
				public Messages.moveit_msgs.MoveItErrorCodes error_code = new Messages.moveit_msgs.MoveItErrorCodes();



            public override string MD5Sum() { return "1d1ed72044ed56f6246c31b522781797"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"geometry_msgs/PoseStamped[] pose_stamped
string[] fk_link_names
MoveItErrorCodes error_code"; }
			public override string MessageType { get { return "moveit_msgs/GetPositionFK__Response"; } }
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
                
                //pose_stamped
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (pose_stamped == null)
                    pose_stamped = new Messages.geometry_msgs.PoseStamped[arraylength];
                else
                    Array.Resize(ref pose_stamped, arraylength);
                for (int i=0;i<pose_stamped.Length; i++) {
                    //pose_stamped[i]
                    pose_stamped[i] = new Messages.geometry_msgs.PoseStamped(serializedMessage, ref currentIndex);
                }
                //fk_link_names
                hasmetacomponents |= false;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (fk_link_names == null)
                    fk_link_names = new string[arraylength];
                else
                    Array.Resize(ref fk_link_names, arraylength);
                for (int i=0;i<fk_link_names.Length; i++) {
                    //fk_link_names[i]
                    fk_link_names[i] = "";
                    piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                    currentIndex += 4;
                    fk_link_names[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                    currentIndex += piecesize;
                }
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
                
                //pose_stamped
                hasmetacomponents |= true;
                if (pose_stamped == null)
                    pose_stamped = new Messages.geometry_msgs.PoseStamped[0];
                pieces.Add(BitConverter.GetBytes(pose_stamped.Length));
                for (int i=0;i<pose_stamped.Length; i++) {
                    //pose_stamped[i]
                    if (pose_stamped[i] == null)
                        pose_stamped[i] = new Messages.geometry_msgs.PoseStamped();
                    pieces.Add(pose_stamped[i].Serialize(true));
                }
                //fk_link_names
                hasmetacomponents |= false;
                if (fk_link_names == null)
                    fk_link_names = new string[0];
                pieces.Add(BitConverter.GetBytes(fk_link_names.Length));
                for (int i=0;i<fk_link_names.Length; i++) {
                    //fk_link_names[i]
                    if (fk_link_names[i] == null)
                        fk_link_names[i] = "";
                    scratch1 = Encoding.ASCII.GetBytes((string)fk_link_names[i]);
                    thischunk = new byte[scratch1.Length + 4];
                    scratch2 = BitConverter.GetBytes(scratch1.Length);
                    Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                    Array.Copy(scratch2, thischunk, 4);
                    pieces.Add(thischunk);
                }
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
                
                //pose_stamped
                arraylength = rand.Next(10);
                if (pose_stamped == null)
                    pose_stamped = new Messages.geometry_msgs.PoseStamped[arraylength];
                else
                    Array.Resize(ref pose_stamped, arraylength);
                for (int i=0;i<pose_stamped.Length; i++) {
                    //pose_stamped[i]
                    pose_stamped[i] = new Messages.geometry_msgs.PoseStamped();
                    pose_stamped[i].Randomize();
                }
                //fk_link_names
                arraylength = rand.Next(10);
                if (fk_link_names == null)
                    fk_link_names = new string[arraylength];
                else
                    Array.Resize(ref fk_link_names, arraylength);
                for (int i=0;i<fk_link_names.Length; i++) {
                    //fk_link_names[i]
                    strlength = rand.Next(100) + 1;
                    strbuf = new byte[strlength];
                    rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                    for (int __x__ = 0; __x__ < strlength; __x__++)
                        if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                            strbuf[__x__] = (byte)(rand.Next(254) + 1);
                    strbuf[strlength - 1] = 0; //null terminate
                    fk_link_names[i] = Encoding.ASCII.GetString(strbuf);
                }
                //error_code
                error_code = new Messages.moveit_msgs.MoveItErrorCodes();
                error_code.Randomize();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                moveit_msgs.GetPositionFK.Response other = (Messages.moveit_msgs.GetPositionFK.Response)____other;

                if (pose_stamped.Length != other.pose_stamped.Length)
                    return false;
                for (int __i__=0; __i__ < pose_stamped.Length; __i__++)
                {
                    ret &= pose_stamped[__i__].Equals(other.pose_stamped[__i__]);
                }
                if (fk_link_names.Length != other.fk_link_names.Length)
                    return false;
                for (int __i__=0; __i__ < fk_link_names.Length; __i__++)
                {
                    ret &= fk_link_names[__i__] == other.fk_link_names[__i__];
                }
                ret &= error_code.Equals(other.error_code);
                // for each SingleType st:
                //    ret &= {st.Name} == other.{st.Name};
                return ret;
            }
        }
    }
}
