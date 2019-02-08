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


namespace Messages.control_msgs
{
	[ActionGoalMessage]
        public class GripperCommandGoal : InnerActionMessage
    {
        			public Messages.control_msgs.GripperCommand command = new Messages.control_msgs.GripperCommand();



        public override string MD5Sum() { return "86fd82f4ddc48a4cb6856cfa69217e43"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"GripperCommand command"; }
		public override string MessageType { get { return "control_msgs/GripperCommandGoal"; } }
        public override bool IsServiceComponent() { return false; }

        public GripperCommandGoal()
        {
            
        }

        public GripperCommandGoal(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public GripperCommandGoal(byte[] serializedMessage, ref int currentIndex)
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

            
                //command
                command = new Messages.control_msgs.GripperCommand(serializedMessage, ref currentIndex);
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

            
                //command
                if (command == null)
                    command = new Messages.control_msgs.GripperCommand();
                pieces.Add(command.Serialize(true));

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

            
                //command
                command = new Messages.control_msgs.GripperCommand();
                command.Randomize();
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            GripperCommandGoal other;
            try
            {
                other = (GripperCommandGoal)message;
            }
            catch
            {
                return false;
            }

            
                ret &= command.Equals(other.command);

            return ret;
        }
    }



    //$ACTION_GOAL_MESSAGE

	[ActionResultMessage]
        public class GripperCommandResult : InnerActionMessage
    {
        			public double position;
			public double effort;
			public bool stalled;
			public bool reached_goal;



        public override string MD5Sum() { return "e4cbff56d3562bcf113da5a5adeef91f"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"float64 position
float64 effort
bool stalled
bool reached_goal"; }
		public override string MessageType { get { return "control_msgs/GripperCommandResult"; } }
        public override bool IsServiceComponent() { return false; }

        public GripperCommandResult()
        {
            
        }

        public GripperCommandResult(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public GripperCommandResult(byte[] serializedMessage, ref int currentIndex)
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

            
                //position
                piecesize = Marshal.SizeOf(typeof(double));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                position = (double)Marshal.PtrToStructure(h, typeof(double));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //effort
                piecesize = Marshal.SizeOf(typeof(double));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                effort = (double)Marshal.PtrToStructure(h, typeof(double));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //stalled
                stalled = serializedMessage[currentIndex++]==1;
                //reached_goal
                reached_goal = serializedMessage[currentIndex++]==1;
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

            
                //position
                scratch1 = new byte[Marshal.SizeOf(typeof(double))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(position, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //effort
                scratch1 = new byte[Marshal.SizeOf(typeof(double))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(effort, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //stalled
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)stalled ? 1 : 0 );
                pieces.Add(thischunk);
                //reached_goal
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)reached_goal ? 1 : 0 );
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

            
                //position
                position = (rand.Next() + rand.NextDouble());
                //effort
                effort = (rand.Next() + rand.NextDouble());
                //stalled
                stalled = rand.Next(2) == 1;
                //reached_goal
                reached_goal = rand.Next(2) == 1;
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            GripperCommandResult other;
            try
            {
                other = (GripperCommandResult)message;
            }
            catch
            {
                return false;
            }

            
                ret &= position == other.position;
                ret &= effort == other.effort;
                ret &= stalled == other.stalled;
                ret &= reached_goal == other.reached_goal;

            return ret;
        }
    }



    //$ACTION_RESULT_MESSAGE


	[ActionFeedbackMessage]
        public class GripperCommandFeedback : InnerActionMessage
    {
        			public double position;
			public double effort;
			public bool stalled;
			public bool reached_goal;



        public override string MD5Sum() { return "e4cbff56d3562bcf113da5a5adeef91f"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"float64 position
float64 effort
bool stalled
bool reached_goal"; }
		public override string MessageType { get { return "control_msgs/GripperCommandFeedback"; } }
        public override bool IsServiceComponent() { return false; }

        public GripperCommandFeedback()
        {
            
        }

        public GripperCommandFeedback(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public GripperCommandFeedback(byte[] serializedMessage, ref int currentIndex)
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

            
                //position
                piecesize = Marshal.SizeOf(typeof(double));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                position = (double)Marshal.PtrToStructure(h, typeof(double));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //effort
                piecesize = Marshal.SizeOf(typeof(double));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                effort = (double)Marshal.PtrToStructure(h, typeof(double));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //stalled
                stalled = serializedMessage[currentIndex++]==1;
                //reached_goal
                reached_goal = serializedMessage[currentIndex++]==1;
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

            
                //position
                scratch1 = new byte[Marshal.SizeOf(typeof(double))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(position, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //effort
                scratch1 = new byte[Marshal.SizeOf(typeof(double))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(effort, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //stalled
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)stalled ? 1 : 0 );
                pieces.Add(thischunk);
                //reached_goal
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)reached_goal ? 1 : 0 );
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

            
                //position
                position = (rand.Next() + rand.NextDouble());
                //effort
                effort = (rand.Next() + rand.NextDouble());
                //stalled
                stalled = rand.Next(2) == 1;
                //reached_goal
                reached_goal = rand.Next(2) == 1;
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            GripperCommandFeedback other;
            try
            {
                other = (GripperCommandFeedback)message;
            }
            catch
            {
                return false;
            }

            
                ret &= position == other.position;
                ret &= effort == other.effort;
                ret &= stalled == other.stalled;
                ret &= reached_goal == other.reached_goal;

            return ret;
        }
    }



    //$ACTION_FEEDBACK_MESSAGE
}