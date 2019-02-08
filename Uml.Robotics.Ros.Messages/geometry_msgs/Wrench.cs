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

namespace Messages.geometry_msgs
{
    public class Wrench : RosMessage
    {

			public Vector3 force = new Vector3();
			public Vector3 torque = new Vector3();


        public override string MD5Sum() { return "4f539cf138b23283b520fd271b567936"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Vector3 force
Vector3 torque"; }
        public override string MessageType { get { return "geometry_msgs/Wrench"; } }
        public override bool IsServiceComponent() { return false; }

        public Wrench()
        {
            
        }

        public Wrench(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public Wrench(byte[] serializedMessage, ref int currentIndex)
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
            
            //force
            force = new Vector3(serializedMessage, ref currentIndex);
            //torque
            torque = new Vector3(serializedMessage, ref currentIndex);
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
            
            //force
            if (force == null)
                force = new Vector3();
            pieces.Add(force.Serialize(true));
            //torque
            if (torque == null)
                torque = new Vector3();
            pieces.Add(torque.Serialize(true));
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
            
            //force
            force = new Vector3();
            force.Randomize();
            //torque
            torque = new Vector3();
            torque.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.geometry_msgs.Wrench;
            if (other == null)
                return false;
            ret &= force.Equals(other.force);
            ret &= torque.Equals(other.torque);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
