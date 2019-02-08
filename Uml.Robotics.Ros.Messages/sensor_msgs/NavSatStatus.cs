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

namespace Messages.sensor_msgs
{
    public class NavSatStatus : RosMessage
    {

			public const sbyte STATUS_NO_FIX =  -1;
			public const sbyte STATUS_FIX =      0;
			public const sbyte STATUS_SBAS_FIX = 1;
			public const sbyte STATUS_GBAS_FIX = 2;
			public sbyte status;
			public const ushort SERVICE_GPS =     1;
			public const ushort SERVICE_GLONASS = 2;
			public const ushort SERVICE_COMPASS = 4;
			public const ushort SERVICE_GALILEO = 8;
			public ushort service;


        public override string MD5Sum() { return "331cdbddfa4bc96ffc3b9ad98900a54c"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"int8 STATUS_NO_FIX=-1
int8 STATUS_FIX=0
int8 STATUS_SBAS_FIX=1
int8 STATUS_GBAS_FIX=2
int8 status
uint16 SERVICE_GPS=1
uint16 SERVICE_GLONASS=2
uint16 SERVICE_COMPASS=4
uint16 SERVICE_GALILEO=8
uint16 service"; }
        public override string MessageType { get { return "sensor_msgs/NavSatStatus"; } }
        public override bool IsServiceComponent() { return false; }

        public NavSatStatus()
        {
            
        }

        public NavSatStatus(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public NavSatStatus(byte[] serializedMessage, ref int currentIndex)
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
            
            //status
            piecesize = Marshal.SizeOf(typeof(sbyte));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            status = (sbyte)Marshal.PtrToStructure(h, typeof(sbyte));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //service
            piecesize = Marshal.SizeOf(typeof(ushort));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            service = (ushort)Marshal.PtrToStructure(h, typeof(ushort));
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
            
            //status
            scratch1 = new byte[Marshal.SizeOf(typeof(sbyte))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(status, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //service
            scratch1 = new byte[Marshal.SizeOf(typeof(ushort))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(service, h.AddrOfPinnedObject(), false);
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
            
            //status
            status = (SByte)(rand.Next(255) - 127);
            //service
            service = (System.UInt16)rand.Next(System.UInt16.MaxValue + 1);
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.sensor_msgs.NavSatStatus;
            if (other == null)
                return false;
            ret &= status == other.status;
            ret &= service == other.service;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
