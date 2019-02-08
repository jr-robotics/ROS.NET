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

namespace Messages.octomap_msgs
{
    public class OctomapWithPose : RosMessage
    {

			public Header header = new Header();
			public Messages.geometry_msgs.Pose origin = new Messages.geometry_msgs.Pose();
			public Messages.octomap_msgs.Octomap octomap = new Messages.octomap_msgs.Octomap();


        public override string MD5Sum() { return "20b380aca6a508a657e95526cddaf618"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
geometry_msgs/Pose origin
octomap_msgs/Octomap octomap"; }
        public override string MessageType { get { return "octomap_msgs/OctomapWithPose"; } }
        public override bool IsServiceComponent() { return false; }

        public OctomapWithPose()
        {
            
        }

        public OctomapWithPose(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public OctomapWithPose(byte[] serializedMessage, ref int currentIndex)
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
            //origin
            origin = new Messages.geometry_msgs.Pose(serializedMessage, ref currentIndex);
            //octomap
            octomap = new Messages.octomap_msgs.Octomap(serializedMessage, ref currentIndex);
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
            //origin
            if (origin == null)
                origin = new Messages.geometry_msgs.Pose();
            pieces.Add(origin.Serialize(true));
            //octomap
            if (octomap == null)
                octomap = new Messages.octomap_msgs.Octomap();
            pieces.Add(octomap.Serialize(true));
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
            //origin
            origin = new Messages.geometry_msgs.Pose();
            origin.Randomize();
            //octomap
            octomap = new Messages.octomap_msgs.Octomap();
            octomap.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.octomap_msgs.OctomapWithPose;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= origin.Equals(other.origin);
            ret &= octomap.Equals(other.octomap);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
