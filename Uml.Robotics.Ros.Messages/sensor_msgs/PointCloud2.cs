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
    public class PointCloud2 : RosMessage
    {

			public Header header = new Header();
			public uint height;
			public uint width;
			public Messages.sensor_msgs.PointField[] fields;
			public bool    is_bigendian;
			public uint  point_step;
			public uint  row_step;
			public byte[] data;
			public bool is_dense;


        public override string MD5Sum() { return "1158d486dd51d683ce2f1be655c3c181"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
uint32 height
uint32 width
PointField[] fields
bool is_bigendian
uint32 point_step
uint32 row_step
uint8[] data
bool is_dense"; }
        public override string MessageType { get { return "sensor_msgs/PointCloud2"; } }
        public override bool IsServiceComponent() { return false; }

        public PointCloud2()
        {
            
        }

        public PointCloud2(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PointCloud2(byte[] serializedMessage, ref int currentIndex)
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
            //height
            piecesize = Marshal.SizeOf(typeof(uint));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            height = (uint)Marshal.PtrToStructure(h, typeof(uint));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //width
            piecesize = Marshal.SizeOf(typeof(uint));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            width = (uint)Marshal.PtrToStructure(h, typeof(uint));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //fields
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (fields == null)
                fields = new Messages.sensor_msgs.PointField[arraylength];
            else
                Array.Resize(ref fields, arraylength);
            for (int i=0;i<fields.Length; i++) {
                //fields[i]
                fields[i] = new Messages.sensor_msgs.PointField(serializedMessage, ref currentIndex);
            }
            //is_bigendian
            is_bigendian = serializedMessage[currentIndex++]==1;
            //point_step
            piecesize = Marshal.SizeOf(typeof(uint));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            point_step = (uint)Marshal.PtrToStructure(h, typeof(uint));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //row_step
            piecesize = Marshal.SizeOf(typeof(uint));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            row_step = (uint)Marshal.PtrToStructure(h, typeof(uint));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
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
            //is_dense
            is_dense = serializedMessage[currentIndex++]==1;
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
            //height
            scratch1 = new byte[Marshal.SizeOf(typeof(uint))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(height, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //width
            scratch1 = new byte[Marshal.SizeOf(typeof(uint))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(width, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //fields
            hasmetacomponents |= true;
            if (fields == null)
                fields = new Messages.sensor_msgs.PointField[0];
            pieces.Add(BitConverter.GetBytes(fields.Length));
            for (int i=0;i<fields.Length; i++) {
                //fields[i]
                if (fields[i] == null)
                    fields[i] = new Messages.sensor_msgs.PointField();
                pieces.Add(fields[i].Serialize(true));
            }
            //is_bigendian
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)is_bigendian ? 1 : 0 );
            pieces.Add(thischunk);
            //point_step
            scratch1 = new byte[Marshal.SizeOf(typeof(uint))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(point_step, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //row_step
            scratch1 = new byte[Marshal.SizeOf(typeof(uint))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(row_step, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //data
            hasmetacomponents |= false;
            if (data == null)
                data = new byte[0];
            pieces.Add(BitConverter.GetBytes(data.Length));
            pieces.Add((byte[])data);
            //is_dense
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)is_dense ? 1 : 0 );
            pieces.Add(thischunk);
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
            //height
            height = (uint)rand.Next();
            //width
            width = (uint)rand.Next();
            //fields
            arraylength = rand.Next(10);
            if (fields == null)
                fields = new Messages.sensor_msgs.PointField[arraylength];
            else
                Array.Resize(ref fields, arraylength);
            for (int i=0;i<fields.Length; i++) {
                //fields[i]
                fields[i] = new Messages.sensor_msgs.PointField();
                fields[i].Randomize();
            }
            //is_bigendian
            is_bigendian = rand.Next(2) == 1;
            //point_step
            point_step = (uint)rand.Next();
            //row_step
            row_step = (uint)rand.Next();
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
            //is_dense
            is_dense = rand.Next(2) == 1;
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.sensor_msgs.PointCloud2;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= height == other.height;
            ret &= width == other.width;
            if (fields.Length != other.fields.Length)
                return false;
            for (int __i__=0; __i__ < fields.Length; __i__++)
            {
                ret &= fields[__i__].Equals(other.fields[__i__]);
            }
            ret &= is_bigendian == other.is_bigendian;
            ret &= point_step == other.point_step;
            ret &= row_step == other.row_step;
            if (data.Length != other.data.Length)
                return false;
            for (int __i__=0; __i__ < data.Length; __i__++)
            {
                ret &= data[__i__] == other.data[__i__];
            }
            ret &= is_dense == other.is_dense;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
