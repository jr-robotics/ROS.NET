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

namespace Messages.gazebo_msgs
{
    public class WorldState : RosMessage
    {

			public Header header = new Header();
			public string[] name;
			public Messages.geometry_msgs.Pose[] pose;
			public Messages.geometry_msgs.Twist[] twist;
			public Messages.geometry_msgs.Wrench[] wrench;


        public override string MD5Sum() { return "de1a9de3ab7ba97ac0e9ec01a4eb481e"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
string[] name
geometry_msgs/Pose[] pose
geometry_msgs/Twist[] twist
geometry_msgs/Wrench[] wrench"; }
        public override string MessageType { get { return "gazebo_msgs/WorldState"; } }
        public override bool IsServiceComponent() { return false; }

        public WorldState()
        {
            
        }

        public WorldState(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public WorldState(byte[] serializedMessage, ref int currentIndex)
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
            //name
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (name == null)
                name = new string[arraylength];
            else
                Array.Resize(ref name, arraylength);
            for (int i=0;i<name.Length; i++) {
                //name[i]
                name[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                name[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
            }
            //pose
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (pose == null)
                pose = new Messages.geometry_msgs.Pose[arraylength];
            else
                Array.Resize(ref pose, arraylength);
            for (int i=0;i<pose.Length; i++) {
                //pose[i]
                pose[i] = new Messages.geometry_msgs.Pose(serializedMessage, ref currentIndex);
            }
            //twist
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (twist == null)
                twist = new Messages.geometry_msgs.Twist[arraylength];
            else
                Array.Resize(ref twist, arraylength);
            for (int i=0;i<twist.Length; i++) {
                //twist[i]
                twist[i] = new Messages.geometry_msgs.Twist(serializedMessage, ref currentIndex);
            }
            //wrench
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (wrench == null)
                wrench = new Messages.geometry_msgs.Wrench[arraylength];
            else
                Array.Resize(ref wrench, arraylength);
            for (int i=0;i<wrench.Length; i++) {
                //wrench[i]
                wrench[i] = new Messages.geometry_msgs.Wrench(serializedMessage, ref currentIndex);
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
            
            //header
            if (header == null)
                header = new Header();
            pieces.Add(header.Serialize(true));
            //name
            hasmetacomponents |= false;
            if (name == null)
                name = new string[0];
            pieces.Add(BitConverter.GetBytes(name.Length));
            for (int i=0;i<name.Length; i++) {
                //name[i]
                if (name[i] == null)
                    name[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)name[i]);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
            }
            //pose
            hasmetacomponents |= true;
            if (pose == null)
                pose = new Messages.geometry_msgs.Pose[0];
            pieces.Add(BitConverter.GetBytes(pose.Length));
            for (int i=0;i<pose.Length; i++) {
                //pose[i]
                if (pose[i] == null)
                    pose[i] = new Messages.geometry_msgs.Pose();
                pieces.Add(pose[i].Serialize(true));
            }
            //twist
            hasmetacomponents |= true;
            if (twist == null)
                twist = new Messages.geometry_msgs.Twist[0];
            pieces.Add(BitConverter.GetBytes(twist.Length));
            for (int i=0;i<twist.Length; i++) {
                //twist[i]
                if (twist[i] == null)
                    twist[i] = new Messages.geometry_msgs.Twist();
                pieces.Add(twist[i].Serialize(true));
            }
            //wrench
            hasmetacomponents |= true;
            if (wrench == null)
                wrench = new Messages.geometry_msgs.Wrench[0];
            pieces.Add(BitConverter.GetBytes(wrench.Length));
            for (int i=0;i<wrench.Length; i++) {
                //wrench[i]
                if (wrench[i] == null)
                    wrench[i] = new Messages.geometry_msgs.Wrench();
                pieces.Add(wrench[i].Serialize(true));
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
            
            //header
            header = new Header();
            header.Randomize();
            //name
            arraylength = rand.Next(10);
            if (name == null)
                name = new string[arraylength];
            else
                Array.Resize(ref name, arraylength);
            for (int i=0;i<name.Length; i++) {
                //name[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                name[i] = Encoding.ASCII.GetString(strbuf);
            }
            //pose
            arraylength = rand.Next(10);
            if (pose == null)
                pose = new Messages.geometry_msgs.Pose[arraylength];
            else
                Array.Resize(ref pose, arraylength);
            for (int i=0;i<pose.Length; i++) {
                //pose[i]
                pose[i] = new Messages.geometry_msgs.Pose();
                pose[i].Randomize();
            }
            //twist
            arraylength = rand.Next(10);
            if (twist == null)
                twist = new Messages.geometry_msgs.Twist[arraylength];
            else
                Array.Resize(ref twist, arraylength);
            for (int i=0;i<twist.Length; i++) {
                //twist[i]
                twist[i] = new Messages.geometry_msgs.Twist();
                twist[i].Randomize();
            }
            //wrench
            arraylength = rand.Next(10);
            if (wrench == null)
                wrench = new Messages.geometry_msgs.Wrench[arraylength];
            else
                Array.Resize(ref wrench, arraylength);
            for (int i=0;i<wrench.Length; i++) {
                //wrench[i]
                wrench[i] = new Messages.geometry_msgs.Wrench();
                wrench[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.gazebo_msgs.WorldState;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            if (name.Length != other.name.Length)
                return false;
            for (int __i__=0; __i__ < name.Length; __i__++)
            {
                ret &= name[__i__] == other.name[__i__];
            }
            if (pose.Length != other.pose.Length)
                return false;
            for (int __i__=0; __i__ < pose.Length; __i__++)
            {
                ret &= pose[__i__].Equals(other.pose[__i__]);
            }
            if (twist.Length != other.twist.Length)
                return false;
            for (int __i__=0; __i__ < twist.Length; __i__++)
            {
                ret &= twist[__i__].Equals(other.twist[__i__]);
            }
            if (wrench.Length != other.wrench.Length)
                return false;
            for (int __i__=0; __i__ < wrench.Length; __i__++)
            {
                ret &= wrench[__i__].Equals(other.wrench[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
