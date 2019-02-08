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


namespace Messages.actionlib
{
	[ActionGoalMessage]
        public class TestRequestGoal : InnerActionMessage
    {
        			public const int TERMINATE_SUCCESS = 0;
			public const int TERMINATE_ABORTED = 1;
			public const int TERMINATE_REJECTED = 2;
			public const int TERMINATE_LOSE = 3;
			public const int TERMINATE_DROP = 4;
			public const int TERMINATE_EXCEPTION = 5;
			public int terminate_status;
			public bool ignore_cancel;
			public string result_text = "";
			public int the_result;
			public bool is_simple_client;
			public Duration delay_accept = new Duration();
			public Duration delay_terminate = new Duration();
			public Duration pause_status = new Duration();



        public override string MD5Sum() { return "db5d00ba98302d6c6dd3737e9a03ceea"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"int32 TERMINATE_SUCCESS = 0
int32 TERMINATE_ABORTED = 1
int32 TERMINATE_REJECTED = 2
int32 TERMINATE_LOSE = 3
int32 TERMINATE_DROP = 4
int32 TERMINATE_EXCEPTION = 5
int32 terminate_status
bool ignore_cancel
string result_text
int32 the_result
bool is_simple_client
duration delay_accept
duration delay_terminate
duration pause_status"; }
		public override string MessageType { get { return "actionlib/TestRequestGoal"; } }
        public override bool IsServiceComponent() { return false; }

        public TestRequestGoal()
        {
            
        }

        public TestRequestGoal(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public TestRequestGoal(byte[] serializedMessage, ref int currentIndex)
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

            
                //terminate_status
                piecesize = Marshal.SizeOf(typeof(int));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                terminate_status = (int)Marshal.PtrToStructure(h, typeof(int));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //ignore_cancel
                ignore_cancel = serializedMessage[currentIndex++]==1;
                //result_text
                result_text = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                result_text = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //the_result
                piecesize = Marshal.SizeOf(typeof(int));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                the_result = (int)Marshal.PtrToStructure(h, typeof(int));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //is_simple_client
                is_simple_client = serializedMessage[currentIndex++]==1;
                //delay_accept
                delay_accept = new Duration(new TimeData(
                        BitConverter.ToInt32(serializedMessage, currentIndex),
                        BitConverter.ToInt32(serializedMessage, currentIndex+Marshal.SizeOf(typeof(System.Int32)))));
                currentIndex += 2*Marshal.SizeOf(typeof(System.Int32));
                //delay_terminate
                delay_terminate = new Duration(new TimeData(
                        BitConverter.ToInt32(serializedMessage, currentIndex),
                        BitConverter.ToInt32(serializedMessage, currentIndex+Marshal.SizeOf(typeof(System.Int32)))));
                currentIndex += 2*Marshal.SizeOf(typeof(System.Int32));
                //pause_status
                pause_status = new Duration(new TimeData(
                        BitConverter.ToInt32(serializedMessage, currentIndex),
                        BitConverter.ToInt32(serializedMessage, currentIndex+Marshal.SizeOf(typeof(System.Int32)))));
                currentIndex += 2*Marshal.SizeOf(typeof(System.Int32));
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

            
                //terminate_status
                scratch1 = new byte[Marshal.SizeOf(typeof(int))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(terminate_status, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //ignore_cancel
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)ignore_cancel ? 1 : 0 );
                pieces.Add(thischunk);
                //result_text
                if (result_text == null)
                    result_text = "";
                scratch1 = Encoding.ASCII.GetBytes((string)result_text);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //the_result
                scratch1 = new byte[Marshal.SizeOf(typeof(int))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(the_result, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //is_simple_client
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)is_simple_client ? 1 : 0 );
                pieces.Add(thischunk);
                //delay_accept
                pieces.Add(BitConverter.GetBytes(delay_accept.data.sec));
                pieces.Add(BitConverter.GetBytes(delay_accept.data.nsec));
                //delay_terminate
                pieces.Add(BitConverter.GetBytes(delay_terminate.data.sec));
                pieces.Add(BitConverter.GetBytes(delay_terminate.data.nsec));
                //pause_status
                pieces.Add(BitConverter.GetBytes(pause_status.data.sec));
                pieces.Add(BitConverter.GetBytes(pause_status.data.nsec));

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

            
                //terminate_status
                terminate_status = rand.Next();
                //ignore_cancel
                ignore_cancel = rand.Next(2) == 1;
                //result_text
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                result_text = Encoding.ASCII.GetString(strbuf);
                //the_result
                the_result = rand.Next();
                //is_simple_client
                is_simple_client = rand.Next(2) == 1;
                //delay_accept
                delay_accept = new Duration(new TimeData(
                        Convert.ToInt32(rand.Next()),
                        Convert.ToInt32(rand.Next())));
                //delay_terminate
                delay_terminate = new Duration(new TimeData(
                        Convert.ToInt32(rand.Next()),
                        Convert.ToInt32(rand.Next())));
                //pause_status
                pause_status = new Duration(new TimeData(
                        Convert.ToInt32(rand.Next()),
                        Convert.ToInt32(rand.Next())));
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            TestRequestGoal other;
            try
            {
                other = (TestRequestGoal)message;
            }
            catch
            {
                return false;
            }

            
                ret &= terminate_status == other.terminate_status;
                ret &= ignore_cancel == other.ignore_cancel;
                ret &= result_text == other.result_text;
                ret &= the_result == other.the_result;
                ret &= is_simple_client == other.is_simple_client;
                ret &= delay_accept.data.Equals(other.delay_accept.data);
                ret &= delay_terminate.data.Equals(other.delay_terminate.data);
                ret &= pause_status.data.Equals(other.pause_status.data);

            return ret;
        }
    }



