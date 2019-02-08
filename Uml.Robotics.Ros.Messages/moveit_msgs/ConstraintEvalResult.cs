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
    public class ConstraintEvalResult : RosMessage
    {

			public bool result;
			public double distance;


        public override string MD5Sum() { return "093643083d24f6488cb5a868bd47c090"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"bool result
float64 distance"; }
        public override string MessageType { get { return "moveit_msgs/ConstraintEvalResult"; } }
        public override bool IsServiceComponent() { return false; }

        public ConstraintEvalResult()
        {
            
        }

        public ConstraintEvalResult(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public ConstraintEvalResult(byte[] serializedMessage, ref int currentIndex)
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
            
            //result
            result = serializedMessage[currentIndex++]==1;
            //distance
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            distance = (double)Marshal.PtrToStructure(h, typeof(double));
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
            
            //result
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)result ? 1 : 0 );
            pieces.Add(thischunk);
            //distance
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(distance, h.AddrOfPinnedObject(), false);
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
            
            //result
            result = rand.Next(2) == 1;
            //distance
            distance = (rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.ConstraintEvalResult;
            if (other == null)
                return false;
            ret &= result == other.result;
            ret &= distance == other.distance;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
