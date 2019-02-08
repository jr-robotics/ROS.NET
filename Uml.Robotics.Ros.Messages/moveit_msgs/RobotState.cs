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
    public class RobotState : RosMessage
    {

			public Messages.sensor_msgs.JointState joint_state = new Messages.sensor_msgs.JointState();
			public Messages.sensor_msgs.MultiDOFJointState multi_dof_joint_state = new Messages.sensor_msgs.MultiDOFJointState();
			public Messages.moveit_msgs.AttachedCollisionObject[] attached_collision_objects;
			public bool is_diff;


        public override string MD5Sum() { return "217a2e8e5547f4162b13a37db9cb4da4"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"sensor_msgs/JointState joint_state
sensor_msgs/MultiDOFJointState multi_dof_joint_state
AttachedCollisionObject[] attached_collision_objects
bool is_diff"; }
        public override string MessageType { get { return "moveit_msgs/RobotState"; } }
        public override bool IsServiceComponent() { return false; }

        public RobotState()
        {
            
        }

        public RobotState(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public RobotState(byte[] serializedMessage, ref int currentIndex)
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
            
            //joint_state
            joint_state = new Messages.sensor_msgs.JointState(serializedMessage, ref currentIndex);
            //multi_dof_joint_state
            multi_dof_joint_state = new Messages.sensor_msgs.MultiDOFJointState(serializedMessage, ref currentIndex);
            //attached_collision_objects
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (attached_collision_objects == null)
                attached_collision_objects = new Messages.moveit_msgs.AttachedCollisionObject[arraylength];
            else
                Array.Resize(ref attached_collision_objects, arraylength);
            for (int i=0;i<attached_collision_objects.Length; i++) {
                //attached_collision_objects[i]
                attached_collision_objects[i] = new Messages.moveit_msgs.AttachedCollisionObject(serializedMessage, ref currentIndex);
            }
            //is_diff
            is_diff = serializedMessage[currentIndex++]==1;
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
            
            //joint_state
            if (joint_state == null)
                joint_state = new Messages.sensor_msgs.JointState();
            pieces.Add(joint_state.Serialize(true));
            //multi_dof_joint_state
            if (multi_dof_joint_state == null)
                multi_dof_joint_state = new Messages.sensor_msgs.MultiDOFJointState();
            pieces.Add(multi_dof_joint_state.Serialize(true));
            //attached_collision_objects
            hasmetacomponents |= true;
            if (attached_collision_objects == null)
                attached_collision_objects = new Messages.moveit_msgs.AttachedCollisionObject[0];
            pieces.Add(BitConverter.GetBytes(attached_collision_objects.Length));
            for (int i=0;i<attached_collision_objects.Length; i++) {
                //attached_collision_objects[i]
                if (attached_collision_objects[i] == null)
                    attached_collision_objects[i] = new Messages.moveit_msgs.AttachedCollisionObject();
                pieces.Add(attached_collision_objects[i].Serialize(true));
            }
            //is_diff
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)is_diff ? 1 : 0 );
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
            
            //joint_state
            joint_state = new Messages.sensor_msgs.JointState();
            joint_state.Randomize();
            //multi_dof_joint_state
            multi_dof_joint_state = new Messages.sensor_msgs.MultiDOFJointState();
            multi_dof_joint_state.Randomize();
            //attached_collision_objects
            arraylength = rand.Next(10);
            if (attached_collision_objects == null)
                attached_collision_objects = new Messages.moveit_msgs.AttachedCollisionObject[arraylength];
            else
                Array.Resize(ref attached_collision_objects, arraylength);
            for (int i=0;i<attached_collision_objects.Length; i++) {
                //attached_collision_objects[i]
                attached_collision_objects[i] = new Messages.moveit_msgs.AttachedCollisionObject();
                attached_collision_objects[i].Randomize();
            }
            //is_diff
            is_diff = rand.Next(2) == 1;
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.RobotState;
            if (other == null)
                return false;
            ret &= joint_state.Equals(other.joint_state);
            ret &= multi_dof_joint_state.Equals(other.multi_dof_joint_state);
            if (attached_collision_objects.Length != other.attached_collision_objects.Length)
                return false;
            for (int __i__=0; __i__ < attached_collision_objects.Length; __i__++)
            {
                ret &= attached_collision_objects[__i__].Equals(other.attached_collision_objects[__i__]);
            }
            ret &= is_diff == other.is_diff;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
