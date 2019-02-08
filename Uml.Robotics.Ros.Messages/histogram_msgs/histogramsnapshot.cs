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

namespace Messages.histogram_msgs
{
    public class histogramsnapshot : RosMessage
    {

			public Single[] belief;


        public override string MD5Sum() { return "b03ac63e0fdfafd4c894fd4598047522"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"float32[] belief"; }
        public override string MessageType { get { return "histogram_msgs/histogramsnapshot"; } }
        public override bool IsServiceComponent() { return false; }

        public histogramsnapshot()
        {
            
        }

        public histogramsnapshot(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public histogramsnapshot(byte[] serializedMessage, ref int currentIndex)
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
            
            //belief
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (belief == null)
                belief = new Single[arraylength];
            else
                Array.Resize(ref belief, arraylength);
// Start Xamla
                //belief
                piecesize = Marshal.SizeOf(typeof(Single)) * belief.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, belief, 0, piecesize);
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
            
            //belief
            hasmetacomponents |= false;
            if (belief == null)
                belief = new Single[0];
            pieces.Add(BitConverter.GetBytes(belief.Length));
// Start Xamla
                //belief
                x__size = Marshal.SizeOf(typeof(Single)) * belief.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(belief, 0, scratch1, 0, x__size);
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
            
            //belief
            arraylength = rand.Next(10);
            if (belief == null)
                belief = new Single[arraylength];
            else
                Array.Resize(ref belief, arraylength);
            for (int i=0;i<belief.Length; i++) {
                //belief[i]
                belief[i] = (float)(rand.Next() + rand.NextDouble());
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.histogram_msgs.histogramsnapshot;
            if (other == null)
                return false;
            if (belief.Length != other.belief.Length)
                return false;
            for (int __i__=0; __i__ < belief.Length; __i__++)
            {
                ret &= belief[__i__] == other.belief[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
