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
    public class ContactInformation : RosMessage
    {

			public Header header = new Header();
			public Messages.geometry_msgs.Point position = new Messages.geometry_msgs.Point();
			public Messages.geometry_msgs.Vector3 normal = new Messages.geometry_msgs.Vector3();
			public double depth;
			public string contact_body_1 = "";
			public uint body_type_1;
			public string contact_body_2 = "";
			public uint body_type_2;
			public const uint ROBOT_LINK = 0U;
			public const uint WORLD_OBJECT = 1U;
			public const uint ROBOT_ATTACHED = 2U;


        public override string MD5Sum() { return "116228ca08b0c286ec5ca32a50fdc17b"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
geometry_msgs/Point position
geometry_msgs/Vector3 normal
float64 depth
string contact_body_1
uint32 body_type_1
string contact_body_2
uint32 body_type_2
uint32 ROBOT_LINK=0
uint32 WORLD_OBJECT=1
uint32 ROBOT_ATTACHED=2"; }
        public override string MessageType { get { return "moveit_msgs/ContactInformation"; } }
        public override bool IsServiceComponent() { return false; }

        public ContactInformation()
        {
            
        }

        public ContactInformation(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public ContactInformation(byte[] serializedMessage, ref int currentIndex)
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
            //position
            position = new Messages.geometry_msgs.Point(serializedMessage, ref currentIndex);
            //normal
            normal = new Messages.geometry_msgs.Vector3(serializedMessage, ref currentIndex);
            //depth
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            depth = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //contact_body_1
            contact_body_1 = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            contact_body_1 = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //body_type_1
            piecesize = Marshal.SizeOf(typeof(uint));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            body_type_1 = (uint)Marshal.PtrToStructure(h, typeof(uint));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //contact_body_2
            contact_body_2 = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            contact_body_2 = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //body_type_2
            piecesize = Marshal.SizeOf(typeof(uint));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            body_type_2 = (uint)Marshal.PtrToStructure(h, typeof(uint));
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
            //position
            if (position == null)
                position = new Messages.geometry_msgs.Point();
            pieces.Add(position.Serialize(true));
            //normal
            if (normal == null)
                normal = new Messages.geometry_msgs.Vector3();
            pieces.Add(normal.Serialize(true));
            //depth
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(depth, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //contact_body_1
            if (contact_body_1 == null)
                contact_body_1 = "";
            scratch1 = Encoding.ASCII.GetBytes((string)contact_body_1);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //body_type_1
            scratch1 = new byte[Marshal.SizeOf(typeof(uint))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(body_type_1, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //contact_body_2
            if (contact_body_2 == null)
                contact_body_2 = "";
            scratch1 = Encoding.ASCII.GetBytes((string)contact_body_2);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //body_type_2
            scratch1 = new byte[Marshal.SizeOf(typeof(uint))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(body_type_2, h.AddrOfPinnedObject(), false);
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
            //position
            position = new Messages.geometry_msgs.Point();
            position.Randomize();
            //normal
            normal = new Messages.geometry_msgs.Vector3();
            normal.Randomize();
            //depth
            depth = (rand.Next() + rand.NextDouble());
            //contact_body_1
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            contact_body_1 = Encoding.ASCII.GetString(strbuf);
            //body_type_1
            body_type_1 = (uint)rand.Next();
            //contact_body_2
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            contact_body_2 = Encoding.ASCII.GetString(strbuf);
            //body_type_2
            body_type_2 = (uint)rand.Next();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.ContactInformation;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= position.Equals(other.position);
            ret &= normal.Equals(other.normal);
            ret &= depth == other.depth;
            ret &= contact_body_1 == other.contact_body_1;
            ret &= body_type_1 == other.body_type_1;
            ret &= contact_body_2 == other.contact_body_2;
            ret &= body_type_2 == other.body_type_2;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
