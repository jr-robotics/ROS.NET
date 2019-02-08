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
    public class CompressedImage : RosMessage
    {

			public Header header = new Header();
			public string format = "";
			public byte[] data;


        public override string MD5Sum() { return "8f7a12909da2c9d3332d540a0977563f"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
string format
uint8[] data"; }
        public override string MessageType { get { return "sensor_msgs/CompressedImage"; } }
        public override bool IsServiceComponent() { return false; }

        public CompressedImage()
        {
            
        }

        public CompressedImage(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public CompressedImage(byte[] serializedMessage, ref int currentIndex)
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
            //format
            format = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            format = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //data
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (data == null)
                data = new byte[arraylength];
            else
                Array.Resize(ref data, arraylength);
            Array.Copy(serializedMessage, currentIndex, data, 0, data.Length);
            currentIndex += data.Length;
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
            //format
            if (format == null)
                format = "";
            scratch1 = Encoding.ASCII.GetBytes((string)format);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //data
            hasmetacomponents |= false;
            if (data == null)
                data = new byte[0];
            pieces.Add(BitConverter.GetBytes(data.Length));
            pieces.Add((byte[])data);
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
            //format
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            format = Encoding.ASCII.GetString(strbuf);
            //data
            arraylength = rand.Next(10);
            if (data == null)
                data = new byte[arraylength];
            else
                Array.Resize(ref data, arraylength);
            for (int i=0;i<data.Length; i++) {
                //data[i]
                myByte = new byte[1];
                rand.NextBytes(myByte);
                data[i]= myByte[0];
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.sensor_msgs.CompressedImage;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= format == other.format;
            if (data.Length != other.data.Length)
                return false;
            for (int __i__=0; __i__ < data.Length; __i__++)
            {
                ret &= data[__i__] == other.data[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
