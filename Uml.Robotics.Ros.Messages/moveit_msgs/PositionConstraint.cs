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
    public class PositionConstraint : RosMessage
    {

			public Header header = new Header();
			public string link_name = "";
			public Messages.geometry_msgs.Vector3 target_point_offset = new Messages.geometry_msgs.Vector3();
			public Messages.moveit_msgs.BoundingVolume constraint_region = new Messages.moveit_msgs.BoundingVolume();
			public double weight;


        public override string MD5Sum() { return "c83edf208d87d3aa3169f47775a58e6a"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
string link_name
geometry_msgs/Vector3 target_point_offset
BoundingVolume constraint_region
float64 weight"; }
        public override string MessageType { get { return "moveit_msgs/PositionConstraint"; } }
        public override bool IsServiceComponent() { return false; }

        public PositionConstraint()
        {
            
        }

        public PositionConstraint(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PositionConstraint(byte[] serializedMessage, ref int currentIndex)
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
            //link_name
            link_name = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            link_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //target_point_offset
            target_point_offset = new Messages.geometry_msgs.Vector3(serializedMessage, ref currentIndex);
            //constraint_region
            constraint_region = new Messages.moveit_msgs.BoundingVolume(serializedMessage, ref currentIndex);
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
            //link_name
            if (link_name == null)
                link_name = "";
            scratch1 = Encoding.ASCII.GetBytes((string)link_name);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //target_point_offset
            if (target_point_offset == null)
                target_point_offset = new Messages.geometry_msgs.Vector3();
            pieces.Add(target_point_offset.Serialize(true));
            //constraint_region
            if (constraint_region == null)
                constraint_region = new Messages.moveit_msgs.BoundingVolume();
            pieces.Add(constraint_region.Serialize(true));
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
            //link_name
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            link_name = Encoding.ASCII.GetString(strbuf);
            //target_point_offset
            target_point_offset = new Messages.geometry_msgs.Vector3();
            target_point_offset.Randomize();
            //constraint_region
            constraint_region = new Messages.moveit_msgs.BoundingVolume();
            constraint_region.Randomize();
            //weight
            weight = (rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.PositionConstraint;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= link_name == other.link_name;
            ret &= target_point_offset.Equals(other.target_point_offset);
            ret &= constraint_region.Equals(other.constraint_region);
            ret &= weight == other.weight;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
