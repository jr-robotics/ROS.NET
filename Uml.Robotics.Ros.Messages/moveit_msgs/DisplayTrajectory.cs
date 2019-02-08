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
    public class DisplayTrajectory : RosMessage
    {

			public string model_id = "";
			public Messages.moveit_msgs.RobotTrajectory[] trajectory;
			public Messages.moveit_msgs.RobotState trajectory_start = new Messages.moveit_msgs.RobotState();


        public override string MD5Sum() { return "c3c039261ab9e8a11457dac56b6316c8"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"string model_id
RobotTrajectory[] trajectory
RobotState trajectory_start"; }
        public override string MessageType { get { return "moveit_msgs/DisplayTrajectory"; } }
        public override bool IsServiceComponent() { return false; }

        public DisplayTrajectory()
        {
            
        }

        public DisplayTrajectory(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public DisplayTrajectory(byte[] serializedMessage, ref int currentIndex)
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
            
            //model_id
            model_id = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            model_id = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //trajectory
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (trajectory == null)
                trajectory = new Messages.moveit_msgs.RobotTrajectory[arraylength];
            else
                Array.Resize(ref trajectory, arraylength);
            for (int i=0;i<trajectory.Length; i++) {
                //trajectory[i]
                trajectory[i] = new Messages.moveit_msgs.RobotTrajectory(serializedMessage, ref currentIndex);
            }
            //trajectory_start
            trajectory_start = new Messages.moveit_msgs.RobotState(serializedMessage, ref currentIndex);
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
            
            //model_id
            if (model_id == null)
                model_id = "";
            scratch1 = Encoding.ASCII.GetBytes((string)model_id);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //trajectory
            hasmetacomponents |= true;
            if (trajectory == null)
                trajectory = new Messages.moveit_msgs.RobotTrajectory[0];
            pieces.Add(BitConverter.GetBytes(trajectory.Length));
            for (int i=0;i<trajectory.Length; i++) {
                //trajectory[i]
                if (trajectory[i] == null)
                    trajectory[i] = new Messages.moveit_msgs.RobotTrajectory();
                pieces.Add(trajectory[i].Serialize(true));
            }
            //trajectory_start
            if (trajectory_start == null)
                trajectory_start = new Messages.moveit_msgs.RobotState();
            pieces.Add(trajectory_start.Serialize(true));
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
            
            //model_id
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            model_id = Encoding.ASCII.GetString(strbuf);
            //trajectory
            arraylength = rand.Next(10);
            if (trajectory == null)
                trajectory = new Messages.moveit_msgs.RobotTrajectory[arraylength];
            else
                Array.Resize(ref trajectory, arraylength);
            for (int i=0;i<trajectory.Length; i++) {
                //trajectory[i]
                trajectory[i] = new Messages.moveit_msgs.RobotTrajectory();
                trajectory[i].Randomize();
            }
            //trajectory_start
            trajectory_start = new Messages.moveit_msgs.RobotState();
            trajectory_start.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.DisplayTrajectory;
            if (other == null)
                return false;
            ret &= model_id == other.model_id;
            if (trajectory.Length != other.trajectory.Length)
                return false;
            for (int __i__=0; __i__ < trajectory.Length; __i__++)
            {
                ret &= trajectory[__i__].Equals(other.trajectory[__i__]);
            }
            ret &= trajectory_start.Equals(other.trajectory_start);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
