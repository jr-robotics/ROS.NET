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

namespace Messages.object_recognition_msgs
{
    public class Table : RosMessage
    {

			public Header header = new Header();
			public Messages.geometry_msgs.Pose pose = new Messages.geometry_msgs.Pose();
			public Messages.geometry_msgs.Point[] convex_hull;


        public override string MD5Sum() { return "39efebc7d51e44bd2d72f2df6c7823a2"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
geometry_msgs/Pose pose
geometry_msgs/Point[] convex_hull"; }
        public override string MessageType { get { return "object_recognition_msgs/Table"; } }
        public override bool IsServiceComponent() { return false; }

        public Table()
        {
            
        }

        public Table(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public Table(byte[] serializedMessage, ref int currentIndex)
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
            pose = new Messages.geometry_msgs.Pose(serializedMessage, ref currentIndex);
            //convex_hull
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (convex_hull == null)
                convex_hull = new Messages.geometry_msgs.Point[arraylength];
            else
                Array.Resize(ref convex_hull, arraylength);
            for (int i=0;i<convex_hull.Length; i++) {
                //convex_hull[i]
                convex_hull[i] = new Messages.geometry_msgs.Point(serializedMessage, ref currentIndex);
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
            //pose
            if (pose == null)
                pose = new Messages.geometry_msgs.Pose();
            pieces.Add(pose.Serialize(true));
            //convex_hull
            hasmetacomponents |= true;
            if (convex_hull == null)
                convex_hull = new Messages.geometry_msgs.Point[0];
            pieces.Add(BitConverter.GetBytes(convex_hull.Length));
            for (int i=0;i<convex_hull.Length; i++) {
                //convex_hull[i]
                if (convex_hull[i] == null)
                    convex_hull[i] = new Messages.geometry_msgs.Point();
                pieces.Add(convex_hull[i].Serialize(true));
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
            //pose
            pose = new Messages.geometry_msgs.Pose();
            pose.Randomize();
            //convex_hull
            arraylength = rand.Next(10);
            if (convex_hull == null)
                convex_hull = new Messages.geometry_msgs.Point[arraylength];
            else
                Array.Resize(ref convex_hull, arraylength);
            for (int i=0;i<convex_hull.Length; i++) {
                //convex_hull[i]
                convex_hull[i] = new Messages.geometry_msgs.Point();
                convex_hull[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.object_recognition_msgs.Table;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= pose.Equals(other.pose);
            if (convex_hull.Length != other.convex_hull.Length)
                return false;
            for (int __i__=0; __i__ < convex_hull.Length; __i__++)
            {
                ret &= convex_hull[__i__].Equals(other.convex_hull[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
