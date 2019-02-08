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

namespace Messages.nav_msgs
{
    public class OccupancyGrid : RosMessage
    {

			public Header header = new Header();
			public Messages.nav_msgs.MapMetaData info = new Messages.nav_msgs.MapMetaData();
			public sbyte[] data;


        public override string MD5Sum() { return "3381f2d731d4076ec5c71b0759edbe4e"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
MapMetaData info
int8[] data"; }
        public override string MessageType { get { return "nav_msgs/OccupancyGrid"; } }
        public override bool IsServiceComponent() { return false; }

        public OccupancyGrid()
        {
            
        }

        public OccupancyGrid(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public OccupancyGrid(byte[] serializedMessage, ref int currentIndex)
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
            //info
            info = new Messages.nav_msgs.MapMetaData(serializedMessage, ref currentIndex);
            //data
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (data == null)
                data = new sbyte[arraylength];
            else
                Array.Resize(ref data, arraylength);
// Start Xamla
                //data
                piecesize = Marshal.SizeOf(typeof(sbyte)) * data.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, data, 0, piecesize);
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
            //info
            if (info == null)
                info = new Messages.nav_msgs.MapMetaData();
            pieces.Add(info.Serialize(true));
            //data
            hasmetacomponents |= false;
            if (data == null)
                data = new sbyte[0];
            pieces.Add(BitConverter.GetBytes(data.Length));
// Start Xamla
                //data
                x__size = Marshal.SizeOf(typeof(sbyte)) * data.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(data, 0, scratch1, 0, x__size);
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
            //info
            info = new Messages.nav_msgs.MapMetaData();
            info.Randomize();
            //data
            arraylength = rand.Next(10);
            if (data == null)
                data = new sbyte[arraylength];
            else
                Array.Resize(ref data, arraylength);
            for (int i=0;i<data.Length; i++) {
                //data[i]
                data[i] = (SByte)(rand.Next(255) - 127);
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.nav_msgs.OccupancyGrid;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= info.Equals(other.info);
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
