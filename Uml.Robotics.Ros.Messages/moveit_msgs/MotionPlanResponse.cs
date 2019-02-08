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
    public class MotionPlanResponse : RosMessage
    {

			public Messages.moveit_msgs.RobotState trajectory_start = new Messages.moveit_msgs.RobotState();
			public string group_name = "";
			public Messages.moveit_msgs.RobotTrajectory trajectory = new Messages.moveit_msgs.RobotTrajectory();
			public double planning_time;
			public Messages.moveit_msgs.MoveItErrorCodes error_code = new Messages.moveit_msgs.MoveItErrorCodes();


        public override string MD5Sum() { return "e493d20ab41424c48f671e152c70fc74"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"RobotState trajectory_start
string group_name
RobotTrajectory trajectory
float64 planning_time
MoveItErrorCodes error_code"; }
        public override string MessageType { get { return "moveit_msgs/MotionPlanResponse"; } }
        public override bool IsServiceComponent() { return false; }

        public MotionPlanResponse()
        {
            
        }

        public MotionPlanResponse(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public MotionPlanResponse(byte[] serializedMessage, ref int currentIndex)
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
            
            //trajectory_start
            trajectory_start = new Messages.moveit_msgs.RobotState(serializedMessage, ref currentIndex);
            //group_name
            group_name = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            group_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //trajectory
            trajectory = new Messages.moveit_msgs.RobotTrajectory(serializedMessage, ref currentIndex);
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
            
            //trajectory_start
            if (trajectory_start == null)
                trajectory_start = new Messages.moveit_msgs.RobotState();
            pieces.Add(trajectory_start.Serialize(true));
            //group_name
            if (group_name == null)
                group_name = "";
            scratch1 = Encoding.ASCII.GetBytes((string)group_name);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //trajectory
            if (trajectory == null)
                trajectory = new Messages.moveit_msgs.RobotTrajectory();
            pieces.Add(trajectory.Serialize(true));
            //planning_time
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(planning_time, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //error_code
            if (error_code == null)
                error_code = new Messages.moveit_msgs.MoveItErrorCodes();
            pieces.Add(error_code.Serialize(true));
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
            
            //trajectory_start
            trajectory_start = new Messages.moveit_msgs.RobotState();
            trajectory_start.Randomize();
            //group_name
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            group_name = Encoding.ASCII.GetString(strbuf);
            //trajectory
            trajectory = new Messages.moveit_msgs.RobotTrajectory();
            trajectory.Randomize();
            //planning_time
            planning_time = (rand.Next() + rand.NextDouble());
            //error_code
            error_code = new Messages.moveit_msgs.MoveItErrorCodes();
            error_code.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.MotionPlanResponse;
            if (other == null)
                return false;
            ret &= trajectory_start.Equals(other.trajectory_start);
            ret &= group_name == other.group_name;
            ret &= trajectory.Equals(other.trajectory);
            ret &= planning_time == other.planning_time;
            ret &= error_code.Equals(other.error_code);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
