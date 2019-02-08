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
        public class PointHeadGoal : InnerActionMessage
    {
        			public Messages.geometry_msgs.PointStamped target = new Messages.geometry_msgs.PointStamped();
			public Messages.geometry_msgs.Vector3 pointing_axis = new Messages.geometry_msgs.Vector3();
			public string pointing_frame = "";
			public Duration min_duration = new Duration();
			public double max_velocity;



        public override string MD5Sum() { return "8b92b1cd5e06c8a94c917dc3209a4c1d"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"geometry_msgs/PointStamped target
geometry_msgs/Vector3 pointing_axis
string pointing_frame
duration min_duration
float64 max_velocity"; }
		public override string MessageType { get { return "control_msgs/PointHeadGoal"; } }
        public override bool IsServiceComponent() { return false; }

        public PointHeadGoal()
        {
            
        }

        public PointHeadGoal(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PointHeadGoal(byte[] serializedMessage, ref int currentIndex)
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

            
                //target
                target = new Messages.geometry_msgs.PointStamped(serializedMessage, ref currentIndex);
                //pointing_axis
                pointing_axis = new Messages.geometry_msgs.Vector3(serializedMessage, ref currentIndex);
                //pointing_frame
                pointing_frame = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                pointing_frame = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //min_duration
                min_duration = new Duration(new TimeData(
                        BitConverter.ToInt32(serializedMessage, currentIndex),
                        BitConverter.ToInt32(serializedMessage, currentIndex+Marshal.SizeOf(typeof(System.Int32)))));
                currentIndex += 2*Marshal.SizeOf(typeof(System.Int32));
                //max_velocity
                piecesize = Marshal.SizeOf(typeof(double));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                max_velocity = (double)Marshal.PtrToStructure(h, typeof(double));
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

            
                //target
                if (target == null)
                    target = new Messages.geometry_msgs.PointStamped();
                pieces.Add(target.Serialize(true));
                //pointing_axis
                if (pointing_axis == null)
                    pointing_axis = new Messages.geometry_msgs.Vector3();
                pieces.Add(pointing_axis.Serialize(true));
                //pointing_frame
                if (pointing_frame == null)
                    pointing_frame = "";
                scratch1 = Encoding.ASCII.GetBytes((string)pointing_frame);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //min_duration
                pieces.Add(BitConverter.GetBytes(min_duration.data.sec));
                pieces.Add(BitConverter.GetBytes(min_duration.data.nsec));
                //max_velocity
                scratch1 = new byte[Marshal.SizeOf(typeof(double))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(max_velocity, h.AddrOfPinnedObject(), false);
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

            
                //target
                target = new Messages.geometry_msgs.PointStamped();
                target.Randomize();
                //pointing_axis
                pointing_axis = new Messages.geometry_msgs.Vector3();
                pointing_axis.Randomize();
                //pointing_frame
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                pointing_frame = Encoding.ASCII.GetString(strbuf);
                //min_duration
                min_duration = new Duration(new TimeData(
                        Convert.ToInt32(rand.Next()),
                        Convert.ToInt32(rand.Next())));
                //max_velocity
                max_velocity = (rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            PointHeadGoal other;
            try
            {
                other = (PointHeadGoal)message;
            }
            catch
            {
                return false;
            }

            
                ret &= target.Equals(other.target);
                ret &= pointing_axis.Equals(other.pointing_axis);
                ret &= pointing_frame == other.pointing_frame;
                ret &= min_duration.data.Equals(other.min_duration.data);
                ret &= max_velocity == other.max_velocity;

            return ret;
        }
    }



    //$ACTION_GOAL_MESSAGE

	[ActionResultMessage]
        public class PointHeadResult : InnerActionMessage
    {
        


        public override string MD5Sum() { return "d41d8cd98f00b204e9800998ecf8427e"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @""; }
		public override string MessageType { get { return "control_msgs/PointHeadResult"; } }
        public override bool IsServiceComponent() { return false; }

        public PointHeadResult()
        {
            
        }

        public PointHeadResult(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PointHeadResult(byte[] serializedMessage, ref int currentIndex)
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
            PointHeadResult other;
            try
            {
                other = (PointHeadResult)message;
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
        public class PointHeadFeedback : InnerActionMessage
    {
        			public double pointing_angle_error;



        public override string MD5Sum() { return "cce80d27fd763682da8805a73316cab4"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"float64 pointing_angle_error"; }
		public override string MessageType { get { return "control_msgs/PointHeadFeedback"; } }
        public override bool IsServiceComponent() { return false; }

        public PointHeadFeedback()
        {
            
        }

        public PointHeadFeedback(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PointHeadFeedback(byte[] serializedMessage, ref int currentIndex)
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

            
                //pointing_angle_error
                piecesize = Marshal.SizeOf(typeof(double));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                pointing_angle_error = (double)Marshal.PtrToStructure(h, typeof(double));
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

            
                //pointing_angle_error
                scratch1 = new byte[Marshal.SizeOf(typeof(double))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(pointing_angle_error, h.AddrOfPinnedObject(), false);
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

            
                //pointing_angle_error
                pointing_angle_error = (rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            PointHeadFeedback other;
            try
            {
                other = (PointHeadFeedback)message;
            }
            catch
            {
                return false;
            }

            
                ret &= pointing_angle_error == other.pointing_angle_error;

            return ret;
        }
    }



    //$ACTION_FEEDBACK_MESSAGE
}