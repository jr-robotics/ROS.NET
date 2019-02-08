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
    public class LaserEcho : RosMessage
    {

			public Single[] echoes;


        public override string MD5Sum() { return "8bc5ae449b200fba4d552b4225586696"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"float32[] echoes"; }
        public override string MessageType { get { return "sensor_msgs/LaserEcho"; } }
        public override bool IsServiceComponent() { return false; }

        public LaserEcho()
        {
            
        }

        public LaserEcho(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public LaserEcho(byte[] serializedMessage, ref int currentIndex)
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
            
            //echoes
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (echoes == null)
                echoes = new Single[arraylength];
            else
                Array.Resize(ref echoes, arraylength);
// Start Xamla
                //echoes
                piecesize = Marshal.SizeOf(typeof(Single)) * echoes.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, echoes, 0, piecesize);
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
            
            //echoes
            hasmetacomponents |= false;
            if (echoes == null)
                echoes = new Single[0];
            pieces.Add(BitConverter.GetBytes(echoes.Length));
// Start Xamla
                //echoes
                x__size = Marshal.SizeOf(typeof(Single)) * echoes.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(echoes, 0, scratch1, 0, x__size);
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
            
            //echoes
            arraylength = rand.Next(10);
            if (echoes == null)
                echoes = new Single[arraylength];
            else
                Array.Resize(ref echoes, arraylength);
            for (int i=0;i<echoes.Length; i++) {
                //echoes[i]
                echoes[i] = (float)(rand.Next() + rand.NextDouble());
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.sensor_msgs.LaserEcho;
            if (other == null)
                return false;
            if (echoes.Length != other.echoes.Length)
                return false;
            for (int __i__=0; __i__ < echoes.Length; __i__++)
            {
                ret &= echoes[__i__] == other.echoes[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
