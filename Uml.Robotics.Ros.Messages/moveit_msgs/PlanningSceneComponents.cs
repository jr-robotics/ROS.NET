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
    public class PlanningSceneComponents : RosMessage
    {

			public const uint SCENE_SETTINGS = 1U;
			public const uint ROBOT_STATE = 2U;
			public const uint ROBOT_STATE_ATTACHED_OBJECTS = 4U;
			public const uint WORLD_OBJECT_NAMES = 8U;
			public const uint WORLD_OBJECT_GEOMETRY = 16U;
			public const uint OCTOMAP = 32U;
			public const uint TRANSFORMS = 64U;
			public const uint ALLOWED_COLLISION_MATRIX = 128U;
			public const uint LINK_PADDING_AND_SCALING = 256U;
			public const uint OBJECT_COLORS = 512U;
			public uint components;


        public override string MD5Sum() { return "bc993e784476960b918b6e7ad5bb58ce"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"uint32 SCENE_SETTINGS=1
uint32 ROBOT_STATE=2
uint32 ROBOT_STATE_ATTACHED_OBJECTS=4
uint32 WORLD_OBJECT_NAMES=8
uint32 WORLD_OBJECT_GEOMETRY=16
uint32 OCTOMAP=32
uint32 TRANSFORMS=64
uint32 ALLOWED_COLLISION_MATRIX=128
uint32 LINK_PADDING_AND_SCALING=256
uint32 OBJECT_COLORS=512
uint32 components"; }
        public override string MessageType { get { return "moveit_msgs/PlanningSceneComponents"; } }
        public override bool IsServiceComponent() { return false; }

        public PlanningSceneComponents()
        {
            
        }

        public PlanningSceneComponents(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PlanningSceneComponents(byte[] serializedMessage, ref int currentIndex)
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
            
            //components
            piecesize = Marshal.SizeOf(typeof(uint));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            components = (uint)Marshal.PtrToStructure(h, typeof(uint));
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
            
            //components
            scratch1 = new byte[Marshal.SizeOf(typeof(uint))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(components, h.AddrOfPinnedObject(), false);
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
            
            //components
            components = (uint)rand.Next();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.PlanningSceneComponents;
            if (other == null)
                return false;
            ret &= components == other.components;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
