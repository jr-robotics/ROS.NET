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

namespace Messages.wpf_msgs
{
    public class WindowState : RosMessage
    {

			public Messages.wpf_msgs.Point2 topleft = new Messages.wpf_msgs.Point2();
			public Messages.wpf_msgs.Point2 bottomright = new Messages.wpf_msgs.Point2();
			public Single width;
			public Single height;


        public override string MD5Sum() { return "b341ba0e121147332f046f0baa47b6a4"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Point2 topleft
Point2 bottomright
float32 width
float32 height"; }
        public override string MessageType { get { return "wpf_msgs/WindowState"; } }
        public override bool IsServiceComponent() { return false; }

        public WindowState()
        {
            
        }

        public WindowState(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public WindowState(byte[] serializedMessage, ref int currentIndex)
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
            
            //topleft
            topleft = new Messages.wpf_msgs.Point2(serializedMessage, ref currentIndex);
            //bottomright
            bottomright = new Messages.wpf_msgs.Point2(serializedMessage, ref currentIndex);
            //width
            piecesize = Marshal.SizeOf(typeof(Single));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            width = (Single)Marshal.PtrToStructure(h, typeof(Single));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //height
            piecesize = Marshal.SizeOf(typeof(Single));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            height = (Single)Marshal.PtrToStructure(h, typeof(Single));
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
            
            //topleft
            if (topleft == null)
                topleft = new Messages.wpf_msgs.Point2();
            pieces.Add(topleft.Serialize(true));
            //bottomright
            if (bottomright == null)
                bottomright = new Messages.wpf_msgs.Point2();
            pieces.Add(bottomright.Serialize(true));
            //width
            scratch1 = new byte[Marshal.SizeOf(typeof(Single))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(width, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //height
            scratch1 = new byte[Marshal.SizeOf(typeof(Single))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(height, h.AddrOfPinnedObject(), false);
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
            
            //topleft
            topleft = new Messages.wpf_msgs.Point2();
            topleft.Randomize();
            //bottomright
            bottomright = new Messages.wpf_msgs.Point2();
            bottomright.Randomize();
            //width
            width = (float)(rand.Next() + rand.NextDouble());
            //height
            height = (float)(rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.wpf_msgs.WindowState;
            if (other == null)
                return false;
            ret &= topleft.Equals(other.topleft);
            ret &= bottomright.Equals(other.bottomright);
            ret &= width == other.width;
            ret &= height == other.height;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
