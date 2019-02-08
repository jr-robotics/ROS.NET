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
    public class JointLimits : RosMessage
    {

			public string joint_name = "";
			public bool has_position_limits;
			public double min_position;
			public double max_position;
			public bool has_velocity_limits;
			public double max_velocity;
			public bool has_acceleration_limits;
			public double max_acceleration;


        public override string MD5Sum() { return "8ca618c7329ea46142cbc864a2efe856"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"string joint_name
bool has_position_limits
float64 min_position
float64 max_position
bool has_velocity_limits
float64 max_velocity
bool has_acceleration_limits
float64 max_acceleration"; }
        public override string MessageType { get { return "moveit_msgs/JointLimits"; } }
        public override bool IsServiceComponent() { return false; }

        public JointLimits()
        {
            
        }

        public JointLimits(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public JointLimits(byte[] serializedMessage, ref int currentIndex)
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
            
            //joint_name
            joint_name = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            joint_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //has_position_limits
            has_position_limits = serializedMessage[currentIndex++]==1;
            //min_position
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            min_position = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //max_position
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            max_position = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //has_velocity_limits
            has_velocity_limits = serializedMessage[currentIndex++]==1;
            //max_velocity
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            max_velocity = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //has_acceleration_limits
            has_acceleration_limits = serializedMessage[currentIndex++]==1;
            //max_acceleration
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            max_acceleration = (double)Marshal.PtrToStructure(h, typeof(double));
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
            
            //joint_name
            if (joint_name == null)
                joint_name = "";
            scratch1 = Encoding.ASCII.GetBytes((string)joint_name);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //has_position_limits
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)has_position_limits ? 1 : 0 );
            pieces.Add(thischunk);
            //min_position
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(min_position, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //max_position
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(max_position, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //has_velocity_limits
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)has_velocity_limits ? 1 : 0 );
            pieces.Add(thischunk);
            //max_velocity
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(max_velocity, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //has_acceleration_limits
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)has_acceleration_limits ? 1 : 0 );
            pieces.Add(thischunk);
            //max_acceleration
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(max_acceleration, h.AddrOfPinnedObject(), false);
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
            
            //joint_name
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            joint_name = Encoding.ASCII.GetString(strbuf);
            //has_position_limits
            has_position_limits = rand.Next(2) == 1;
            //min_position
            min_position = (rand.Next() + rand.NextDouble());
            //max_position
            max_position = (rand.Next() + rand.NextDouble());
            //has_velocity_limits
            has_velocity_limits = rand.Next(2) == 1;
            //max_velocity
            max_velocity = (rand.Next() + rand.NextDouble());
            //has_acceleration_limits
            has_acceleration_limits = rand.Next(2) == 1;
            //max_acceleration
            max_acceleration = (rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.JointLimits;
            if (other == null)
                return false;
            ret &= joint_name == other.joint_name;
            ret &= has_position_limits == other.has_position_limits;
            ret &= min_position == other.min_position;
            ret &= max_position == other.max_position;
            ret &= has_velocity_limits == other.has_velocity_limits;
            ret &= max_velocity == other.max_velocity;
            ret &= has_acceleration_limits == other.has_acceleration_limits;
            ret &= max_acceleration == other.max_acceleration;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
