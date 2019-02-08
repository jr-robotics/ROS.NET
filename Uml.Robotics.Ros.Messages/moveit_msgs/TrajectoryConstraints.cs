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
    public class TrajectoryConstraints : RosMessage
    {

			public Messages.moveit_msgs.Constraints[] constraints;


        public override string MD5Sum() { return "461e1a732dfebb01e7d6c75d51a51eac"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Constraints[] constraints"; }
        public override string MessageType { get { return "moveit_msgs/TrajectoryConstraints"; } }
        public override bool IsServiceComponent() { return false; }

        public TrajectoryConstraints()
        {
            
        }

        public TrajectoryConstraints(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public TrajectoryConstraints(byte[] serializedMessage, ref int currentIndex)
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
            
            //constraints
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (constraints == null)
                constraints = new Messages.moveit_msgs.Constraints[arraylength];
            else
                Array.Resize(ref constraints, arraylength);
            for (int i=0;i<constraints.Length; i++) {
                //constraints[i]
                constraints[i] = new Messages.moveit_msgs.Constraints(serializedMessage, ref currentIndex);
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
            
            //constraints
            hasmetacomponents |= true;
            if (constraints == null)
                constraints = new Messages.moveit_msgs.Constraints[0];
            pieces.Add(BitConverter.GetBytes(constraints.Length));
            for (int i=0;i<constraints.Length; i++) {
                //constraints[i]
                if (constraints[i] == null)
                    constraints[i] = new Messages.moveit_msgs.Constraints();
                pieces.Add(constraints[i].Serialize(true));
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
            
            //constraints
            arraylength = rand.Next(10);
            if (constraints == null)
                constraints = new Messages.moveit_msgs.Constraints[arraylength];
            else
                Array.Resize(ref constraints, arraylength);
            for (int i=0;i<constraints.Length; i++) {
                //constraints[i]
                constraints[i] = new Messages.moveit_msgs.Constraints();
                constraints[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.TrajectoryConstraints;
            if (other == null)
                return false;
            if (constraints.Length != other.constraints.Length)
                return false;
            for (int __i__=0; __i__ < constraints.Length; __i__++)
            {
                ret &= constraints[__i__].Equals(other.constraints[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
