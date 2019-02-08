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
    public class PlanningOptions : RosMessage
    {

			public Messages.moveit_msgs.PlanningScene planning_scene_diff = new Messages.moveit_msgs.PlanningScene();
			public bool plan_only;
			public bool look_around;
			public int look_around_attempts;
			public double max_safe_execution_cost;
			public bool replan;
			public int replan_attempts;
			public double replan_delay;


        public override string MD5Sum() { return "3934e50ede2ecea03e532aade900ab50"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"PlanningScene planning_scene_diff
bool plan_only
bool look_around
int32 look_around_attempts
float64 max_safe_execution_cost
bool replan
int32 replan_attempts
float64 replan_delay"; }
        public override string MessageType { get { return "moveit_msgs/PlanningOptions"; } }
        public override bool IsServiceComponent() { return false; }

        public PlanningOptions()
        {
            
        }

        public PlanningOptions(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PlanningOptions(byte[] serializedMessage, ref int currentIndex)
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
            
            //planning_scene_diff
            planning_scene_diff = new Messages.moveit_msgs.PlanningScene(serializedMessage, ref currentIndex);
            //plan_only
            plan_only = serializedMessage[currentIndex++]==1;
            //look_around
            look_around = serializedMessage[currentIndex++]==1;
            //look_around_attempts
            piecesize = Marshal.SizeOf(typeof(int));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            look_around_attempts = (int)Marshal.PtrToStructure(h, typeof(int));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //max_safe_execution_cost
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            max_safe_execution_cost = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //replan
            replan = serializedMessage[currentIndex++]==1;
            //replan_attempts
            piecesize = Marshal.SizeOf(typeof(int));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            replan_attempts = (int)Marshal.PtrToStructure(h, typeof(int));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //replan_delay
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            replan_delay = (double)Marshal.PtrToStructure(h, typeof(double));
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
            
            //planning_scene_diff
            if (planning_scene_diff == null)
                planning_scene_diff = new Messages.moveit_msgs.PlanningScene();
            pieces.Add(planning_scene_diff.Serialize(true));
            //plan_only
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)plan_only ? 1 : 0 );
            pieces.Add(thischunk);
            //look_around
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)look_around ? 1 : 0 );
            pieces.Add(thischunk);
            //look_around_attempts
            scratch1 = new byte[Marshal.SizeOf(typeof(int))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(look_around_attempts, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //max_safe_execution_cost
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(max_safe_execution_cost, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //replan
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)replan ? 1 : 0 );
            pieces.Add(thischunk);
            //replan_attempts
            scratch1 = new byte[Marshal.SizeOf(typeof(int))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(replan_attempts, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //replan_delay
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(replan_delay, h.AddrOfPinnedObject(), false);
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
            
            //planning_scene_diff
            planning_scene_diff = new Messages.moveit_msgs.PlanningScene();
            planning_scene_diff.Randomize();
            //plan_only
            plan_only = rand.Next(2) == 1;
            //look_around
            look_around = rand.Next(2) == 1;
            //look_around_attempts
            look_around_attempts = rand.Next();
            //max_safe_execution_cost
            max_safe_execution_cost = (rand.Next() + rand.NextDouble());
            //replan
            replan = rand.Next(2) == 1;
            //replan_attempts
            replan_attempts = rand.Next();
            //replan_delay
            replan_delay = (rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.PlanningOptions;
            if (other == null)
                return false;
            ret &= planning_scene_diff.Equals(other.planning_scene_diff);
            ret &= plan_only == other.plan_only;
            ret &= look_around == other.look_around;
            ret &= look_around_attempts == other.look_around_attempts;
            ret &= max_safe_execution_cost == other.max_safe_execution_cost;
            ret &= replan == other.replan;
            ret &= replan_attempts == other.replan_attempts;
            ret &= replan_delay == other.replan_delay;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
