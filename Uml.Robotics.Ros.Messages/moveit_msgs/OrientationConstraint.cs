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
    public class OrientationConstraint : RosMessage
    {

			public Header header = new Header();
			public Messages.geometry_msgs.Quaternion orientation = new Messages.geometry_msgs.Quaternion();
			public string link_name = "";
			public double absolute_x_axis_tolerance;
			public double absolute_y_axis_tolerance;
			public double absolute_z_axis_tolerance;
			public double weight;


        public override string MD5Sum() { return "ab5cefb9bc4c0089620f5eb4caf4e59a"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
geometry_msgs/Quaternion orientation
string link_name
float64 absolute_x_axis_tolerance
float64 absolute_y_axis_tolerance
float64 absolute_z_axis_tolerance
float64 weight"; }
        public override string MessageType { get { return "moveit_msgs/OrientationConstraint"; } }
        public override bool IsServiceComponent() { return false; }

        public OrientationConstraint()
        {
            
        }

        public OrientationConstraint(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public OrientationConstraint(byte[] serializedMessage, ref int currentIndex)
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
            
            //header
            header = new Header(serializedMessage, ref currentIndex);
            //orientation
            orientation = new Messages.geometry_msgs.Quaternion(serializedMessage, ref currentIndex);
            //link_name
            link_name = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            link_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //absolute_x_axis_tolerance
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            absolute_x_axis_tolerance = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //absolute_y_axis_tolerance
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            absolute_y_axis_tolerance = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //absolute_z_axis_tolerance
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            absolute_z_axis_tolerance = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
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
            
            //header
            if (header == null)
                header = new Header();
            pieces.Add(header.Serialize(true));
            //orientation
            if (orientation == null)
                orientation = new Messages.geometry_msgs.Quaternion();
            pieces.Add(orientation.Serialize(true));
            //link_name
            if (link_name == null)
                link_name = "";
            scratch1 = Encoding.ASCII.GetBytes((string)link_name);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //absolute_x_axis_tolerance
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(absolute_x_axis_tolerance, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //absolute_y_axis_tolerance
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(absolute_y_axis_tolerance, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //absolute_z_axis_tolerance
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(absolute_z_axis_tolerance, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
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
            
            //header
            header = new Header();
            header.Randomize();
            //orientation
            orientation = new Messages.geometry_msgs.Quaternion();
            orientation.Randomize();
            //link_name
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            link_name = Encoding.ASCII.GetString(strbuf);
            //absolute_x_axis_tolerance
            absolute_x_axis_tolerance = (rand.Next() + rand.NextDouble());
            //absolute_y_axis_tolerance
            absolute_y_axis_tolerance = (rand.Next() + rand.NextDouble());
            //absolute_z_axis_tolerance
            absolute_z_axis_tolerance = (rand.Next() + rand.NextDouble());
            //weight
            weight = (rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.OrientationConstraint;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= orientation.Equals(other.orientation);
            ret &= link_name == other.link_name;
            ret &= absolute_x_axis_tolerance == other.absolute_x_axis_tolerance;
            ret &= absolute_y_axis_tolerance == other.absolute_y_axis_tolerance;
            ret &= absolute_z_axis_tolerance == other.absolute_z_axis_tolerance;
            ret &= weight == other.weight;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
