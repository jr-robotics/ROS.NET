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
    public class Constraints : RosMessage
    {

			public string name = "";
			public Messages.moveit_msgs.JointConstraint[] joint_constraints;
			public Messages.moveit_msgs.PositionConstraint[] position_constraints;
			public Messages.moveit_msgs.OrientationConstraint[] orientation_constraints;
			public Messages.moveit_msgs.VisibilityConstraint[] visibility_constraints;


        public override string MD5Sum() { return "8d5ce8d34ef26c65fb5d43c9e99bf6e0"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"string name
JointConstraint[] joint_constraints
PositionConstraint[] position_constraints
OrientationConstraint[] orientation_constraints
VisibilityConstraint[] visibility_constraints"; }
        public override string MessageType { get { return "moveit_msgs/Constraints"; } }
        public override bool IsServiceComponent() { return false; }

        public Constraints()
        {
            
        }

        public Constraints(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public Constraints(byte[] serializedMessage, ref int currentIndex)
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
            
            //name
            name = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //joint_constraints
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (joint_constraints == null)
                joint_constraints = new Messages.moveit_msgs.JointConstraint[arraylength];
            else
                Array.Resize(ref joint_constraints, arraylength);
            for (int i=0;i<joint_constraints.Length; i++) {
                //joint_constraints[i]
                joint_constraints[i] = new Messages.moveit_msgs.JointConstraint(serializedMessage, ref currentIndex);
            }
            //position_constraints
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (position_constraints == null)
                position_constraints = new Messages.moveit_msgs.PositionConstraint[arraylength];
            else
                Array.Resize(ref position_constraints, arraylength);
            for (int i=0;i<position_constraints.Length; i++) {
                //position_constraints[i]
                position_constraints[i] = new Messages.moveit_msgs.PositionConstraint(serializedMessage, ref currentIndex);
            }
            //orientation_constraints
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (orientation_constraints == null)
                orientation_constraints = new Messages.moveit_msgs.OrientationConstraint[arraylength];
            else
                Array.Resize(ref orientation_constraints, arraylength);
            for (int i=0;i<orientation_constraints.Length; i++) {
                //orientation_constraints[i]
                orientation_constraints[i] = new Messages.moveit_msgs.OrientationConstraint(serializedMessage, ref currentIndex);
            }
            //visibility_constraints
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (visibility_constraints == null)
                visibility_constraints = new Messages.moveit_msgs.VisibilityConstraint[arraylength];
            else
                Array.Resize(ref visibility_constraints, arraylength);
            for (int i=0;i<visibility_constraints.Length; i++) {
                //visibility_constraints[i]
                visibility_constraints[i] = new Messages.moveit_msgs.VisibilityConstraint(serializedMessage, ref currentIndex);
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
            
            //name
            if (name == null)
                name = "";
            scratch1 = Encoding.ASCII.GetBytes((string)name);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //joint_constraints
            hasmetacomponents |= true;
            if (joint_constraints == null)
                joint_constraints = new Messages.moveit_msgs.JointConstraint[0];
            pieces.Add(BitConverter.GetBytes(joint_constraints.Length));
            for (int i=0;i<joint_constraints.Length; i++) {
                //joint_constraints[i]
                if (joint_constraints[i] == null)
                    joint_constraints[i] = new Messages.moveit_msgs.JointConstraint();
                pieces.Add(joint_constraints[i].Serialize(true));
            }
            //position_constraints
            hasmetacomponents |= true;
            if (position_constraints == null)
                position_constraints = new Messages.moveit_msgs.PositionConstraint[0];
            pieces.Add(BitConverter.GetBytes(position_constraints.Length));
            for (int i=0;i<position_constraints.Length; i++) {
                //position_constraints[i]
                if (position_constraints[i] == null)
                    position_constraints[i] = new Messages.moveit_msgs.PositionConstraint();
                pieces.Add(position_constraints[i].Serialize(true));
            }
            //orientation_constraints
            hasmetacomponents |= true;
            if (orientation_constraints == null)
                orientation_constraints = new Messages.moveit_msgs.OrientationConstraint[0];
            pieces.Add(BitConverter.GetBytes(orientation_constraints.Length));
            for (int i=0;i<orientation_constraints.Length; i++) {
                //orientation_constraints[i]
                if (orientation_constraints[i] == null)
                    orientation_constraints[i] = new Messages.moveit_msgs.OrientationConstraint();
                pieces.Add(orientation_constraints[i].Serialize(true));
            }
            //visibility_constraints
            hasmetacomponents |= true;
            if (visibility_constraints == null)
                visibility_constraints = new Messages.moveit_msgs.VisibilityConstraint[0];
            pieces.Add(BitConverter.GetBytes(visibility_constraints.Length));
            for (int i=0;i<visibility_constraints.Length; i++) {
                //visibility_constraints[i]
                if (visibility_constraints[i] == null)
                    visibility_constraints[i] = new Messages.moveit_msgs.VisibilityConstraint();
                pieces.Add(visibility_constraints[i].Serialize(true));
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
            
            //name
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            name = Encoding.ASCII.GetString(strbuf);
            //joint_constraints
            arraylength = rand.Next(10);
            if (joint_constraints == null)
                joint_constraints = new Messages.moveit_msgs.JointConstraint[arraylength];
            else
                Array.Resize(ref joint_constraints, arraylength);
            for (int i=0;i<joint_constraints.Length; i++) {
                //joint_constraints[i]
                joint_constraints[i] = new Messages.moveit_msgs.JointConstraint();
                joint_constraints[i].Randomize();
            }
            //position_constraints
            arraylength = rand.Next(10);
            if (position_constraints == null)
                position_constraints = new Messages.moveit_msgs.PositionConstraint[arraylength];
            else
                Array.Resize(ref position_constraints, arraylength);
            for (int i=0;i<position_constraints.Length; i++) {
                //position_constraints[i]
                position_constraints[i] = new Messages.moveit_msgs.PositionConstraint();
                position_constraints[i].Randomize();
            }
            //orientation_constraints
            arraylength = rand.Next(10);
            if (orientation_constraints == null)
                orientation_constraints = new Messages.moveit_msgs.OrientationConstraint[arraylength];
            else
                Array.Resize(ref orientation_constraints, arraylength);
            for (int i=0;i<orientation_constraints.Length; i++) {
                //orientation_constraints[i]
                orientation_constraints[i] = new Messages.moveit_msgs.OrientationConstraint();
                orientation_constraints[i].Randomize();
            }
            //visibility_constraints
            arraylength = rand.Next(10);
            if (visibility_constraints == null)
                visibility_constraints = new Messages.moveit_msgs.VisibilityConstraint[arraylength];
            else
                Array.Resize(ref visibility_constraints, arraylength);
            for (int i=0;i<visibility_constraints.Length; i++) {
                //visibility_constraints[i]
                visibility_constraints[i] = new Messages.moveit_msgs.VisibilityConstraint();
                visibility_constraints[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.Constraints;
            if (other == null)
                return false;
            ret &= name == other.name;
            if (joint_constraints.Length != other.joint_constraints.Length)
                return false;
            for (int __i__=0; __i__ < joint_constraints.Length; __i__++)
            {
                ret &= joint_constraints[__i__].Equals(other.joint_constraints[__i__]);
            }
            if (position_constraints.Length != other.position_constraints.Length)
                return false;
            for (int __i__=0; __i__ < position_constraints.Length; __i__++)
            {
                ret &= position_constraints[__i__].Equals(other.position_constraints[__i__]);
            }
            if (orientation_constraints.Length != other.orientation_constraints.Length)
                return false;
            for (int __i__=0; __i__ < orientation_constraints.Length; __i__++)
            {
                ret &= orientation_constraints[__i__].Equals(other.orientation_constraints[__i__]);
            }
            if (visibility_constraints.Length != other.visibility_constraints.Length)
                return false;
            for (int __i__=0; __i__ < visibility_constraints.Length; __i__++)
            {
                ret &= visibility_constraints[__i__].Equals(other.visibility_constraints[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
