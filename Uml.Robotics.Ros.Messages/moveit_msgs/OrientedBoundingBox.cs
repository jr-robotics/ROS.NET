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
    public class OrientedBoundingBox : RosMessage
    {

			public Messages.geometry_msgs.Pose pose = new Messages.geometry_msgs.Pose();
			public Messages.geometry_msgs.Point32 extents = new Messages.geometry_msgs.Point32();


        public override string MD5Sum() { return "da3bd98e7cb14efa4141367a9d886ee7"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"geometry_msgs/Pose pose
geometry_msgs/Point32 extents"; }
        public override string MessageType { get { return "moveit_msgs/OrientedBoundingBox"; } }
        public override bool IsServiceComponent() { return false; }

        public OrientedBoundingBox()
        {
            
        }

        public OrientedBoundingBox(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public OrientedBoundingBox(byte[] serializedMessage, ref int currentIndex)
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
            
            //pose
            pose = new Messages.geometry_msgs.Pose(serializedMessage, ref currentIndex);
            //extents
            extents = new Messages.geometry_msgs.Point32(serializedMessage, ref currentIndex);
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
            
            //pose
            if (pose == null)
                pose = new Messages.geometry_msgs.Pose();
            pieces.Add(pose.Serialize(true));
            //extents
            if (extents == null)
                extents = new Messages.geometry_msgs.Point32();
            pieces.Add(extents.Serialize(true));
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
            
            //pose
            pose = new Messages.geometry_msgs.Pose();
            pose.Randomize();
            //extents
            extents = new Messages.geometry_msgs.Point32();
            extents.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.OrientedBoundingBox;
            if (other == null)
                return false;
            ret &= pose.Equals(other.pose);
            ret &= extents.Equals(other.extents);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
