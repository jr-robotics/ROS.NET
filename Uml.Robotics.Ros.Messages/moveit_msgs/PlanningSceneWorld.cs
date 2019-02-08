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
    public class PlanningSceneWorld : RosMessage
    {

			public Messages.moveit_msgs.CollisionObject[] collision_objects;
			public Messages.octomap_msgs.OctomapWithPose octomap = new Messages.octomap_msgs.OctomapWithPose();


        public override string MD5Sum() { return "373d88390d1db385335639f687723ee6"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"CollisionObject[] collision_objects
octomap_msgs/OctomapWithPose octomap"; }
        public override string MessageType { get { return "moveit_msgs/PlanningSceneWorld"; } }
        public override bool IsServiceComponent() { return false; }

        public PlanningSceneWorld()
        {
            
        }

        public PlanningSceneWorld(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PlanningSceneWorld(byte[] serializedMessage, ref int currentIndex)
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
            
            //collision_objects
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (collision_objects == null)
                collision_objects = new Messages.moveit_msgs.CollisionObject[arraylength];
            else
                Array.Resize(ref collision_objects, arraylength);
            for (int i=0;i<collision_objects.Length; i++) {
                //collision_objects[i]
                collision_objects[i] = new Messages.moveit_msgs.CollisionObject(serializedMessage, ref currentIndex);
            }
            //octomap
            octomap = new Messages.octomap_msgs.OctomapWithPose(serializedMessage, ref currentIndex);
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
            
            //collision_objects
            hasmetacomponents |= true;
            if (collision_objects == null)
                collision_objects = new Messages.moveit_msgs.CollisionObject[0];
            pieces.Add(BitConverter.GetBytes(collision_objects.Length));
            for (int i=0;i<collision_objects.Length; i++) {
                //collision_objects[i]
                if (collision_objects[i] == null)
                    collision_objects[i] = new Messages.moveit_msgs.CollisionObject();
                pieces.Add(collision_objects[i].Serialize(true));
            }
            //octomap
            if (octomap == null)
                octomap = new Messages.octomap_msgs.OctomapWithPose();
            pieces.Add(octomap.Serialize(true));
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
            
            //collision_objects
            arraylength = rand.Next(10);
            if (collision_objects == null)
                collision_objects = new Messages.moveit_msgs.CollisionObject[arraylength];
            else
                Array.Resize(ref collision_objects, arraylength);
            for (int i=0;i<collision_objects.Length; i++) {
                //collision_objects[i]
                collision_objects[i] = new Messages.moveit_msgs.CollisionObject();
                collision_objects[i].Randomize();
            }
            //octomap
            octomap = new Messages.octomap_msgs.OctomapWithPose();
            octomap.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.PlanningSceneWorld;
            if (other == null)
                return false;
            if (collision_objects.Length != other.collision_objects.Length)
                return false;
            for (int __i__=0; __i__ < collision_objects.Length; __i__++)
            {
                ret &= collision_objects[__i__].Equals(other.collision_objects[__i__]);
            }
            ret &= octomap.Equals(other.octomap);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
