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
    public class ModelState : RosMessage
    {

			public string model_name = "";
			public Messages.geometry_msgs.Pose pose = new Messages.geometry_msgs.Pose();
			public Messages.geometry_msgs.Twist twist = new Messages.geometry_msgs.Twist();
			public string reference_frame = "";


        public override string MD5Sum() { return "9330fd35f2fcd82d457e54bd54e10593"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"string model_name
geometry_msgs/Pose pose
geometry_msgs/Twist twist
string reference_frame"; }
        public override string MessageType { get { return "gazebo_msgs/ModelState"; } }
        public override bool IsServiceComponent() { return false; }

        public ModelState()
        {
            
        }

        public ModelState(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public ModelState(byte[] serializedMessage, ref int currentIndex)
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
            
            //model_name
            model_name = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            model_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //pose
            pose = new Messages.geometry_msgs.Pose(serializedMessage, ref currentIndex);
            //twist
            twist = new Messages.geometry_msgs.Twist(serializedMessage, ref currentIndex);
            //reference_frame
            reference_frame = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            reference_frame = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
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
            
            //model_name
            if (model_name == null)
                model_name = "";
            scratch1 = Encoding.ASCII.GetBytes((string)model_name);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //pose
            if (pose == null)
                pose = new Messages.geometry_msgs.Pose();
            pieces.Add(pose.Serialize(true));
            //twist
            if (twist == null)
                twist = new Messages.geometry_msgs.Twist();
            pieces.Add(twist.Serialize(true));
            //reference_frame
            if (reference_frame == null)
                reference_frame = "";
            scratch1 = Encoding.ASCII.GetBytes((string)reference_frame);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
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
            
            //model_name
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            model_name = Encoding.ASCII.GetString(strbuf);
            //pose
            pose = new Messages.geometry_msgs.Pose();
            pose.Randomize();
            //twist
            twist = new Messages.geometry_msgs.Twist();
            twist.Randomize();
            //reference_frame
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            reference_frame = Encoding.ASCII.GetString(strbuf);
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.gazebo_msgs.ModelState;
            if (other == null)
                return false;
            ret &= model_name == other.model_name;
            ret &= pose.Equals(other.pose);
            ret &= twist.Equals(other.twist);
            ret &= reference_frame == other.reference_frame;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
