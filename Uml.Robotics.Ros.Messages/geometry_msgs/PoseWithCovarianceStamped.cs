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
    public class PoseWithCovarianceStamped : RosMessage
    {

			public Header header = new Header();
			public Messages.geometry_msgs.PoseWithCovariance pose = new Messages.geometry_msgs.PoseWithCovariance();


        public override string MD5Sum() { return "953b798c0f514ff060a53a3498ce6246"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
PoseWithCovariance pose"; }
        public override string MessageType { get { return "geometry_msgs/PoseWithCovarianceStamped"; } }
        public override bool IsServiceComponent() { return false; }

        public PoseWithCovarianceStamped()
        {
            
        }

        public PoseWithCovarianceStamped(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PoseWithCovarianceStamped(byte[] serializedMessage, ref int currentIndex)
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
            //pose
            pose = new Messages.geometry_msgs.PoseWithCovariance(serializedMessage, ref currentIndex);
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
            //pose
            if (pose == null)
                pose = new Messages.geometry_msgs.PoseWithCovariance();
            pieces.Add(pose.Serialize(true));
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
            //pose
            pose = new Messages.geometry_msgs.PoseWithCovariance();
            pose.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.geometry_msgs.PoseWithCovarianceStamped;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= pose.Equals(other.pose);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
