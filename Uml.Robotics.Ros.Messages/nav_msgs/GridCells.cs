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
    public class GridCells : RosMessage
    {

			public Header header = new Header();
			public Single cell_width;
			public Single cell_height;
			public Messages.geometry_msgs.Point[] cells;


        public override string MD5Sum() { return "b9e4f5df6d28e272ebde00a3994830f5"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
float32 cell_width
float32 cell_height
geometry_msgs/Point[] cells"; }
        public override string MessageType { get { return "nav_msgs/GridCells"; } }
        public override bool IsServiceComponent() { return false; }

        public GridCells()
        {
            
        }

        public GridCells(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public GridCells(byte[] serializedMessage, ref int currentIndex)
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
            //cell_width
            piecesize = Marshal.SizeOf(typeof(Single));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            cell_width = (Single)Marshal.PtrToStructure(h, typeof(Single));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //cell_height
            piecesize = Marshal.SizeOf(typeof(Single));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            cell_height = (Single)Marshal.PtrToStructure(h, typeof(Single));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //cells
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (cells == null)
                cells = new Messages.geometry_msgs.Point[arraylength];
            else
                Array.Resize(ref cells, arraylength);
            for (int i=0;i<cells.Length; i++) {
                //cells[i]
                cells[i] = new Messages.geometry_msgs.Point(serializedMessage, ref currentIndex);
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
            
            //header
            if (header == null)
                header = new Header();
            pieces.Add(header.Serialize(true));
            //cell_width
            scratch1 = new byte[Marshal.SizeOf(typeof(Single))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(cell_width, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //cell_height
            scratch1 = new byte[Marshal.SizeOf(typeof(Single))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(cell_height, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //cells
            hasmetacomponents |= true;
            if (cells == null)
                cells = new Messages.geometry_msgs.Point[0];
            pieces.Add(BitConverter.GetBytes(cells.Length));
            for (int i=0;i<cells.Length; i++) {
                //cells[i]
                if (cells[i] == null)
                    cells[i] = new Messages.geometry_msgs.Point();
                pieces.Add(cells[i].Serialize(true));
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
            
            //header
            header = new Header();
            header.Randomize();
            //cell_width
            cell_width = (float)(rand.Next() + rand.NextDouble());
            //cell_height
            cell_height = (float)(rand.Next() + rand.NextDouble());
            //cells
            arraylength = rand.Next(10);
            if (cells == null)
                cells = new Messages.geometry_msgs.Point[arraylength];
            else
                Array.Resize(ref cells, arraylength);
            for (int i=0;i<cells.Length; i++) {
                //cells[i]
                cells[i] = new Messages.geometry_msgs.Point();
                cells[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.nav_msgs.GridCells;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= cell_width == other.cell_width;
            ret &= cell_height == other.cell_height;
            if (cells.Length != other.cells.Length)
                return false;
            for (int __i__=0; __i__ < cells.Length; __i__++)
            {
                ret &= cells[__i__].Equals(other.cells[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
