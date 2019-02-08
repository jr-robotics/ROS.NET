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
        public class PlaceGoal : InnerActionMessage
    {
        			public string group_name = "";
			public string attached_object_name = "";
			public Messages.moveit_msgs.PlaceLocation[] place_locations;
			public bool place_eef;
			public string support_surface_name = "";
			public bool allow_gripper_support_collision;
			public Messages.moveit_msgs.Constraints path_constraints = new Messages.moveit_msgs.Constraints();
			public string planner_id = "";
			public string[] allowed_touch_objects;
			public double allowed_planning_time;
			public Messages.moveit_msgs.PlanningOptions planning_options = new Messages.moveit_msgs.PlanningOptions();



        public override string MD5Sum() { return "e3f3e956e536ccd313fd8f23023f0a94"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"string group_name
string attached_object_name
PlaceLocation[] place_locations
bool place_eef
string support_surface_name
bool allow_gripper_support_collision
Constraints path_constraints
string planner_id
string[] allowed_touch_objects
float64 allowed_planning_time
PlanningOptions planning_options"; }
		public override string MessageType { get { return "moveit_msgs/PlaceGoal"; } }
        public override bool IsServiceComponent() { return false; }

        public PlaceGoal()
        {
            
        }

        public PlaceGoal(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PlaceGoal(byte[] serializedMessage, ref int currentIndex)
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

            
                //group_name
                group_name = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                group_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //attached_object_name
                attached_object_name = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                attached_object_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //place_locations
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (place_locations == null)
                    place_locations = new Messages.moveit_msgs.PlaceLocation[arraylength];
                else
                    Array.Resize(ref place_locations, arraylength);
                for (int i=0;i<place_locations.Length; i++) {
                    //place_locations[i]
                    place_locations[i] = new Messages.moveit_msgs.PlaceLocation(serializedMessage, ref currentIndex);
                }
                //place_eef
                place_eef = serializedMessage[currentIndex++]==1;
                //support_surface_name
                support_surface_name = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                support_surface_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //allow_gripper_support_collision
                allow_gripper_support_collision = serializedMessage[currentIndex++]==1;
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

            
                //group_name
                if (group_name == null)
                    group_name = "";
                scratch1 = Encoding.ASCII.GetBytes((string)group_name);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //attached_object_name
                if (attached_object_name == null)
                    attached_object_name = "";
                scratch1 = Encoding.ASCII.GetBytes((string)attached_object_name);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //place_locations
                hasmetacomponents |= true;
                if (place_locations == null)
                    place_locations = new Messages.moveit_msgs.PlaceLocation[0];
                pieces.Add(BitConverter.GetBytes(place_locations.Length));
                for (int i=0;i<place_locations.Length; i++) {
                    //place_locations[i]
                    if (place_locations[i] == null)
                        place_locations[i] = new Messages.moveit_msgs.PlaceLocation();
                    pieces.Add(place_locations[i].Serialize(true));
                }
                //place_eef
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)place_eef ? 1 : 0 );
                pieces.Add(thischunk);
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

            
                //group_name
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                group_name = Encoding.ASCII.GetString(strbuf);
                //attached_object_name
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                attached_object_name = Encoding.ASCII.GetString(strbuf);
                //place_locations
                arraylength = rand.Next(10);
                if (place_locations == null)
                    place_locations = new Messages.moveit_msgs.PlaceLocation[arraylength];
                else
                    Array.Resize(ref place_locations, arraylength);
                for (int i=0;i<place_locations.Length; i++) {
                    //place_locations[i]
                    place_locations[i] = new Messages.moveit_msgs.PlaceLocation();
                    place_locations[i].Randomize();
                }
                //place_eef
                place_eef = rand.Next(2) == 1;
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
            PlaceGoal other;
            try
            {
                other = (PlaceGoal)message;
            }
            catch
            {
                return false;
            }

            
                ret &= group_name == other.group_name;
                ret &= attached_object_name == other.attached_object_name;
                if (place_locations.Length != other.place_locations.Length)
                    return false;
                for (int __i__=0; __i__ < place_locations.Length; __i__++)
                {
                    ret &= place_locations[__i__].Equals(other.place_locations[__i__]);
                }
                ret &= place_eef == other.place_eef;
                ret &= support_surface_name == other.support_surface_name;
                ret &= allow_gripper_support_collision == other.allow_gripper_support_collision;
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
        public class PlaceResult : InnerActionMessage
    {
        			public Messages.moveit_msgs.MoveItErrorCodes error_code = new Messages.moveit_msgs.MoveItErrorCodes();
			public Messages.moveit_msgs.RobotState trajectory_start = new Messages.moveit_msgs.RobotState();
			public Messages.moveit_msgs.RobotTrajectory[] trajectory_stages;
			public string[] trajectory_descriptions;
			public Messages.moveit_msgs.PlaceLocation place_location = new Messages.moveit_msgs.PlaceLocation();



        public override string MD5Sum() { return "da2eea14de05cf0aa280f150a84ded50"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"MoveItErrorCodes error_code
RobotState trajectory_start
RobotTrajectory[] trajectory_stages
string[] trajectory_descriptions
PlaceLocation place_location"; }
		public override string MessageType { get { return "moveit_msgs/PlaceResult"; } }
        public override bool IsServiceComponent() { return false; }

        public PlaceResult()
        {
            
        }

        public PlaceResult(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PlaceResult(byte[] serializedMessage, ref int currentIndex)
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
                //place_location
                place_location = new Messages.moveit_msgs.PlaceLocation(serializedMessage, ref currentIndex);
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
                //place_location
                if (place_location == null)
                    place_location = new Messages.moveit_msgs.PlaceLocation();
                pieces.Add(place_location.Serialize(true));

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
                //place_location
                place_location = new Messages.moveit_msgs.PlaceLocation();
                place_location.Randomize();
        }

        public override bool Equals(RosMessage message)
        {
            if (message == null)
            {
                return false;
            }
            bool ret = true;
            PlaceResult other;
            try
            {
                other = (PlaceResult)message;
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
                ret &= place_location.Equals(other.place_location);

            return ret;
        }
    }



    //$ACTION_RESULT_MESSAGE


	[ActionFeedbackMessage]
        public class PlaceFeedback : InnerActionMessage
    {
        			public string state = "";



        public override string MD5Sum() { return "af6d3a99f0fbeb66d3248fa4b3e675fb"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"string state"; }
		public override string MessageType { get { return "moveit_msgs/PlaceFeedback"; } }
        public override bool IsServiceComponent() { return false; }

        public PlaceFeedback()
        {
            
        }

        public PlaceFeedback(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PlaceFeedback(byte[] serializedMessage, ref int currentIndex)
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
            PlaceFeedback other;
            try
            {
                other = (PlaceFeedback)message;
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