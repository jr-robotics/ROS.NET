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
    public class Plane : RosMessage
    {

			public double[] coef = new double[4];


        public override string MD5Sum() { return "2c1b92ed8f31492f8e73f6a4a44ca796"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"float64[4] coef"; }
        public override string MessageType { get { return "shape_msgs/Plane"; } }
        public override bool IsServiceComponent() { return false; }

        public Plane()
        {
            
        }

        public Plane(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public Plane(byte[] serializedMessage, ref int currentIndex)
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
            
            //coef
            hasmetacomponents |= false;
            if (coef == null)
                coef = new double[4];
            else
                Array.Resize(ref coef, 4);
// Start Xamla
                //coef
                piecesize = Marshal.SizeOf(typeof(double)) * coef.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, coef, 0, piecesize);
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
            
            //coef
            hasmetacomponents |= false;
            if (coef == null)
                coef = new double[0];
// Start Xamla
                //coef
                x__size = Marshal.SizeOf(typeof(double)) * coef.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(coef, 0, scratch1, 0, x__size);
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
            
            //coef
            if (coef == null)
                coef = new double[4];
            else
                Array.Resize(ref coef, 4);
            for (int i=0;i<coef.Length; i++) {
                //coef[i]
                coef[i] = (rand.Next() + rand.NextDouble());
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.shape_msgs.Plane;
            if (other == null)
                return false;
            if (coef.Length != other.coef.Length)
                return false;
            for (int __i__=0; __i__ < coef.Length; __i__++)
            {
                ret &= coef[__i__] == other.coef[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
