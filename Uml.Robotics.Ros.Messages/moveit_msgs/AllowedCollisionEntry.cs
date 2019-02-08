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

namespace Messages.moveit_msgs
{
    public class AllowedCollisionEntry : RosMessage
    {

			public bool[] enabled;


        public override string MD5Sum() { return "90d1ae1850840724bb043562fe3285fc"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"bool[] enabled"; }
        public override string MessageType { get { return "moveit_msgs/AllowedCollisionEntry"; } }
        public override bool IsServiceComponent() { return false; }

        public AllowedCollisionEntry()
        {
            
        }

        public AllowedCollisionEntry(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public AllowedCollisionEntry(byte[] serializedMessage, ref int currentIndex)
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
            
            //enabled
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (enabled == null)
                enabled = new bool[arraylength];
            else
                Array.Resize(ref enabled, arraylength);
            for (int i=0;i<enabled.Length; i++) {
                //enabled[i]
                enabled[i] = serializedMessage[currentIndex++]==1;
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
            
            //enabled
            hasmetacomponents |= false;
            if (enabled == null)
                enabled = new bool[0];
            pieces.Add(BitConverter.GetBytes(enabled.Length));
            for (int i=0;i<enabled.Length; i++) {
                //enabled[i]
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)enabled[i] ? 1 : 0 );
                pieces.Add(thischunk);
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
            
            //enabled
            arraylength = rand.Next(10);
            if (enabled == null)
                enabled = new bool[arraylength];
            else
                Array.Resize(ref enabled, arraylength);
            for (int i=0;i<enabled.Length; i++) {
                //enabled[i]
                enabled[i] = rand.Next(2) == 1;
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.AllowedCollisionEntry;
            if (other == null)
                return false;
            if (enabled.Length != other.enabled.Length)
                return false;
            for (int __i__=0; __i__ < enabled.Length; __i__++)
            {
                ret &= enabled[__i__] == other.enabled[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
