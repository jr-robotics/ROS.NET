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

namespace Messages.custom_msgs
{
    public class arrayofdeez : RosMessage
    {

			public Messages.geometry_msgs.Pose[] nuts;


        public override string MD5Sum() { return "47f86a517116ec6d23123e660975ceb6"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"geometry_msgs/Pose[] nuts"; }
        public override string MessageType { get { return "custom_msgs/arrayofdeez"; } }
        public override bool IsServiceComponent() { return false; }

        public arrayofdeez()
        {
            
        }

        public arrayofdeez(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public arrayofdeez(byte[] serializedMessage, ref int currentIndex)
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
            
            //nuts
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (nuts == null)
                nuts = new Messages.geometry_msgs.Pose[arraylength];
            else
                Array.Resize(ref nuts, arraylength);
            for (int i=0;i<nuts.Length; i++) {
                //nuts[i]
                nuts[i] = new Messages.geometry_msgs.Pose(serializedMessage, ref currentIndex);
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
            
            //nuts
            hasmetacomponents |= true;
            if (nuts == null)
                nuts = new Messages.geometry_msgs.Pose[0];
            pieces.Add(BitConverter.GetBytes(nuts.Length));
            for (int i=0;i<nuts.Length; i++) {
                //nuts[i]
                if (nuts[i] == null)
                    nuts[i] = new Messages.geometry_msgs.Pose();
                pieces.Add(nuts[i].Serialize(true));
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
            
            //nuts
            arraylength = rand.Next(10);
            if (nuts == null)
                nuts = new Messages.geometry_msgs.Pose[arraylength];
            else
                Array.Resize(ref nuts, arraylength);
            for (int i=0;i<nuts.Length; i++) {
                //nuts[i]
                nuts[i] = new Messages.geometry_msgs.Pose();
                nuts[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.custom_msgs.arrayofdeez;
            if (other == null)
                return false;
            if (nuts.Length != other.nuts.Length)
                return false;
            for (int __i__=0; __i__ < nuts.Length; __i__++)
            {
                ret &= nuts[__i__].Equals(other.nuts[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
