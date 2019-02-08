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


namespace Messages.humanoid_nav_msgs
{
	[ActionGoalMessage]
        public class ExecFootstepsGoal : InnerActionMessage
    {
        			public Messages.humanoid_nav_msgs.StepTarget[] footsteps;
			public double feedback_frequency;



        public override string MD5Sum() { return "40a3f8092ef3bb49c3253baa6eb94932"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"humanoid_nav_msgs/StepTarget[] footsteps
float64 feedback_frequency"; }
		public override string MessageType { get { return "humanoid_nav_msgs/ExecFootstepsGoal"; } }
        public override bool IsServiceComponent() { return false; }

        public ExecFootstepsGoal()
        {
            
        }

        public ExecFootstepsGoal(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public ExecFootstepsGoal(byte[] serializedMessage, ref int currentIndex)
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

            
                //footsteps
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (footsteps == null)
                    footsteps = new Messages.humanoid_nav_msgs.StepTarget[arraylength];
                else
                    Array.Resize(ref footsteps, arraylength);
                for (int i=0;i<footsteps.Length; i++) {
                    //footsteps[i]
                    footsteps[i] = new Messages.humanoid_nav_msgs.StepTarget(serializedMessage, ref currentIndex);
                }
                //feedback_frequency
                piecesize = Marshal.SizeOf(typeof(double));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                feedback_frequency = (double)Marshal.PtrToStructure(h, typeof(double));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
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

            
                //footsteps
                hasmetacomponents |= true;
                if (footsteps == null)
                    footsteps = new Messages.humanoid_nav_msgs.StepTarget[0];
                pieces.Add(BitConverter.GetBytes(footsteps.Length));
                for (int i=0;i<footsteps.Length; i++) {
                    //footsteps[i]
                    if (footsteps[i] == null)
                        footsteps[i] = new Messages.humanoid_nav_msgs.StepTarget();
                    pieces.Add(footsteps[i].Serialize(true));
                }
                //feedback_frequency
                scratch1 = new byte[Marshal.SizeOf(typeof(double))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(feedback_frequency, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);

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

            
                //footsteps
                arraylength = rand.Next(10);
                if (footsteps == null)
                    footsteps = new Messages.humanoid_nav_msgs.StepTarget[arraylength];
                else
                    Array.Resize(ref footsteps, arraylength);
                for (int i=0;i<footsteps.Length; i++) {
                    //footsteps[i]
                    footsteps[i] = new Messages.humanoid_nav_msgs.StepTarget();
                    footsteps[i].Randomize();
                }
                //feedback_frequency
                feedback_frequency = (rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            ExecFootstepsGoal other;
            try
            {
                other = (ExecFootstepsGoal)message;
            }
            catch
            {
                return false;
            }

            
                if (footsteps.Length != other.footsteps.Length)
                    return false;
                for (int __i__=0; __i__ < footsteps.Length; __i__++)
                {
                    ret &= footsteps[__i__].Equals(other.footsteps[__i__]);
                }
                ret &= feedback_frequency == other.feedback_frequency;

            return ret;
        }
    }



    //$ACTION_GOAL_MESSAGE

	[ActionResultMessage]
        public class ExecFootstepsResult : InnerActionMessage
    {
        			public Messages.humanoid_nav_msgs.StepTarget[] executed_footsteps;



        public override string MD5Sum() { return "5dfde2cb244d6c76567d3c52c40a988c"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"humanoid_nav_msgs/StepTarget[] executed_footsteps"; }
		public override string MessageType { get { return "humanoid_nav_msgs/ExecFootstepsResult"; } }
        public override bool IsServiceComponent() { return false; }

        public ExecFootstepsResult()
        {
            
        }

        public ExecFootstepsResult(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public ExecFootstepsResult(byte[] serializedMessage, ref int currentIndex)
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

            
                //executed_footsteps
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (executed_footsteps == null)
                    executed_footsteps = new Messages.humanoid_nav_msgs.StepTarget[arraylength];
                else
                    Array.Resize(ref executed_footsteps, arraylength);
                for (int i=0;i<executed_footsteps.Length; i++) {
                    //executed_footsteps[i]
                    executed_footsteps[i] = new Messages.humanoid_nav_msgs.StepTarget(serializedMessage, ref currentIndex);
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

            
                //executed_footsteps
                hasmetacomponents |= true;
                if (executed_footsteps == null)
                    executed_footsteps = new Messages.humanoid_nav_msgs.StepTarget[0];
                pieces.Add(BitConverter.GetBytes(executed_footsteps.Length));
                for (int i=0;i<executed_footsteps.Length; i++) {
                    //executed_footsteps[i]
                    if (executed_footsteps[i] == null)
                        executed_footsteps[i] = new Messages.humanoid_nav_msgs.StepTarget();
                    pieces.Add(executed_footsteps[i].Serialize(true));
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

            
                //executed_footsteps
                arraylength = rand.Next(10);
                if (executed_footsteps == null)
                    executed_footsteps = new Messages.humanoid_nav_msgs.StepTarget[arraylength];
                else
                    Array.Resize(ref executed_footsteps, arraylength);
                for (int i=0;i<executed_footsteps.Length; i++) {
                    //executed_footsteps[i]
                    executed_footsteps[i] = new Messages.humanoid_nav_msgs.StepTarget();
                    executed_footsteps[i].Randomize();
                }
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            ExecFootstepsResult other;
            try
            {
                other = (ExecFootstepsResult)message;
            }
            catch
            {
                return false;
            }

            
                if (executed_footsteps.Length != other.executed_footsteps.Length)
                    return false;
                for (int __i__=0; __i__ < executed_footsteps.Length; __i__++)
                {
                    ret &= executed_footsteps[__i__].Equals(other.executed_footsteps[__i__]);
                }

            return ret;
        }
    }



    //$ACTION_RESULT_MESSAGE


	[ActionFeedbackMessage]
        public class ExecFootstepsFeedback : InnerActionMessage
    {
        			public Messages.humanoid_nav_msgs.StepTarget[] executed_footsteps;



        public override string MD5Sum() { return "5dfde2cb244d6c76567d3c52c40a988c"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"humanoid_nav_msgs/StepTarget[] executed_footsteps"; }
		public override string MessageType { get { return "humanoid_nav_msgs/ExecFootstepsFeedback"; } }
        public override bool IsServiceComponent() { return false; }

        public ExecFootstepsFeedback()
        {
            
        }

        public ExecFootstepsFeedback(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public ExecFootstepsFeedback(byte[] serializedMessage, ref int currentIndex)
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

            
                //executed_footsteps
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (executed_footsteps == null)
                    executed_footsteps = new Messages.humanoid_nav_msgs.StepTarget[arraylength];
                else
                    Array.Resize(ref executed_footsteps, arraylength);
                for (int i=0;i<executed_footsteps.Length; i++) {
                    //executed_footsteps[i]
                    executed_footsteps[i] = new Messages.humanoid_nav_msgs.StepTarget(serializedMessage, ref currentIndex);
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

            
                //executed_footsteps
                hasmetacomponents |= true;
                if (executed_footsteps == null)
                    executed_footsteps = new Messages.humanoid_nav_msgs.StepTarget[0];
                pieces.Add(BitConverter.GetBytes(executed_footsteps.Length));
                for (int i=0;i<executed_footsteps.Length; i++) {
                    //executed_footsteps[i]
                    if (executed_footsteps[i] == null)
                        executed_footsteps[i] = new Messages.humanoid_nav_msgs.StepTarget();
                    pieces.Add(executed_footsteps[i].Serialize(true));
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

            
                //executed_footsteps
                arraylength = rand.Next(10);
                if (executed_footsteps == null)
                    executed_footsteps = new Messages.humanoid_nav_msgs.StepTarget[arraylength];
                else
                    Array.Resize(ref executed_footsteps, arraylength);
                for (int i=0;i<executed_footsteps.Length; i++) {
                    //executed_footsteps[i]
                    executed_footsteps[i] = new Messages.humanoid_nav_msgs.StepTarget();
                    executed_footsteps[i].Randomize();
                }
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            ExecFootstepsFeedback other;
            try
            {
                other = (ExecFootstepsFeedback)message;
            }
            catch
            {
                return false;
            }

            
                if (executed_footsteps.Length != other.executed_footsteps.Length)
                    return false;
                for (int __i__=0; __i__ < executed_footsteps.Length; __i__++)
                {
                    ret &= executed_footsteps[__i__].Equals(other.executed_footsteps[__i__]);
                }

            return ret;
        }
    }



    //$ACTION_FEEDBACK_MESSAGE
}