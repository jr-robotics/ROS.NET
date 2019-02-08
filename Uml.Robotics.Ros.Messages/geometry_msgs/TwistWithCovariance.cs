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

namespace Messages.geometry_msgs
{
    public class TwistWithCovariance : RosMessage
    {

			public Messages.geometry_msgs.Twist twist = new Messages.geometry_msgs.Twist();
			public double[] covariance = new double[36];


        public override string MD5Sum() { return "1fe8a28e6890a4cc3ae4c3ca5c7d82e6"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Twist twist
float64[36] covariance"; }
        public override string MessageType { get { return "geometry_msgs/TwistWithCovariance"; } }
        public override bool IsServiceComponent() { return false; }

        public TwistWithCovariance()
        {
            
        }

        public TwistWithCovariance(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public TwistWithCovariance(byte[] serializedMessage, ref int currentIndex)
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
            
            //twist
            twist = new Messages.geometry_msgs.Twist(serializedMessage, ref currentIndex);
            //covariance
            hasmetacomponents |= false;
            if (covariance == null)
                covariance = new double[36];
            else
                Array.Resize(ref covariance, 36);
// Start Xamla
                //covariance
                piecesize = Marshal.SizeOf(typeof(double)) * covariance.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, covariance, 0, piecesize);
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
            
            //twist
            if (twist == null)
                twist = new Messages.geometry_msgs.Twist();
            pieces.Add(twist.Serialize(true));
            //covariance
            hasmetacomponents |= false;
            if (covariance == null)
                covariance = new double[0];
// Start Xamla
                //covariance
                x__size = Marshal.SizeOf(typeof(double)) * covariance.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(covariance, 0, scratch1, 0, x__size);
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
            
            //twist
            twist = new Messages.geometry_msgs.Twist();
            twist.Randomize();
            //covariance
            if (covariance == null)
                covariance = new double[36];
            else
                Array.Resize(ref covariance, 36);
            for (int i=0;i<covariance.Length; i++) {
                //covariance[i]
                covariance[i] = (rand.Next() + rand.NextDouble());
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.geometry_msgs.TwistWithCovariance;
            if (other == null)
                return false;
            ret &= twist.Equals(other.twist);
            if (covariance.Length != other.covariance.Length)
                return false;
            for (int __i__=0; __i__ < covariance.Length; __i__++)
            {
                ret &= covariance[__i__] == other.covariance[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
