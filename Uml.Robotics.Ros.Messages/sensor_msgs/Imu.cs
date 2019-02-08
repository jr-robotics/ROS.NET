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

namespace Messages.sensor_msgs
{
    public class Imu : RosMessage
    {

			public Header header = new Header();
			public Messages.geometry_msgs.Quaternion orientation = new Messages.geometry_msgs.Quaternion();
			public double[] orientation_covariance = new double[9];
			public Messages.geometry_msgs.Vector3 angular_velocity = new Messages.geometry_msgs.Vector3();
			public double[] angular_velocity_covariance = new double[9];
			public Messages.geometry_msgs.Vector3 linear_acceleration = new Messages.geometry_msgs.Vector3();
			public double[] linear_acceleration_covariance = new double[9];


        public override string MD5Sum() { return "6a62c6daae103f4ff57a132d6f95cec2"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
geometry_msgs/Quaternion orientation
float64[9] orientation_covariance
geometry_msgs/Vector3 angular_velocity
float64[9] angular_velocity_covariance
geometry_msgs/Vector3 linear_acceleration
float64[9] linear_acceleration_covariance"; }
        public override string MessageType { get { return "sensor_msgs/Imu"; } }
        public override bool IsServiceComponent() { return false; }

        public Imu()
        {
            
        }

        public Imu(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public Imu(byte[] serializedMessage, ref int currentIndex)
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
            
            //header
            header = new Header(serializedMessage, ref currentIndex);
            //orientation
            orientation = new Messages.geometry_msgs.Quaternion(serializedMessage, ref currentIndex);
            //orientation_covariance
            hasmetacomponents |= false;
            if (orientation_covariance == null)
                orientation_covariance = new double[9];
            else
                Array.Resize(ref orientation_covariance, 9);
// Start Xamla
                //orientation_covariance
                piecesize = Marshal.SizeOf(typeof(double)) * orientation_covariance.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, orientation_covariance, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //angular_velocity
            angular_velocity = new Messages.geometry_msgs.Vector3(serializedMessage, ref currentIndex);
            //angular_velocity_covariance
            hasmetacomponents |= false;
            if (angular_velocity_covariance == null)
                angular_velocity_covariance = new double[9];
            else
                Array.Resize(ref angular_velocity_covariance, 9);
// Start Xamla
                //angular_velocity_covariance
                piecesize = Marshal.SizeOf(typeof(double)) * angular_velocity_covariance.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, angular_velocity_covariance, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //linear_acceleration
            linear_acceleration = new Messages.geometry_msgs.Vector3(serializedMessage, ref currentIndex);
            //linear_acceleration_covariance
            hasmetacomponents |= false;
            if (linear_acceleration_covariance == null)
                linear_acceleration_covariance = new double[9];
            else
                Array.Resize(ref linear_acceleration_covariance, 9);
// Start Xamla
                //linear_acceleration_covariance
                piecesize = Marshal.SizeOf(typeof(double)) * linear_acceleration_covariance.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, linear_acceleration_covariance, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

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
            //orientation
            if (orientation == null)
                orientation = new Messages.geometry_msgs.Quaternion();
            pieces.Add(orientation.Serialize(true));
            //orientation_covariance
            hasmetacomponents |= false;
            if (orientation_covariance == null)
                orientation_covariance = new double[0];
// Start Xamla
                //orientation_covariance
                x__size = Marshal.SizeOf(typeof(double)) * orientation_covariance.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(orientation_covariance, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //angular_velocity
            if (angular_velocity == null)
                angular_velocity = new Messages.geometry_msgs.Vector3();
            pieces.Add(angular_velocity.Serialize(true));
            //angular_velocity_covariance
            hasmetacomponents |= false;
            if (angular_velocity_covariance == null)
                angular_velocity_covariance = new double[0];
// Start Xamla
                //angular_velocity_covariance
                x__size = Marshal.SizeOf(typeof(double)) * angular_velocity_covariance.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(angular_velocity_covariance, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //linear_acceleration
            if (linear_acceleration == null)
                linear_acceleration = new Messages.geometry_msgs.Vector3();
            pieces.Add(linear_acceleration.Serialize(true));
            //linear_acceleration_covariance
            hasmetacomponents |= false;
            if (linear_acceleration_covariance == null)
                linear_acceleration_covariance = new double[0];
// Start Xamla
                //linear_acceleration_covariance
                x__size = Marshal.SizeOf(typeof(double)) * linear_acceleration_covariance.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(linear_acceleration_covariance, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

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
            //orientation
            orientation = new Messages.geometry_msgs.Quaternion();
            orientation.Randomize();
            //orientation_covariance
            if (orientation_covariance == null)
                orientation_covariance = new double[9];
            else
                Array.Resize(ref orientation_covariance, 9);
            for (int i=0;i<orientation_covariance.Length; i++) {
                //orientation_covariance[i]
                orientation_covariance[i] = (rand.Next() + rand.NextDouble());
            }
            //angular_velocity
            angular_velocity = new Messages.geometry_msgs.Vector3();
            angular_velocity.Randomize();
            //angular_velocity_covariance
            if (angular_velocity_covariance == null)
                angular_velocity_covariance = new double[9];
            else
                Array.Resize(ref angular_velocity_covariance, 9);
            for (int i=0;i<angular_velocity_covariance.Length; i++) {
                //angular_velocity_covariance[i]
                angular_velocity_covariance[i] = (rand.Next() + rand.NextDouble());
            }
            //linear_acceleration
            linear_acceleration = new Messages.geometry_msgs.Vector3();
            linear_acceleration.Randomize();
            //linear_acceleration_covariance
            if (linear_acceleration_covariance == null)
                linear_acceleration_covariance = new double[9];
            else
                Array.Resize(ref linear_acceleration_covariance, 9);
            for (int i=0;i<linear_acceleration_covariance.Length; i++) {
                //linear_acceleration_covariance[i]
                linear_acceleration_covariance[i] = (rand.Next() + rand.NextDouble());
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.sensor_msgs.Imu;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= orientation.Equals(other.orientation);
            if (orientation_covariance.Length != other.orientation_covariance.Length)
                return false;
            for (int __i__=0; __i__ < orientation_covariance.Length; __i__++)
            {
                ret &= orientation_covariance[__i__] == other.orientation_covariance[__i__];
            }
            ret &= angular_velocity.Equals(other.angular_velocity);
            if (angular_velocity_covariance.Length != other.angular_velocity_covariance.Length)
                return false;
            for (int __i__=0; __i__ < angular_velocity_covariance.Length; __i__++)
            {
                ret &= angular_velocity_covariance[__i__] == other.angular_velocity_covariance[__i__];
            }
            ret &= linear_acceleration.Equals(other.linear_acceleration);
            if (linear_acceleration_covariance.Length != other.linear_acceleration_covariance.Length)
                return false;
            for (int __i__=0; __i__ < linear_acceleration_covariance.Length; __i__++)
            {
                ret &= linear_acceleration_covariance[__i__] == other.linear_acceleration_covariance[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
