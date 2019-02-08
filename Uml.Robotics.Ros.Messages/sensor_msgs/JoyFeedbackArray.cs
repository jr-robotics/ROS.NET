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

namespace Messages.sensor_msgs
{
    public class JoyFeedbackArray : RosMessage
    {

			public Messages.sensor_msgs.JoyFeedback[] array;


        public override string MD5Sum() { return "cde5730a895b1fc4dee6f91b754b213d"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"JoyFeedback[] array"; }
        public override string MessageType { get { return "sensor_msgs/JoyFeedbackArray"; } }
        public override bool IsServiceComponent() { return false; }

        public JoyFeedbackArray()
        {
            
        }

        public JoyFeedbackArray(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public JoyFeedbackArray(byte[] serializedMessage, ref int currentIndex)
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
            
            //array
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (array == null)
                array = new Messages.sensor_msgs.JoyFeedback[arraylength];
            else
                Array.Resize(ref array, arraylength);
            for (int i=0;i<array.Length; i++) {
                //array[i]
                array[i] = new Messages.sensor_msgs.JoyFeedback(serializedMessage, ref currentIndex);
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
            
            //array
            hasmetacomponents |= true;
            if (array == null)
                array = new Messages.sensor_msgs.JoyFeedback[0];
            pieces.Add(BitConverter.GetBytes(array.Length));
            for (int i=0;i<array.Length; i++) {
                //array[i]
                if (array[i] == null)
                    array[i] = new Messages.sensor_msgs.JoyFeedback();
                pieces.Add(array[i].Serialize(true));
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
            
            //array
            arraylength = rand.Next(10);
            if (array == null)
                array = new Messages.sensor_msgs.JoyFeedback[arraylength];
            else
                Array.Resize(ref array, arraylength);
            for (int i=0;i<array.Length; i++) {
                //array[i]
                array[i] = new Messages.sensor_msgs.JoyFeedback();
                array[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.sensor_msgs.JoyFeedbackArray;
            if (other == null)
                return false;
            if (array.Length != other.array.Length)
                return false;
            for (int __i__=0; __i__ < array.Length; __i__++)
            {
                ret &= array[__i__].Equals(other.array[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
