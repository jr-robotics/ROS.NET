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
    public class GripperTranslation : RosMessage
    {

			public Messages.geometry_msgs.Vector3Stamped direction = new Messages.geometry_msgs.Vector3Stamped();
			public Single desired_distance;
			public Single min_distance;


        public override string MD5Sum() { return "b53bc0ad0f717cdec3b0e42dec300121"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"geometry_msgs/Vector3Stamped direction
float32 desired_distance
float32 min_distance"; }
        public override string MessageType { get { return "moveit_msgs/GripperTranslation"; } }
        public override bool IsServiceComponent() { return false; }

        public GripperTranslation()
        {
            
        }

        public GripperTranslation(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public GripperTranslation(byte[] serializedMessage, ref int currentIndex)
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
            
            //direction
            direction = new Messages.geometry_msgs.Vector3Stamped(serializedMessage, ref currentIndex);
            //desired_distance
            piecesize = Marshal.SizeOf(typeof(Single));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            desired_distance = (Single)Marshal.PtrToStructure(h, typeof(Single));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //min_distance
            piecesize = Marshal.SizeOf(typeof(Single));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            min_distance = (Single)Marshal.PtrToStructure(h, typeof(Single));
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
            
            //direction
            if (direction == null)
                direction = new Messages.geometry_msgs.Vector3Stamped();
            pieces.Add(direction.Serialize(true));
            //desired_distance
            scratch1 = new byte[Marshal.SizeOf(typeof(Single))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(desired_distance, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //min_distance
            scratch1 = new byte[Marshal.SizeOf(typeof(Single))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(min_distance, h.AddrOfPinnedObject(), false);
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
            
            //direction
            direction = new Messages.geometry_msgs.Vector3Stamped();
            direction.Randomize();
            //desired_distance
            desired_distance = (float)(rand.Next() + rand.NextDouble());
            //min_distance
            min_distance = (float)(rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.GripperTranslation;
            if (other == null)
                return false;
            ret &= direction.Equals(other.direction);
            ret &= desired_distance == other.desired_distance;
            ret &= min_distance == other.min_distance;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
