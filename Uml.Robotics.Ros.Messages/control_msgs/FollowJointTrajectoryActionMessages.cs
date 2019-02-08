using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

using Uml.Robotics.Ros;
using Messages.actionlib_msgs;
using Messages.geometry_msgs;
using Messages.std_msgs;


namespace Messages.control_msgs
{
	[ActionGoalMessage]
        public class FollowJointTrajectoryGoal : InnerActionMessage
    {
        			public Messages.trajectory_msgs.JointTrajectory trajectory = new Messages.trajectory_msgs.JointTrajectory();
			public Messages.control_msgs.JointTolerance[] path_tolerance;
			public Messages.control_msgs.JointTolerance[] goal_tolerance;
			public Duration goal_time_tolerance = new Duration();



        public override string MD5Sum() { return "69636787b6ecbde4d61d711979bc7ecb"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"trajectory_msgs/JointTrajectory trajectory
JointTolerance[] path_tolerance
JointTolerance[] goal_tolerance
duration goal_time_tolerance"; }
		public override string MessageType { get { return "control_msgs/FollowJointTrajectoryGoal"; } }
        public override bool IsServiceComponent() { return false; }

        public FollowJointTrajectoryGoal()
        {
            
        }

        public FollowJointTrajectoryGoal(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public FollowJointTrajectoryGoal(byte[] serializedMessage, ref int currentIndex)
        {
            Deserialize(serializedMessage, ref currentIndex);
        }

        

        public void Deserialize(byte[] serializedMessage, int currentIndex)
        {
            Deserialize(serializedMessage, currentIndex);
        }

        public override void Deserialize(byte[] serializedMessage, ref int currentIndex)
        {
            int arraylength = -1;
            bool hasmetacomponents = false;
            object __thing;
            int piecesize = 0;
            byte[] thischunk, scratch1, scratch2;
            IntPtr h;

            
                //trajectory
                trajectory = new Messages.trajectory_msgs.JointTrajectory(serializedMessage, ref currentIndex);
                //path_tolerance
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (path_tolerance == null)
                    path_tolerance = new Messages.control_msgs.JointTolerance[arraylength];
                else
                    Array.Resize(ref path_tolerance, arraylength);
                for (int i=0;i<path_tolerance.Length; i++) {
                    //path_tolerance[i]
                    path_tolerance[i] = new Messages.control_msgs.JointTolerance(serializedMessage, ref currentIndex);
                }
                //goal_tolerance
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (goal_tolerance == null)
                    goal_tolerance = new Messages.control_msgs.JointTolerance[arraylength];
                else
                    Array.Resize(ref goal_tolerance, arraylength);
                for (int i=0;i<goal_tolerance.Length; i++) {
                    //goal_tolerance[i]
                    goal_tolerance[i] = new Messages.control_msgs.JointTolerance(serializedMessage, ref currentIndex);
                }
                //goal_time_tolerance
                goal_time_tolerance = new Duration(new TimeData(
                        BitConverter.ToInt32(serializedMessage, currentIndex),
                        BitConverter.ToInt32(serializedMessage, currentIndex+Marshal.SizeOf(typeof(System.Int32)))));
                currentIndex += 2*Marshal.SizeOf(typeof(System.Int32));
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

            
                //trajectory
                if (trajectory == null)
                    trajectory = new Messages.trajectory_msgs.JointTrajectory();
                pieces.Add(trajectory.Serialize(true));
                //path_tolerance
                hasmetacomponents |= true;
                if (path_tolerance == null)
                    path_tolerance = new Messages.control_msgs.JointTolerance[0];
                pieces.Add(BitConverter.GetBytes(path_tolerance.Length));
                for (int i=0;i<path_tolerance.Length; i++) {
                    //path_tolerance[i]
                    if (path_tolerance[i] == null)
                        path_tolerance[i] = new Messages.control_msgs.JointTolerance();
                    pieces.Add(path_tolerance[i].Serialize(true));
                }
                //goal_tolerance
                hasmetacomponents |= true;
                if (goal_tolerance == null)
                    goal_tolerance = new Messages.control_msgs.JointTolerance[0];
                pieces.Add(BitConverter.GetBytes(goal_tolerance.Length));
                for (int i=0;i<goal_tolerance.Length; i++) {
                    //goal_tolerance[i]
                    if (goal_tolerance[i] == null)
                        goal_tolerance[i] = new Messages.control_msgs.JointTolerance();
                    pieces.Add(goal_tolerance[i].Serialize(true));
                }
                //goal_time_tolerance
                pieces.Add(BitConverter.GetBytes(goal_time_tolerance.data.sec));
                pieces.Add(BitConverter.GetBytes(goal_time_tolerance.data.nsec));

            // combine every array in pieces into one array and return it
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

            
                //trajectory
                trajectory = new Messages.trajectory_msgs.JointTrajectory();
                trajectory.Randomize();
                //path_tolerance
                arraylength = rand.Next(10);
                if (path_tolerance == null)
                    path_tolerance = new Messages.control_msgs.JointTolerance[arraylength];
                else
                    Array.Resize(ref path_tolerance, arraylength);
                for (int i=0;i<path_tolerance.Length; i++) {
                    //path_tolerance[i]
                    path_tolerance[i] = new Messages.control_msgs.JointTolerance();
                    path_tolerance[i].Randomize();
                }
                //goal_tolerance
                arraylength = rand.Next(10);
                if (goal_tolerance == null)
                    goal_tolerance = new Messages.control_msgs.JointTolerance[arraylength];
                else
                    Array.Resize(ref goal_tolerance, arraylength);
                for (int i=0;i<goal_tolerance.Length; i++) {
                    //goal_tolerance[i]
                    goal_tolerance[i] = new Messages.control_msgs.JointTolerance();
                    goal_tolerance[i].Randomize();
                }
                //goal_time_tolerance
                goal_time_tolerance = new Duration(new TimeData(
                        Convert.ToInt32(rand.Next()),
                        Convert.ToInt32(rand.Next())));
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            FollowJointTrajectoryGoal other;
            try
            {
                other = (FollowJointTrajectoryGoal)message;
            }
            catch
            {
                return false;
            }

            
                ret &= trajectory.Equals(other.trajectory);
                if (path_tolerance.Length != other.path_tolerance.Length)
                    return false;
                for (int __i__=0; __i__ < path_tolerance.Length; __i__++)
                {
                    ret &= path_tolerance[__i__].Equals(other.path_tolerance[__i__]);
                }
                if (goal_tolerance.Length != other.goal_tolerance.Length)
                    return false;
                for (int __i__=0; __i__ < goal_tolerance.Length; __i__++)
                {
                    ret &= goal_tolerance[__i__].Equals(other.goal_tolerance[__i__]);
                }
                ret &= goal_time_tolerance.data.Equals(other.goal_time_tolerance.data);

            return ret;
        }
    }



    //$ACTION_GOAL_MESSAGE

	[ActionResultMessage]
        public class FollowJointTrajectoryResult : InnerActionMessage
    {
        			public int error_code;
			public const int SUCCESSFUL = 0;
			public const int INVALID_GOAL = -1;
			public const int INVALID_JOINTS = -2;
			public const int OLD_HEADER_TIMESTAMP = -3;
			public const int PATH_TOLERANCE_VIOLATED = -4;
			public const int GOAL_TOLERANCE_VIOLATED = -5;
			public string error_string = "";



        public override string MD5Sum() { return "493383b18409bfb604b4e26c676401d2"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"int32 error_code
int32 SUCCESSFUL = 0
int32 INVALID_GOAL = -1
int32 INVALID_JOINTS = -2
int32 OLD_HEADER_TIMESTAMP = -3
int32 PATH_TOLERANCE_VIOLATED = -4
int32 GOAL_TOLERANCE_VIOLATED = -5
string error_string"; }
		public override string MessageType { get { return "control_msgs/FollowJointTrajectoryResult"; } }
        public override bool IsServiceComponent() { return false; }

        public FollowJointTrajectoryResult()
        {
            
        }

        public FollowJointTrajectoryResult(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public FollowJointTrajectoryResult(byte[] serializedMessage, ref int currentIndex)
        {
            Deserialize(serializedMessage, ref currentIndex);
        }

        

        public void Deserialize(byte[] serializedMessage, int currentIndex)
        {
            Deserialize(serializedMessage, currentIndex);
        }

        public override void Deserialize(byte[] serializedMessage, ref int currentIndex)
        {
            int arraylength = -1;
            bool hasmetacomponents = false;
            object __thing;
            int piecesize = 0;
            byte[] thischunk, scratch1, scratch2;
            IntPtr h;

            
                //error_code
                piecesize = Marshal.SizeOf(typeof(int));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                error_code = (int)Marshal.PtrToStructure(h, typeof(int));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //error_string
                error_string = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                error_string = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
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

            
                //error_code
                scratch1 = new byte[Marshal.SizeOf(typeof(int))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(error_code, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //error_string
                if (error_string == null)
                    error_string = "";
                scratch1 = Encoding.ASCII.GetBytes((string)error_string);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);

            // combine every array in pieces into one array and return it
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

            
                //error_code
                error_code = rand.Next();
                //error_string
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                error_string = Encoding.ASCII.GetString(strbuf);
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            FollowJointTrajectoryResult other;
            try
            {
                other = (FollowJointTrajectoryResult)message;
            }
            catch
            {
                return false;
            }

            
                ret &= error_code == other.error_code;
                ret &= error_string == other.error_string;

            return ret;
        }
    }



    //$ACTION_RESULT_MESSAGE


	[ActionFeedbackMessage]
        public class FollowJointTrajectoryFeedback : InnerActionMessage
    {
        			public Header header = new Header();
			public string[] joint_names;
			public Messages.trajectory_msgs.JointTrajectoryPoint desired = new Messages.trajectory_msgs.JointTrajectoryPoint();
			public Messages.trajectory_msgs.JointTrajectoryPoint actual = new Messages.trajectory_msgs.JointTrajectoryPoint();
			public Messages.trajectory_msgs.JointTrajectoryPoint error = new Messages.trajectory_msgs.JointTrajectoryPoint();



        public override string MD5Sum() { return "10817c60c2486ef6b33e97dcd87f4474"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
string[] joint_names
trajectory_msgs/JointTrajectoryPoint desired
trajectory_msgs/JointTrajectoryPoint actual
trajectory_msgs/JointTrajectoryPoint error"; }
		public override string MessageType { get { return "control_msgs/FollowJointTrajectoryFeedback"; } }
        public override bool IsServiceComponent() { return false; }

        public FollowJointTrajectoryFeedback()
        {
            
        }

        public FollowJointTrajectoryFeedback(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public FollowJointTrajectoryFeedback(byte[] serializedMessage, ref int currentIndex)
        {
            Deserialize(serializedMessage, ref currentIndex);
        }

        

        public void Deserialize(byte[] serializedMessage, int currentIndex)
        {
            Deserialize(serializedMessage, currentIndex);
        }

        public override void Deserialize(byte[] serializedMessage, ref int currentIndex)
        {
            int arraylength = -1;
            bool hasmetacomponents = false;
            object __thing;
            int piecesize = 0;
            byte[] thischunk, scratch1, scratch2;
            IntPtr h;

            
                //header
                header = new Header(serializedMessage, ref currentIndex);
                //joint_names
                hasmetacomponents |= false;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (joint_names == null)
                    joint_names = new string[arraylength];
                else
                    Array.Resize(ref joint_names, arraylength);
                for (int i=0;i<joint_names.Length; i++) {
                    //joint_names[i]
                    joint_names[i] = "";
                    piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                    currentIndex += 4;
                    joint_names[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                    currentIndex += piecesize;
                }
                //desired
                desired = new Messages.trajectory_msgs.JointTrajectoryPoint(serializedMessage, ref currentIndex);
                //actual
                actual = new Messages.trajectory_msgs.JointTrajectoryPoint(serializedMessage, ref currentIndex);
                //error
                error = new Messages.trajectory_msgs.JointTrajectoryPoint(serializedMessage, ref currentIndex);
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
                //joint_names
                hasmetacomponents |= false;
                if (joint_names == null)
                    joint_names = new string[0];
                pieces.Add(BitConverter.GetBytes(joint_names.Length));
                for (int i=0;i<joint_names.Length; i++) {
                    //joint_names[i]
                    if (joint_names[i] == null)
                        joint_names[i] = "";
                    scratch1 = Encoding.ASCII.GetBytes((string)joint_names[i]);
                    thischunk = new byte[scratch1.Length + 4];
                    scratch2 = BitConverter.GetBytes(scratch1.Length);
                    Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                    Array.Copy(scratch2, thischunk, 4);
                    pieces.Add(thischunk);
                }
                //desired
                if (desired == null)
                    desired = new Messages.trajectory_msgs.JointTrajectoryPoint();
                pieces.Add(desired.Serialize(true));
                //actual
                if (actual == null)
                    actual = new Messages.trajectory_msgs.JointTrajectoryPoint();
                pieces.Add(actual.Serialize(true));
                //error
                if (error == null)
                    error = new Messages.trajectory_msgs.JointTrajectoryPoint();
                pieces.Add(error.Serialize(true));

            // combine every array in pieces into one array and return it
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

            
                //header
                header = new Header();
                header.Randomize();
                //joint_names
                arraylength = rand.Next(10);
                if (joint_names == null)
                    joint_names = new string[arraylength];
                else
                    Array.Resize(ref joint_names, arraylength);
                for (int i=0;i<joint_names.Length; i++) {
                    //joint_names[i]
                    strlength = rand.Next(100) + 1;
                    strbuf = new byte[strlength];
                    rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                    for (int __x__ = 0; __x__ < strlength; __x__++)
                        if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                            strbuf[__x__] = (byte)(rand.Next(254) + 1);
                    strbuf[strlength - 1] = 0; //null terminate
                    joint_names[i] = Encoding.ASCII.GetString(strbuf);
                }
                //desired
                desired = new Messages.trajectory_msgs.JointTrajectoryPoint();
                desired.Randomize();
                //actual
                actual = new Messages.trajectory_msgs.JointTrajectoryPoint();
                actual.Randomize();
                //error
                error = new Messages.trajectory_msgs.JointTrajectoryPoint();
                error.Randomize();
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            FollowJointTrajectoryFeedback other;
            try
            {
                other = (FollowJointTrajectoryFeedback)message;
            }
            catch
            {
                return false;
            }

            
                ret &= header.Equals(other.header);
                if (joint_names.Length != other.joint_names.Length)
                    return false;
                for (int __i__=0; __i__ < joint_names.Length; __i__++)
                {
                    ret &= joint_names[__i__] == other.joint_names[__i__];
                }
                ret &= desired.Equals(other.desired);
                ret &= actual.Equals(other.actual);
                ret &= error.Equals(other.error);

            return ret;
        }
    }



    //$ACTION_FEEDBACK_MESSAGE
}