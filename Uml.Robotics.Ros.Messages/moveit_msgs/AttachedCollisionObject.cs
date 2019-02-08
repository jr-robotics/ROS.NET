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
    public class AttachedCollisionObject : RosMessage
    {

			public string link_name = "";
			public Messages.moveit_msgs.CollisionObject @object = new Messages.moveit_msgs.CollisionObject();
			public string[] touch_links;
			public Messages.trajectory_msgs.JointTrajectory detach_posture = new Messages.trajectory_msgs.JointTrajectory();
			public double weight;


        public override string MD5Sum() { return "3ceac60b21e85bbd6c5b0ab9d476b752"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"string link_name
CollisionObject object
string[] touch_links
trajectory_msgs/JointTrajectory detach_posture
float64 weight"; }
        public override string MessageType { get { return "moveit_msgs/AttachedCollisionObject"; } }
        public override bool IsServiceComponent() { return false; }

        public AttachedCollisionObject()
        {
            
        }

        public AttachedCollisionObject(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public AttachedCollisionObject(byte[] serializedMessage, ref int currentIndex)
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
            
            //link_name
            link_name = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            link_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //@object
            @object = new Messages.moveit_msgs.CollisionObject(serializedMessage, ref currentIndex);
            //touch_links
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (touch_links == null)
                touch_links = new string[arraylength];
            else
                Array.Resize(ref touch_links, arraylength);
            for (int i=0;i<touch_links.Length; i++) {
                //touch_links[i]
                touch_links[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                touch_links[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
            }
            //detach_posture
            detach_posture = new Messages.trajectory_msgs.JointTrajectory(serializedMessage, ref currentIndex);
            //weight
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            weight = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
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
            
            //link_name
            if (link_name == null)
                link_name = "";
            scratch1 = Encoding.ASCII.GetBytes((string)link_name);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //@object
            if (@object == null)
                @object = new Messages.moveit_msgs.CollisionObject();
            pieces.Add(@object.Serialize(true));
            //touch_links
            hasmetacomponents |= false;
            if (touch_links == null)
                touch_links = new string[0];
            pieces.Add(BitConverter.GetBytes(touch_links.Length));
            for (int i=0;i<touch_links.Length; i++) {
                //touch_links[i]
                if (touch_links[i] == null)
                    touch_links[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)touch_links[i]);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
            }
            //detach_posture
            if (detach_posture == null)
                detach_posture = new Messages.trajectory_msgs.JointTrajectory();
            pieces.Add(detach_posture.Serialize(true));
            //weight
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(weight, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
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
            
            //link_name
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            link_name = Encoding.ASCII.GetString(strbuf);
            //@object
            @object = new Messages.moveit_msgs.CollisionObject();
            @object.Randomize();
            //touch_links
            arraylength = rand.Next(10);
            if (touch_links == null)
                touch_links = new string[arraylength];
            else
                Array.Resize(ref touch_links, arraylength);
            for (int i=0;i<touch_links.Length; i++) {
                //touch_links[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                touch_links[i] = Encoding.ASCII.GetString(strbuf);
            }
            //detach_posture
            detach_posture = new Messages.trajectory_msgs.JointTrajectory();
            detach_posture.Randomize();
            //weight
            weight = (rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.AttachedCollisionObject;
            if (other == null)
                return false;
            ret &= link_name == other.link_name;
            ret &= @object.Equals(other.@object);
            if (touch_links.Length != other.touch_links.Length)
                return false;
            for (int __i__=0; __i__ < touch_links.Length; __i__++)
            {
                ret &= touch_links[__i__] == other.touch_links[__i__];
            }
            ret &= detach_posture.Equals(other.detach_posture);
            ret &= weight == other.weight;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
