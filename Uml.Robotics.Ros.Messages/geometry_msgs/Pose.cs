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
    public class Pose : RosMessage
    {

			public Messages.geometry_msgs.Point position = new Messages.geometry_msgs.Point();
			public Quaternion orientation = new Quaternion();


        public override string MD5Sum() { return "e45d45a5a1ce597b249e23fb30fc871f"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Point position
Quaternion orientation"; }
        public override string MessageType { get { return "geometry_msgs/Pose"; } }
        public override bool IsServiceComponent() { return false; }

        public Pose()
        {
            
        }

        public Pose(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public Pose(byte[] serializedMessage, ref int currentIndex)
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
            
            //position
            position = new Messages.geometry_msgs.Point(serializedMessage, ref currentIndex);
            //orientation
            orientation = new Quaternion(serializedMessage, ref currentIndex);
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
            
            //position
            if (position == null)
                position = new Messages.geometry_msgs.Point();
            pieces.Add(position.Serialize(true));
            //orientation
            if (orientation == null)
                orientation = new Quaternion();
            pieces.Add(orientation.Serialize(true));
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
            
            //position
            position = new Messages.geometry_msgs.Point();
            position.Randomize();
            //orientation
            orientation = new Quaternion();
            orientation.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.geometry_msgs.Pose;
            if (other == null)
                return false;
            ret &= position.Equals(other.position);
            ret &= orientation.Equals(other.orientation);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
