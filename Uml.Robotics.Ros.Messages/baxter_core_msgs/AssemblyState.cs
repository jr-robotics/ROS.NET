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
    public class AssemblyState : RosMessage
    {

			public bool enabled;
			public bool stopped;
			public bool error;
			public byte  estop_button;
			public const byte   ESTOP_BUTTON_UNPRESSED = 0;
			public const byte   ESTOP_BUTTON_PRESSED   = 1;
			public const byte   ESTOP_BUTTON_UNKNOWN   = 2;
			public const byte   ESTOP_BUTTON_RELEASED  = 3;
			public byte  estop_source;
			public const byte  ESTOP_SOURCE_NONE      = 0;
			public const byte  ESTOP_SOURCE_USER      = 1;
			public const byte  ESTOP_SOURCE_UNKNOWN   = 2;
			public const byte  ESTOP_SOURCE_FAULT     = 3;
			public const byte  ESTOP_SOURCE_BRAIN     = 4;


        public override string MD5Sum() { return "d7ff2b9fa7d5f688665ce44db4ee2af8"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"bool enabled
bool stopped
bool error
uint8 estop_button
uint8 ESTOP_BUTTON_UNPRESSED=0
uint8 ESTOP_BUTTON_PRESSED=1
uint8 ESTOP_BUTTON_UNKNOWN=2
uint8 ESTOP_BUTTON_RELEASED=3
uint8 estop_source
uint8 ESTOP_SOURCE_NONE=0
uint8 ESTOP_SOURCE_USER=1
uint8 ESTOP_SOURCE_UNKNOWN=2
uint8 ESTOP_SOURCE_FAULT=3
uint8 ESTOP_SOURCE_BRAIN=4"; }
        public override string MessageType { get { return "baxter_core_msgs/AssemblyState"; } }
        public override bool IsServiceComponent() { return false; }

        public AssemblyState()
        {
            
        }

        public AssemblyState(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public AssemblyState(byte[] serializedMessage, ref int currentIndex)
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
            
            //enabled
            enabled = serializedMessage[currentIndex++]==1;
            //stopped
            stopped = serializedMessage[currentIndex++]==1;
            //error
            error = serializedMessage[currentIndex++]==1;
            //estop_button
            estop_button=serializedMessage[currentIndex++];
            //estop_source
            estop_source=serializedMessage[currentIndex++];
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
            
            //enabled
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)enabled ? 1 : 0 );
            pieces.Add(thischunk);
            //stopped
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)stopped ? 1 : 0 );
            pieces.Add(thischunk);
            //error
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)error ? 1 : 0 );
            pieces.Add(thischunk);
            //estop_button
            pieces.Add(new[] { (byte)estop_button });
            //estop_source
            pieces.Add(new[] { (byte)estop_source });
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
            
            //enabled
            enabled = rand.Next(2) == 1;
            //stopped
            stopped = rand.Next(2) == 1;
            //error
            error = rand.Next(2) == 1;
            //estop_button
            myByte = new byte[1];
            rand.NextBytes(myByte);
            estop_button= myByte[0];
            //estop_source
            myByte = new byte[1];
            rand.NextBytes(myByte);
            estop_source= myByte[0];
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.baxter_core_msgs.AssemblyState;
            if (other == null)
                return false;
            ret &= enabled == other.enabled;
            ret &= stopped == other.stopped;
            ret &= error == other.error;
            ret &= estop_button == other.estop_button;
            ret &= estop_source == other.estop_source;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
