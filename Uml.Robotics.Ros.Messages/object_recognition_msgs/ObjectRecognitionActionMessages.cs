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


namespace Messages.object_recognition_msgs
{
	[ActionGoalMessage]
        public class ObjectRecognitionGoal : InnerActionMessage
    {
        			public bool use_roi;
			public Single[] filter_limits;



        public override string MD5Sum() { return "49bea2f03a1bba0ad05926e01e3525fa"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"bool use_roi
float32[] filter_limits"; }
		public override string MessageType { get { return "object_recognition_msgs/ObjectRecognitionGoal"; } }
        public override bool IsServiceComponent() { return false; }

        public ObjectRecognitionGoal()
        {
            
        }

        public ObjectRecognitionGoal(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public ObjectRecognitionGoal(byte[] serializedMessage, ref int currentIndex)
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

            
                //use_roi
                use_roi = serializedMessage[currentIndex++]==1;
                //filter_limits
                hasmetacomponents |= false;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (filter_limits == null)
                    filter_limits = new Single[arraylength];
                else
                    Array.Resize(ref filter_limits, arraylength);
// Start Xamla
                    //filter_limits
                    piecesize = Marshal.SizeOf(typeof(Single)) * filter_limits.Length;
                    if (currentIndex + piecesize > serializedMessage.Length) {
                        throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                    }
                    Buffer.BlockCopy(serializedMessage, currentIndex, filter_limits, 0, piecesize);
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

            
                //use_roi
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)use_roi ? 1 : 0 );
                pieces.Add(thischunk);
                //filter_limits
                hasmetacomponents |= false;
                if (filter_limits == null)
                    filter_limits = new Single[0];
                pieces.Add(BitConverter.GetBytes(filter_limits.Length));
// Start Xamla
                    //filter_limits
                    x__size = Marshal.SizeOf(typeof(Single)) * filter_limits.Length;
                    scratch1 = new byte[x__size];
                    Buffer.BlockCopy(filter_limits, 0, scratch1, 0, x__size);
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

            
                //use_roi
                use_roi = rand.Next(2) == 1;
                //filter_limits
                arraylength = rand.Next(10);
                if (filter_limits == null)
                    filter_limits = new Single[arraylength];
                else
                    Array.Resize(ref filter_limits, arraylength);
                for (int i=0;i<filter_limits.Length; i++) {
                    //filter_limits[i]
                    filter_limits[i] = (float)(rand.Next() + rand.NextDouble());
                }
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            ObjectRecognitionGoal other;
            try
            {
                other = (ObjectRecognitionGoal)message;
            }
            catch
            {
                return false;
            }

            
                ret &= use_roi == other.use_roi;
                if (filter_limits.Length != other.filter_limits.Length)
                    return false;
                for (int __i__=0; __i__ < filter_limits.Length; __i__++)
                {
                    ret &= filter_limits[__i__] == other.filter_limits[__i__];
                }

            return ret;
        }
    }



    //$ACTION_GOAL_MESSAGE

	[ActionResultMessage]
        public class ObjectRecognitionResult : InnerActionMessage
    {
        			public Messages.object_recognition_msgs.RecognizedObjectArray recognized_objects = new Messages.object_recognition_msgs.RecognizedObjectArray();



        public override string MD5Sum() { return "868e41288f9f8636e2b6c51f1af6aa9c"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"object_recognition_msgs/RecognizedObjectArray recognized_objects"; }
		public override string MessageType { get { return "object_recognition_msgs/ObjectRecognitionResult"; } }
        public override bool IsServiceComponent() { return false; }

        public ObjectRecognitionResult()
        {
            
        }

        public ObjectRecognitionResult(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public ObjectRecognitionResult(byte[] serializedMessage, ref int currentIndex)
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

            
                //recognized_objects
                recognized_objects = new Messages.object_recognition_msgs.RecognizedObjectArray(serializedMessage, ref currentIndex);
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

            
                //recognized_objects
                if (recognized_objects == null)
                    recognized_objects = new Messages.object_recognition_msgs.RecognizedObjectArray();
                pieces.Add(recognized_objects.Serialize(true));

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

            
                //recognized_objects
                recognized_objects = new Messages.object_recognition_msgs.RecognizedObjectArray();
                recognized_objects.Randomize();
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            ObjectRecognitionResult other;
            try
            {
                other = (ObjectRecognitionResult)message;
            }
            catch
            {
                return false;
            }

            
                ret &= recognized_objects.Equals(other.recognized_objects);

            return ret;
        }
    }



    //$ACTION_RESULT_MESSAGE


	[ActionFeedbackMessage]
        public class ObjectRecognitionFeedback : InnerActionMessage
    {
        


        public override string MD5Sum() { return "d41d8cd98f00b204e9800998ecf8427e"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @""; }
		public override string MessageType { get { return "object_recognition_msgs/ObjectRecognitionFeedback"; } }
        public override bool IsServiceComponent() { return false; }

        public ObjectRecognitionFeedback()
        {
            
        }

        public ObjectRecognitionFeedback(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public ObjectRecognitionFeedback(byte[] serializedMessage, ref int currentIndex)
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
            ObjectRecognitionFeedback other;
            try
            {
                other = (ObjectRecognitionFeedback)message;
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