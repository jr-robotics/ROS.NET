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
    public class MagneticField : RosMessage
    {

			public Header header = new Header();
			public Messages.geometry_msgs.Vector3 magnetic_field = new Messages.geometry_msgs.Vector3();
			public double[] magnetic_field_covariance = new double[9];


        public override string MD5Sum() { return "2f3b0b43eed0c9501de0fa3ff89a45aa"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
geometry_msgs/Vector3 magnetic_field
float64[9] magnetic_field_covariance"; }
        public override string MessageType { get { return "sensor_msgs/MagneticField"; } }
        public override bool IsServiceComponent() { return false; }

        public MagneticField()
        {
            
        }

        public MagneticField(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public MagneticField(byte[] serializedMessage, ref int currentIndex)
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
            //magnetic_field
            magnetic_field = new Messages.geometry_msgs.Vector3(serializedMessage, ref currentIndex);
            //magnetic_field_covariance
            hasmetacomponents |= false;
            if (magnetic_field_covariance == null)
                magnetic_field_covariance = new double[9];
            else
                Array.Resize(ref magnetic_field_covariance, 9);
// Start Xamla
                //magnetic_field_covariance
                piecesize = Marshal.SizeOf(typeof(double)) * magnetic_field_covariance.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, magnetic_field_covariance, 0, piecesize);
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
            //magnetic_field
            if (magnetic_field == null)
                magnetic_field = new Messages.geometry_msgs.Vector3();
            pieces.Add(magnetic_field.Serialize(true));
            //magnetic_field_covariance
            hasmetacomponents |= false;
            if (magnetic_field_covariance == null)
                magnetic_field_covariance = new double[0];
// Start Xamla
                //magnetic_field_covariance
                x__size = Marshal.SizeOf(typeof(double)) * magnetic_field_covariance.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(magnetic_field_covariance, 0, scratch1, 0, x__size);
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
            //magnetic_field
            magnetic_field = new Messages.geometry_msgs.Vector3();
            magnetic_field.Randomize();
            //magnetic_field_covariance
            if (magnetic_field_covariance == null)
                magnetic_field_covariance = new double[9];
            else
                Array.Resize(ref magnetic_field_covariance, 9);
            for (int i=0;i<magnetic_field_covariance.Length; i++) {
                //magnetic_field_covariance[i]
                magnetic_field_covariance[i] = (rand.Next() + rand.NextDouble());
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.sensor_msgs.MagneticField;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= magnetic_field.Equals(other.magnetic_field);
            if (magnetic_field_covariance.Length != other.magnetic_field_covariance.Length)
                return false;
            for (int __i__=0; __i__ < magnetic_field_covariance.Length; __i__++)
            {
                ret &= magnetic_field_covariance[__i__] == other.magnetic_field_covariance[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
