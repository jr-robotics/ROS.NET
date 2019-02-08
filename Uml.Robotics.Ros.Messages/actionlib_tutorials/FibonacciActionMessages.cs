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
        public class FibonacciGoal : InnerActionMessage
    {
        			public int order;



        public override string MD5Sum() { return "6889063349a00b249bd1661df429d822"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"int32 order"; }
		public override string MessageType { get { return "actionlib_tutorials/FibonacciGoal"; } }
        public override bool IsServiceComponent() { return false; }

        public FibonacciGoal()
        {
            
        }

        public FibonacciGoal(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public FibonacciGoal(byte[] serializedMessage, ref int currentIndex)
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

            
                //order
                piecesize = Marshal.SizeOf(typeof(int));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                order = (int)Marshal.PtrToStructure(h, typeof(int));
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

            
                //order
                scratch1 = new byte[Marshal.SizeOf(typeof(int))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(order, h.AddrOfPinnedObject(), false);
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

            
                //order
                order = rand.Next();
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            FibonacciGoal other;
            try
            {
                other = (FibonacciGoal)message;
            }
            catch
            {
                return false;
            }

            
                ret &= order == other.order;

            return ret;
        }
    }



    //$ACTION_GOAL_MESSAGE

	[ActionResultMessage]
        public class FibonacciResult : InnerActionMessage
    {
        			public int[] sequence;



        public override string MD5Sum() { return "b81e37d2a31925a0e8ae261a8699cb79"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"int32[] sequence"; }
		public override string MessageType { get { return "actionlib_tutorials/FibonacciResult"; } }
        public override bool IsServiceComponent() { return false; }

        public FibonacciResult()
        {
            
        }

        public FibonacciResult(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public FibonacciResult(byte[] serializedMessage, ref int currentIndex)
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

            
                //sequence
                hasmetacomponents |= false;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (sequence == null)
                    sequence = new int[arraylength];
                else
                    Array.Resize(ref sequence, arraylength);
// Start Xamla
                    //sequence
                    piecesize = Marshal.SizeOf(typeof(int)) * sequence.Length;
                    if (currentIndex + piecesize > serializedMessage.Length) {
                        throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                    }
                    Buffer.BlockCopy(serializedMessage, currentIndex, sequence, 0, piecesize);
                    currentIndex += piecesize;
// End Xamla

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

            
                //sequence
                hasmetacomponents |= false;
                if (sequence == null)
                    sequence = new int[0];
                pieces.Add(BitConverter.GetBytes(sequence.Length));
// Start Xamla
                    //sequence
                    x__size = Marshal.SizeOf(typeof(int)) * sequence.Length;
                    scratch1 = new byte[x__size];
                    Buffer.BlockCopy(sequence, 0, scratch1, 0, x__size);
                    pieces.Add(scratch1);
// End Xamla


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

            
                //sequence
                arraylength = rand.Next(10);
                if (sequence == null)
                    sequence = new int[arraylength];
                else
                    Array.Resize(ref sequence, arraylength);
                for (int i=0;i<sequence.Length; i++) {
                    //sequence[i]
                    sequence[i] = rand.Next();
                }
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            FibonacciResult other;
            try
            {
                other = (FibonacciResult)message;
            }
            catch
            {
                return false;
            }

            
                if (sequence.Length != other.sequence.Length)
                    return false;
                for (int __i__=0; __i__ < sequence.Length; __i__++)
                {
                    ret &= sequence[__i__] == other.sequence[__i__];
                }

            return ret;
        }
    }



    //$ACTION_RESULT_MESSAGE


	[ActionFeedbackMessage]
        public class FibonacciFeedback : InnerActionMessage
    {
        			public int[] sequence;



        public override string MD5Sum() { return "b81e37d2a31925a0e8ae261a8699cb79"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"int32[] sequence"; }
		public override string MessageType { get { return "actionlib_tutorials/FibonacciFeedback"; } }
        public override bool IsServiceComponent() { return false; }

        public FibonacciFeedback()
        {
            
        }

        public FibonacciFeedback(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public FibonacciFeedback(byte[] serializedMessage, ref int currentIndex)
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

            
                //sequence
                hasmetacomponents |= false;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (sequence == null)
                    sequence = new int[arraylength];
                else
                    Array.Resize(ref sequence, arraylength);
// Start Xamla
                    //sequence
                    piecesize = Marshal.SizeOf(typeof(int)) * sequence.Length;
                    if (currentIndex + piecesize > serializedMessage.Length) {
                        throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                    }
                    Buffer.BlockCopy(serializedMessage, currentIndex, sequence, 0, piecesize);
                    currentIndex += piecesize;
// End Xamla

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

            
                //sequence
                hasmetacomponents |= false;
                if (sequence == null)
                    sequence = new int[0];
                pieces.Add(BitConverter.GetBytes(sequence.Length));
// Start Xamla
                    //sequence
                    x__size = Marshal.SizeOf(typeof(int)) * sequence.Length;
                    scratch1 = new byte[x__size];
                    Buffer.BlockCopy(sequence, 0, scratch1, 0, x__size);
                    pieces.Add(scratch1);
// End Xamla


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

            
                //sequence
                arraylength = rand.Next(10);
                if (sequence == null)
                    sequence = new int[arraylength];
                else
                    Array.Resize(ref sequence, arraylength);
                for (int i=0;i<sequence.Length; i++) {
                    //sequence[i]
                    sequence[i] = rand.Next();
                }
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            FibonacciFeedback other;
            try
            {
                other = (FibonacciFeedback)message;
            }
            catch
            {
                return false;
            }

            
                if (sequence.Length != other.sequence.Length)
                    return false;
                for (int __i__=0; __i__ < sequence.Length; __i__++)
                {
                    ret &= sequence[__i__] == other.sequence[__i__];
                }

            return ret;
        }
    }



    //$ACTION_FEEDBACK_MESSAGE
}