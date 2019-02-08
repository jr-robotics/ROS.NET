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
    public class DisplayRobotState : RosMessage
    {

			public Messages.moveit_msgs.RobotState state = new Messages.moveit_msgs.RobotState();
			public Messages.moveit_msgs.ObjectColor[] highlight_links;


        public override string MD5Sum() { return "6a3bab3a33a8c47aee24481a455a21aa"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"RobotState state
ObjectColor[] highlight_links"; }
        public override string MessageType { get { return "moveit_msgs/DisplayRobotState"; } }
        public override bool IsServiceComponent() { return false; }

        public DisplayRobotState()
        {
            
        }

        public DisplayRobotState(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public DisplayRobotState(byte[] serializedMessage, ref int currentIndex)
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
            state = new Messages.moveit_msgs.RobotState(serializedMessage, ref currentIndex);
            //highlight_links
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (highlight_links == null)
                highlight_links = new Messages.moveit_msgs.ObjectColor[arraylength];
            else
                Array.Resize(ref highlight_links, arraylength);
            for (int i=0;i<highlight_links.Length; i++) {
                //highlight_links[i]
                highlight_links[i] = new Messages.moveit_msgs.ObjectColor(serializedMessage, ref currentIndex);
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
            
            //state
            if (state == null)
                state = new Messages.moveit_msgs.RobotState();
            pieces.Add(state.Serialize(true));
            //highlight_links
            hasmetacomponents |= true;
            if (highlight_links == null)
                highlight_links = new Messages.moveit_msgs.ObjectColor[0];
            pieces.Add(BitConverter.GetBytes(highlight_links.Length));
            for (int i=0;i<highlight_links.Length; i++) {
                //highlight_links[i]
                if (highlight_links[i] == null)
                    highlight_links[i] = new Messages.moveit_msgs.ObjectColor();
                pieces.Add(highlight_links[i].Serialize(true));
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
            
            //state
            state = new Messages.moveit_msgs.RobotState();
            state.Randomize();
            //highlight_links
            arraylength = rand.Next(10);
            if (highlight_links == null)
                highlight_links = new Messages.moveit_msgs.ObjectColor[arraylength];
            else
                Array.Resize(ref highlight_links, arraylength);
            for (int i=0;i<highlight_links.Length; i++) {
                //highlight_links[i]
                highlight_links[i] = new Messages.moveit_msgs.ObjectColor();
                highlight_links[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.DisplayRobotState;
            if (other == null)
                return false;
            ret &= state.Equals(other.state);
            if (highlight_links.Length != other.highlight_links.Length)
                return false;
            for (int __i__=0; __i__ < highlight_links.Length; __i__++)
            {
                ret &= highlight_links[__i__].Equals(other.highlight_links[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
