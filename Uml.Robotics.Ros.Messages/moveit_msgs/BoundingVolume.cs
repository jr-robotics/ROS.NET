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
    public class BoundingVolume : RosMessage
    {

			public Messages.shape_msgs.SolidPrimitive[] primitives;
			public Messages.geometry_msgs.Pose[] primitive_poses;
			public Messages.shape_msgs.Mesh[] meshes;
			public Messages.geometry_msgs.Pose[] mesh_poses;


        public override string MD5Sum() { return "22db94010f39e9198032cb4a1aeda26e"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"shape_msgs/SolidPrimitive[] primitives
geometry_msgs/Pose[] primitive_poses
shape_msgs/Mesh[] meshes
geometry_msgs/Pose[] mesh_poses"; }
        public override string MessageType { get { return "moveit_msgs/BoundingVolume"; } }
        public override bool IsServiceComponent() { return false; }

        public BoundingVolume()
        {
            
        }

        public BoundingVolume(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public BoundingVolume(byte[] serializedMessage, ref int currentIndex)
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
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.BoundingVolume;
            if (other == null)
                return false;
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
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
