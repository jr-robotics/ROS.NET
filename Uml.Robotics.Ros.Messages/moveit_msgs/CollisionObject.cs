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

namespace Messages.moveit_msgs
{
    public class CollisionObject : RosMessage
    {

			public Header header = new Header();
			public string id = "";
			public Messages.object_recognition_msgs.ObjectType type = new Messages.object_recognition_msgs.ObjectType();
			public Messages.shape_msgs.SolidPrimitive[] primitives;
			public Messages.geometry_msgs.Pose[] primitive_poses;
			public Messages.shape_msgs.Mesh[] meshes;
			public Messages.geometry_msgs.Pose[] mesh_poses;
			public Messages.shape_msgs.Plane[] planes;
			public Messages.geometry_msgs.Pose[] plane_poses;
			public const byte ADD = 0;
			public const byte REMOVE = 1;
			public const byte APPEND = 2;
			public const byte MOVE = 3;
			public byte operation;


        public override string MD5Sum() { return "568a161b26dc46c54a5a07621ce82cf3"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
string id
object_recognition_msgs/ObjectType type
shape_msgs/SolidPrimitive[] primitives
geometry_msgs/Pose[] primitive_poses
shape_msgs/Mesh[] meshes
geometry_msgs/Pose[] mesh_poses
shape_msgs/Plane[] planes
geometry_msgs/Pose[] plane_poses
byte ADD=0
byte REMOVE=1
byte APPEND=2
byte MOVE=3
byte operation"; }
        public override string MessageType { get { return "moveit_msgs/CollisionObject"; } }
        public override bool IsServiceComponent() { return false; }

        public CollisionObject()
        {
            
        }

        public CollisionObject(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public CollisionObject(byte[] serializedMessage, ref int currentIndex)
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
            //id
            id = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            id = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //type
            type = new Messages.object_recognition_msgs.ObjectType(serializedMessage, ref currentIndex);
            //primitives
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (primitives == null)
                primitives = new Messages.shape_msgs.SolidPrimitive[arraylength];
            else
                Array.Resize(ref primitives, arraylength);
            for (int i=0;i<primitives.Length; i++) {
                //primitives[i]
                primitives[i] = new Messages.shape_msgs.SolidPrimitive(serializedMessage, ref currentIndex);
            }
            //primitive_poses
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (primitive_poses == null)
                primitive_poses = new Messages.geometry_msgs.Pose[arraylength];
            else
                Array.Resize(ref primitive_poses, arraylength);
            for (int i=0;i<primitive_poses.Length; i++) {
                //primitive_poses[i]
                primitive_poses[i] = new Messages.geometry_msgs.Pose(serializedMessage, ref currentIndex);
            }
            //meshes
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (meshes == null)
                meshes = new Messages.shape_msgs.Mesh[arraylength];
            else
                Array.Resize(ref meshes, arraylength);
            for (int i=0;i<meshes.Length; i++) {
                //meshes[i]
                meshes[i] = new Messages.shape_msgs.Mesh(serializedMessage, ref currentIndex);
            }
            //mesh_poses
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (mesh_poses == null)
                mesh_poses = new Messages.geometry_msgs.Pose[arraylength];
            else
                Array.Resize(ref mesh_poses, arraylength);
            for (int i=0;i<mesh_poses.Length; i++) {
                //mesh_poses[i]
                mesh_poses[i] = new Messages.geometry_msgs.Pose(serializedMessage, ref currentIndex);
            }
            //planes
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (planes == null)
                planes = new Messages.shape_msgs.Plane[arraylength];
            else
                Array.Resize(ref planes, arraylength);
            for (int i=0;i<planes.Length; i++) {
                //planes[i]
                planes[i] = new Messages.shape_msgs.Plane(serializedMessage, ref currentIndex);
            }
            //plane_poses
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (plane_poses == null)
                plane_poses = new Messages.geometry_msgs.Pose[arraylength];
            else
                Array.Resize(ref plane_poses, arraylength);
            for (int i=0;i<plane_poses.Length; i++) {
                //plane_poses[i]
                plane_poses[i] = new Messages.geometry_msgs.Pose(serializedMessage, ref currentIndex);
            }
            //operation
            operation=serializedMessage[currentIndex++];
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
            //id
            if (id == null)
                id = "";
            scratch1 = Encoding.ASCII.GetBytes((string)id);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //type
            if (type == null)
                type = new Messages.object_recognition_msgs.ObjectType();
            pieces.Add(type.Serialize(true));
            //primitives
            hasmetacomponents |= true;
            if (primitives == null)
                primitives = new Messages.shape_msgs.SolidPrimitive[0];
            pieces.Add(BitConverter.GetBytes(primitives.Length));
            for (int i=0;i<primitives.Length; i++) {
                //primitives[i]
                if (primitives[i] == null)
                    primitives[i] = new Messages.shape_msgs.SolidPrimitive();
                pieces.Add(primitives[i].Serialize(true));
            }
            //primitive_poses
            hasmetacomponents |= true;
            if (primitive_poses == null)
                primitive_poses = new Messages.geometry_msgs.Pose[0];
            pieces.Add(BitConverter.GetBytes(primitive_poses.Length));
            for (int i=0;i<primitive_poses.Length; i++) {
                //primitive_poses[i]
                if (primitive_poses[i] == null)
                    primitive_poses[i] = new Messages.geometry_msgs.Pose();
                pieces.Add(primitive_poses[i].Serialize(true));
            }
            //meshes
            hasmetacomponents |= true;
            if (meshes == null)
                meshes = new Messages.shape_msgs.Mesh[0];
            pieces.Add(BitConverter.GetBytes(meshes.Length));
            for (int i=0;i<meshes.Length; i++) {
                //meshes[i]
                if (meshes[i] == null)
                    meshes[i] = new Messages.shape_msgs.Mesh();
                pieces.Add(meshes[i].Serialize(true));
            }
            //mesh_poses
            hasmetacomponents |= true;
            if (mesh_poses == null)
                mesh_poses = new Messages.geometry_msgs.Pose[0];
            pieces.Add(BitConverter.GetBytes(mesh_poses.Length));
            for (int i=0;i<mesh_poses.Length; i++) {
                //mesh_poses[i]
                if (mesh_poses[i] == null)
                    mesh_poses[i] = new Messages.geometry_msgs.Pose();
                pieces.Add(mesh_poses[i].Serialize(true));
            }
            //planes
            hasmetacomponents |= true;
            if (planes == null)
                planes = new Messages.shape_msgs.Plane[0];
            pieces.Add(BitConverter.GetBytes(planes.Length));
            for (int i=0;i<planes.Length; i++) {
                //planes[i]
                if (planes[i] == null)
                    planes[i] = new Messages.shape_msgs.Plane();
                pieces.Add(planes[i].Serialize(true));
            }
            //plane_poses
            hasmetacomponents |= true;
            if (plane_poses == null)
                plane_poses = new Messages.geometry_msgs.Pose[0];
            pieces.Add(BitConverter.GetBytes(plane_poses.Length));
            for (int i=0;i<plane_poses.Length; i++) {
                //plane_poses[i]
                if (plane_poses[i] == null)
                    plane_poses[i] = new Messages.geometry_msgs.Pose();
                pieces.Add(plane_poses[i].Serialize(true));
            }
            //operation
            pieces.Add(new[] { (byte)operation });
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
            //id
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            id = Encoding.ASCII.GetString(strbuf);
            //type
            type = new Messages.object_recognition_msgs.ObjectType();
            type.Randomize();
            //primitives
            arraylength = rand.Next(10);
            if (primitives == null)
                primitives = new Messages.shape_msgs.SolidPrimitive[arraylength];
            else
                Array.Resize(ref primitives, arraylength);
            for (int i=0;i<primitives.Length; i++) {
                //primitives[i]
                primitives[i] = new Messages.shape_msgs.SolidPrimitive();
                primitives[i].Randomize();
            }
            //primitive_poses
            arraylength = rand.Next(10);
            if (primitive_poses == null)
                primitive_poses = new Messages.geometry_msgs.Pose[arraylength];
            else
                Array.Resize(ref primitive_poses, arraylength);
            for (int i=0;i<primitive_poses.Length; i++) {
                //primitive_poses[i]
                primitive_poses[i] = new Messages.geometry_msgs.Pose();
                primitive_poses[i].Randomize();
            }
            //meshes
            arraylength = rand.Next(10);
            if (meshes == null)
                meshes = new Messages.shape_msgs.Mesh[arraylength];
            else
                Array.Resize(ref meshes, arraylength);
            for (int i=0;i<meshes.Length; i++) {
                //meshes[i]
                meshes[i] = new Messages.shape_msgs.Mesh();
                meshes[i].Randomize();
            }
            //mesh_poses
            arraylength = rand.Next(10);
            if (mesh_poses == null)
                mesh_poses = new Messages.geometry_msgs.Pose[arraylength];
            else
                Array.Resize(ref mesh_poses, arraylength);
            for (int i=0;i<mesh_poses.Length; i++) {
                //mesh_poses[i]
                mesh_poses[i] = new Messages.geometry_msgs.Pose();
                mesh_poses[i].Randomize();
            }
            //planes
            arraylength = rand.Next(10);
            if (planes == null)
                planes = new Messages.shape_msgs.Plane[arraylength];
            else
                Array.Resize(ref planes, arraylength);
            for (int i=0;i<planes.Length; i++) {
                //planes[i]
                planes[i] = new Messages.shape_msgs.Plane();
                planes[i].Randomize();
            }
            //plane_poses
            arraylength = rand.Next(10);
            if (plane_poses == null)
                plane_poses = new Messages.geometry_msgs.Pose[arraylength];
            else
                Array.Resize(ref plane_poses, arraylength);
            for (int i=0;i<plane_poses.Length; i++) {
                //plane_poses[i]
                plane_poses[i] = new Messages.geometry_msgs.Pose();
                plane_poses[i].Randomize();
            }
            //operation
            myByte = new byte[1];
            rand.NextBytes(myByte);
            operation= myByte[0];
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.CollisionObject;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= id == other.id;
            ret &= type.Equals(other.type);
            if (primitives.Length != other.primitives.Length)
                return false;
            for (int __i__=0; __i__ < primitives.Length; __i__++)
            {
                ret &= primitives[__i__].Equals(other.primitives[__i__]);
            }
            if (primitive_poses.Length != other.primitive_poses.Length)
                return false;
            for (int __i__=0; __i__ < primitive_poses.Length; __i__++)
            {
                ret &= primitive_poses[__i__].Equals(other.primitive_poses[__i__]);
            }
            if (meshes.Length != other.meshes.Length)
                return false;
            for (int __i__=0; __i__ < meshes.Length; __i__++)
            {
                ret &= meshes[__i__].Equals(other.meshes[__i__]);
            }
            if (mesh_poses.Length != other.mesh_poses.Length)
                return false;
            for (int __i__=0; __i__ < mesh_poses.Length; __i__++)
            {
                ret &= mesh_poses[__i__].Equals(other.mesh_poses[__i__]);
            }
            if (planes.Length != other.planes.Length)
                return false;
            for (int __i__=0; __i__ < planes.Length; __i__++)
            {
                ret &= planes[__i__].Equals(other.planes[__i__]);
            }
            if (plane_poses.Length != other.plane_poses.Length)
                return false;
            for (int __i__=0; __i__ < plane_poses.Length; __i__++)
            {
                ret &= plane_poses[__i__].Equals(other.plane_poses[__i__]);
            }
            ret &= operation == other.operation;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
