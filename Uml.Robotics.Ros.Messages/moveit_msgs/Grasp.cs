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
    public class Grasp : RosMessage
    {

			public string id = "";
			public Messages.trajectory_msgs.JointTrajectory pre_grasp_posture = new Messages.trajectory_msgs.JointTrajectory();
			public Messages.trajectory_msgs.JointTrajectory grasp_posture = new Messages.trajectory_msgs.JointTrajectory();
			public Messages.geometry_msgs.PoseStamped grasp_pose = new Messages.geometry_msgs.PoseStamped();
			public double grasp_quality;
			public Messages.moveit_msgs.GripperTranslation pre_grasp_approach = new Messages.moveit_msgs.GripperTranslation();
			public Messages.moveit_msgs.GripperTranslation post_grasp_retreat = new Messages.moveit_msgs.GripperTranslation();
			public Messages.moveit_msgs.GripperTranslation post_place_retreat = new Messages.moveit_msgs.GripperTranslation();
			public Single max_contact_force;
			public string[] allowed_touch_objects;


        public override string MD5Sum() { return "e26c8fb64f589c33c5d5e54bd7b5e4cb"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"string id
trajectory_msgs/JointTrajectory pre_grasp_posture
trajectory_msgs/JointTrajectory grasp_posture
geometry_msgs/PoseStamped grasp_pose
float64 grasp_quality
GripperTranslation pre_grasp_approach
GripperTranslation post_grasp_retreat
GripperTranslation post_place_retreat
float32 max_contact_force
string[] allowed_touch_objects"; }
        public override string MessageType { get { return "moveit_msgs/Grasp"; } }
        public override bool IsServiceComponent() { return false; }

        public Grasp()
        {
            
        }

        public Grasp(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public Grasp(byte[] serializedMessage, ref int currentIndex)
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
            
            //id
            id = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            id = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //pre_grasp_posture
            pre_grasp_posture = new Messages.trajectory_msgs.JointTrajectory(serializedMessage, ref currentIndex);
            //grasp_posture
            grasp_posture = new Messages.trajectory_msgs.JointTrajectory(serializedMessage, ref currentIndex);
            //grasp_pose
            grasp_pose = new Messages.geometry_msgs.PoseStamped(serializedMessage, ref currentIndex);
            //grasp_quality
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            grasp_quality = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //pre_grasp_approach
            pre_grasp_approach = new Messages.moveit_msgs.GripperTranslation(serializedMessage, ref currentIndex);
            //post_grasp_retreat
            post_grasp_retreat = new Messages.moveit_msgs.GripperTranslation(serializedMessage, ref currentIndex);
            //post_place_retreat
            post_place_retreat = new Messages.moveit_msgs.GripperTranslation(serializedMessage, ref currentIndex);
            //max_contact_force
            piecesize = Marshal.SizeOf(typeof(Single));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            max_contact_force = (Single)Marshal.PtrToStructure(h, typeof(Single));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //allowed_touch_objects
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (allowed_touch_objects == null)
                allowed_touch_objects = new string[arraylength];
            else
                Array.Resize(ref allowed_touch_objects, arraylength);
            for (int i=0;i<allowed_touch_objects.Length; i++) {
                //allowed_touch_objects[i]
                allowed_touch_objects[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                allowed_touch_objects[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
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
            
            //id
            if (id == null)
                id = "";
            scratch1 = Encoding.ASCII.GetBytes((string)id);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //pre_grasp_posture
            if (pre_grasp_posture == null)
                pre_grasp_posture = new Messages.trajectory_msgs.JointTrajectory();
            pieces.Add(pre_grasp_posture.Serialize(true));
            //grasp_posture
            if (grasp_posture == null)
                grasp_posture = new Messages.trajectory_msgs.JointTrajectory();
            pieces.Add(grasp_posture.Serialize(true));
            //grasp_pose
            if (grasp_pose == null)
                grasp_pose = new Messages.geometry_msgs.PoseStamped();
            pieces.Add(grasp_pose.Serialize(true));
            //grasp_quality
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(grasp_quality, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //pre_grasp_approach
            if (pre_grasp_approach == null)
                pre_grasp_approach = new Messages.moveit_msgs.GripperTranslation();
            pieces.Add(pre_grasp_approach.Serialize(true));
            //post_grasp_retreat
            if (post_grasp_retreat == null)
                post_grasp_retreat = new Messages.moveit_msgs.GripperTranslation();
            pieces.Add(post_grasp_retreat.Serialize(true));
            //post_place_retreat
            if (post_place_retreat == null)
                post_place_retreat = new Messages.moveit_msgs.GripperTranslation();
            pieces.Add(post_place_retreat.Serialize(true));
            //max_contact_force
            scratch1 = new byte[Marshal.SizeOf(typeof(Single))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(max_contact_force, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //allowed_touch_objects
            hasmetacomponents |= false;
            if (allowed_touch_objects == null)
                allowed_touch_objects = new string[0];
            pieces.Add(BitConverter.GetBytes(allowed_touch_objects.Length));
            for (int i=0;i<allowed_touch_objects.Length; i++) {
                //allowed_touch_objects[i]
                if (allowed_touch_objects[i] == null)
                    allowed_touch_objects[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)allowed_touch_objects[i]);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
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
            
            //id
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            id = Encoding.ASCII.GetString(strbuf);
            //pre_grasp_posture
            pre_grasp_posture = new Messages.trajectory_msgs.JointTrajectory();
            pre_grasp_posture.Randomize();
            //grasp_posture
            grasp_posture = new Messages.trajectory_msgs.JointTrajectory();
            grasp_posture.Randomize();
            //grasp_pose
            grasp_pose = new Messages.geometry_msgs.PoseStamped();
            grasp_pose.Randomize();
            //grasp_quality
            grasp_quality = (rand.Next() + rand.NextDouble());
            //pre_grasp_approach
            pre_grasp_approach = new Messages.moveit_msgs.GripperTranslation();
            pre_grasp_approach.Randomize();
            //post_grasp_retreat
            post_grasp_retreat = new Messages.moveit_msgs.GripperTranslation();
            post_grasp_retreat.Randomize();
            //post_place_retreat
            post_place_retreat = new Messages.moveit_msgs.GripperTranslation();
            post_place_retreat.Randomize();
            //max_contact_force
            max_contact_force = (float)(rand.Next() + rand.NextDouble());
            //allowed_touch_objects
            arraylength = rand.Next(10);
            if (allowed_touch_objects == null)
                allowed_touch_objects = new string[arraylength];
            else
                Array.Resize(ref allowed_touch_objects, arraylength);
            for (int i=0;i<allowed_touch_objects.Length; i++) {
                //allowed_touch_objects[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                allowed_touch_objects[i] = Encoding.ASCII.GetString(strbuf);
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.Grasp;
            if (other == null)
                return false;
            ret &= id == other.id;
            ret &= pre_grasp_posture.Equals(other.pre_grasp_posture);
            ret &= grasp_posture.Equals(other.grasp_posture);
            ret &= grasp_pose.Equals(other.grasp_pose);
            ret &= grasp_quality == other.grasp_quality;
            ret &= pre_grasp_approach.Equals(other.pre_grasp_approach);
            ret &= post_grasp_retreat.Equals(other.post_grasp_retreat);
            ret &= post_place_retreat.Equals(other.post_place_retreat);
            ret &= max_contact_force == other.max_contact_force;
            if (allowed_touch_objects.Length != other.allowed_touch_objects.Length)
                return false;
            for (int __i__=0; __i__ < allowed_touch_objects.Length; __i__++)
            {
                ret &= allowed_touch_objects[__i__] == other.allowed_touch_objects[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
