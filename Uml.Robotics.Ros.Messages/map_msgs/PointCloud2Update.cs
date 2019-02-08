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

namespace Messages.map_msgs
{
    public class PointCloud2Update : RosMessage
    {

			public const uint ADD = 0U;
			public const uint DELETE = 1U;
			public Header header = new Header();
			public uint type;
			public Messages.sensor_msgs.PointCloud2 points = new Messages.sensor_msgs.PointCloud2();


        public override string MD5Sum() { return "6c58e4f249ae9cd2b24fb1ee0f99195e"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"uint32 ADD=0
uint32 DELETE=1
Header header
uint32 type
sensor_msgs/PointCloud2 points"; }
        public override string MessageType { get { return "map_msgs/PointCloud2Update"; } }
        public override bool IsServiceComponent() { return false; }

        public PointCloud2Update()
        {
            
        }

        public PointCloud2Update(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PointCloud2Update(byte[] serializedMessage, ref int currentIndex)
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
            //type
            piecesize = Marshal.SizeOf(typeof(uint));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            type = (uint)Marshal.PtrToStructure(h, typeof(uint));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //points
            points = new Messages.sensor_msgs.PointCloud2(serializedMessage, ref currentIndex);
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
            //type
            scratch1 = new byte[Marshal.SizeOf(typeof(uint))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(type, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //points
            if (points == null)
                points = new Messages.sensor_msgs.PointCloud2();
            pieces.Add(points.Serialize(true));
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
            //type
            type = (uint)rand.Next();
            //points
            points = new Messages.sensor_msgs.PointCloud2();
            points.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.map_msgs.PointCloud2Update;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= type == other.type;
            ret &= points.Equals(other.points);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
