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

namespace Messages.geometry_msgs
{
    public class PoseArray : RosMessage
    {

			public Header header = new Header();
			public Messages.geometry_msgs.Pose[] poses;


        public override string MD5Sum() { return "916c28c5764443f268b296bb671b9d97"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
geometry_msgs/Pose[] poses"; }
        public override string MessageType { get { return "geometry_msgs/PoseArray"; } }
        public override bool IsServiceComponent() { return false; }

        public PoseArray()
        {
            
        }

        public PoseArray(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PoseArray(byte[] serializedMessage, ref int currentIndex)
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
            
            //header
            header = new Header(serializedMessage, ref currentIndex);
            //poses
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (poses == null)
                poses = new Messages.geometry_msgs.Pose[arraylength];
            else
                Array.Resize(ref poses, arraylength);
            for (int i=0;i<poses.Length; i++) {
                //poses[i]
                poses[i] = new Messages.geometry_msgs.Pose(serializedMessage, ref currentIndex);
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
            
            //header
            if (header == null)
                header = new Header();
            pieces.Add(header.Serialize(true));
            //poses
            hasmetacomponents |= true;
            if (poses == null)
                poses = new Messages.geometry_msgs.Pose[0];
            pieces.Add(BitConverter.GetBytes(poses.Length));
            for (int i=0;i<poses.Length; i++) {
                //poses[i]
                if (poses[i] == null)
                    poses[i] = new Messages.geometry_msgs.Pose();
                pieces.Add(poses[i].Serialize(true));
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
            
            //header
            header = new Header();
            header.Randomize();
            //poses
            arraylength = rand.Next(10);
            if (poses == null)
                poses = new Messages.geometry_msgs.Pose[arraylength];
            else
                Array.Resize(ref poses, arraylength);
            for (int i=0;i<poses.Length; i++) {
                //poses[i]
                poses[i] = new Messages.geometry_msgs.Pose();
                poses[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.geometry_msgs.PoseArray;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            if (poses.Length != other.poses.Length)
                return false;
            for (int __i__=0; __i__ < poses.Length; __i__++)
            {
                ret &= poses[__i__].Equals(other.poses[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
