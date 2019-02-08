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

namespace Messages.shape_msgs
{
    public class MeshTriangle : RosMessage
    {

			public uint[] vertex_indices = new uint[3];


        public override string MD5Sum() { return "23688b2e6d2de3d32fe8af104a903253"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"uint32[3] vertex_indices"; }
        public override string MessageType { get { return "shape_msgs/MeshTriangle"; } }
        public override bool IsServiceComponent() { return false; }

        public MeshTriangle()
        {
            
        }

        public MeshTriangle(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public MeshTriangle(byte[] serializedMessage, ref int currentIndex)
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
            
            //vertex_indices
            hasmetacomponents |= false;
            if (vertex_indices == null)
                vertex_indices = new uint[3];
            else
                Array.Resize(ref vertex_indices, 3);
// Start Xamla
                //vertex_indices
                piecesize = Marshal.SizeOf(typeof(uint)) * vertex_indices.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, vertex_indices, 0, piecesize);
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
            
            //vertex_indices
            hasmetacomponents |= false;
            if (vertex_indices == null)
                vertex_indices = new uint[0];
// Start Xamla
                //vertex_indices
                x__size = Marshal.SizeOf(typeof(uint)) * vertex_indices.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(vertex_indices, 0, scratch1, 0, x__size);
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
            
            //vertex_indices
            if (vertex_indices == null)
                vertex_indices = new uint[3];
            else
                Array.Resize(ref vertex_indices, 3);
            for (int i=0;i<vertex_indices.Length; i++) {
                //vertex_indices[i]
                vertex_indices[i] = (uint)rand.Next();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.shape_msgs.MeshTriangle;
            if (other == null)
                return false;
            if (vertex_indices.Length != other.vertex_indices.Length)
                return false;
            for (int __i__=0; __i__ < vertex_indices.Length; __i__++)
            {
                ret &= vertex_indices[__i__] == other.vertex_indices[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
