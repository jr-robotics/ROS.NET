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


namespace Messages.tf2_msgs
{
	[ActionGoalMessage]
        public class LookupTransformGoal : InnerActionMessage
    {
        			public string target_frame = "";
			public string source_frame = "";
			public Time source_time = new Time();
			public Duration timeout = new Duration();
			public Time target_time = new Time();
			public string fixed_frame = "";
			public bool advanced;



        public override string MD5Sum() { return "35e3720468131d675a18bb6f3e5f22f8"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"string target_frame
string source_frame
time source_time
duration timeout
time target_time
string fixed_frame
bool advanced"; }
		public override string MessageType { get { return "tf2_msgs/LookupTransformGoal"; } }
        public override bool IsServiceComponent() { return false; }

        public LookupTransformGoal()
        {
            
        }

        public LookupTransformGoal(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public LookupTransformGoal(byte[] serializedMessage, ref int currentIndex)
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

            
                //target_frame
                target_frame = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                target_frame = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //source_frame
                source_frame = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                source_frame = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //source_time
                source_time = new Time(new TimeData(
                        BitConverter.ToInt32(serializedMessage, currentIndex),
                        BitConverter.ToInt32(serializedMessage, currentIndex+Marshal.SizeOf(typeof(System.Int32)))));
                currentIndex += 2*Marshal.SizeOf(typeof(System.Int32));
                //timeout
                timeout = new Duration(new TimeData(
                        BitConverter.ToInt32(serializedMessage, currentIndex),
                        BitConverter.ToInt32(serializedMessage, currentIndex+Marshal.SizeOf(typeof(System.Int32)))));
                currentIndex += 2*Marshal.SizeOf(typeof(System.Int32));
                //target_time
                target_time = new Time(new TimeData(
                        BitConverter.ToInt32(serializedMessage, currentIndex),
                        BitConverter.ToInt32(serializedMessage, currentIndex+Marshal.SizeOf(typeof(System.Int32)))));
                currentIndex += 2*Marshal.SizeOf(typeof(System.Int32));
                //fixed_frame
                fixed_frame = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                fixed_frame = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //advanced
                advanced = serializedMessage[currentIndex++]==1;
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

            
                //target_frame
                if (target_frame == null)
                    target_frame = "";
                scratch1 = Encoding.ASCII.GetBytes((string)target_frame);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //source_frame
                if (source_frame == null)
                    source_frame = "";
                scratch1 = Encoding.ASCII.GetBytes((string)source_frame);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //source_time
                pieces.Add(BitConverter.GetBytes(source_time.data.sec));
                pieces.Add(BitConverter.GetBytes(source_time.data.nsec));
                //timeout
                pieces.Add(BitConverter.GetBytes(timeout.data.sec));
                pieces.Add(BitConverter.GetBytes(timeout.data.nsec));
                //target_time
                pieces.Add(BitConverter.GetBytes(target_time.data.sec));
                pieces.Add(BitConverter.GetBytes(target_time.data.nsec));
                //fixed_frame
                if (fixed_frame == null)
                    fixed_frame = "";
                scratch1 = Encoding.ASCII.GetBytes((string)fixed_frame);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //advanced
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)advanced ? 1 : 0 );
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

            
                //target_frame
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                target_frame = Encoding.ASCII.GetString(strbuf);
                //source_frame
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                source_frame = Encoding.ASCII.GetString(strbuf);
                //source_time
                source_time = new Time(new TimeData(
                        Convert.ToInt32(rand.Next()),
                        Convert.ToInt32(rand.Next())));
                //timeout
                timeout = new Duration(new TimeData(
                        Convert.ToInt32(rand.Next()),
                        Convert.ToInt32(rand.Next())));
                //target_time
                target_time = new Time(new TimeData(
                        Convert.ToInt32(rand.Next()),
                        Convert.ToInt32(rand.Next())));
                //fixed_frame
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                fixed_frame = Encoding.ASCII.GetString(strbuf);
                //advanced
                advanced = rand.Next(2) == 1;
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            LookupTransformGoal other;
            try
            {
                other = (LookupTransformGoal)message;
            }
            catch
            {
                return false;
            }

            
                ret &= target_frame == other.target_frame;
                ret &= source_frame == other.source_frame;
                ret &= source_time.data.Equals(other.source_time.data);
                ret &= timeout.data.Equals(other.timeout.data);
                ret &= target_time.data.Equals(other.target_time.data);
                ret &= fixed_frame == other.fixed_frame;
                ret &= advanced == other.advanced;

            return ret;
        }
    }



    //$ACTION_GOAL_MESSAGE

	[ActionResultMessage]
        public class LookupTransformResult : InnerActionMessage
    {
        			public Messages.geometry_msgs.TransformStamped transform = new Messages.geometry_msgs.TransformStamped();
			public Messages.tf2_msgs.TF2Error error = new Messages.tf2_msgs.TF2Error();



        public override string MD5Sum() { return "3fe5db6a19ca9cfb675418c5ad875c36"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"geometry_msgs/TransformStamped transform
tf2_msgs/TF2Error error"; }
		public override string MessageType { get { return "tf2_msgs/LookupTransformResult"; } }
        public override bool IsServiceComponent() { return false; }

        public LookupTransformResult()
        {
            
        }

        public LookupTransformResult(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public LookupTransformResult(byte[] serializedMessage, ref int currentIndex)
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

            
                //transform
                transform = new Messages.geometry_msgs.TransformStamped(serializedMessage, ref currentIndex);
                //error
                error = new Messages.tf2_msgs.TF2Error(serializedMessage, ref currentIndex);
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

            
                //transform
                if (transform == null)
                    transform = new Messages.geometry_msgs.TransformStamped();
                pieces.Add(transform.Serialize(true));
                //error
                if (error == null)
                    error = new Messages.tf2_msgs.TF2Error();
                pieces.Add(error.Serialize(true));

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

            
                //transform
                transform = new Messages.geometry_msgs.TransformStamped();
                transform.Randomize();
                //error
                error = new Messages.tf2_msgs.TF2Error();
                error.Randomize();
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            LookupTransformResult other;
            try
            {
                other = (LookupTransformResult)message;
            }
            catch
            {
                return false;
            }

            
                ret &= transform.Equals(other.transform);
                ret &= error.Equals(other.error);

            return ret;
        }
    }



    //$ACTION_RESULT_MESSAGE


	[ActionFeedbackMessage]
        public class LookupTransformFeedback : InnerActionMessage
    {
        


        public override string MD5Sum() { return "d41d8cd98f00b204e9800998ecf8427e"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @""; }
		public override string MessageType { get { return "tf2_msgs/LookupTransformFeedback"; } }
        public override bool IsServiceComponent() { return false; }

        public LookupTransformFeedback()
        {
            
        }

        public LookupTransformFeedback(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public LookupTransformFeedback(byte[] serializedMessage, ref int currentIndex)
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
            LookupTransformFeedback other;
            try
            {
                other = (LookupTransformFeedback)message;
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