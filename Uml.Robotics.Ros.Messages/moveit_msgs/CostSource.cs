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
    public class CostSource : RosMessage
    {

			public double cost_density;
			public Messages.geometry_msgs.Vector3 aabb_min = new Messages.geometry_msgs.Vector3();
			public Messages.geometry_msgs.Vector3 aabb_max = new Messages.geometry_msgs.Vector3();


        public override string MD5Sum() { return "abb7e013237dacaaa8b97e704102f908"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"float64 cost_density
geometry_msgs/Vector3 aabb_min
geometry_msgs/Vector3 aabb_max"; }
        public override string MessageType { get { return "moveit_msgs/CostSource"; } }
        public override bool IsServiceComponent() { return false; }

        public CostSource()
        {
            
        }

        public CostSource(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public CostSource(byte[] serializedMessage, ref int currentIndex)
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
            
            //cost_density
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            cost_density = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //aabb_min
            aabb_min = new Messages.geometry_msgs.Vector3(serializedMessage, ref currentIndex);
            //aabb_max
            aabb_max = new Messages.geometry_msgs.Vector3(serializedMessage, ref currentIndex);
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
            
            //cost_density
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(cost_density, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //aabb_min
            if (aabb_min == null)
                aabb_min = new Messages.geometry_msgs.Vector3();
            pieces.Add(aabb_min.Serialize(true));
            //aabb_max
            if (aabb_max == null)
                aabb_max = new Messages.geometry_msgs.Vector3();
            pieces.Add(aabb_max.Serialize(true));
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
            
            //cost_density
            cost_density = (rand.Next() + rand.NextDouble());
            //aabb_min
            aabb_min = new Messages.geometry_msgs.Vector3();
            aabb_min.Randomize();
            //aabb_max
            aabb_max = new Messages.geometry_msgs.Vector3();
            aabb_max.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.CostSource;
            if (other == null)
                return false;
            ret &= cost_density == other.cost_density;
            ret &= aabb_min.Equals(other.aabb_min);
            ret &= aabb_max.Equals(other.aabb_max);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
