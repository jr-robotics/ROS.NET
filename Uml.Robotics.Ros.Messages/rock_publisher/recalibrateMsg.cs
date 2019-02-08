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

namespace Messages.rock_publisher
{
    public class recalibrateMsg : RosMessage
    {

			public Messages.rock_publisher.imgData data = new Messages.rock_publisher.imgData();
			public Messages.sensor_msgs.CompressedImage img = new Messages.sensor_msgs.CompressedImage();


        public override string MD5Sum() { return "ef610363f297374bacad9ee0e5b9e6cf"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"imgData data
sensor_msgs/CompressedImage img"; }
        public override string MessageType { get { return "rock_publisher/recalibrateMsg"; } }
        public override bool IsServiceComponent() { return false; }

        public recalibrateMsg()
        {
            
        }

        public recalibrateMsg(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public recalibrateMsg(byte[] serializedMessage, ref int currentIndex)
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
            
            //data
            data = new Messages.rock_publisher.imgData(serializedMessage, ref currentIndex);
            //img
            img = new Messages.sensor_msgs.CompressedImage(serializedMessage, ref currentIndex);
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
            
            //data
            if (data == null)
                data = new Messages.rock_publisher.imgData();
            pieces.Add(data.Serialize(true));
            //img
            if (img == null)
                img = new Messages.sensor_msgs.CompressedImage();
            pieces.Add(img.Serialize(true));
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
            
            //data
            data = new Messages.rock_publisher.imgData();
            data.Randomize();
            //img
            img = new Messages.sensor_msgs.CompressedImage();
            img.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.rock_publisher.recalibrateMsg;
            if (other == null)
                return false;
            ret &= data.Equals(other.data);
            ret &= img.Equals(other.img);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
