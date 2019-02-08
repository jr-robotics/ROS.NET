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
    public class cgeo : RosMessage
    {

			public Messages.geometry_msgs.Vector3[] vec;


        public override string MD5Sum() { return "5466fc697deeda647d8a50c8f0a1b4ad"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"geometry_msgs/Vector3[] vec"; }
        public override string MessageType { get { return "custom_msgs/cgeo"; } }
        public override bool IsServiceComponent() { return false; }

        public cgeo()
        {
            
        }

        public cgeo(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public cgeo(byte[] serializedMessage, ref int currentIndex)
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
            
            //vec
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (vec == null)
                vec = new Messages.geometry_msgs.Vector3[arraylength];
            else
                Array.Resize(ref vec, arraylength);
            for (int i=0;i<vec.Length; i++) {
                //vec[i]
                vec[i] = new Messages.geometry_msgs.Vector3(serializedMessage, ref currentIndex);
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
            
            //vec
            hasmetacomponents |= false;
            if (vec == null)
                vec = new Messages.geometry_msgs.Vector3[0];
            pieces.Add(BitConverter.GetBytes(vec.Length));
            for (int i=0;i<vec.Length; i++) {
                //vec[i]
                if (vec[i] == null)
                    vec[i] = new Messages.geometry_msgs.Vector3();
                pieces.Add(vec[i].Serialize(true));
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
            
            //vec
            arraylength = rand.Next(10);
            if (vec == null)
                vec = new Messages.geometry_msgs.Vector3[arraylength];
            else
                Array.Resize(ref vec, arraylength);
            for (int i=0;i<vec.Length; i++) {
                //vec[i]
                vec[i] = new Messages.geometry_msgs.Vector3();
                vec[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.custom_msgs.cgeo;
            if (other == null)
                return false;
            if (vec.Length != other.vec.Length)
                return false;
            for (int __i__=0; __i__ < vec.Length; __i__++)
            {
                ret &= vec[__i__].Equals(other.vec[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
