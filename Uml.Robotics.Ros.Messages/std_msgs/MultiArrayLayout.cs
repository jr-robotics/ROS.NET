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

namespace Messages.std_msgs
{
    public class MultiArrayLayout : RosMessage
    {

			public Messages.std_msgs.MultiArrayDimension[] dim;
			public uint data_offset;


        public override string MD5Sum() { return "0fed2a11c13e11c5571b4e2a995a91a3"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"MultiArrayDimension[] dim
uint32 data_offset"; }
        public override string MessageType { get { return "std_msgs/MultiArrayLayout"; } }
        public override bool IsServiceComponent() { return false; }

        public MultiArrayLayout()
        {
            
        }

        public MultiArrayLayout(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public MultiArrayLayout(byte[] serializedMessage, ref int currentIndex)
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
            
            //dim
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (dim == null)
                dim = new Messages.std_msgs.MultiArrayDimension[arraylength];
            else
                Array.Resize(ref dim, arraylength);
            for (int i=0;i<dim.Length; i++) {
                //dim[i]
                dim[i] = new Messages.std_msgs.MultiArrayDimension(serializedMessage, ref currentIndex);
            }
            //data_offset
            piecesize = Marshal.SizeOf(typeof(uint));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            data_offset = (uint)Marshal.PtrToStructure(h, typeof(uint));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
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
            
            //dim
            hasmetacomponents |= true;
            if (dim == null)
                dim = new Messages.std_msgs.MultiArrayDimension[0];
            pieces.Add(BitConverter.GetBytes(dim.Length));
            for (int i=0;i<dim.Length; i++) {
                //dim[i]
                if (dim[i] == null)
                    dim[i] = new Messages.std_msgs.MultiArrayDimension();
                pieces.Add(dim[i].Serialize(true));
            }
            //data_offset
            scratch1 = new byte[Marshal.SizeOf(typeof(uint))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(data_offset, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
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
            
            //dim
            arraylength = rand.Next(10);
            if (dim == null)
                dim = new Messages.std_msgs.MultiArrayDimension[arraylength];
            else
                Array.Resize(ref dim, arraylength);
            for (int i=0;i<dim.Length; i++) {
                //dim[i]
                dim[i] = new Messages.std_msgs.MultiArrayDimension();
                dim[i].Randomize();
            }
            //data_offset
            data_offset = (uint)rand.Next();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.std_msgs.MultiArrayLayout;
            if (other == null)
                return false;
            if (dim.Length != other.dim.Length)
                return false;
            for (int __i__=0; __i__ < dim.Length; __i__++)
            {
                ret &= dim[__i__].Equals(other.dim[__i__]);
            }
            ret &= data_offset == other.data_offset;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
