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
    public class Twist : RosMessage
    {

			public Vector3 linear = new Vector3();
			public Vector3 angular = new Vector3();


        public override string MD5Sum() { return "9f195f881246fdfa2798d1d3eebca84a"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Vector3 linear
Vector3 angular"; }
        public override string MessageType { get { return "geometry_msgs/Twist"; } }
        public override bool IsServiceComponent() { return false; }

        public Twist()
        {
            
        }

        public Twist(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public Twist(byte[] serializedMessage, ref int currentIndex)
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
            
            //linear
            linear = new Vector3(serializedMessage, ref currentIndex);
            //angular
            angular = new Vector3(serializedMessage, ref currentIndex);
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
            
            //linear
            if (linear == null)
                linear = new Vector3();
            pieces.Add(linear.Serialize(true));
            //angular
            if (angular == null)
                angular = new Vector3();
            pieces.Add(angular.Serialize(true));
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
            
            //linear
            linear = new Vector3();
            linear.Randomize();
            //angular
            angular = new Vector3();
            angular.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.geometry_msgs.Twist;
            if (other == null)
                return false;
            ret &= linear.Equals(other.linear);
            ret &= angular.Equals(other.angular);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
