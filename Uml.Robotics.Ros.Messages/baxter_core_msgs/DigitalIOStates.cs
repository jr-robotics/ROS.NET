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
    public class DigitalIOStates : RosMessage
    {

			public string[]         names;
			public Messages.baxter_core_msgs.DigitalIOState[] states;


        public override string MD5Sum() { return "d434210c6ec20947fec667d6c13d6062"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"string[] names
DigitalIOState[] states"; }
        public override string MessageType { get { return "baxter_core_msgs/DigitalIOStates"; } }
        public override bool IsServiceComponent() { return false; }

        public DigitalIOStates()
        {
            
        }

        public DigitalIOStates(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public DigitalIOStates(byte[] serializedMessage, ref int currentIndex)
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
            
            //names
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (names == null)
                names = new string[arraylength];
            else
                Array.Resize(ref names, arraylength);
            for (int i=0;i<names.Length; i++) {
                //names[i]
                names[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                names[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
            }
            //states
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (states == null)
                states = new Messages.baxter_core_msgs.DigitalIOState[arraylength];
            else
                Array.Resize(ref states, arraylength);
            for (int i=0;i<states.Length; i++) {
                //states[i]
                states[i] = new Messages.baxter_core_msgs.DigitalIOState(serializedMessage, ref currentIndex);
            }
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
            
            //names
            hasmetacomponents |= false;
            if (names == null)
                names = new string[0];
            pieces.Add(BitConverter.GetBytes(names.Length));
            for (int i=0;i<names.Length; i++) {
                //names[i]
                if (names[i] == null)
                    names[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)names[i]);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
            }
            //states
            hasmetacomponents |= true;
            if (states == null)
                states = new Messages.baxter_core_msgs.DigitalIOState[0];
            pieces.Add(BitConverter.GetBytes(states.Length));
            for (int i=0;i<states.Length; i++) {
                //states[i]
                if (states[i] == null)
                    states[i] = new Messages.baxter_core_msgs.DigitalIOState();
                pieces.Add(states[i].Serialize(true));
            }
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
            
            //names
            arraylength = rand.Next(10);
            if (names == null)
                names = new string[arraylength];
            else
                Array.Resize(ref names, arraylength);
            for (int i=0;i<names.Length; i++) {
                //names[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                names[i] = Encoding.ASCII.GetString(strbuf);
            }
            //states
            arraylength = rand.Next(10);
            if (states == null)
                states = new Messages.baxter_core_msgs.DigitalIOState[arraylength];
            else
                Array.Resize(ref states, arraylength);
            for (int i=0;i<states.Length; i++) {
                //states[i]
                states[i] = new Messages.baxter_core_msgs.DigitalIOState();
                states[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.baxter_core_msgs.DigitalIOStates;
            if (other == null)
                return false;
            if (names.Length != other.names.Length)
                return false;
            for (int __i__=0; __i__ < names.Length; __i__++)
            {
                ret &= names[__i__] == other.names[__i__];
            }
            if (states.Length != other.states.Length)
                return false;
            for (int __i__=0; __i__ < states.Length; __i__++)
            {
                ret &= states[__i__].Equals(other.states[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
