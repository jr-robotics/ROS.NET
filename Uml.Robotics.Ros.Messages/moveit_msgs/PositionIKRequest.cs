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
    public class PositionIKRequest : RosMessage
    {

			public string group_name = "";
			public Messages.moveit_msgs.RobotState robot_state = new Messages.moveit_msgs.RobotState();
			public Messages.moveit_msgs.Constraints constraints = new Messages.moveit_msgs.Constraints();
			public bool avoid_collisions;
			public string ik_link_name = "";
			public Messages.geometry_msgs.PoseStamped pose_stamped = new Messages.geometry_msgs.PoseStamped();
			public string[] ik_link_names;
			public Messages.geometry_msgs.PoseStamped[] pose_stamped_vector;
			public Duration timeout = new Duration();
			public int attempts;


        public override string MD5Sum() { return "9936dc239c90af180ec94a51596c96f2"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"string group_name
moveit_msgs/RobotState robot_state
Constraints constraints
bool avoid_collisions
string ik_link_name
geometry_msgs/PoseStamped pose_stamped
string[] ik_link_names
geometry_msgs/PoseStamped[] pose_stamped_vector
duration timeout
int32 attempts"; }
        public override string MessageType { get { return "moveit_msgs/PositionIKRequest"; } }
        public override bool IsServiceComponent() { return false; }

        public PositionIKRequest()
        {
            
        }

        public PositionIKRequest(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PositionIKRequest(byte[] serializedMessage, ref int currentIndex)
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
            
            //group_name
            group_name = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            group_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //robot_state
            robot_state = new Messages.moveit_msgs.RobotState(serializedMessage, ref currentIndex);
            //constraints
            constraints = new Messages.moveit_msgs.Constraints(serializedMessage, ref currentIndex);
            //avoid_collisions
            avoid_collisions = serializedMessage[currentIndex++]==1;
            //ik_link_name
            ik_link_name = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            ik_link_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //pose_stamped
            pose_stamped = new Messages.geometry_msgs.PoseStamped(serializedMessage, ref currentIndex);
            //ik_link_names
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (ik_link_names == null)
                ik_link_names = new string[arraylength];
            else
                Array.Resize(ref ik_link_names, arraylength);
            for (int i=0;i<ik_link_names.Length; i++) {
                //ik_link_names[i]
                ik_link_names[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                ik_link_names[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
            }
            //pose_stamped_vector
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (pose_stamped_vector == null)
                pose_stamped_vector = new Messages.geometry_msgs.PoseStamped[arraylength];
            else
                Array.Resize(ref pose_stamped_vector, arraylength);
            for (int i=0;i<pose_stamped_vector.Length; i++) {
                //pose_stamped_vector[i]
                pose_stamped_vector[i] = new Messages.geometry_msgs.PoseStamped(serializedMessage, ref currentIndex);
            }
            //timeout
            timeout = new Duration(new TimeData(
                    BitConverter.ToInt32(serializedMessage, currentIndex),
                    BitConverter.ToInt32(serializedMessage, currentIndex+Marshal.SizeOf(typeof(System.Int32)))));
            currentIndex += 2*Marshal.SizeOf(typeof(System.Int32));
            //attempts
            piecesize = Marshal.SizeOf(typeof(int));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            attempts = (int)Marshal.PtrToStructure(h, typeof(int));
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
            
            //group_name
            if (group_name == null)
                group_name = "";
            scratch1 = Encoding.ASCII.GetBytes((string)group_name);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //robot_state
            if (robot_state == null)
                robot_state = new Messages.moveit_msgs.RobotState();
            pieces.Add(robot_state.Serialize(true));
            //constraints
            if (constraints == null)
                constraints = new Messages.moveit_msgs.Constraints();
            pieces.Add(constraints.Serialize(true));
            //avoid_collisions
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)avoid_collisions ? 1 : 0 );
            pieces.Add(thischunk);
            //ik_link_name
            if (ik_link_name == null)
                ik_link_name = "";
            scratch1 = Encoding.ASCII.GetBytes((string)ik_link_name);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //pose_stamped
            if (pose_stamped == null)
                pose_stamped = new Messages.geometry_msgs.PoseStamped();
            pieces.Add(pose_stamped.Serialize(true));
            //ik_link_names
            hasmetacomponents |= false;
            if (ik_link_names == null)
                ik_link_names = new string[0];
            pieces.Add(BitConverter.GetBytes(ik_link_names.Length));
            for (int i=0;i<ik_link_names.Length; i++) {
                //ik_link_names[i]
                if (ik_link_names[i] == null)
                    ik_link_names[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)ik_link_names[i]);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
            }
            //pose_stamped_vector
            hasmetacomponents |= true;
            if (pose_stamped_vector == null)
                pose_stamped_vector = new Messages.geometry_msgs.PoseStamped[0];
            pieces.Add(BitConverter.GetBytes(pose_stamped_vector.Length));
            for (int i=0;i<pose_stamped_vector.Length; i++) {
                //pose_stamped_vector[i]
                if (pose_stamped_vector[i] == null)
                    pose_stamped_vector[i] = new Messages.geometry_msgs.PoseStamped();
                pieces.Add(pose_stamped_vector[i].Serialize(true));
            }
            //timeout
            pieces.Add(BitConverter.GetBytes(timeout.data.sec));
            pieces.Add(BitConverter.GetBytes(timeout.data.nsec));
            //attempts
            scratch1 = new byte[Marshal.SizeOf(typeof(int))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(attempts, h.AddrOfPinnedObject(), false);
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
            
            //group_name
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            group_name = Encoding.ASCII.GetString(strbuf);
            //robot_state
            robot_state = new Messages.moveit_msgs.RobotState();
            robot_state.Randomize();
            //constraints
            constraints = new Messages.moveit_msgs.Constraints();
            constraints.Randomize();
            //avoid_collisions
            avoid_collisions = rand.Next(2) == 1;
            //ik_link_name
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            ik_link_name = Encoding.ASCII.GetString(strbuf);
            //pose_stamped
            pose_stamped = new Messages.geometry_msgs.PoseStamped();
            pose_stamped.Randomize();
            //ik_link_names
            arraylength = rand.Next(10);
            if (ik_link_names == null)
                ik_link_names = new string[arraylength];
            else
                Array.Resize(ref ik_link_names, arraylength);
            for (int i=0;i<ik_link_names.Length; i++) {
                //ik_link_names[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                ik_link_names[i] = Encoding.ASCII.GetString(strbuf);
            }
            //pose_stamped_vector
            arraylength = rand.Next(10);
            if (pose_stamped_vector == null)
                pose_stamped_vector = new Messages.geometry_msgs.PoseStamped[arraylength];
            else
                Array.Resize(ref pose_stamped_vector, arraylength);
            for (int i=0;i<pose_stamped_vector.Length; i++) {
                //pose_stamped_vector[i]
                pose_stamped_vector[i] = new Messages.geometry_msgs.PoseStamped();
                pose_stamped_vector[i].Randomize();
            }
            //timeout
            timeout = new Duration(new TimeData(
                    Convert.ToInt32(rand.Next()),
                    Convert.ToInt32(rand.Next())));
            //attempts
            attempts = rand.Next();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.PositionIKRequest;
            if (other == null)
                return false;
            ret &= group_name == other.group_name;
            ret &= robot_state.Equals(other.robot_state);
            ret &= constraints.Equals(other.constraints);
            ret &= avoid_collisions == other.avoid_collisions;
            ret &= ik_link_name == other.ik_link_name;
            ret &= pose_stamped.Equals(other.pose_stamped);
            if (ik_link_names.Length != other.ik_link_names.Length)
                return false;
            for (int __i__=0; __i__ < ik_link_names.Length; __i__++)
            {
                ret &= ik_link_names[__i__] == other.ik_link_names[__i__];
            }
            if (pose_stamped_vector.Length != other.pose_stamped_vector.Length)
                return false;
            for (int __i__=0; __i__ < pose_stamped_vector.Length; __i__++)
            {
                ret &= pose_stamped_vector[__i__].Equals(other.pose_stamped_vector[__i__]);
            }
            ret &= timeout.data.Equals(other.timeout.data);
            ret &= attempts == other.attempts;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
