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

namespace Messages.dynamixel_msgs
{
    public class JointState : RosMessage
    {

			public Header header = new Header();
			public string name = "";
			public int[] motor_ids;
			public int[] motor_temps;
			public double goal_pos;
			public double current_pos;
			public double error;
			public double velocity;
			public double load;
			public bool is_moving;


        public override string MD5Sum() { return "2b8449320cde76616338e2539db27c32"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
string name
int32[] motor_ids
int32[] motor_temps
float64 goal_pos
float64 current_pos
float64 error
float64 velocity
float64 load
bool is_moving"; }
        public override string MessageType { get { return "dynamixel_msgs/JointState"; } }
        public override bool IsServiceComponent() { return false; }

        public JointState()
        {
            
        }

        public JointState(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public JointState(byte[] serializedMessage, ref int currentIndex)
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
            //name
            name = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //motor_ids
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (motor_ids == null)
                motor_ids = new int[arraylength];
            else
                Array.Resize(ref motor_ids, arraylength);
// Start Xamla
                //motor_ids
                piecesize = Marshal.SizeOf(typeof(int)) * motor_ids.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, motor_ids, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //motor_temps
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (motor_temps == null)
                motor_temps = new int[arraylength];
            else
                Array.Resize(ref motor_temps, arraylength);
// Start Xamla
                //motor_temps
                piecesize = Marshal.SizeOf(typeof(int)) * motor_temps.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, motor_temps, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //goal_pos
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            goal_pos = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //current_pos
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            current_pos = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //error
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            error = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //velocity
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            velocity = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //load
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            load = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //is_moving
            is_moving = serializedMessage[currentIndex++]==1;
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
            //name
            if (name == null)
                name = "";
            scratch1 = Encoding.ASCII.GetBytes((string)name);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //motor_ids
            hasmetacomponents |= false;
            if (motor_ids == null)
                motor_ids = new int[0];
            pieces.Add(BitConverter.GetBytes(motor_ids.Length));
// Start Xamla
                //motor_ids
                x__size = Marshal.SizeOf(typeof(int)) * motor_ids.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(motor_ids, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //motor_temps
            hasmetacomponents |= false;
            if (motor_temps == null)
                motor_temps = new int[0];
            pieces.Add(BitConverter.GetBytes(motor_temps.Length));
// Start Xamla
                //motor_temps
                x__size = Marshal.SizeOf(typeof(int)) * motor_temps.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(motor_temps, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //goal_pos
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(goal_pos, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //current_pos
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(current_pos, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //error
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(error, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //velocity
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(velocity, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //load
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(load, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //is_moving
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)is_moving ? 1 : 0 );
            pieces.Add(thischunk);
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
            //name
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            name = Encoding.ASCII.GetString(strbuf);
            //motor_ids
            arraylength = rand.Next(10);
            if (motor_ids == null)
                motor_ids = new int[arraylength];
            else
                Array.Resize(ref motor_ids, arraylength);
            for (int i=0;i<motor_ids.Length; i++) {
                //motor_ids[i]
                motor_ids[i] = rand.Next();
            }
            //motor_temps
            arraylength = rand.Next(10);
            if (motor_temps == null)
                motor_temps = new int[arraylength];
            else
                Array.Resize(ref motor_temps, arraylength);
            for (int i=0;i<motor_temps.Length; i++) {
                //motor_temps[i]
                motor_temps[i] = rand.Next();
            }
            //goal_pos
            goal_pos = (rand.Next() + rand.NextDouble());
            //current_pos
            current_pos = (rand.Next() + rand.NextDouble());
            //error
            error = (rand.Next() + rand.NextDouble());
            //velocity
            velocity = (rand.Next() + rand.NextDouble());
            //load
            load = (rand.Next() + rand.NextDouble());
            //is_moving
            is_moving = rand.Next(2) == 1;
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.dynamixel_msgs.JointState;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= name == other.name;
            if (motor_ids.Length != other.motor_ids.Length)
                return false;
            for (int __i__=0; __i__ < motor_ids.Length; __i__++)
            {
                ret &= motor_ids[__i__] == other.motor_ids[__i__];
            }
            if (motor_temps.Length != other.motor_temps.Length)
                return false;
            for (int __i__=0; __i__ < motor_temps.Length; __i__++)
            {
                ret &= motor_temps[__i__] == other.motor_temps[__i__];
            }
            ret &= goal_pos == other.goal_pos;
            ret &= current_pos == other.current_pos;
            ret &= error == other.error;
            ret &= velocity == other.velocity;
            ret &= load == other.load;
            ret &= is_moving == other.is_moving;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
