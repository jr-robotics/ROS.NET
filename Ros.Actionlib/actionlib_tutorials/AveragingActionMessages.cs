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


namespace Messages.actionlib_tutorials
{
	[ActionGoalMessage]
        public class AveragingGoal : InnerActionMessage
    {
        			public int samples;



        public override string MD5Sum() { return "32c9b10ef9b253faa93b93f564762c8f"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"int32 samples"; }
		public override string MessageType { get { return "actionlib_tutorials/AveragingGoal"; } }
        public override bool IsServiceComponent() { return false; }

        public AveragingGoal()
        {
            
        }

        public AveragingGoal(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public AveragingGoal(byte[] serializedMessage, ref int currentIndex)
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

            
                //samples
                piecesize = Marshal.SizeOf(typeof(int));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                samples = (int)Marshal.PtrToStructure(h, typeof(int));
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

            
                //samples
                scratch1 = new byte[Marshal.SizeOf(typeof(int))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(samples, h.AddrOfPinnedObject(), false);
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

            
                //samples
                samples = rand.Next();
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            AveragingGoal other;
            try
            {
                other = (AveragingGoal)message;
            }
            catch
            {
                return false;
            }

            
                ret &= samples == other.samples;

            return ret;
        }
    }



    //$ACTION_GOAL_MESSAGE

	[ActionResultMessage]
        public class AveragingResult : InnerActionMessage
    {
        			public Single mean;
			public Single std_dev;



        public override string MD5Sum() { return "d5c7decf6df75ffb4367a05c1bcc7612"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"float32 mean
float32 std_dev"; }
		public override string MessageType { get { return "actionlib_tutorials/AveragingResult"; } }
        public override bool IsServiceComponent() { return false; }

        public AveragingResult()
        {
            
        }

        public AveragingResult(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public AveragingResult(byte[] serializedMessage, ref int currentIndex)
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

            
                //mean
                piecesize = Marshal.SizeOf(typeof(Single));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                mean = (Single)Marshal.PtrToStructure(h, typeof(Single));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //std_dev
                piecesize = Marshal.SizeOf(typeof(Single));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                std_dev = (Single)Marshal.PtrToStructure(h, typeof(Single));
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

            
                //mean
                scratch1 = new byte[Marshal.SizeOf(typeof(Single))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(mean, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //std_dev
                scratch1 = new byte[Marshal.SizeOf(typeof(Single))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(std_dev, h.AddrOfPinnedObject(), false);
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

            
                //mean
                mean = (float)(rand.Next() + rand.NextDouble());
                //std_dev
                std_dev = (float)(rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            AveragingResult other;
            try
            {
                other = (AveragingResult)message;
            }
            catch
            {
                return false;
            }

            
                ret &= mean == other.mean;
                ret &= std_dev == other.std_dev;

            return ret;
        }
    }



    //$ACTION_RESULT_MESSAGE


	[ActionFeedbackMessage]
        public class AveragingFeedback : InnerActionMessage
    {
        			public int sample;
			public Single data;
			public Single mean;
			public Single std_dev;



        public override string MD5Sum() { return "9e8dfc53c2f2a032ca33fa80ec46fd4f"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"int32 sample
float32 data
float32 mean
float32 std_dev"; }
		public override string MessageType { get { return "actionlib_tutorials/AveragingFeedback"; } }
        public override bool IsServiceComponent() { return false; }

        public AveragingFeedback()
        {
            
        }

        public AveragingFeedback(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public AveragingFeedback(byte[] serializedMessage, ref int currentIndex)
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

            
                //sample
                piecesize = Marshal.SizeOf(typeof(int));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                sample = (int)Marshal.PtrToStructure(h, typeof(int));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //data
                piecesize = Marshal.SizeOf(typeof(Single));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                data = (Single)Marshal.PtrToStructure(h, typeof(Single));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //mean
                piecesize = Marshal.SizeOf(typeof(Single));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                mean = (Single)Marshal.PtrToStructure(h, typeof(Single));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //std_dev
                piecesize = Marshal.SizeOf(typeof(Single));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                std_dev = (Single)Marshal.PtrToStructure(h, typeof(Single));
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

            
                //sample
                scratch1 = new byte[Marshal.SizeOf(typeof(int))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(sample, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //data
                scratch1 = new byte[Marshal.SizeOf(typeof(Single))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(data, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //mean
                scratch1 = new byte[Marshal.SizeOf(typeof(Single))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(mean, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //std_dev
                scratch1 = new byte[Marshal.SizeOf(typeof(Single))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(std_dev, h.AddrOfPinnedObject(), false);
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

            
                //sample
                sample = rand.Next();
                //data
                data = (float)(rand.Next() + rand.NextDouble());
                //mean
                mean = (float)(rand.Next() + rand.NextDouble());
                //std_dev
                std_dev = (float)(rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            AveragingFeedback other;
            try
            {
                other = (AveragingFeedback)message;
            }
            catch
            {
                return false;
            }

            
                ret &= sample == other.sample;
                ret &= data == other.data;
                ret &= mean == other.mean;
                ret &= std_dev == other.std_dev;

            return ret;
        }
    }



    //$ACTION_FEEDBACK_MESSAGE
}