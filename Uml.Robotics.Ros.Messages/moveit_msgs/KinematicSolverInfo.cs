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
    public class KinematicSolverInfo : RosMessage
    {

			public string[] joint_names;
			public Messages.moveit_msgs.JointLimits[] limits;
			public string[] link_names;


        public override string MD5Sum() { return "cc048557c0f9795c392dd80f8bb00489"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"string[] joint_names
moveit_msgs/JointLimits[] limits
string[] link_names"; }
        public override string MessageType { get { return "moveit_msgs/KinematicSolverInfo"; } }
        public override bool IsServiceComponent() { return false; }

        public KinematicSolverInfo()
        {
            
        }

        public KinematicSolverInfo(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public KinematicSolverInfo(byte[] serializedMessage, ref int currentIndex)
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
            
            //joint_names
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (joint_names == null)
                joint_names = new string[arraylength];
            else
                Array.Resize(ref joint_names, arraylength);
            for (int i=0;i<joint_names.Length; i++) {
                //joint_names[i]
                joint_names[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                joint_names[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
            }
            //limits
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (limits == null)
                limits = new Messages.moveit_msgs.JointLimits[arraylength];
            else
                Array.Resize(ref limits, arraylength);
            for (int i=0;i<limits.Length; i++) {
                //limits[i]
                limits[i] = new Messages.moveit_msgs.JointLimits(serializedMessage, ref currentIndex);
            }
            //link_names
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (link_names == null)
                link_names = new string[arraylength];
            else
                Array.Resize(ref link_names, arraylength);
            for (int i=0;i<link_names.Length; i++) {
                //link_names[i]
                link_names[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                link_names[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
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
            
            //joint_names
            hasmetacomponents |= false;
            if (joint_names == null)
                joint_names = new string[0];
            pieces.Add(BitConverter.GetBytes(joint_names.Length));
            for (int i=0;i<joint_names.Length; i++) {
                //joint_names[i]
                if (joint_names[i] == null)
                    joint_names[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)joint_names[i]);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
            }
            //limits
            hasmetacomponents |= true;
            if (limits == null)
                limits = new Messages.moveit_msgs.JointLimits[0];
            pieces.Add(BitConverter.GetBytes(limits.Length));
            for (int i=0;i<limits.Length; i++) {
                //limits[i]
                if (limits[i] == null)
                    limits[i] = new Messages.moveit_msgs.JointLimits();
                pieces.Add(limits[i].Serialize(true));
            }
            //link_names
            hasmetacomponents |= false;
            if (link_names == null)
                link_names = new string[0];
            pieces.Add(BitConverter.GetBytes(link_names.Length));
            for (int i=0;i<link_names.Length; i++) {
                //link_names[i]
                if (link_names[i] == null)
                    link_names[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)link_names[i]);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
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
            
            //joint_names
            arraylength = rand.Next(10);
            if (joint_names == null)
                joint_names = new string[arraylength];
            else
                Array.Resize(ref joint_names, arraylength);
            for (int i=0;i<joint_names.Length; i++) {
                //joint_names[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                joint_names[i] = Encoding.ASCII.GetString(strbuf);
            }
            //limits
            arraylength = rand.Next(10);
            if (limits == null)
                limits = new Messages.moveit_msgs.JointLimits[arraylength];
            else
                Array.Resize(ref limits, arraylength);
            for (int i=0;i<limits.Length; i++) {
                //limits[i]
                limits[i] = new Messages.moveit_msgs.JointLimits();
                limits[i].Randomize();
            }
            //link_names
            arraylength = rand.Next(10);
            if (link_names == null)
                link_names = new string[arraylength];
            else
                Array.Resize(ref link_names, arraylength);
            for (int i=0;i<link_names.Length; i++) {
                //link_names[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                link_names[i] = Encoding.ASCII.GetString(strbuf);
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.KinematicSolverInfo;
            if (other == null)
                return false;
            if (joint_names.Length != other.joint_names.Length)
                return false;
            for (int __i__=0; __i__ < joint_names.Length; __i__++)
            {
                ret &= joint_names[__i__] == other.joint_names[__i__];
            }
            if (limits.Length != other.limits.Length)
                return false;
            for (int __i__=0; __i__ < limits.Length; __i__++)
            {
                ret &= limits[__i__].Equals(other.limits[__i__]);
            }
            if (link_names.Length != other.link_names.Length)
                return false;
            for (int __i__=0; __i__ < link_names.Length; __i__++)
            {
                ret &= link_names[__i__] == other.link_names[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
