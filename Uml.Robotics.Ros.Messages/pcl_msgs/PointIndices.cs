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

namespace Messages.pcl_msgs
{
    public class PointIndices : RosMessage
    {

			public Header header = new Header();
			public int[] indices;


        public override string MD5Sum() { return "458c7998b7eaf99908256472e273b3d4"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
int32[] indices"; }
        public override string MessageType { get { return "pcl_msgs/PointIndices"; } }
        public override bool IsServiceComponent() { return false; }

        public PointIndices()
        {
            
        }

        public PointIndices(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PointIndices(byte[] serializedMessage, ref int currentIndex)
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
            //indices
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (indices == null)
                indices = new int[arraylength];
            else
                Array.Resize(ref indices, arraylength);
// Start Xamla
                //indices
                piecesize = Marshal.SizeOf(typeof(int)) * indices.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, indices, 0, piecesize);
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
            //indices
            hasmetacomponents |= false;
            if (indices == null)
                indices = new int[0];
            pieces.Add(BitConverter.GetBytes(indices.Length));
// Start Xamla
                //indices
                x__size = Marshal.SizeOf(typeof(int)) * indices.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(indices, 0, scratch1, 0, x__size);
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
            //indices
            arraylength = rand.Next(10);
            if (indices == null)
                indices = new int[arraylength];
            else
                Array.Resize(ref indices, arraylength);
            for (int i=0;i<indices.Length; i++) {
                //indices[i]
                indices[i] = rand.Next();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.pcl_msgs.PointIndices;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            if (indices.Length != other.indices.Length)
                return false;
            for (int __i__=0; __i__ < indices.Length; __i__++)
            {
                ret &= indices[__i__] == other.indices[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
