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
    public class RobotTrajectory : RosMessage
    {

			public Messages.trajectory_msgs.JointTrajectory joint_trajectory = new Messages.trajectory_msgs.JointTrajectory();
			public Messages.trajectory_msgs.MultiDOFJointTrajectory multi_dof_joint_trajectory = new Messages.trajectory_msgs.MultiDOFJointTrajectory();


        public override string MD5Sum() { return "dfa9556423d709a3729bcef664bddf67"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"trajectory_msgs/JointTrajectory joint_trajectory
trajectory_msgs/MultiDOFJointTrajectory multi_dof_joint_trajectory"; }
        public override string MessageType { get { return "moveit_msgs/RobotTrajectory"; } }
        public override bool IsServiceComponent() { return false; }

        public RobotTrajectory()
        {
            
        }

        public RobotTrajectory(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public RobotTrajectory(byte[] serializedMessage, ref int currentIndex)
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
            
            //joint_trajectory
            joint_trajectory = new Messages.trajectory_msgs.JointTrajectory(serializedMessage, ref currentIndex);
            //multi_dof_joint_trajectory
            multi_dof_joint_trajectory = new Messages.trajectory_msgs.MultiDOFJointTrajectory(serializedMessage, ref currentIndex);
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
            
            //joint_trajectory
            if (joint_trajectory == null)
                joint_trajectory = new Messages.trajectory_msgs.JointTrajectory();
            pieces.Add(joint_trajectory.Serialize(true));
            //multi_dof_joint_trajectory
            if (multi_dof_joint_trajectory == null)
                multi_dof_joint_trajectory = new Messages.trajectory_msgs.MultiDOFJointTrajectory();
            pieces.Add(multi_dof_joint_trajectory.Serialize(true));
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
            
            //joint_trajectory
            joint_trajectory = new Messages.trajectory_msgs.JointTrajectory();
            joint_trajectory.Randomize();
            //multi_dof_joint_trajectory
            multi_dof_joint_trajectory = new Messages.trajectory_msgs.MultiDOFJointTrajectory();
            multi_dof_joint_trajectory.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.RobotTrajectory;
            if (other == null)
                return false;
            ret &= joint_trajectory.Equals(other.joint_trajectory);
            ret &= multi_dof_joint_trajectory.Equals(other.multi_dof_joint_trajectory);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
