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
    public class Mesh : RosMessage
    {

			public Messages.shape_msgs.MeshTriangle[] triangles;
			public Messages.geometry_msgs.Point[] vertices;


        public override string MD5Sum() { return "1ffdae9486cd3316a121c578b47a85cc"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"MeshTriangle[] triangles
geometry_msgs/Point[] vertices"; }
        public override string MessageType { get { return "shape_msgs/Mesh"; } }
        public override bool IsServiceComponent() { return false; }

        public Mesh()
        {
            
        }

        public Mesh(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public Mesh(byte[] serializedMessage, ref int currentIndex)
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
            
            //triangles
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (triangles == null)
                triangles = new Messages.shape_msgs.MeshTriangle[arraylength];
            else
                Array.Resize(ref triangles, arraylength);
            for (int i=0;i<triangles.Length; i++) {
                //triangles[i]
                triangles[i] = new Messages.shape_msgs.MeshTriangle(serializedMessage, ref currentIndex);
            }
            //vertices
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (vertices == null)
                vertices = new Messages.geometry_msgs.Point[arraylength];
            else
                Array.Resize(ref vertices, arraylength);
            for (int i=0;i<vertices.Length; i++) {
                //vertices[i]
                vertices[i] = new Messages.geometry_msgs.Point(serializedMessage, ref currentIndex);
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
            
            //triangles
            hasmetacomponents |= true;
            if (triangles == null)
                triangles = new Messages.shape_msgs.MeshTriangle[0];
            pieces.Add(BitConverter.GetBytes(triangles.Length));
            for (int i=0;i<triangles.Length; i++) {
                //triangles[i]
                if (triangles[i] == null)
                    triangles[i] = new Messages.shape_msgs.MeshTriangle();
                pieces.Add(triangles[i].Serialize(true));
            }
            //vertices
            hasmetacomponents |= true;
            if (vertices == null)
                vertices = new Messages.geometry_msgs.Point[0];
            pieces.Add(BitConverter.GetBytes(vertices.Length));
            for (int i=0;i<vertices.Length; i++) {
                //vertices[i]
                if (vertices[i] == null)
                    vertices[i] = new Messages.geometry_msgs.Point();
                pieces.Add(vertices[i].Serialize(true));
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
            
            //triangles
            arraylength = rand.Next(10);
            if (triangles == null)
                triangles = new Messages.shape_msgs.MeshTriangle[arraylength];
            else
                Array.Resize(ref triangles, arraylength);
            for (int i=0;i<triangles.Length; i++) {
                //triangles[i]
                triangles[i] = new Messages.shape_msgs.MeshTriangle();
                triangles[i].Randomize();
            }
            //vertices
            arraylength = rand.Next(10);
            if (vertices == null)
                vertices = new Messages.geometry_msgs.Point[arraylength];
            else
                Array.Resize(ref vertices, arraylength);
            for (int i=0;i<vertices.Length; i++) {
                //vertices[i]
                vertices[i] = new Messages.geometry_msgs.Point();
                vertices[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.shape_msgs.Mesh;
            if (other == null)
                return false;
            if (triangles.Length != other.triangles.Length)
                return false;
            for (int __i__=0; __i__ < triangles.Length; __i__++)
            {
                ret &= triangles[__i__].Equals(other.triangles[__i__]);
            }
            if (vertices.Length != other.vertices.Length)
                return false;
            for (int __i__=0; __i__ < vertices.Length; __i__++)
            {
                ret &= vertices[__i__].Equals(other.vertices[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
