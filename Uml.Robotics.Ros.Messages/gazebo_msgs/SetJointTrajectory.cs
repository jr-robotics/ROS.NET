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
    public class SetJointTrajectory : RosService
    {
        public override string ServiceType { get { return "gazebo_msgs/SetJointTrajectory"; } }
        public override string ServiceDefinition() { return @"string model_name
trajectory_msgs/JointTrajectory joint_trajectory
geometry_msgs/Pose model_pose
bool set_model_pose
bool disable_physics_updates
---
bool success
string status_message"; }
        public override string MD5Sum() { return "88f5c10979e3f9649d5ae87a3b12aa65"; }

        public SetJointTrajectory()
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
				public string model_name = "";
				public Messages.trajectory_msgs.JointTrajectory joint_trajectory = new Messages.trajectory_msgs.JointTrajectory();
				public Messages.geometry_msgs.Pose model_pose = new Messages.geometry_msgs.Pose();
				public bool set_model_pose;
				public bool disable_physics_updates;


            public override string MD5Sum() { return "649dd2eba5ffd358069238825f9f85ab"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"string model_name
trajectory_msgs/JointTrajectory joint_trajectory
geometry_msgs/Pose model_pose
bool set_model_pose
bool disable_physics_updates"; }
			public override string MessageType { get { return "gazebo_msgs/SetJointTrajectory__Request"; } }
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
                
                //model_name
                model_name = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                model_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //joint_trajectory
                joint_trajectory = new Messages.trajectory_msgs.JointTrajectory(serializedMessage, ref currentIndex);
                //model_pose
                model_pose = new Messages.geometry_msgs.Pose(serializedMessage, ref currentIndex);
                //set_model_pose
                set_model_pose = serializedMessage[currentIndex++]==1;
                //disable_physics_updates
                disable_physics_updates = serializedMessage[currentIndex++]==1;
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
                
                //model_name
                if (model_name == null)
                    model_name = "";
                scratch1 = Encoding.ASCII.GetBytes((string)model_name);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //joint_trajectory
                if (joint_trajectory == null)
                    joint_trajectory = new Messages.trajectory_msgs.JointTrajectory();
                pieces.Add(joint_trajectory.Serialize(true));
                //model_pose
                if (model_pose == null)
                    model_pose = new Messages.geometry_msgs.Pose();
                pieces.Add(model_pose.Serialize(true));
                //set_model_pose
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)set_model_pose ? 1 : 0 );
                pieces.Add(thischunk);
                //disable_physics_updates
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)disable_physics_updates ? 1 : 0 );
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
                
                //model_name
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                model_name = Encoding.ASCII.GetString(strbuf);
                //joint_trajectory
                joint_trajectory = new Messages.trajectory_msgs.JointTrajectory();
                joint_trajectory.Randomize();
                //model_pose
                model_pose = new Messages.geometry_msgs.Pose();
                model_pose.Randomize();
                //set_model_pose
                set_model_pose = rand.Next(2) == 1;
                //disable_physics_updates
                disable_physics_updates = rand.Next(2) == 1;
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                gazebo_msgs.SetJointTrajectory.Request other = (Messages.gazebo_msgs.SetJointTrajectory.Request)____other;

                ret &= model_name == other.model_name;
                ret &= joint_trajectory.Equals(other.joint_trajectory);
                ret &= model_pose.Equals(other.model_pose);
                ret &= set_model_pose == other.set_model_pose;
                ret &= disable_physics_updates == other.disable_physics_updates;
                return ret;
            }
        }

        public class Response : RosMessage
        {
				public bool success;
				public string status_message = "";



            public override string MD5Sum() { return "649dd2eba5ffd358069238825f9f85ab"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return false; }
            public override string MessageDefinition() { return @"bool success
string status_message"; }
			public override string MessageType { get { return "gazebo_msgs/SetJointTrajectory__Response"; } }
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
                gazebo_msgs.SetJointTrajectory.Response other = (Messages.gazebo_msgs.SetJointTrajectory.Response)____other;

                ret &= success == other.success;
                ret &= status_message == other.status_message;
                // for each SingleType st:
                //    ret &= {st.Name} == other.{st.Name};
                return ret;
            }
        }
    }
}
