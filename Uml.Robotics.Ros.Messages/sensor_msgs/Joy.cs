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
    public class Joy : RosMessage
    {

			public Header header = new Header();
			public Single[] axes;
			public int[] buttons;


        public override string MD5Sum() { return "5a9ea5f83505693b71e785041e67a8bb"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
float32[] axes
int32[] buttons"; }
        public override string MessageType { get { return "sensor_msgs/Joy"; } }
        public override bool IsServiceComponent() { return false; }

        public Joy()
        {
            
        }

        public Joy(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public Joy(byte[] serializedMessage, ref int currentIndex)
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
            //axes
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (axes == null)
                axes = new Single[arraylength];
            else
                Array.Resize(ref axes, arraylength);
// Start Xamla
                //axes
                piecesize = Marshal.SizeOf(typeof(Single)) * axes.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, axes, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //buttons
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (buttons == null)
                buttons = new int[arraylength];
            else
                Array.Resize(ref buttons, arraylength);
// Start Xamla
                //buttons
                piecesize = Marshal.SizeOf(typeof(int)) * buttons.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, buttons, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

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
            //axes
            hasmetacomponents |= false;
            if (axes == null)
                axes = new Single[0];
            pieces.Add(BitConverter.GetBytes(axes.Length));
// Start Xamla
                //axes
                x__size = Marshal.SizeOf(typeof(Single)) * axes.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(axes, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //buttons
            hasmetacomponents |= false;
            if (buttons == null)
                buttons = new int[0];
            pieces.Add(BitConverter.GetBytes(buttons.Length));
// Start Xamla
                //buttons
                x__size = Marshal.SizeOf(typeof(int)) * buttons.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(buttons, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

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
            //axes
            arraylength = rand.Next(10);
            if (axes == null)
                axes = new Single[arraylength];
            else
                Array.Resize(ref axes, arraylength);
            for (int i=0;i<axes.Length; i++) {
                //axes[i]
                axes[i] = (float)(rand.Next() + rand.NextDouble());
            }
            //buttons
            arraylength = rand.Next(10);
            if (buttons == null)
                buttons = new int[arraylength];
            else
                Array.Resize(ref buttons, arraylength);
            for (int i=0;i<buttons.Length; i++) {
                //buttons[i]
                buttons[i] = rand.Next();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.sensor_msgs.Joy;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            if (axes.Length != other.axes.Length)
                return false;
            for (int __i__=0; __i__ < axes.Length; __i__++)
            {
                ret &= axes[__i__] == other.axes[__i__];
            }
            if (buttons.Length != other.buttons.Length)
                return false;
            for (int __i__=0; __i__ < buttons.Length; __i__++)
            {
                ret &= buttons[__i__] == other.buttons[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