    //$ACTION_GOAL_MESSAGE

	[ActionResultMessage]
        public class TestRequestResult : InnerActionMessage
    {
        			public int the_result;
			public bool is_simple_server;



        public override string MD5Sum() { return "61c2364524499c7c5017e2f3fce7ba06"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"int32 the_result
bool is_simple_server"; }
		public override string MessageType { get { return "actionlib/TestRequestResult"; } }
        public override bool IsServiceComponent() { return false; }

        public TestRequestResult()
        {
            
        }

        public TestRequestResult(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public TestRequestResult(byte[] serializedMessage, ref int currentIndex)
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

            
                //the_result
                piecesize = Marshal.SizeOf(typeof(int));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                the_result = (int)Marshal.PtrToStructure(h, typeof(int));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //is_simple_server
                is_simple_server = serializedMessage[currentIndex++]==1;
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

            
                //the_result
                scratch1 = new byte[Marshal.SizeOf(typeof(int))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(the_result, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //is_simple_server
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)is_simple_server ? 1 : 0 );
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

            
                //the_result
                the_result = rand.Next();
                //is_simple_server
                is_simple_server = rand.Next(2) == 1;
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            TestRequestResult other;
            try
            {
                other = (TestRequestResult)message;
            }
            catch
            {
                return false;
            }

            
                ret &= the_result == other.the_result;
                ret &= is_simple_server == other.is_simple_server;

            return ret;
        }
    }



    //$ACTION_RESULT_MESSAGE


	[ActionFeedbackMessage]
        public class TestRequestFeedback : InnerActionMessage
    {
        


        public override string MD5Sum() { return "d41d8cd98f00b204e9800998ecf8427e"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @""; }
		public override string MessageType { get { return "actionlib/TestRequestFeedback"; } }
        public override bool IsServiceComponent() { return false; }

        public TestRequestFeedback()
        {
            
        }

        public TestRequestFeedback(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public TestRequestFeedback(byte[] serializedMessage, ref int currentIndex)
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
            TestRequestFeedback other;
            try
            {
                other = (TestRequestFeedback)message;
            }
            catch
            {
                return false;
            }

            

            return ret;
        }
    }



    //$ACTION_FEEDBACK_MESSAGE
}