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

namespace Messages.custom_msgs
{
    public class simpleintarray : RosMessage
    {

			public short[] knownlengtharray = new short[3];
			public short[] unknownlengtharray;


        public override string MD5Sum() { return "5788d544e629aca889424556ab4e5260"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"int16[3] knownlengtharray
int16[] unknownlengtharray"; }
        public override string MessageType { get { return "custom_msgs/simpleintarray"; } }
        public override bool IsServiceComponent() { return false; }

        public simpleintarray()
        {
            
        }

        public simpleintarray(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public simpleintarray(byte[] serializedMessage, ref int currentIndex)
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
            
            //knownlengtharray
            hasmetacomponents |= false;
            if (knownlengtharray == null)
                knownlengtharray = new short[3];
            else
                Array.Resize(ref knownlengtharray, 3);
// Start Xamla
                //knownlengtharray
                piecesize = Marshal.SizeOf(typeof(short)) * knownlengtharray.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, knownlengtharray, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //unknownlengtharray
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (unknownlengtharray == null)
                unknownlengtharray = new short[arraylength];
            else
                Array.Resize(ref unknownlengtharray, arraylength);
// Start Xamla
                //unknownlengtharray
                piecesize = Marshal.SizeOf(typeof(short)) * unknownlengtharray.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, unknownlengtharray, 0, piecesize);
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
            
            //knownlengtharray
            hasmetacomponents |= false;
            if (knownlengtharray == null)
                knownlengtharray = new short[0];
// Start Xamla
                //knownlengtharray
                x__size = Marshal.SizeOf(typeof(short)) * knownlengtharray.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(knownlengtharray, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //unknownlengtharray
            hasmetacomponents |= false;
            if (unknownlengtharray == null)
                unknownlengtharray = new short[0];
            pieces.Add(BitConverter.GetBytes(unknownlengtharray.Length));
// Start Xamla
                //unknownlengtharray
                x__size = Marshal.SizeOf(typeof(short)) * unknownlengtharray.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(unknownlengtharray, 0, scratch1, 0, x__size);
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
            
            //knownlengtharray
            if (knownlengtharray == null)
                knownlengtharray = new short[3];
            else
                Array.Resize(ref knownlengtharray, 3);
            for (int i=0;i<knownlengtharray.Length; i++) {
                //knownlengtharray[i]
                knownlengtharray[i] = (System.Int16)rand.Next(System.Int16.MaxValue + 1);
            }
            //unknownlengtharray
            arraylength = rand.Next(10);
            if (unknownlengtharray == null)
                unknownlengtharray = new short[arraylength];
            else
                Array.Resize(ref unknownlengtharray, arraylength);
            for (int i=0;i<unknownlengtharray.Length; i++) {
                //unknownlengtharray[i]
                unknownlengtharray[i] = (System.Int16)rand.Next(System.Int16.MaxValue + 1);
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.custom_msgs.simpleintarray;
            if (other == null)
                return false;
            if (knownlengtharray.Length != other.knownlengtharray.Length)
                return false;
            for (int __i__=0; __i__ < knownlengtharray.Length; __i__++)
            {
                ret &= knownlengtharray[__i__] == other.knownlengtharray[__i__];
            }
            if (unknownlengtharray.Length != other.unknownlengtharray.Length)
                return false;
            for (int __i__=0; __i__ < unknownlengtharray.Length; __i__++)
            {
                ret &= unknownlengtharray[__i__] == other.unknownlengtharray[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
