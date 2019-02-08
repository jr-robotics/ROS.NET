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

namespace Messages.sensor_msgs
{
    public class JoyFeedback : RosMessage
    {

			public const byte TYPE_LED    = 0;
			public const byte TYPE_RUMBLE = 1;
			public const byte TYPE_BUZZER = 2;
			public byte type;
			public byte id;
			public Single intensity;


        public override string MD5Sum() { return "f4dcd73460360d98f36e55ee7f2e46f1"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"uint8 TYPE_LED=0
uint8 TYPE_RUMBLE=1
uint8 TYPE_BUZZER=2
uint8 type
uint8 id
float32 intensity"; }
        public override string MessageType { get { return "sensor_msgs/JoyFeedback"; } }
        public override bool IsServiceComponent() { return false; }

        public JoyFeedback()
        {
            
        }

        public JoyFeedback(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public JoyFeedback(byte[] serializedMessage, ref int currentIndex)
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
            
            //type
            type=serializedMessage[currentIndex++];
            //id
            id=serializedMessage[currentIndex++];
            //intensity
            piecesize = Marshal.SizeOf(typeof(Single));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            intensity = (Single)Marshal.PtrToStructure(h, typeof(Single));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
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
            
            //type
            pieces.Add(new[] { (byte)type });
            //id
            pieces.Add(new[] { (byte)id });
            //intensity
            scratch1 = new byte[Marshal.SizeOf(typeof(Single))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(intensity, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
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
            
            //type
            myByte = new byte[1];
            rand.NextBytes(myByte);
            type= myByte[0];
            //id
            myByte = new byte[1];
            rand.NextBytes(myByte);
            id= myByte[0];
            //intensity
            intensity = (float)(rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.sensor_msgs.JoyFeedback;
            if (other == null)
                return false;
            ret &= type == other.type;
            ret &= id == other.id;
            ret &= intensity == other.intensity;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
