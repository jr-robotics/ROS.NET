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

namespace Messages.custom_msgs
{
    public class robotMortality : RosMessage
    {

			public const int keep_alive = 0;
			public const int going_up = 1;
			public const int going_down = 2;
			public int status;
			public int robot_id;


        public override string MD5Sum() { return "fb23049ae51cb0705054cab2d93cfbdd"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"int32 keep_alive=0
int32 going_up=1
int32 going_down=2
int32 status
int32 robot_id"; }
        public override string MessageType { get { return "custom_msgs/robotMortality"; } }
        public override bool IsServiceComponent() { return false; }

        public robotMortality()
        {
            
        }

        public robotMortality(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public robotMortality(byte[] serializedMessage, ref int currentIndex)
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
            
            //status
            piecesize = Marshal.SizeOf(typeof(int));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            status = (int)Marshal.PtrToStructure(h, typeof(int));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //robot_id
            piecesize = Marshal.SizeOf(typeof(int));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            robot_id = (int)Marshal.PtrToStructure(h, typeof(int));
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
            
            //status
            scratch1 = new byte[Marshal.SizeOf(typeof(int))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(status, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //robot_id
            scratch1 = new byte[Marshal.SizeOf(typeof(int))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(robot_id, h.AddrOfPinnedObject(), false);
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
            
            //status
            status = rand.Next();
            //robot_id
            robot_id = rand.Next();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.custom_msgs.robotMortality;
            if (other == null)
                return false;
            ret &= status == other.status;
            ret &= robot_id == other.robot_id;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
