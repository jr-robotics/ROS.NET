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

namespace Messages.shape_msgs
{
    public class SolidPrimitive : RosMessage
    {

			public const byte BOX = 1;
			public const byte SPHERE = 2;
			public const byte CYLINDER = 3;
			public const byte CONE = 4;
			public byte type;
			public double[] dimensions;
			public const byte BOX_X = 0;
			public const byte BOX_Y = 1;
			public const byte BOX_Z = 2;
			public const byte SPHERE_RADIUS = 0;
			public const byte CYLINDER_HEIGHT = 0;
			public const byte CYLINDER_RADIUS = 1;
			public const byte CONE_HEIGHT = 0;
			public const byte CONE_RADIUS = 1;


        public override string MD5Sum() { return "d8f8cbc74c5ff283fca29569ccefb45d"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"uint8 BOX=1
uint8 SPHERE=2
uint8 CYLINDER=3
uint8 CONE=4
uint8 type
float64[] dimensions
uint8 BOX_X=0
uint8 BOX_Y=1
uint8 BOX_Z=2
uint8 SPHERE_RADIUS=0
uint8 CYLINDER_HEIGHT=0
uint8 CYLINDER_RADIUS=1
uint8 CONE_HEIGHT=0
uint8 CONE_RADIUS=1"; }
        public override string MessageType { get { return "shape_msgs/SolidPrimitive"; } }
        public override bool IsServiceComponent() { return false; }

        public SolidPrimitive()
        {
            
        }

        public SolidPrimitive(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public SolidPrimitive(byte[] serializedMessage, ref int currentIndex)
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
            
            //type
            type=serializedMessage[currentIndex++];
            //dimensions
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (dimensions == null)
                dimensions = new double[arraylength];
            else
                Array.Resize(ref dimensions, arraylength);
// Start Xamla
                //dimensions
                piecesize = Marshal.SizeOf(typeof(double)) * dimensions.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, dimensions, 0, piecesize);
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
            
            //type
            pieces.Add(new[] { (byte)type });
            //dimensions
            hasmetacomponents |= false;
            if (dimensions == null)
                dimensions = new double[0];
            pieces.Add(BitConverter.GetBytes(dimensions.Length));
// Start Xamla
                //dimensions
                x__size = Marshal.SizeOf(typeof(double)) * dimensions.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(dimensions, 0, scratch1, 0, x__size);
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
            
            //type
            myByte = new byte[1];
            rand.NextBytes(myByte);
            type= myByte[0];
            //dimensions
            arraylength = rand.Next(10);
            if (dimensions == null)
                dimensions = new double[arraylength];
            else
                Array.Resize(ref dimensions, arraylength);
            for (int i=0;i<dimensions.Length; i++) {
                //dimensions[i]
                dimensions[i] = (rand.Next() + rand.NextDouble());
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.shape_msgs.SolidPrimitive;
            if (other == null)
                return false;
            ret &= type == other.type;
            if (dimensions.Length != other.dimensions.Length)
                return false;
            for (int __i__=0; __i__ < dimensions.Length; __i__++)
            {
                ret &= dimensions[__i__] == other.dimensions[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
