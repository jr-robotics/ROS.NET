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

namespace Messages.baxter_core_msgs
{
    public class DigitalIOState : RosMessage
    {

			public sbyte state;
			public bool isInputOnly;
			public const sbyte OFF = 0;
			public const sbyte ON  = 1;
			public const sbyte PRESSED = 1;
			public const sbyte UNPRESSED = 0;


        public override string MD5Sum() { return "29d0be3859dae81a66b28f167ecec98c"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"int8 state
bool isInputOnly
int8 OFF=0
int8 ON=1
int8 PRESSED=1
int8 UNPRESSED=0"; }
        public override string MessageType { get { return "baxter_core_msgs/DigitalIOState"; } }
        public override bool IsServiceComponent() { return false; }

        public DigitalIOState()
        {
            
        }

        public DigitalIOState(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public DigitalIOState(byte[] serializedMessage, ref int currentIndex)
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
            
            //state
            piecesize = Marshal.SizeOf(typeof(sbyte));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            state = (sbyte)Marshal.PtrToStructure(h, typeof(sbyte));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //isInputOnly
            isInputOnly = serializedMessage[currentIndex++]==1;
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
            
            //state
            scratch1 = new byte[Marshal.SizeOf(typeof(sbyte))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(state, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //isInputOnly
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)isInputOnly ? 1 : 0 );
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
            
            //state
            state = (SByte)(rand.Next(255) - 127);
            //isInputOnly
            isInputOnly = rand.Next(2) == 1;
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.baxter_core_msgs.DigitalIOState;
            if (other == null)
                return false;
            ret &= state == other.state;
            ret &= isInputOnly == other.isInputOnly;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
