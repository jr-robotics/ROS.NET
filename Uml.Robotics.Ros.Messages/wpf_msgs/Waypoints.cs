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

namespace Messages.wpf_msgs
{
    public class Waypoints : RosMessage
    {

			public int[] robots;
			public Messages.wpf_msgs.Point2[] path;


        public override string MD5Sum() { return "ecd896609fd827470735b1eee1359fa2"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"int32[] robots
Point2[] path"; }
        public override string MessageType { get { return "wpf_msgs/Waypoints"; } }
        public override bool IsServiceComponent() { return false; }

        public Waypoints()
        {
            
        }

        public Waypoints(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public Waypoints(byte[] serializedMessage, ref int currentIndex)
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
            
            //robots
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (robots == null)
                robots = new int[arraylength];
            else
                Array.Resize(ref robots, arraylength);
// Start Xamla
                //robots
                piecesize = Marshal.SizeOf(typeof(int)) * robots.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, robots, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //path
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (path == null)
                path = new Messages.wpf_msgs.Point2[arraylength];
            else
                Array.Resize(ref path, arraylength);
            for (int i=0;i<path.Length; i++) {
                //path[i]
                path[i] = new Messages.wpf_msgs.Point2(serializedMessage, ref currentIndex);
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
            
            //robots
            hasmetacomponents |= false;
            if (robots == null)
                robots = new int[0];
            pieces.Add(BitConverter.GetBytes(robots.Length));
// Start Xamla
                //robots
                x__size = Marshal.SizeOf(typeof(int)) * robots.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(robots, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //path
            hasmetacomponents |= true;
            if (path == null)
                path = new Messages.wpf_msgs.Point2[0];
            pieces.Add(BitConverter.GetBytes(path.Length));
            for (int i=0;i<path.Length; i++) {
                //path[i]
                if (path[i] == null)
                    path[i] = new Messages.wpf_msgs.Point2();
                pieces.Add(path[i].Serialize(true));
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
            
            //robots
            arraylength = rand.Next(10);
            if (robots == null)
                robots = new int[arraylength];
            else
                Array.Resize(ref robots, arraylength);
            for (int i=0;i<robots.Length; i++) {
                //robots[i]
                robots[i] = rand.Next();
            }
            //path
            arraylength = rand.Next(10);
            if (path == null)
                path = new Messages.wpf_msgs.Point2[arraylength];
            else
                Array.Resize(ref path, arraylength);
            for (int i=0;i<path.Length; i++) {
                //path[i]
                path[i] = new Messages.wpf_msgs.Point2();
                path[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.wpf_msgs.Waypoints;
            if (other == null)
                return false;
            if (robots.Length != other.robots.Length)
                return false;
            for (int __i__=0; __i__ < robots.Length; __i__++)
            {
                ret &= robots[__i__] == other.robots[__i__];
            }
            if (path.Length != other.path.Length)
                return false;
            for (int __i__=0; __i__ < path.Length; __i__++)
            {
                ret &= path[__i__].Equals(other.path[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
