using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

using Uml.Robotics.Ros;
using Messages.actionlib_msgs;
using Messages.geometry_msgs;
using Messages.std_msgs;


namespace Messages.move_base_msgs
{
	[ActionGoalMessage]
        public class MoveBaseGoal : InnerActionMessage
    {
        			public Messages.geometry_msgs.PoseStamped target_pose = new Messages.geometry_msgs.PoseStamped();



        public override string MD5Sum() { return "257d089627d7eb7136c24d3593d05a16"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"geometry_msgs/PoseStamped target_pose"; }
		public override string MessageType { get { return "move_base_msgs/MoveBaseGoal"; } }
        public override bool IsServiceComponent() { return false; }

        public MoveBaseGoal()
        {
            
        }

        public MoveBaseGoal(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public MoveBaseGoal(byte[] serializedMessage, ref int currentIndex)
        {
            Deserialize(serializedMessage, ref currentIndex);
        }

        

        public void Deserialize(byte[] serializedMessage, int currentIndex)
        {
            Deserialize(serializedMessage, currentIndex);
        }

        public override void Deserialize(byte[] serializedMessage, ref int currentIndex)
        {
            int arraylength = -1;
            bool hasmetacomponents = false;
            object __thing;
            int piecesize = 0;
            byte[] thischunk, scratch1, scratch2;
            IntPtr h;

            
                //target_pose
                target_pose = new Messages.geometry_msgs.PoseStamped(serializedMessage, ref currentIndex);
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

            
                //target_pose
                if (target_pose == null)
                    target_pose = new Messages.geometry_msgs.PoseStamped();
                pieces.Add(target_pose.Serialize(true));

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

            
                //target_pose
                target_pose = new Messages.geometry_msgs.PoseStamped();
                target_pose.Randomize();
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            MoveBaseGoal other;
            try
            {
                other = (MoveBaseGoal)message;
            }
            catch
            {
                return false;
            }

            
                ret &= target_pose.Equals(other.target_pose);

            return ret;
        }
    }



    //$ACTION_GOAL_MESSAGE

	[ActionResultMessage]
        public class MoveBaseResult : InnerActionMessage
    {
        


        public override string MD5Sum() { return "d41d8cd98f00b204e9800998ecf8427e"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @""; }
		public override string MessageType { get { return "move_base_msgs/MoveBaseResult"; } }
        public override bool IsServiceComponent() { return false; }

        public MoveBaseResult()
        {
            
        }

        public MoveBaseResult(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public MoveBaseResult(byte[] serializedMessage, ref int currentIndex)
        {
            Deserialize(serializedMessage, ref currentIndex);
        }

        

        public void Deserialize(byte[] serializedMessage, int currentIndex)
        {
            Deserialize(serializedMessage, currentIndex);
        }

        public override void Deserialize(byte[] serializedMessage, ref int currentIndex)
        {
            int arraylength = -1;
            bool hasmetacomponents = false;
            object __thing;
            int piecesize = 0;
            byte[] thischunk, scratch1, scratch2;
            IntPtr h;

            
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

            
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            MoveBaseResult other;
            try
            {
                other = (MoveBaseResult)message;
            }
            catch
            {
                return false;
            }

            

            return ret;
        }
    }



    //$ACTION_RESULT_MESSAGE


	[ActionFeedbackMessage]
        public class MoveBaseFeedback : InnerActionMessage
    {
        			public Messages.geometry_msgs.PoseStamped base_position = new Messages.geometry_msgs.PoseStamped();



        public override string MD5Sum() { return "3fb824c456a757373a226f6d08071bf0"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"geometry_msgs/PoseStamped base_position"; }
		public override string MessageType { get { return "move_base_msgs/MoveBaseFeedback"; } }
        public override bool IsServiceComponent() { return false; }

        public MoveBaseFeedback()
        {
            
        }

        public MoveBaseFeedback(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public MoveBaseFeedback(byte[] serializedMessage, ref int currentIndex)
        {
            Deserialize(serializedMessage, ref currentIndex);
        }

        

        public void Deserialize(byte[] serializedMessage, int currentIndex)
        {
            Deserialize(serializedMessage, currentIndex);
        }

        public override void Deserialize(byte[] serializedMessage, ref int currentIndex)
        {
            int arraylength = -1;
            bool hasmetacomponents = false;
            object __thing;
            int piecesize = 0;
            byte[] thischunk, scratch1, scratch2;
            IntPtr h;

            
                //base_position
                base_position = new Messages.geometry_msgs.PoseStamped(serializedMessage, ref currentIndex);
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

            
                //base_position
                if (base_position == null)
                    base_position = new Messages.geometry_msgs.PoseStamped();
                pieces.Add(base_position.Serialize(true));

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

            
                //base_position
                base_position = new Messages.geometry_msgs.PoseStamped();
                base_position.Randomize();
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            MoveBaseFeedback other;
            try
            {
                other = (MoveBaseFeedback)message;
            }
            catch
            {
                return false;
            }

            
                ret &= base_position.Equals(other.base_position);

            return ret;
        }
    }



    //$ACTION_FEEDBACK_MESSAGE
}