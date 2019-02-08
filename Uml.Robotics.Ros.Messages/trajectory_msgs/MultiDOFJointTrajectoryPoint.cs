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

namespace Messages.trajectory_msgs
{
    public class MultiDOFJointTrajectoryPoint : RosMessage
    {

			public Messages.geometry_msgs.Transform[] transforms;
			public Messages.geometry_msgs.Twist[] velocities;
			public Messages.geometry_msgs.Twist[] accelerations;
			public Duration time_from_start = new Duration();


        public override string MD5Sum() { return "3ebe08d1abd5b65862d50e09430db776"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"geometry_msgs/Transform[] transforms
geometry_msgs/Twist[] velocities
geometry_msgs/Twist[] accelerations
duration time_from_start"; }
        public override string MessageType { get { return "trajectory_msgs/MultiDOFJointTrajectoryPoint"; } }
        public override bool IsServiceComponent() { return false; }

        public MultiDOFJointTrajectoryPoint()
        {
            
        }

        public MultiDOFJointTrajectoryPoint(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public MultiDOFJointTrajectoryPoint(byte[] serializedMessage, ref int currentIndex)
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
            
            //transforms
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (transforms == null)
                transforms = new Messages.geometry_msgs.Transform[arraylength];
            else
                Array.Resize(ref transforms, arraylength);
            for (int i=0;i<transforms.Length; i++) {
                //transforms[i]
                transforms[i] = new Messages.geometry_msgs.Transform(serializedMessage, ref currentIndex);
            }
            //velocities
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (velocities == null)
                velocities = new Messages.geometry_msgs.Twist[arraylength];
            else
                Array.Resize(ref velocities, arraylength);
            for (int i=0;i<velocities.Length; i++) {
                //velocities[i]
                velocities[i] = new Messages.geometry_msgs.Twist(serializedMessage, ref currentIndex);
            }
            //accelerations
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (accelerations == null)
                accelerations = new Messages.geometry_msgs.Twist[arraylength];
            else
                Array.Resize(ref accelerations, arraylength);
            for (int i=0;i<accelerations.Length; i++) {
                //accelerations[i]
                accelerations[i] = new Messages.geometry_msgs.Twist(serializedMessage, ref currentIndex);
            }
            //time_from_start
            time_from_start = new Duration(new TimeData(
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
            
            //transforms
            hasmetacomponents |= false;
            if (transforms == null)
                transforms = new Messages.geometry_msgs.Transform[0];
            pieces.Add(BitConverter.GetBytes(transforms.Length));
            for (int i=0;i<transforms.Length; i++) {
                //transforms[i]
                if (transforms[i] == null)
                    transforms[i] = new Messages.geometry_msgs.Transform();
                pieces.Add(transforms[i].Serialize(true));
            }
            //velocities
            hasmetacomponents |= true;
            if (velocities == null)
                velocities = new Messages.geometry_msgs.Twist[0];
            pieces.Add(BitConverter.GetBytes(velocities.Length));
            for (int i=0;i<velocities.Length; i++) {
                //velocities[i]
                if (velocities[i] == null)
                    velocities[i] = new Messages.geometry_msgs.Twist();
                pieces.Add(velocities[i].Serialize(true));
            }
            //accelerations
            hasmetacomponents |= true;
            if (accelerations == null)
                accelerations = new Messages.geometry_msgs.Twist[0];
            pieces.Add(BitConverter.GetBytes(accelerations.Length));
            for (int i=0;i<accelerations.Length; i++) {
                //accelerations[i]
                if (accelerations[i] == null)
                    accelerations[i] = new Messages.geometry_msgs.Twist();
                pieces.Add(accelerations[i].Serialize(true));
            }
            //time_from_start
            pieces.Add(BitConverter.GetBytes(time_from_start.data.sec));
            pieces.Add(BitConverter.GetBytes(time_from_start.data.nsec));
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
            
            //transforms
            arraylength = rand.Next(10);
            if (transforms == null)
                transforms = new Messages.geometry_msgs.Transform[arraylength];
            else
                Array.Resize(ref transforms, arraylength);
            for (int i=0;i<transforms.Length; i++) {
                //transforms[i]
                transforms[i] = new Messages.geometry_msgs.Transform();
                transforms[i].Randomize();
            }
            //velocities
            arraylength = rand.Next(10);
            if (velocities == null)
                velocities = new Messages.geometry_msgs.Twist[arraylength];
            else
                Array.Resize(ref velocities, arraylength);
            for (int i=0;i<velocities.Length; i++) {
                //velocities[i]
                velocities[i] = new Messages.geometry_msgs.Twist();
                velocities[i].Randomize();
            }
            //accelerations
            arraylength = rand.Next(10);
            if (accelerations == null)
                accelerations = new Messages.geometry_msgs.Twist[arraylength];
            else
                Array.Resize(ref accelerations, arraylength);
            for (int i=0;i<accelerations.Length; i++) {
                //accelerations[i]
                accelerations[i] = new Messages.geometry_msgs.Twist();
                accelerations[i].Randomize();
            }
            //time_from_start
            time_from_start = new Duration(new TimeData(
                    Convert.ToInt32(rand.Next()),
                    Convert.ToInt32(rand.Next())));
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.trajectory_msgs.MultiDOFJointTrajectoryPoint;
            if (other == null)
                return false;
            if (transforms.Length != other.transforms.Length)
                return false;
            for (int __i__=0; __i__ < transforms.Length; __i__++)
            {
                ret &= transforms[__i__].Equals(other.transforms[__i__]);
            }
            if (velocities.Length != other.velocities.Length)
                return false;
            for (int __i__=0; __i__ < velocities.Length; __i__++)
            {
                ret &= velocities[__i__].Equals(other.velocities[__i__]);
            }
            if (accelerations.Length != other.accelerations.Length)
                return false;
            for (int __i__=0; __i__ < accelerations.Length; __i__++)
            {
                ret &= accelerations[__i__].Equals(other.accelerations[__i__]);
            }
            ret &= time_from_start.data.Equals(other.time_from_start.data);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
