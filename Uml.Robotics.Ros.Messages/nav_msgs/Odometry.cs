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

namespace Messages.nav_msgs
{
    public class Odometry : RosMessage
    {

			public Header header = new Header();
			public string child_frame_id = "";
			public Messages.geometry_msgs.PoseWithCovariance pose = new Messages.geometry_msgs.PoseWithCovariance();
			public Messages.geometry_msgs.TwistWithCovariance twist = new Messages.geometry_msgs.TwistWithCovariance();


        public override string MD5Sum() { return "cd5e73d190d741a2f92e81eda573aca7"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
string child_frame_id
geometry_msgs/PoseWithCovariance pose
geometry_msgs/TwistWithCovariance twist"; }
        public override string MessageType { get { return "nav_msgs/Odometry"; } }
        public override bool IsServiceComponent() { return false; }

        public Odometry()
        {
            
        }

        public Odometry(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public Odometry(byte[] serializedMessage, ref int currentIndex)
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
            //child_frame_id
            child_frame_id = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            child_frame_id = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //pose
            pose = new Messages.geometry_msgs.PoseWithCovariance(serializedMessage, ref currentIndex);
            //twist
            twist = new Messages.geometry_msgs.TwistWithCovariance(serializedMessage, ref currentIndex);
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
            //child_frame_id
            if (child_frame_id == null)
                child_frame_id = "";
            scratch1 = Encoding.ASCII.GetBytes((string)child_frame_id);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //pose
            if (pose == null)
                pose = new Messages.geometry_msgs.PoseWithCovariance();
            pieces.Add(pose.Serialize(true));
            //twist
            if (twist == null)
                twist = new Messages.geometry_msgs.TwistWithCovariance();
            pieces.Add(twist.Serialize(true));
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
            //child_frame_id
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            child_frame_id = Encoding.ASCII.GetString(strbuf);
            //pose
            pose = new Messages.geometry_msgs.PoseWithCovariance();
            pose.Randomize();
            //twist
            twist = new Messages.geometry_msgs.TwistWithCovariance();
            twist.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.nav_msgs.Odometry;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= child_frame_id == other.child_frame_id;
            ret &= pose.Equals(other.pose);
            ret &= twist.Equals(other.twist);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
