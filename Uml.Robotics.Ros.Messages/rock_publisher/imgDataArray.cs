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
    public class imgDataArray : RosMessage
    {

			public Messages.rock_publisher.imgData[] rockData;


        public override string MD5Sum() { return "203e50542367a4a58cac7ab553215738"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"imgData[] rockData"; }
        public override string MessageType { get { return "rock_publisher/imgDataArray"; } }
        public override bool IsServiceComponent() { return false; }

        public imgDataArray()
        {
            
        }

        public imgDataArray(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public imgDataArray(byte[] serializedMessage, ref int currentIndex)
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
            
            //rockData
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (rockData == null)
                rockData = new Messages.rock_publisher.imgData[arraylength];
            else
                Array.Resize(ref rockData, arraylength);
            for (int i=0;i<rockData.Length; i++) {
                //rockData[i]
                rockData[i] = new Messages.rock_publisher.imgData(serializedMessage, ref currentIndex);
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
            
            //rockData
            hasmetacomponents |= true;
            if (rockData == null)
                rockData = new Messages.rock_publisher.imgData[0];
            pieces.Add(BitConverter.GetBytes(rockData.Length));
            for (int i=0;i<rockData.Length; i++) {
                //rockData[i]
                if (rockData[i] == null)
                    rockData[i] = new Messages.rock_publisher.imgData();
                pieces.Add(rockData[i].Serialize(true));
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
            
            //rockData
            arraylength = rand.Next(10);
            if (rockData == null)
                rockData = new Messages.rock_publisher.imgData[arraylength];
            else
                Array.Resize(ref rockData, arraylength);
            for (int i=0;i<rockData.Length; i++) {
                //rockData[i]
                rockData[i] = new Messages.rock_publisher.imgData();
                rockData[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.rock_publisher.imgDataArray;
            if (other == null)
                return false;
            if (rockData.Length != other.rockData.Length)
                return false;
            for (int __i__=0; __i__ < rockData.Length; __i__++)
            {
                ret &= rockData[__i__].Equals(other.rockData[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
