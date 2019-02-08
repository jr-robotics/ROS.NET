using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

using Uml.Robotics.Ros;
using Messages.actionlib_msgs;
using Messages.geometry_msgs;
using Messages.std_msgs;


namespace Messages.moveit_msgs
{
	[ActionGoalMessage]
        public class PickupGoal : InnerActionMessage
    {
        			public string target_name = "";
			public string group_name = "";
			public string end_effector = "";
			public Messages.moveit_msgs.Grasp[] possible_grasps;
			public string support_surface_name = "";
			public bool allow_gripper_support_collision;
			public string[] attached_object_touch_links;
			public bool minimize_object_distance;
			public Messages.moveit_msgs.Constraints path_constraints = new Messages.moveit_msgs.Constraints();
			public string planner_id = "";
			public string[] allowed_touch_objects;
			public double allowed_planning_time;
			public Messages.moveit_msgs.PlanningOptions planning_options = new Messages.moveit_msgs.PlanningOptions();



        public override string MD5Sum() { return "458c6ab3761d73e99b070063f7b74c2a"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"string target_name
string group_name
string end_effector
Grasp[] possible_grasps
string support_surface_name
bool allow_gripper_support_collision
string[] attached_object_touch_links
bool minimize_object_distance
Constraints path_constraints
string planner_id
string[] allowed_touch_objects
float64 allowed_planning_time
PlanningOptions planning_options"; }
		public override string MessageType { get { return "moveit_msgs/PickupGoal"; } }
        public override bool IsServiceComponent() { return false; }

        public PickupGoal()
        {
            
        }

        public PickupGoal(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PickupGoal(byte[] serializedMessage, ref int currentIndex)
        {
            Deserialize(serializedMessage, ref currentIndex);
        }

        

        public void Deserialize(byte[] serializedMessage, int currentIndex)
        {
            Deserialize(serializedMessage, currentIndex);
        }

        public override void Deserialize(byte[] serializedMessage, ref int currentIndex)
        {
            int arraylength = -1;
            bool hasmetacomponents = false;
            object __thing;
            int piecesize = 0;
            byte[] thischunk, scratch1, scratch2;
            IntPtr h;

            
                //target_name
                target_name = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                target_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //group_name
                group_name = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                group_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //end_effector
                end_effector = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                end_effector = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //possible_grasps
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (possible_grasps == null)
                    possible_grasps = new Messages.moveit_msgs.Grasp[arraylength];
                else
                    Array.Resize(ref possible_grasps, arraylength);
                for (int i=0;i<possible_grasps.Length; i++) {
                    //possible_grasps[i]
                    possible_grasps[i] = new Messages.moveit_msgs.Grasp(serializedMessage, ref currentIndex);
                }
                //support_surface_name
                support_surface_name = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                support_surface_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //allow_gripper_support_collision
                allow_gripper_support_collision = serializedMessage[currentIndex++]==1;
                //attached_object_touch_links
                hasmetacomponents |= false;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (attached_object_touch_links == null)
                    attached_object_touch_links = new string[arraylength];
                else
                    Array.Resize(ref attached_object_touch_links, arraylength);
                for (int i=0;i<attached_object_touch_links.Length; i++) {
                    //attached_object_touch_links[i]
                    attached_object_touch_links[i] = "";
                    piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                    currentIndex += 4;
                    attached_object_touch_links[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                    currentIndex += piecesize;
                }
                //minimize_object_distance
                minimize_object_distance = serializedMessage[currentIndex++]==1;
                //path_constraints
                path_constraints = new Messages.moveit_msgs.Constraints(serializedMessage, ref currentIndex);
                //planner_id
                planner_id = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                planner_id = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //allowed_touch_objects
                hasmetacomponents |= false;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (allowed_touch_objects == null)
                    allowed_touch_objects = new string[arraylength];
                else
                    Array.Resize(ref allowed_touch_objects, arraylength);
                for (int i=0;i<allowed_touch_objects.Length; i++) {
                    //allowed_touch_objects[i]
                    allowed_touch_objects[i] = "";
                    piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                    currentIndex += 4;
                    allowed_touch_objects[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                    currentIndex += piecesize;
                }
                //allowed_planning_time
                piecesize = Marshal.SizeOf(typeof(double));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                allowed_planning_time = (double)Marshal.PtrToStructure(h, typeof(double));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //planning_options
                planning_options = new Messages.moveit_msgs.PlanningOptions(serializedMessage, ref currentIndex);
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

            
                //target_name
                if (target_name == null)
                    target_name = "";
                scratch1 = Encoding.ASCII.GetBytes((string)target_name);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //group_name
                if (group_name == null)
                    group_name = "";
                scratch1 = Encoding.ASCII.GetBytes((string)group_name);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //end_effector
                if (end_effector == null)
                    end_effector = "";
                scratch1 = Encoding.ASCII.GetBytes((string)end_effector);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //possible_grasps
                hasmetacomponents |= true;
                if (possible_grasps == null)
                    possible_grasps = new Messages.moveit_msgs.Grasp[0];
                pieces.Add(BitConverter.GetBytes(possible_grasps.Length));
                for (int i=0;i<possible_grasps.Length; i++) {
                    //possible_grasps[i]
                    if (possible_grasps[i] == null)
                        possible_grasps[i] = new Messages.moveit_msgs.Grasp();
                    pieces.Add(possible_grasps[i].Serialize(true));
                }
                //support_surface_name
                if (support_surface_name == null)
                    support_surface_name = "";
                scratch1 = Encoding.ASCII.GetBytes((string)support_surface_name);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //allow_gripper_support_collision
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)allow_gripper_support_collision ? 1 : 0 );
                pieces.Add(thischunk);
                //attached_object_touch_links
                hasmetacomponents |= false;
                if (attached_object_touch_links == null)
                    attached_object_touch_links = new string[0];
                pieces.Add(BitConverter.GetBytes(attached_object_touch_links.Length));
                for (int i=0;i<attached_object_touch_links.Length; i++) {
                    //attached_object_touch_links[i]
                    if (attached_object_touch_links[i] == null)
                        attached_object_touch_links[i] = "";
                    scratch1 = Encoding.ASCII.GetBytes((string)attached_object_touch_links[i]);
                    thischunk = new byte[scratch1.Length + 4];
                    scratch2 = BitConverter.GetBytes(scratch1.Length);
                    Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                    Array.Copy(scratch2, thischunk, 4);
                    pieces.Add(thischunk);
                }
                //minimize_object_distance
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)minimize_object_distance ? 1 : 0 );
                pieces.Add(thischunk);
                //path_constraints
                if (path_constraints == null)
                    path_constraints = new Messages.moveit_msgs.Constraints();
                pieces.Add(path_constraints.Serialize(true));
                //planner_id
                if (planner_id == null)
                    planner_id = "";
                scratch1 = Encoding.ASCII.GetBytes((string)planner_id);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //allowed_touch_objects
                hasmetacomponents |= false;
                if (allowed_touch_objects == null)
                    allowed_touch_objects = new string[0];
                pieces.Add(BitConverter.GetBytes(allowed_touch_objects.Length));
                for (int i=0;i<allowed_touch_objects.Length; i++) {
                    //allowed_touch_objects[i]
                    if (allowed_touch_objects[i] == null)
                        allowed_touch_objects[i] = "";
                    scratch1 = Encoding.ASCII.GetBytes((string)allowed_touch_objects[i]);
                    thischunk = new byte[scratch1.Length + 4];
                    scratch2 = BitConverter.GetBytes(scratch1.Length);
                    Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                    Array.Copy(scratch2, thischunk, 4);
                    pieces.Add(thischunk);
                }
                //allowed_planning_time
                scratch1 = new byte[Marshal.SizeOf(typeof(double))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(allowed_planning_time, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //planning_options
                if (planning_options == null)
                    planning_options = new Messages.moveit_msgs.PlanningOptions();
                pieces.Add(planning_options.Serialize(true));

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

            
                //target_name
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                target_name = Encoding.ASCII.GetString(strbuf);
                //group_name
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                group_name = Encoding.ASCII.GetString(strbuf);
                //end_effector
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                end_effector = Encoding.ASCII.GetString(strbuf);
                //possible_grasps
                arraylength = rand.Next(10);
                if (possible_grasps == null)
                    possible_grasps = new Messages.moveit_msgs.Grasp[arraylength];
                else
                    Array.Resize(ref possible_grasps, arraylength);
                for (int i=0;i<possible_grasps.Length; i++) {
                    //possible_grasps[i]
                    possible_grasps[i] = new Messages.moveit_msgs.Grasp();
                    possible_grasps[i].Randomize();
                }
                //support_surface_name
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                support_surface_name = Encoding.ASCII.GetString(strbuf);
                //allow_gripper_support_collision
                allow_gripper_support_collision = rand.Next(2) == 1;
                //attached_object_touch_links
                arraylength = rand.Next(10);
                if (attached_object_touch_links == null)
                    attached_object_touch_links = new string[arraylength];
                else
                    Array.Resize(ref attached_object_touch_links, arraylength);
                for (int i=0;i<attached_object_touch_links.Length; i++) {
                    //attached_object_touch_links[i]
                    strlength = rand.Next(100) + 1;
                    strbuf = new byte[strlength];
                    rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                    for (int __x__ = 0; __x__ < strlength; __x__++)
                        if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                            strbuf[__x__] = (byte)(rand.Next(254) + 1);
                    strbuf[strlength - 1] = 0; //null terminate
                    attached_object_touch_links[i] = Encoding.ASCII.GetString(strbuf);
                }
                //minimize_object_distance
                minimize_object_distance = rand.Next(2) == 1;
                //path_constraints
                path_constraints = new Messages.moveit_msgs.Constraints();
                path_constraints.Randomize();
                //planner_id
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                planner_id = Encoding.ASCII.GetString(strbuf);
                //allowed_touch_objects
                arraylength = rand.Next(10);
                if (allowed_touch_objects == null)
                    allowed_touch_objects = new string[arraylength];
                else
                    Array.Resize(ref allowed_touch_objects, arraylength);
                for (int i=0;i<allowed_touch_objects.Length; i++) {
                    //allowed_touch_objects[i]
                    strlength = rand.Next(100) + 1;
                    strbuf = new byte[strlength];
                    rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                    for (int __x__ = 0; __x__ < strlength; __x__++)
                        if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                            strbuf[__x__] = (byte)(rand.Next(254) + 1);
                    strbuf[strlength - 1] = 0; //null terminate
                    allowed_touch_objects[i] = Encoding.ASCII.GetString(strbuf);
                }
                //allowed_planning_time
                allowed_planning_time = (rand.Next() + rand.NextDouble());
                //planning_options
                planning_options = new Messages.moveit_msgs.PlanningOptions();
                planning_options.Randomize();
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            PickupGoal other;
            try
            {
                other = (PickupGoal)message;
            }
            catch
            {
                return false;
            }

            
                ret &= target_name == other.target_name;
                ret &= group_name == other.group_name;
                ret &= end_effector == other.end_effector;
                if (possible_grasps.Length != other.possible_grasps.Length)
                    return false;
                for (int __i__=0; __i__ < possible_grasps.Length; __i__++)
                {
                    ret &= possible_grasps[__i__].Equals(other.possible_grasps[__i__]);
                }
                ret &= support_surface_name == other.support_surface_name;
                ret &= allow_gripper_support_collision == other.allow_gripper_support_collision;
                if (attached_object_touch_links.Length != other.attached_object_touch_links.Length)
                    return false;
                for (int __i__=0; __i__ < attached_object_touch_links.Length; __i__++)
                {
                    ret &= attached_object_touch_links[__i__] == other.attached_object_touch_links[__i__];
                }
                ret &= minimize_object_distance == other.minimize_object_distance;
                ret &= path_constraints.Equals(other.path_constraints);
                ret &= planner_id == other.planner_id;
                if (allowed_touch_objects.Length != other.allowed_touch_objects.Length)
                    return false;
                for (int __i__=0; __i__ < allowed_touch_objects.Length; __i__++)
                {
                    ret &= allowed_touch_objects[__i__] == other.allowed_touch_objects[__i__];
                }
                ret &= allowed_planning_time == other.allowed_planning_time;
                ret &= planning_options.Equals(other.planning_options);

            return ret;
        }
    }



    //$ACTION_GOAL_MESSAGE

	[ActionResultMessage]
        public class PickupResult : InnerActionMessage
    {
        			public Messages.moveit_msgs.MoveItErrorCodes error_code = new Messages.moveit_msgs.MoveItErrorCodes();
			public Messages.moveit_msgs.RobotState trajectory_start = new Messages.moveit_msgs.RobotState();
			public Messages.moveit_msgs.RobotTrajectory[] trajectory_stages;
			public string[] trajectory_descriptions;
			public Messages.moveit_msgs.Grasp grasp = new Messages.moveit_msgs.Grasp();



        public override string MD5Sum() { return "23c6d8bf0580f4bc8f7a8e1f59b4b6b7"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"MoveItErrorCodes error_code
RobotState trajectory_start
RobotTrajectory[] trajectory_stages
string[] trajectory_descriptions
Grasp grasp"; }
		public override string MessageType { get { return "moveit_msgs/PickupResult"; } }
        public override bool IsServiceComponent() { return false; }

        public PickupResult()
        {
            
        }

        public PickupResult(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PickupResult(byte[] serializedMessage, ref int currentIndex)
        {
            Deserialize(serializedMessage, ref currentIndex);
        }

        

        public void Deserialize(byte[] serializedMessage, int currentIndex)
        {
            Deserialize(serializedMessage, currentIndex);
        }

        public override void Deserialize(byte[] serializedMessage, ref int currentIndex)
        {
            int arraylength = -1;
            bool hasmetacomponents = false;
            object __thing;
            int piecesize = 0;
            byte[] thischunk, scratch1, scratch2;
            IntPtr h;

            
                //error_code
                error_code = new Messages.moveit_msgs.MoveItErrorCodes(serializedMessage, ref currentIndex);
                //trajectory_start
                trajectory_start = new Messages.moveit_msgs.RobotState(serializedMessage, ref currentIndex);
                //trajectory_stages
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (trajectory_stages == null)
                    trajectory_stages = new Messages.moveit_msgs.RobotTrajectory[arraylength];
                else
                    Array.Resize(ref trajectory_stages, arraylength);
                for (int i=0;i<trajectory_stages.Length; i++) {
                    //trajectory_stages[i]
                    trajectory_stages[i] = new Messages.moveit_msgs.RobotTrajectory(serializedMessage, ref currentIndex);
                }
                //trajectory_descriptions
                hasmetacomponents |= false;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (trajectory_descriptions == null)
                    trajectory_descriptions = new string[arraylength];
                else
                    Array.Resize(ref trajectory_descriptions, arraylength);
                for (int i=0;i<trajectory_descriptions.Length; i++) {
                    //trajectory_descriptions[i]
                    trajectory_descriptions[i] = "";
                    piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                    currentIndex += 4;
                    trajectory_descriptions[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                    currentIndex += piecesize;
                }
                //grasp
                grasp = new Messages.moveit_msgs.Grasp(serializedMessage, ref currentIndex);
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

            
                //error_code
                if (error_code == null)
                    error_code = new Messages.moveit_msgs.MoveItErrorCodes();
                pieces.Add(error_code.Serialize(true));
                //trajectory_start
                if (trajectory_start == null)
                    trajectory_start = new Messages.moveit_msgs.RobotState();
                pieces.Add(trajectory_start.Serialize(true));
                //trajectory_stages
                hasmetacomponents |= true;
                if (trajectory_stages == null)
                    trajectory_stages = new Messages.moveit_msgs.RobotTrajectory[0];
                pieces.Add(BitConverter.GetBytes(trajectory_stages.Length));
                for (int i=0;i<trajectory_stages.Length; i++) {
                    //trajectory_stages[i]
                    if (trajectory_stages[i] == null)
                        trajectory_stages[i] = new Messages.moveit_msgs.RobotTrajectory();
                    pieces.Add(trajectory_stages[i].Serialize(true));
                }
                //trajectory_descriptions
                hasmetacomponents |= false;
                if (trajectory_descriptions == null)
                    trajectory_descriptions = new string[0];
                pieces.Add(BitConverter.GetBytes(trajectory_descriptions.Length));
                for (int i=0;i<trajectory_descriptions.Length; i++) {
                    //trajectory_descriptions[i]
                    if (trajectory_descriptions[i] == null)
                        trajectory_descriptions[i] = "";
                    scratch1 = Encoding.ASCII.GetBytes((string)trajectory_descriptions[i]);
                    thischunk = new byte[scratch1.Length + 4];
                    scratch2 = BitConverter.GetBytes(scratch1.Length);
                    Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                    Array.Copy(scratch2, thischunk, 4);
                    pieces.Add(thischunk);
                }
                //grasp
                if (grasp == null)
                    grasp = new Messages.moveit_msgs.Grasp();
                pieces.Add(grasp.Serialize(true));

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

            
                //error_code
                error_code = new Messages.moveit_msgs.MoveItErrorCodes();
                error_code.Randomize();
                //trajectory_start
                trajectory_start = new Messages.moveit_msgs.RobotState();
                trajectory_start.Randomize();
                //trajectory_stages
                arraylength = rand.Next(10);
                if (trajectory_stages == null)
                    trajectory_stages = new Messages.moveit_msgs.RobotTrajectory[arraylength];
                else
                    Array.Resize(ref trajectory_stages, arraylength);
                for (int i=0;i<trajectory_stages.Length; i++) {
                    //trajectory_stages[i]
                    trajectory_stages[i] = new Messages.moveit_msgs.RobotTrajectory();
                    trajectory_stages[i].Randomize();
                }
                //trajectory_descriptions
                arraylength = rand.Next(10);
                if (trajectory_descriptions == null)
                    trajectory_descriptions = new string[arraylength];
                else
                    Array.Resize(ref trajectory_descriptions, arraylength);
                for (int i=0;i<trajectory_descriptions.Length; i++) {
                    //trajectory_descriptions[i]
                    strlength = rand.Next(100) + 1;
                    strbuf = new byte[strlength];
                    rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                    for (int __x__ = 0; __x__ < strlength; __x__++)
                        if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                            strbuf[__x__] = (byte)(rand.Next(254) + 1);
                    strbuf[strlength - 1] = 0; //null terminate
                    trajectory_descriptions[i] = Encoding.ASCII.GetString(strbuf);
                }
                //grasp
                grasp = new Messages.moveit_msgs.Grasp();
                grasp.Randomize();
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            PickupResult other;
            try
            {
                other = (PickupResult)message;
            }
            catch
            {
                return false;
            }

            
                ret &= error_code.Equals(other.error_code);
                ret &= trajectory_start.Equals(other.trajectory_start);
                if (trajectory_stages.Length != other.trajectory_stages.Length)
                    return false;
                for (int __i__=0; __i__ < trajectory_stages.Length; __i__++)
                {
                    ret &= trajectory_stages[__i__].Equals(other.trajectory_stages[__i__]);
                }
                if (trajectory_descriptions.Length != other.trajectory_descriptions.Length)
                    return false;
                for (int __i__=0; __i__ < trajectory_descriptions.Length; __i__++)
                {
                    ret &= trajectory_descriptions[__i__] == other.trajectory_descriptions[__i__];
                }
                ret &= grasp.Equals(other.grasp);

            return ret;
        }
    }



    //$ACTION_RESULT_MESSAGE


	[ActionFeedbackMessage]
        public class PickupFeedback : InnerActionMessage
    {
        			public string state = "";



        public override string MD5Sum() { return "af6d3a99f0fbeb66d3248fa4b3e675fb"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"string state"; }
		public override string MessageType { get { return "moveit_msgs/PickupFeedback"; } }
        public override bool IsServiceComponent() { return false; }

        public PickupFeedback()
        {
            
        }

        public PickupFeedback(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PickupFeedback(byte[] serializedMessage, ref int currentIndex)
        {
            Deserialize(serializedMessage, ref currentIndex);
        }

        

        public void Deserialize(byte[] serializedMessage, int currentIndex)
        {
            Deserialize(serializedMessage, currentIndex);
        }

        public override void Deserialize(byte[] serializedMessage, ref int currentIndex)
        {
            int arraylength = -1;
            bool hasmetacomponents = false;
            object __thing;
            int piecesize = 0;
            byte[] thischunk, scratch1, scratch2;
            IntPtr h;

            
                //state
                state = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                state = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
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

            
                //state
                if (state == null)
                    state = "";
                scratch1 = Encoding.ASCII.GetBytes((string)state);
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

            
                //state
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                state = Encoding.ASCII.GetString(strbuf);
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            PickupFeedback other;
            try
            {
                other = (PickupFeedback)message;
            }
            catch
            {
                return false;
            }

            
                ret &= state == other.state;

            return ret;
        }
    }



    //$ACTION_FEEDBACK_MESSAGE
}