using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using uint8 = System.Byte;
using Uml.Robotics.Ros;
using Messages.geometry_msgs;
using Messages.sensor_msgs;
using Messages.actionlib_msgs;

using Messages.std_msgs;
using String=System.String;

namespace Messages.moveit_msgs
{
    public class MoveItErrorCodes : RosMessage
    {

			public int val;
			public const int SUCCESS = 1;
			public const int FAILURE = 99999;
			public const int PLANNING_FAILED = -1;
			public const int INVALID_MOTION_PLAN = -2;
			public const int MOTION_PLAN_INVALIDATED_BY_ENVIRONMENT_CHANGE = -3;
			public const int CONTROL_FAILED = -4;
			public const int UNABLE_TO_AQUIRE_SENSOR_DATA = -5;
			public const int TIMED_OUT = -6;
			public const int PREEMPTED = -7;
			public const int START_STATE_IN_COLLISION = -10;
			public const int START_STATE_VIOLATES_PATH_CONSTRAINTS = -11;
			public const int GOAL_IN_COLLISION = -12;
			public const int GOAL_VIOLATES_PATH_CONSTRAINTS = -13;
			public const int GOAL_CONSTRAINTS_VIOLATED = -14;
			public const int INVALID_GROUP_NAME = -15;
			public const int INVALID_GOAL_CONSTRAINTS = -16;
			public const int INVALID_ROBOT_STATE = -17;
			public const int INVALID_LINK_NAME = -18;
			public const int INVALID_OBJECT_NAME = -19;
			public const int FRAME_TRANSFORM_FAILURE = -21;
			public const int COLLISION_CHECKING_UNAVAILABLE = -22;
			public const int ROBOT_STATE_STALE = -23;
			public const int SENSOR_INFO_STALE = -24;
			public const int NO_IK_SOLUTION = -31;


        public override string MD5Sum() { return "aa336b18d80531f66439810112c0a43e"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"int32 val
int32 SUCCESS=1
int32 FAILURE=99999
int32 PLANNING_FAILED=-1
int32 INVALID_MOTION_PLAN=-2
int32 MOTION_PLAN_INVALIDATED_BY_ENVIRONMENT_CHANGE=-3
int32 CONTROL_FAILED=-4
int32 UNABLE_TO_AQUIRE_SENSOR_DATA=-5
int32 TIMED_OUT=-6
int32 PREEMPTED=-7
int32 START_STATE_IN_COLLISION=-10
int32 START_STATE_VIOLATES_PATH_CONSTRAINTS=-11
int32 GOAL_IN_COLLISION=-12
int32 GOAL_VIOLATES_PATH_CONSTRAINTS=-13
int32 GOAL_CONSTRAINTS_VIOLATED=-14
int32 INVALID_GROUP_NAME=-15
int32 INVALID_GOAL_CONSTRAINTS=-16
int32 INVALID_ROBOT_STATE=-17
int32 INVALID_LINK_NAME=-18
int32 INVALID_OBJECT_NAME=-19
int32 FRAME_TRANSFORM_FAILURE=-21
int32 COLLISION_CHECKING_UNAVAILABLE=-22
int32 ROBOT_STATE_STALE=-23
int32 SENSOR_INFO_STALE=-24
int32 NO_IK_SOLUTION=-31"; }
        public override string MessageType { get { return "moveit_msgs/MoveItErrorCodes"; } }
        public override bool IsServiceComponent() { return false; }

        public MoveItErrorCodes()
        {
            
        }

        public MoveItErrorCodes(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public MoveItErrorCodes(byte[] serializedMessage, ref int currentIndex)
        {
            Deserialize(serializedMessage, ref currentIndex);
        }



        public override void Deserialize(byte[] serializedMessage, ref int currentIndex)
        {
            int arraylength = -1;
            bool hasmetacomponents = false;
            object __thing;
            int piecesize = 0;
            byte[] thischunk, scratch1, scratch2;
            IntPtr h;
            
            //val
            piecesize = Marshal.SizeOf(typeof(int));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            val = (int)Marshal.PtrToStructure(h, typeof(int));
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
            
            //val
            scratch1 = new byte[Marshal.SizeOf(typeof(int))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(val, h.AddrOfPinnedObject(), false);
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
            
            //val
            val = rand.Next();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.MoveItErrorCodes;
            if (other == null)
                return false;
            ret &= val == other.val;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
