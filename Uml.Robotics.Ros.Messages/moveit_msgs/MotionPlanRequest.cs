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
    public class MotionPlanRequest : RosMessage
    {

			public Messages.moveit_msgs.WorkspaceParameters workspace_parameters = new Messages.moveit_msgs.WorkspaceParameters();
			public Messages.moveit_msgs.RobotState start_state = new Messages.moveit_msgs.RobotState();
			public Messages.moveit_msgs.Constraints[] goal_constraints;
			public Messages.moveit_msgs.Constraints path_constraints = new Messages.moveit_msgs.Constraints();
			public Messages.moveit_msgs.TrajectoryConstraints trajectory_constraints = new Messages.moveit_msgs.TrajectoryConstraints();
			public string planner_id = "";
			public string group_name = "";
			public int num_planning_attempts;
			public double allowed_planning_time;
			public double max_velocity_scaling_factor;
			public double max_acceleration_scaling_factor;


        public override string MD5Sum() { return "c3bec13a525a6ae66e0fc57b768fdca6"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"WorkspaceParameters workspace_parameters
RobotState start_state
Constraints[] goal_constraints
Constraints path_constraints
TrajectoryConstraints trajectory_constraints
string planner_id
string group_name
int32 num_planning_attempts
float64 allowed_planning_time
float64 max_velocity_scaling_factor
float64 max_acceleration_scaling_factor"; }
        public override string MessageType { get { return "moveit_msgs/MotionPlanRequest"; } }
        public override bool IsServiceComponent() { return false; }

        public MotionPlanRequest()
        {
            
        }

        public MotionPlanRequest(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public MotionPlanRequest(byte[] serializedMessage, ref int currentIndex)
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
            
            //workspace_parameters
            workspace_parameters = new Messages.moveit_msgs.WorkspaceParameters(serializedMessage, ref currentIndex);
            //start_state
            start_state = new Messages.moveit_msgs.RobotState(serializedMessage, ref currentIndex);
            //goal_constraints
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (goal_constraints == null)
                goal_constraints = new Messages.moveit_msgs.Constraints[arraylength];
            else
                Array.Resize(ref goal_constraints, arraylength);
            for (int i=0;i<goal_constraints.Length; i++) {
                //goal_constraints[i]
                goal_constraints[i] = new Messages.moveit_msgs.Constraints(serializedMessage, ref currentIndex);
            }
            //path_constraints
            path_constraints = new Messages.moveit_msgs.Constraints(serializedMessage, ref currentIndex);
            //trajectory_constraints
            trajectory_constraints = new Messages.moveit_msgs.TrajectoryConstraints(serializedMessage, ref currentIndex);
            //planner_id
            planner_id = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            planner_id = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //group_name
            group_name = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            group_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //num_planning_attempts
            piecesize = Marshal.SizeOf(typeof(int));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            num_planning_attempts = (int)Marshal.PtrToStructure(h, typeof(int));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
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
            //max_velocity_scaling_factor
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            max_velocity_scaling_factor = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //max_acceleration_scaling_factor
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            max_acceleration_scaling_factor = (double)Marshal.PtrToStructure(h, typeof(double));
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
            
            //workspace_parameters
            if (workspace_parameters == null)
                workspace_parameters = new Messages.moveit_msgs.WorkspaceParameters();
            pieces.Add(workspace_parameters.Serialize(true));
            //start_state
            if (start_state == null)
                start_state = new Messages.moveit_msgs.RobotState();
            pieces.Add(start_state.Serialize(true));
            //goal_constraints
            hasmetacomponents |= true;
            if (goal_constraints == null)
                goal_constraints = new Messages.moveit_msgs.Constraints[0];
            pieces.Add(BitConverter.GetBytes(goal_constraints.Length));
            for (int i=0;i<goal_constraints.Length; i++) {
                //goal_constraints[i]
                if (goal_constraints[i] == null)
                    goal_constraints[i] = new Messages.moveit_msgs.Constraints();
                pieces.Add(goal_constraints[i].Serialize(true));
            }
            //path_constraints
            if (path_constraints == null)
                path_constraints = new Messages.moveit_msgs.Constraints();
            pieces.Add(path_constraints.Serialize(true));
            //trajectory_constraints
            if (trajectory_constraints == null)
                trajectory_constraints = new Messages.moveit_msgs.TrajectoryConstraints();
            pieces.Add(trajectory_constraints.Serialize(true));
            //planner_id
            if (planner_id == null)
                planner_id = "";
            scratch1 = Encoding.ASCII.GetBytes((string)planner_id);
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
            //num_planning_attempts
            scratch1 = new byte[Marshal.SizeOf(typeof(int))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(num_planning_attempts, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //allowed_planning_time
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(allowed_planning_time, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //max_velocity_scaling_factor
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(max_velocity_scaling_factor, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //max_acceleration_scaling_factor
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(max_acceleration_scaling_factor, h.AddrOfPinnedObject(), false);
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
            
            //workspace_parameters
            workspace_parameters = new Messages.moveit_msgs.WorkspaceParameters();
            workspace_parameters.Randomize();
            //start_state
            start_state = new Messages.moveit_msgs.RobotState();
            start_state.Randomize();
            //goal_constraints
            arraylength = rand.Next(10);
            if (goal_constraints == null)
                goal_constraints = new Messages.moveit_msgs.Constraints[arraylength];
            else
                Array.Resize(ref goal_constraints, arraylength);
            for (int i=0;i<goal_constraints.Length; i++) {
                //goal_constraints[i]
                goal_constraints[i] = new Messages.moveit_msgs.Constraints();
                goal_constraints[i].Randomize();
            }
            //path_constraints
            path_constraints = new Messages.moveit_msgs.Constraints();
            path_constraints.Randomize();
            //trajectory_constraints
            trajectory_constraints = new Messages.moveit_msgs.TrajectoryConstraints();
            trajectory_constraints.Randomize();
            //planner_id
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            planner_id = Encoding.ASCII.GetString(strbuf);
            //group_name
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            group_name = Encoding.ASCII.GetString(strbuf);
            //num_planning_attempts
            num_planning_attempts = rand.Next();
            //allowed_planning_time
            allowed_planning_time = (rand.Next() + rand.NextDouble());
            //max_velocity_scaling_factor
            max_velocity_scaling_factor = (rand.Next() + rand.NextDouble());
            //max_acceleration_scaling_factor
            max_acceleration_scaling_factor = (rand.Next() + rand.NextDouble());
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.MotionPlanRequest;
            if (other == null)
                return false;
            ret &= workspace_parameters.Equals(other.workspace_parameters);
            ret &= start_state.Equals(other.start_state);
            if (goal_constraints.Length != other.goal_constraints.Length)
                return false;
            for (int __i__=0; __i__ < goal_constraints.Length; __i__++)
            {
                ret &= goal_constraints[__i__].Equals(other.goal_constraints[__i__]);
            }
            ret &= path_constraints.Equals(other.path_constraints);
            ret &= trajectory_constraints.Equals(other.trajectory_constraints);
            ret &= planner_id == other.planner_id;
            ret &= group_name == other.group_name;
            ret &= num_planning_attempts == other.num_planning_attempts;
            ret &= allowed_planning_time == other.allowed_planning_time;
            ret &= max_velocity_scaling_factor == other.max_velocity_scaling_factor;
            ret &= max_acceleration_scaling_factor == other.max_acceleration_scaling_factor;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
