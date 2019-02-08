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
    public class VisibilityConstraint : RosMessage
    {

			public double target_radius;
			public Messages.geometry_msgs.PoseStamped target_pose = new Messages.geometry_msgs.PoseStamped();
			public int cone_sides;
			public Messages.geometry_msgs.PoseStamped sensor_pose = new Messages.geometry_msgs.PoseStamped();
			public double max_view_angle;
			public double max_range_angle;
			public const byte SENSOR_Z = 0;
			public const byte SENSOR_Y = 1;
			public const byte SENSOR_X = 2;
			public byte sensor_view_direction;
			public double weight;


        public override string MD5Sum() { return "62cda903bfe31ff2e5fcdc3810d577ad"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"float64 target_radius
geometry_msgs/PoseStamped target_pose
int32 cone_sides
geometry_msgs/PoseStamped sensor_pose
float64 max_view_angle
float64 max_range_angle
uint8 SENSOR_Z=0
uint8 SENSOR_Y=1
uint8 SENSOR_X=2
uint8 sensor_view_direction
float64 weight"; }
        public override string MessageType { get { return "moveit_msgs/VisibilityConstraint"; } }
        public override bool IsServiceComponent() { return false; }

        public VisibilityConstraint()
        {
            
        }

        public VisibilityConstraint(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public VisibilityConstraint(byte[] serializedMessage, ref int currentIndex)
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
            
            //target_radius
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            target_radius = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //target_pose
            target_pose = new Messages.geometry_msgs.PoseStamped(serializedMessage, ref currentIndex);
            //cone_sides
            piecesize = Marshal.SizeOf(typeof(int));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            cone_sides = (int)Marshal.PtrToStructure(h, typeof(int));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //sensor_pose
            sensor_pose = new Messages.geometry_msgs.PoseStamped(serializedMessage, ref currentIndex);
            //max_view_angle
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            max_view_angle = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //max_range_angle
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            max_range_angle = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //sensor_view_direction
            sensor_view_direction=serializedMessage[currentIndex++];
            //weight
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            weight = (double)Marshal.PtrToStructure(h, typeof(double));
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
            
            //target_radius
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(target_radius, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //target_pose
            if (target_pose == null)
                target_pose = new Messages.geometry_msgs.PoseStamped();
            pieces.Add(target_pose.Serialize(true));
            //cone_sides
            scratch1 = new byte[Marshal.SizeOf(typeof(int))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(cone_sides, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //sensor_pose
            if (sensor_pose == null)
                sensor_pose = new Messages.geometry_msgs.PoseStamped();
            pieces.Add(sensor_pose.Serialize(true));
            //max_view_angle
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(max_view_angle, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //max_range_angle
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(max_range_angle, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //sensor_view_direction
            pieces.Add(new[] { (byte)sensor_view_direction });
            //weight
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(weight, h.AddrOfPinnedObject(), false);
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
            
            //target_radius
            target_radius = (rand.Next() + rand.NextDouble());
            //target_pose
            target_pose = new Messages.geometry_msgs.PoseStamped();
            target_pose.Randomize();
            //cone_sides
            cone_sides = rand.Next();
            //sensor_pose
            sensor_pose = new Messages.geometry_msgs.PoseStamped();
            sensor_pose.Randomize();
            //max_view_angle
            max_view_angle = (rand.Next() + rand.NextDouble());
            //max_range_angle
            max_range_angle = (rand.Next() + rand.NextDouble());
            //sensor_view_direction
            myByte = new byte[1];
            rand.NextBytes(myByte);
            sensor_view_direction= myByte[0];
            //weight
            weight = (rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.VisibilityConstraint;
            if (other == null)
                return false;
            ret &= target_radius == other.target_radius;
            ret &= target_pose.Equals(other.target_pose);
            ret &= cone_sides == other.cone_sides;
            ret &= sensor_pose.Equals(other.sensor_pose);
            ret &= max_view_angle == other.max_view_angle;
            ret &= max_range_angle == other.max_range_angle;
            ret &= sensor_view_direction == other.sensor_view_direction;
            ret &= weight == other.weight;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
