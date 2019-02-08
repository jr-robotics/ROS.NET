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
    public class NavSatFix : RosMessage
    {

			public Header header = new Header();
			public Messages.sensor_msgs.NavSatStatus status = new Messages.sensor_msgs.NavSatStatus();
			public double latitude;
			public double longitude;
			public double altitude;
			public double[] position_covariance = new double[9];
			public const byte COVARIANCE_TYPE_UNKNOWN = 0;
			public const byte COVARIANCE_TYPE_APPROXIMATED = 1;
			public const byte COVARIANCE_TYPE_DIAGONAL_KNOWN = 2;
			public const byte COVARIANCE_TYPE_KNOWN = 3;
			public byte position_covariance_type;


        public override string MD5Sum() { return "2d3a8cd499b9b4a0249fb98fd05cfa48"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
NavSatStatus status
float64 latitude
float64 longitude
float64 altitude
float64[9] position_covariance
uint8 COVARIANCE_TYPE_UNKNOWN=0
uint8 COVARIANCE_TYPE_APPROXIMATED=1
uint8 COVARIANCE_TYPE_DIAGONAL_KNOWN=2
uint8 COVARIANCE_TYPE_KNOWN=3
uint8 position_covariance_type"; }
        public override string MessageType { get { return "sensor_msgs/NavSatFix"; } }
        public override bool IsServiceComponent() { return false; }

        public NavSatFix()
        {
            
        }

        public NavSatFix(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public NavSatFix(byte[] serializedMessage, ref int currentIndex)
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
            //status
            status = new Messages.sensor_msgs.NavSatStatus(serializedMessage, ref currentIndex);
            //latitude
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            latitude = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //longitude
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            longitude = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //altitude
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            altitude = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //position_covariance
            hasmetacomponents |= false;
            if (position_covariance == null)
                position_covariance = new double[9];
            else
                Array.Resize(ref position_covariance, 9);
// Start Xamla
                //position_covariance
                piecesize = Marshal.SizeOf(typeof(double)) * position_covariance.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, position_covariance, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //position_covariance_type
            position_covariance_type=serializedMessage[currentIndex++];
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
            //status
            if (status == null)
                status = new Messages.sensor_msgs.NavSatStatus();
            pieces.Add(status.Serialize(true));
            //latitude
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(latitude, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //longitude
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(longitude, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //altitude
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(altitude, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //position_covariance
            hasmetacomponents |= false;
            if (position_covariance == null)
                position_covariance = new double[0];
// Start Xamla
                //position_covariance
                x__size = Marshal.SizeOf(typeof(double)) * position_covariance.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(position_covariance, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //position_covariance_type
            pieces.Add(new[] { (byte)position_covariance_type });
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
            //status
            status = new Messages.sensor_msgs.NavSatStatus();
            status.Randomize();
            //latitude
            latitude = (rand.Next() + rand.NextDouble());
            //longitude
            longitude = (rand.Next() + rand.NextDouble());
            //altitude
            altitude = (rand.Next() + rand.NextDouble());
            //position_covariance
            if (position_covariance == null)
                position_covariance = new double[9];
            else
                Array.Resize(ref position_covariance, 9);
            for (int i=0;i<position_covariance.Length; i++) {
                //position_covariance[i]
                position_covariance[i] = (rand.Next() + rand.NextDouble());
            }
            //position_covariance_type
            myByte = new byte[1];
            rand.NextBytes(myByte);
            position_covariance_type= myByte[0];
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.sensor_msgs.NavSatFix;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= status.Equals(other.status);
            ret &= latitude == other.latitude;
            ret &= longitude == other.longitude;
            ret &= altitude == other.altitude;
            if (position_covariance.Length != other.position_covariance.Length)
                return false;
            for (int __i__=0; __i__ < position_covariance.Length; __i__++)
            {
                ret &= position_covariance[__i__] == other.position_covariance[__i__];
            }
            ret &= position_covariance_type == other.position_covariance_type;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
