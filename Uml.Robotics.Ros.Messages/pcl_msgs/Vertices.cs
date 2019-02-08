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
    public class Vertices : RosMessage
    {

			public uint[] vertices;


        public override string MD5Sum() { return "39bd7b1c23763ddd1b882b97cb7cfe11"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"uint32[] vertices"; }
        public override string MessageType { get { return "pcl_msgs/Vertices"; } }
        public override bool IsServiceComponent() { return false; }

        public Vertices()
        {
            
        }

        public Vertices(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public Vertices(byte[] serializedMessage, ref int currentIndex)
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
            
            //vertices
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (vertices == null)
                vertices = new uint[arraylength];
            else
                Array.Resize(ref vertices, arraylength);
// Start Xamla
                //vertices
                piecesize = Marshal.SizeOf(typeof(uint)) * vertices.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, vertices, 0, piecesize);
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
            
            //vertices
            hasmetacomponents |= false;
            if (vertices == null)
                vertices = new uint[0];
            pieces.Add(BitConverter.GetBytes(vertices.Length));
// Start Xamla
                //vertices
                x__size = Marshal.SizeOf(typeof(uint)) * vertices.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(vertices, 0, scratch1, 0, x__size);
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
            
            //vertices
            arraylength = rand.Next(10);
            if (vertices == null)
                vertices = new uint[arraylength];
            else
                Array.Resize(ref vertices, arraylength);
            for (int i=0;i<vertices.Length; i++) {
                //vertices[i]
                vertices[i] = (uint)rand.Next();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.pcl_msgs.Vertices;
            if (other == null)
                return false;
            if (vertices.Length != other.vertices.Length)
                return false;
            for (int __i__=0; __i__ < vertices.Length; __i__++)
            {
                ret &= vertices[__i__] == other.vertices[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
