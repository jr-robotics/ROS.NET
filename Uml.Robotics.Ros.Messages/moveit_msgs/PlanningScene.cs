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
    public class PlanningScene : RosMessage
    {

			public string name = "";
			public Messages.moveit_msgs.RobotState robot_state = new Messages.moveit_msgs.RobotState();
			public string robot_model_name = "";
			public Messages.geometry_msgs.TransformStamped[] fixed_frame_transforms;
			public Messages.moveit_msgs.AllowedCollisionMatrix allowed_collision_matrix = new Messages.moveit_msgs.AllowedCollisionMatrix();
			public Messages.moveit_msgs.LinkPadding[] link_padding;
			public Messages.moveit_msgs.LinkScale[] link_scale;
			public Messages.moveit_msgs.ObjectColor[] object_colors;
			public Messages.moveit_msgs.PlanningSceneWorld world = new Messages.moveit_msgs.PlanningSceneWorld();
			public bool is_diff;


        public override string MD5Sum() { return "89aac6d20db967ba716cba5a86b1b9d5"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"string name
RobotState robot_state
string robot_model_name
geometry_msgs/TransformStamped[] fixed_frame_transforms
AllowedCollisionMatrix allowed_collision_matrix
LinkPadding[] link_padding
LinkScale[] link_scale
ObjectColor[] object_colors
PlanningSceneWorld world
bool is_diff"; }
        public override string MessageType { get { return "moveit_msgs/PlanningScene"; } }
        public override bool IsServiceComponent() { return false; }

        public PlanningScene()
        {
            
        }

        public PlanningScene(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PlanningScene(byte[] serializedMessage, ref int currentIndex)
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
            //robot_state
            robot_state = new Messages.moveit_msgs.RobotState(serializedMessage, ref currentIndex);
            //robot_model_name
            robot_model_name = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            robot_model_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //fixed_frame_transforms
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (fixed_frame_transforms == null)
                fixed_frame_transforms = new Messages.geometry_msgs.TransformStamped[arraylength];
            else
                Array.Resize(ref fixed_frame_transforms, arraylength);
            for (int i=0;i<fixed_frame_transforms.Length; i++) {
                //fixed_frame_transforms[i]
                fixed_frame_transforms[i] = new Messages.geometry_msgs.TransformStamped(serializedMessage, ref currentIndex);
            }
            //allowed_collision_matrix
            allowed_collision_matrix = new Messages.moveit_msgs.AllowedCollisionMatrix(serializedMessage, ref currentIndex);
            //link_padding
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (link_padding == null)
                link_padding = new Messages.moveit_msgs.LinkPadding[arraylength];
            else
                Array.Resize(ref link_padding, arraylength);
            for (int i=0;i<link_padding.Length; i++) {
                //link_padding[i]
                link_padding[i] = new Messages.moveit_msgs.LinkPadding(serializedMessage, ref currentIndex);
            }
            //link_scale
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (link_scale == null)
                link_scale = new Messages.moveit_msgs.LinkScale[arraylength];
            else
                Array.Resize(ref link_scale, arraylength);
            for (int i=0;i<link_scale.Length; i++) {
                //link_scale[i]
                link_scale[i] = new Messages.moveit_msgs.LinkScale(serializedMessage, ref currentIndex);
            }
            //object_colors
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (object_colors == null)
                object_colors = new Messages.moveit_msgs.ObjectColor[arraylength];
            else
                Array.Resize(ref object_colors, arraylength);
            for (int i=0;i<object_colors.Length; i++) {
                //object_colors[i]
                object_colors[i] = new Messages.moveit_msgs.ObjectColor(serializedMessage, ref currentIndex);
            }
            //world
            world = new Messages.moveit_msgs.PlanningSceneWorld(serializedMessage, ref currentIndex);
            //is_diff
            is_diff = serializedMessage[currentIndex++]==1;
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
            //robot_state
            if (robot_state == null)
                robot_state = new Messages.moveit_msgs.RobotState();
            pieces.Add(robot_state.Serialize(true));
            //robot_model_name
            if (robot_model_name == null)
                robot_model_name = "";
            scratch1 = Encoding.ASCII.GetBytes((string)robot_model_name);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //fixed_frame_transforms
            hasmetacomponents |= false;
            if (fixed_frame_transforms == null)
                fixed_frame_transforms = new Messages.geometry_msgs.TransformStamped[0];
            pieces.Add(BitConverter.GetBytes(fixed_frame_transforms.Length));
            for (int i=0;i<fixed_frame_transforms.Length; i++) {
                //fixed_frame_transforms[i]
                if (fixed_frame_transforms[i] == null)
                    fixed_frame_transforms[i] = new Messages.geometry_msgs.TransformStamped();
                pieces.Add(fixed_frame_transforms[i].Serialize(true));
            }
            //allowed_collision_matrix
            if (allowed_collision_matrix == null)
                allowed_collision_matrix = new Messages.moveit_msgs.AllowedCollisionMatrix();
            pieces.Add(allowed_collision_matrix.Serialize(true));
            //link_padding
            hasmetacomponents |= true;
            if (link_padding == null)
                link_padding = new Messages.moveit_msgs.LinkPadding[0];
            pieces.Add(BitConverter.GetBytes(link_padding.Length));
            for (int i=0;i<link_padding.Length; i++) {
                //link_padding[i]
                if (link_padding[i] == null)
                    link_padding[i] = new Messages.moveit_msgs.LinkPadding();
                pieces.Add(link_padding[i].Serialize(true));
            }
            //link_scale
            hasmetacomponents |= true;
            if (link_scale == null)
                link_scale = new Messages.moveit_msgs.LinkScale[0];
            pieces.Add(BitConverter.GetBytes(link_scale.Length));
            for (int i=0;i<link_scale.Length; i++) {
                //link_scale[i]
                if (link_scale[i] == null)
                    link_scale[i] = new Messages.moveit_msgs.LinkScale();
                pieces.Add(link_scale[i].Serialize(true));
            }
            //object_colors
            hasmetacomponents |= true;
            if (object_colors == null)
                object_colors = new Messages.moveit_msgs.ObjectColor[0];
            pieces.Add(BitConverter.GetBytes(object_colors.Length));
            for (int i=0;i<object_colors.Length; i++) {
                //object_colors[i]
                if (object_colors[i] == null)
                    object_colors[i] = new Messages.moveit_msgs.ObjectColor();
                pieces.Add(object_colors[i].Serialize(true));
            }
            //world
            if (world == null)
                world = new Messages.moveit_msgs.PlanningSceneWorld();
            pieces.Add(world.Serialize(true));
            //is_diff
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)is_diff ? 1 : 0 );
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
            
            //name
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            name = Encoding.ASCII.GetString(strbuf);
            //robot_state
            robot_state = new Messages.moveit_msgs.RobotState();
            robot_state.Randomize();
            //robot_model_name
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            robot_model_name = Encoding.ASCII.GetString(strbuf);
            //fixed_frame_transforms
            arraylength = rand.Next(10);
            if (fixed_frame_transforms == null)
                fixed_frame_transforms = new Messages.geometry_msgs.TransformStamped[arraylength];
            else
                Array.Resize(ref fixed_frame_transforms, arraylength);
            for (int i=0;i<fixed_frame_transforms.Length; i++) {
                //fixed_frame_transforms[i]
                fixed_frame_transforms[i] = new Messages.geometry_msgs.TransformStamped();
                fixed_frame_transforms[i].Randomize();
            }
            //allowed_collision_matrix
            allowed_collision_matrix = new Messages.moveit_msgs.AllowedCollisionMatrix();
            allowed_collision_matrix.Randomize();
            //link_padding
            arraylength = rand.Next(10);
            if (link_padding == null)
                link_padding = new Messages.moveit_msgs.LinkPadding[arraylength];
            else
                Array.Resize(ref link_padding, arraylength);
            for (int i=0;i<link_padding.Length; i++) {
                //link_padding[i]
                link_padding[i] = new Messages.moveit_msgs.LinkPadding();
                link_padding[i].Randomize();
            }
            //link_scale
            arraylength = rand.Next(10);
            if (link_scale == null)
                link_scale = new Messages.moveit_msgs.LinkScale[arraylength];
            else
                Array.Resize(ref link_scale, arraylength);
            for (int i=0;i<link_scale.Length; i++) {
                //link_scale[i]
                link_scale[i] = new Messages.moveit_msgs.LinkScale();
                link_scale[i].Randomize();
            }
            //object_colors
            arraylength = rand.Next(10);
            if (object_colors == null)
                object_colors = new Messages.moveit_msgs.ObjectColor[arraylength];
            else
                Array.Resize(ref object_colors, arraylength);
            for (int i=0;i<object_colors.Length; i++) {
                //object_colors[i]
                object_colors[i] = new Messages.moveit_msgs.ObjectColor();
                object_colors[i].Randomize();
            }
            //world
            world = new Messages.moveit_msgs.PlanningSceneWorld();
            world.Randomize();
            //is_diff
            is_diff = rand.Next(2) == 1;
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.PlanningScene;
            if (other == null)
                return false;
            ret &= name == other.name;
            ret &= robot_state.Equals(other.robot_state);
            ret &= robot_model_name == other.robot_model_name;
            if (fixed_frame_transforms.Length != other.fixed_frame_transforms.Length)
                return false;
            for (int __i__=0; __i__ < fixed_frame_transforms.Length; __i__++)
            {
                ret &= fixed_frame_transforms[__i__].Equals(other.fixed_frame_transforms[__i__]);
            }
            ret &= allowed_collision_matrix.Equals(other.allowed_collision_matrix);
            if (link_padding.Length != other.link_padding.Length)
                return false;
            for (int __i__=0; __i__ < link_padding.Length; __i__++)
            {
                ret &= link_padding[__i__].Equals(other.link_padding[__i__]);
            }
            if (link_scale.Length != other.link_scale.Length)
                return false;
            for (int __i__=0; __i__ < link_scale.Length; __i__++)
            {
                ret &= link_scale[__i__].Equals(other.link_scale[__i__]);
            }
            if (object_colors.Length != other.object_colors.Length)
                return false;
            for (int __i__=0; __i__ < object_colors.Length; __i__++)
            {
                ret &= object_colors[__i__].Equals(other.object_colors[__i__]);
            }
            ret &= world.Equals(other.world);
            ret &= is_diff == other.is_diff;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
