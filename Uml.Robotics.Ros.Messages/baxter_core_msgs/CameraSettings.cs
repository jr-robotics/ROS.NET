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

namespace Messages.baxter_core_msgs
{
    public class CameraSettings : RosMessage
    {

			public int           width;
			public int           height;
			public Single         fps;
			public Messages.baxter_core_msgs.CameraControl[] controls;


        public override string MD5Sum() { return "d133bef4a3bd9a6e490a5dc91d20f429"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"int32 width
int32 height
float32 fps
CameraControl[] controls"; }
        public override string MessageType { get { return "baxter_core_msgs/CameraSettings"; } }
        public override bool IsServiceComponent() { return false; }

        public CameraSettings()
        {
            
        }

        public CameraSettings(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public CameraSettings(byte[] serializedMessage, ref int currentIndex)
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
            
            //width
            piecesize = Marshal.SizeOf(typeof(int));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            width = (int)Marshal.PtrToStructure(h, typeof(int));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //height
            piecesize = Marshal.SizeOf(typeof(int));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            height = (int)Marshal.PtrToStructure(h, typeof(int));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //fps
            piecesize = Marshal.SizeOf(typeof(Single));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            fps = (Single)Marshal.PtrToStructure(h, typeof(Single));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //controls
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (controls == null)
                controls = new Messages.baxter_core_msgs.CameraControl[arraylength];
            else
                Array.Resize(ref controls, arraylength);
            for (int i=0;i<controls.Length; i++) {
                //controls[i]
                controls[i] = new Messages.baxter_core_msgs.CameraControl(serializedMessage, ref currentIndex);
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
            
            //width
            scratch1 = new byte[Marshal.SizeOf(typeof(int))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(width, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //height
            scratch1 = new byte[Marshal.SizeOf(typeof(int))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(height, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //fps
            scratch1 = new byte[Marshal.SizeOf(typeof(Single))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(fps, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //controls
            hasmetacomponents |= true;
            if (controls == null)
                controls = new Messages.baxter_core_msgs.CameraControl[0];
            pieces.Add(BitConverter.GetBytes(controls.Length));
            for (int i=0;i<controls.Length; i++) {
                //controls[i]
                if (controls[i] == null)
                    controls[i] = new Messages.baxter_core_msgs.CameraControl();
                pieces.Add(controls[i].Serialize(true));
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
            
            //width
            width = rand.Next();
            //height
            height = rand.Next();
            //fps
            fps = (float)(rand.Next() + rand.NextDouble());
            //controls
            arraylength = rand.Next(10);
            if (controls == null)
                controls = new Messages.baxter_core_msgs.CameraControl[arraylength];
            else
                Array.Resize(ref controls, arraylength);
            for (int i=0;i<controls.Length; i++) {
                //controls[i]
                controls[i] = new Messages.baxter_core_msgs.CameraControl();
                controls[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.baxter_core_msgs.CameraSettings;
            if (other == null)
                return false;
            ret &= width == other.width;
            ret &= height == other.height;
            ret &= fps == other.fps;
            if (controls.Length != other.controls.Length)
                return false;
            for (int __i__=0; __i__ < controls.Length; __i__++)
            {
                ret &= controls[__i__].Equals(other.controls[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
