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
    public class arraytest : RosMessage
    {

			public int[] integers = new int[2];
			public int[] lengthlessintegers;
			public string teststring = "";
			public string[] teststringarray = new string[2];
			public string[] teststringarraylengthless;


        public override string MD5Sum() { return "82af8866e192a1899a24ce14a64ec82a"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"int32[2] integers
int32[] lengthlessintegers
string teststring
string[2] teststringarray
string[] teststringarraylengthless"; }
        public override string MessageType { get { return "custom_msgs/arraytest"; } }
        public override bool IsServiceComponent() { return false; }

        public arraytest()
        {
            
        }

        public arraytest(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public arraytest(byte[] serializedMessage, ref int currentIndex)
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
            
            //integers
            hasmetacomponents |= false;
            if (integers == null)
                integers = new int[2];
            else
                Array.Resize(ref integers, 2);
// Start Xamla
                //integers
                piecesize = Marshal.SizeOf(typeof(int)) * integers.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, integers, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //lengthlessintegers
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (lengthlessintegers == null)
                lengthlessintegers = new int[arraylength];
            else
                Array.Resize(ref lengthlessintegers, arraylength);
// Start Xamla
                //lengthlessintegers
                piecesize = Marshal.SizeOf(typeof(int)) * lengthlessintegers.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, lengthlessintegers, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //teststring
            teststring = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            teststring = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //teststringarray
            hasmetacomponents |= false;
            if (teststringarray == null)
                teststringarray = new string[2];
            else
                Array.Resize(ref teststringarray, 2);
            for (int i=0;i<teststringarray.Length; i++) {
                //teststringarray[i]
                teststringarray[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                teststringarray[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
            }
            //teststringarraylengthless
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (teststringarraylengthless == null)
                teststringarraylengthless = new string[arraylength];
            else
                Array.Resize(ref teststringarraylengthless, arraylength);
            for (int i=0;i<teststringarraylengthless.Length; i++) {
                //teststringarraylengthless[i]
                teststringarraylengthless[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                teststringarraylengthless[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
            }
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
            
            //integers
            hasmetacomponents |= false;
            if (integers == null)
                integers = new int[0];
// Start Xamla
                //integers
                x__size = Marshal.SizeOf(typeof(int)) * integers.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(integers, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //lengthlessintegers
            hasmetacomponents |= false;
            if (lengthlessintegers == null)
                lengthlessintegers = new int[0];
            pieces.Add(BitConverter.GetBytes(lengthlessintegers.Length));
// Start Xamla
                //lengthlessintegers
                x__size = Marshal.SizeOf(typeof(int)) * lengthlessintegers.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(lengthlessintegers, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //teststring
            if (teststring == null)
                teststring = "";
            scratch1 = Encoding.ASCII.GetBytes((string)teststring);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //teststringarray
            hasmetacomponents |= false;
            if (teststringarray == null)
                teststringarray = new string[0];
            for (int i=0;i<teststringarray.Length; i++) {
                //teststringarray[i]
                if (teststringarray[i] == null)
                    teststringarray[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)teststringarray[i]);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
            }
            //teststringarraylengthless
            hasmetacomponents |= false;
            if (teststringarraylengthless == null)
                teststringarraylengthless = new string[0];
            pieces.Add(BitConverter.GetBytes(teststringarraylengthless.Length));
            for (int i=0;i<teststringarraylengthless.Length; i++) {
                //teststringarraylengthless[i]
                if (teststringarraylengthless[i] == null)
                    teststringarraylengthless[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)teststringarraylengthless[i]);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
            }
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
            
            //integers
            if (integers == null)
                integers = new int[2];
            else
                Array.Resize(ref integers, 2);
            for (int i=0;i<integers.Length; i++) {
                //integers[i]
                integers[i] = rand.Next();
            }
            //lengthlessintegers
            arraylength = rand.Next(10);
            if (lengthlessintegers == null)
                lengthlessintegers = new int[arraylength];
            else
                Array.Resize(ref lengthlessintegers, arraylength);
            for (int i=0;i<lengthlessintegers.Length; i++) {
                //lengthlessintegers[i]
                lengthlessintegers[i] = rand.Next();
            }
            //teststring
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            teststring = Encoding.ASCII.GetString(strbuf);
            //teststringarray
            if (teststringarray == null)
                teststringarray = new string[2];
            else
                Array.Resize(ref teststringarray, 2);
            for (int i=0;i<teststringarray.Length; i++) {
                //teststringarray[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                teststringarray[i] = Encoding.ASCII.GetString(strbuf);
            }
            //teststringarraylengthless
            arraylength = rand.Next(10);
            if (teststringarraylengthless == null)
                teststringarraylengthless = new string[arraylength];
            else
                Array.Resize(ref teststringarraylengthless, arraylength);
            for (int i=0;i<teststringarraylengthless.Length; i++) {
                //teststringarraylengthless[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                teststringarraylengthless[i] = Encoding.ASCII.GetString(strbuf);
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.custom_msgs.arraytest;
            if (other == null)
                return false;
            if (integers.Length != other.integers.Length)
                return false;
            for (int __i__=0; __i__ < integers.Length; __i__++)
            {
                ret &= integers[__i__] == other.integers[__i__];
            }
            if (lengthlessintegers.Length != other.lengthlessintegers.Length)
                return false;
            for (int __i__=0; __i__ < lengthlessintegers.Length; __i__++)
            {
                ret &= lengthlessintegers[__i__] == other.lengthlessintegers[__i__];
            }
            ret &= teststring == other.teststring;
            if (teststringarray.Length != other.teststringarray.Length)
                return false;
            for (int __i__=0; __i__ < teststringarray.Length; __i__++)
            {
                ret &= teststringarray[__i__] == other.teststringarray[__i__];
            }
            if (teststringarraylengthless.Length != other.teststringarraylengthless.Length)
                return false;
            for (int __i__=0; __i__ < teststringarraylengthless.Length; __i__++)
            {
                ret &= teststringarraylengthless[__i__] == other.teststringarraylengthless[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
