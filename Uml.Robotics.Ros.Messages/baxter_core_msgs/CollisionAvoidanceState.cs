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

namespace Messages.baxter_core_msgs
{
    public class CollisionAvoidanceState : RosMessage
    {

			public Messages.std_msgs.Header header = new Messages.std_msgs.Header();
			public bool other_arm;
			public string[] collision_object;


        public override string MD5Sum() { return "30f5cb8ae019f1ffe8b599e6d2e589c7"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"std_msgs/Header header
bool other_arm
string[] collision_object"; }
        public override string MessageType { get { return "baxter_core_msgs/CollisionAvoidanceState"; } }
        public override bool IsServiceComponent() { return false; }

        public CollisionAvoidanceState()
        {
            
        }

        public CollisionAvoidanceState(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public CollisionAvoidanceState(byte[] serializedMessage, ref int currentIndex)
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
            header = new Messages.std_msgs.Header(serializedMessage, ref currentIndex);
            //other_arm
            other_arm = serializedMessage[currentIndex++]==1;
            //collision_object
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (collision_object == null)
                collision_object = new string[arraylength];
            else
                Array.Resize(ref collision_object, arraylength);
            for (int i=0;i<collision_object.Length; i++) {
                //collision_object[i]
                collision_object[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                collision_object[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
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
            
            //header
            if (header == null)
                header = new Messages.std_msgs.Header();
            pieces.Add(header.Serialize(true));
            //other_arm
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)other_arm ? 1 : 0 );
            pieces.Add(thischunk);
            //collision_object
            hasmetacomponents |= false;
            if (collision_object == null)
                collision_object = new string[0];
            pieces.Add(BitConverter.GetBytes(collision_object.Length));
            for (int i=0;i<collision_object.Length; i++) {
                //collision_object[i]
                if (collision_object[i] == null)
                    collision_object[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)collision_object[i]);
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
            
            //header
            header = new Messages.std_msgs.Header();
            header.Randomize();
            //other_arm
            other_arm = rand.Next(2) == 1;
            //collision_object
            arraylength = rand.Next(10);
            if (collision_object == null)
                collision_object = new string[arraylength];
            else
                Array.Resize(ref collision_object, arraylength);
            for (int i=0;i<collision_object.Length; i++) {
                //collision_object[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                collision_object[i] = Encoding.ASCII.GetString(strbuf);
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.baxter_core_msgs.CollisionAvoidanceState;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            ret &= other_arm == other.other_arm;
            if (collision_object.Length != other.collision_object.Length)
                return false;
            for (int __i__=0; __i__ < collision_object.Length; __i__++)
            {
                ret &= collision_object[__i__] == other.collision_object[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
