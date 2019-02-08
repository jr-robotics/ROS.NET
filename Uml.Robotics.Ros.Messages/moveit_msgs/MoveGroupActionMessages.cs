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


namespace Messages.moveit_msgs
{
	[ActionGoalMessage]
        public class MoveGroupGoal : InnerActionMessage
    {
        			public Messages.moveit_msgs.MotionPlanRequest request = new Messages.moveit_msgs.MotionPlanRequest();
			public Messages.moveit_msgs.PlanningOptions planning_options = new Messages.moveit_msgs.PlanningOptions();



        public override string MD5Sum() { return "a6de2db49c561a49babce1a8172e8906"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"MotionPlanRequest request
PlanningOptions planning_options"; }
		public override string MessageType { get { return "moveit_msgs/MoveGroupGoal"; } }
        public override bool IsServiceComponent() { return false; }

        public MoveGroupGoal()
        {
            
        }

        public MoveGroupGoal(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public MoveGroupGoal(byte[] serializedMessage, ref int currentIndex)
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

            
                //request
                request = new Messages.moveit_msgs.MotionPlanRequest(serializedMessage, ref currentIndex);
                //planning_options
                planning_options = new Messages.moveit_msgs.PlanningOptions(serializedMessage, ref currentIndex);
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

            
                //request
                if (request == null)
                    request = new Messages.moveit_msgs.MotionPlanRequest();
                pieces.Add(request.Serialize(true));
                //planning_options
                if (planning_options == null)
                    planning_options = new Messages.moveit_msgs.PlanningOptions();
                pieces.Add(planning_options.Serialize(true));

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

            
                //request
                request = new Messages.moveit_msgs.MotionPlanRequest();
                request.Randomize();
                //planning_options
                planning_options = new Messages.moveit_msgs.PlanningOptions();
                planning_options.Randomize();
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            MoveGroupGoal other;
            try
            {
                other = (MoveGroupGoal)message;
            }
            catch
            {
                return false;
            }

            
                ret &= request.Equals(other.request);
                ret &= planning_options.Equals(other.planning_options);

            return ret;
        }
    }



    //$ACTION_GOAL_MESSAGE

	[ActionResultMessage]
        public class MoveGroupResult : InnerActionMessage
    {
        			public Messages.moveit_msgs.MoveItErrorCodes error_code = new Messages.moveit_msgs.MoveItErrorCodes();
			public Messages.moveit_msgs.RobotState trajectory_start = new Messages.moveit_msgs.RobotState();
			public Messages.moveit_msgs.RobotTrajectory planned_trajectory = new Messages.moveit_msgs.RobotTrajectory();
			public Messages.moveit_msgs.RobotTrajectory executed_trajectory = new Messages.moveit_msgs.RobotTrajectory();
			public double planning_time;



        public override string MD5Sum() { return "34098589d402fee7ae9c3fd413e5a6c6"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"MoveItErrorCodes error_code
moveit_msgs/RobotState trajectory_start
moveit_msgs/RobotTrajectory planned_trajectory
moveit_msgs/RobotTrajectory executed_trajectory
float64 planning_time"; }
		public override string MessageType { get { return "moveit_msgs/MoveGroupResult"; } }
        public override bool IsServiceComponent() { return false; }

        public MoveGroupResult()
        {
            
        }

        public MoveGroupResult(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public MoveGroupResult(byte[] serializedMessage, ref int currentIndex)
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
                error_code = new Messages.moveit_msgs.MoveItErrorCodes(serializedMessage, ref currentIndex);
                //trajectory_start
                trajectory_start = new Messages.moveit_msgs.RobotState(serializedMessage, ref currentIndex);
                //planned_trajectory
                planned_trajectory = new Messages.moveit_msgs.RobotTrajectory(serializedMessage, ref currentIndex);
                //executed_trajectory
                executed_trajectory = new Messages.moveit_msgs.RobotTrajectory(serializedMessage, ref currentIndex);
                //planning_time
                piecesize = Marshal.SizeOf(typeof(double));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                planning_time = (double)Marshal.PtrToStructure(h, typeof(double));
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

            
                //error_code
                if (error_code == null)
                    error_code = new Messages.moveit_msgs.MoveItErrorCodes();
                pieces.Add(error_code.Serialize(true));
                //trajectory_start
                if (trajectory_start == null)
                    trajectory_start = new Messages.moveit_msgs.RobotState();
                pieces.Add(trajectory_start.Serialize(true));
                //planned_trajectory
                if (planned_trajectory == null)
                    planned_trajectory = new Messages.moveit_msgs.RobotTrajectory();
                pieces.Add(planned_trajectory.Serialize(true));
                //executed_trajectory
                if (executed_trajectory == null)
                    executed_trajectory = new Messages.moveit_msgs.RobotTrajectory();
                pieces.Add(executed_trajectory.Serialize(true));
                //planning_time
                scratch1 = new byte[Marshal.SizeOf(typeof(double))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(planning_time, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);

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
                error_code = new Messages.moveit_msgs.MoveItErrorCodes();
                error_code.Randomize();
                //trajectory_start
                trajectory_start = new Messages.moveit_msgs.RobotState();
                trajectory_start.Randomize();
                //planned_trajectory
                planned_trajectory = new Messages.moveit_msgs.RobotTrajectory();
                planned_trajectory.Randomize();
                //executed_trajectory
                executed_trajectory = new Messages.moveit_msgs.RobotTrajectory();
                executed_trajectory.Randomize();
                //planning_time
                planning_time = (rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            MoveGroupResult other;
            try
            {
                other = (MoveGroupResult)message;
            }
            catch
            {
                return false;
            }

            
                ret &= error_code.Equals(other.error_code);
                ret &= trajectory_start.Equals(other.trajectory_start);
                ret &= planned_trajectory.Equals(other.planned_trajectory);
                ret &= executed_trajectory.Equals(other.executed_trajectory);
                ret &= planning_time == other.planning_time;

            return ret;
        }
    }



    //$ACTION_RESULT_MESSAGE


	[ActionFeedbackMessage]
        public class MoveGroupFeedback : InnerActionMessage
    {
        			public string state = "";



        public override string MD5Sum() { return "af6d3a99f0fbeb66d3248fa4b3e675fb"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"string state"; }
		public override string MessageType { get { return "moveit_msgs/MoveGroupFeedback"; } }
        public override bool IsServiceComponent() { return false; }

        public MoveGroupFeedback()
        {
            
        }

        public MoveGroupFeedback(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public MoveGroupFeedback(byte[] serializedMessage, ref int currentIndex)
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

            
                //state
                state = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                state = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
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

            
                //state
                if (state == null)
                    state = "";
                scratch1 = Encoding.ASCII.GetBytes((string)state);
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

            
                //state
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                state = Encoding.ASCII.GetString(strbuf);
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            MoveGroupFeedback other;
            try
            {
                other = (MoveGroupFeedback)message;
            }
            catch
            {
                return false;
            }

            
                ret &= state == other.state;

            return ret;
        }
    }



    //$ACTION_FEEDBACK_MESSAGE
}