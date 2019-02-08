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

namespace Messages.trust_msgs
{
    public class InterfaceCommand : RosMessage
    {

			public string cmd = "";
			public const string CMD_FULL_AUTONOMY   = "full_autonomy";
			public const string CMD_ASSISTED   = "assisted";
			public const string CMD_BRAKE_ON   = "brake_on";
			public const string CMD_BRAKE_OFF   = "brake_off";
			public const string CMD_START_RUN   = "start_run";
			public const string CMD_STOP_RUN   = "stop_run";
			public const string CMD_QUIT_RUN   = "quit_run";
			public const string CMD_PAUSE_RUN   = "pause_run";
			public const string CMD_UNPAUSE_RUN   = "unpause_run";


        public override string MD5Sum() { return "69cd17f3df3159d4c2333ada468a9bc7"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"string cmd
string CMD_FULL_AUTONOMY=full_autonomy
string CMD_ASSISTED=assisted
string CMD_BRAKE_ON=brake_on
string CMD_BRAKE_OFF=brake_off
string CMD_START_RUN=start_run
string CMD_STOP_RUN=stop_run
string CMD_QUIT_RUN=quit_run
string CMD_PAUSE_RUN=pause_run
string CMD_UNPAUSE_RUN=unpause_run"; }
        public override string MessageType { get { return "trust_msgs/InterfaceCommand"; } }
        public override bool IsServiceComponent() { return false; }

        public InterfaceCommand()
        {
            
        }

        public InterfaceCommand(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public InterfaceCommand(byte[] serializedMessage, ref int currentIndex)
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
            
            //cmd
            cmd = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            cmd = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
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
            
            //cmd
            if (cmd == null)
                cmd = "";
            scratch1 = Encoding.ASCII.GetBytes((string)cmd);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
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
            
            //cmd
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            cmd = Encoding.ASCII.GetString(strbuf);
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.trust_msgs.InterfaceCommand;
            if (other == null)
                return false;
            ret &= cmd == other.cmd;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
