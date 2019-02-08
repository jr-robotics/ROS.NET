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
    public class MotionPlanDetailedResponse : RosMessage
    {

			public Messages.moveit_msgs.RobotState trajectory_start = new Messages.moveit_msgs.RobotState();
			public string group_name = "";
			public Messages.moveit_msgs.RobotTrajectory[] trajectory;
			public string[] description;
			public double[] processing_time;
			public Messages.moveit_msgs.MoveItErrorCodes error_code = new Messages.moveit_msgs.MoveItErrorCodes();


        public override string MD5Sum() { return "7b84c374bb2e37bdc0eba664f7636a8f"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"RobotState trajectory_start
string group_name
RobotTrajectory[] trajectory
string[] description
float64[] processing_time
MoveItErrorCodes error_code"; }
        public override string MessageType { get { return "moveit_msgs/MotionPlanDetailedResponse"; } }
        public override bool IsServiceComponent() { return false; }

        public MotionPlanDetailedResponse()
        {
            
        }

        public MotionPlanDetailedResponse(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public MotionPlanDetailedResponse(byte[] serializedMessage, ref int currentIndex)
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
            //description
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (description == null)
                description = new string[arraylength];
            else
                Array.Resize(ref description, arraylength);
            for (int i=0;i<description.Length; i++) {
                //description[i]
                description[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                description[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
            }
            //processing_time
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (processing_time == null)
                processing_time = new double[arraylength];
            else
                Array.Resize(ref processing_time, arraylength);
// Start Xamla
                //processing_time
                piecesize = Marshal.SizeOf(typeof(double)) * processing_time.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, processing_time, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

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
            //description
            hasmetacomponents |= false;
            if (description == null)
                description = new string[0];
            pieces.Add(BitConverter.GetBytes(description.Length));
            for (int i=0;i<description.Length; i++) {
                //description[i]
                if (description[i] == null)
                    description[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)description[i]);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
            }
            //processing_time
            hasmetacomponents |= false;
            if (processing_time == null)
                processing_time = new double[0];
            pieces.Add(BitConverter.GetBytes(processing_time.Length));
// Start Xamla
                //processing_time
                x__size = Marshal.SizeOf(typeof(double)) * processing_time.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(processing_time, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

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
            //description
            arraylength = rand.Next(10);
            if (description == null)
                description = new string[arraylength];
            else
                Array.Resize(ref description, arraylength);
            for (int i=0;i<description.Length; i++) {
                //description[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                description[i] = Encoding.ASCII.GetString(strbuf);
            }
            //processing_time
            arraylength = rand.Next(10);
            if (processing_time == null)
                processing_time = new double[arraylength];
            else
                Array.Resize(ref processing_time, arraylength);
            for (int i=0;i<processing_time.Length; i++) {
                //processing_time[i]
                processing_time[i] = (rand.Next() + rand.NextDouble());
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
            var other = ____other as Messages.moveit_msgs.MotionPlanDetailedResponse;
            if (other == null)
                return false;
            ret &= trajectory_start.Equals(other.trajectory_start);
            ret &= group_name == other.group_name;
            if (trajectory.Length != other.trajectory.Length)
                return false;
            for (int __i__=0; __i__ < trajectory.Length; __i__++)
            {
                ret &= trajectory[__i__].Equals(other.trajectory[__i__]);
            }
            if (description.Length != other.description.Length)
                return false;
            for (int __i__=0; __i__ < description.Length; __i__++)
            {
                ret &= description[__i__] == other.description[__i__];
            }
            if (processing_time.Length != other.processing_time.Length)
                return false;
            for (int __i__=0; __i__ < processing_time.Length; __i__++)
            {
                ret &= processing_time[__i__] == other.processing_time[__i__];
            }
            ret &= error_code.Equals(other.error_code);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
