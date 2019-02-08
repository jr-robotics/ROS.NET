using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using uint8 = System.Byte;
using Uml.Robotics.Ros;


using Messages.std_msgs;
using String=System.String;
using Messages.geometry_msgs;

namespace Messages.humanoid_nav_msgs
{
    public class PlanFootstepsBetweenFeet : RosService
    {
        public override string ServiceType { get { return "humanoid_nav_msgs/PlanFootstepsBetweenFeet"; } }
        public override string ServiceDefinition() { return @"humanoid_nav_msgs/StepTarget start_left
humanoid_nav_msgs/StepTarget start_right
humanoid_nav_msgs/StepTarget goal_left
humanoid_nav_msgs/StepTarget goal_right
---
bool result
humanoid_nav_msgs/StepTarget[] footsteps
float64 costs
float64 final_eps
float64 planning_time
int64 expanded_states"; }
        public override string MD5Sum() { return "a4b63c1d84c3783139a04f9abafe7214"; }

        public PlanFootstepsBetweenFeet()
        {
            InitSubtypes(new Request(), new Response());
        }

        public Response Invoke(Func<Request, Response> fn, Request req)
        {
            RosServiceDelegate rsd = (m)=>{
                Request r = m as Request;
                if (r == null)
                    throw new Exception("Invalid Service Request Type");
                return fn(r);
            };
            return (Response)GeneralInvoke(rsd, (RosMessage)req);
        }

        public Request req { get { return (Request)RequestMessage; } set { RequestMessage = (RosMessage)value; } }
        public Response resp { get { return (Response)ResponseMessage; } set { ResponseMessage = (RosMessage)value; } }

        public class Request : RosMessage
        {
				public Messages.humanoid_nav_msgs.StepTarget start_left = new Messages.humanoid_nav_msgs.StepTarget();
				public Messages.humanoid_nav_msgs.StepTarget start_right = new Messages.humanoid_nav_msgs.StepTarget();
				public Messages.humanoid_nav_msgs.StepTarget goal_left = new Messages.humanoid_nav_msgs.StepTarget();
				public Messages.humanoid_nav_msgs.StepTarget goal_right = new Messages.humanoid_nav_msgs.StepTarget();


            public override string MD5Sum() { return "a081711eb51a4a4283b2b9f345efe272"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"humanoid_nav_msgs/StepTarget start_left
humanoid_nav_msgs/StepTarget start_right
humanoid_nav_msgs/StepTarget goal_left
humanoid_nav_msgs/StepTarget goal_right"; }
			public override string MessageType { get { return "humanoid_nav_msgs/PlanFootstepsBetweenFeet__Request"; } }
            public override bool IsServiceComponent() { return true; }

            public Request()
            {
                
            }

            public Request(byte[] serializedMessage)
            {
                Deserialize(serializedMessage);
            }

            public Request(byte[] serializedMessage, ref int currentIndex)
            {
                Deserialize(serializedMessage, ref currentIndex);
            }

    

            public override void Deserialize(byte[] serializedMessage, ref int currentIndex)
            {
                int arraylength=-1;
                bool hasmetacomponents = false;
                byte[] thischunk, scratch1, scratch2;
                object __thing;
                int piecesize=0;
                IntPtr h;
                
                //start_left
                start_left = new Messages.humanoid_nav_msgs.StepTarget(serializedMessage, ref currentIndex);
                //start_right
                start_right = new Messages.humanoid_nav_msgs.StepTarget(serializedMessage, ref currentIndex);
                //goal_left
                goal_left = new Messages.humanoid_nav_msgs.StepTarget(serializedMessage, ref currentIndex);
                //goal_right
                goal_right = new Messages.humanoid_nav_msgs.StepTarget(serializedMessage, ref currentIndex);
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
                
                //start_left
                if (start_left == null)
                    start_left = new Messages.humanoid_nav_msgs.StepTarget();
                pieces.Add(start_left.Serialize(true));
                //start_right
                if (start_right == null)
                    start_right = new Messages.humanoid_nav_msgs.StepTarget();
                pieces.Add(start_right.Serialize(true));
                //goal_left
                if (goal_left == null)
                    goal_left = new Messages.humanoid_nav_msgs.StepTarget();
                pieces.Add(goal_left.Serialize(true));
                //goal_right
                if (goal_right == null)
                    goal_right = new Messages.humanoid_nav_msgs.StepTarget();
                pieces.Add(goal_right.Serialize(true));
                //combine every array in pieces into one array and return it
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
                int arraylength=-1;
                Random rand = new Random();
                int strlength;
                byte[] strbuf, myByte;
                
                //start_left
                start_left = new Messages.humanoid_nav_msgs.StepTarget();
                start_left.Randomize();
                //start_right
                start_right = new Messages.humanoid_nav_msgs.StepTarget();
                start_right.Randomize();
                //goal_left
                goal_left = new Messages.humanoid_nav_msgs.StepTarget();
                goal_left.Randomize();
                //goal_right
                goal_right = new Messages.humanoid_nav_msgs.StepTarget();
                goal_right.Randomize();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                humanoid_nav_msgs.PlanFootstepsBetweenFeet.Request other = (Messages.humanoid_nav_msgs.PlanFootstepsBetweenFeet.Request)____other;

                ret &= start_left.Equals(other.start_left);
                ret &= start_right.Equals(other.start_right);
                ret &= goal_left.Equals(other.goal_left);
                ret &= goal_right.Equals(other.goal_right);
                return ret;
            }
        }

        public class Response : RosMessage
        {
				public bool result;
				public Messages.humanoid_nav_msgs.StepTarget[] footsteps;
				public double costs;
				public double final_eps;
				public double planning_time;
				public long expanded_states;



            public override string MD5Sum() { return "a081711eb51a4a4283b2b9f345efe272"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"bool result
humanoid_nav_msgs/StepTarget[] footsteps
float64 costs
float64 final_eps
float64 planning_time
int64 expanded_states"; }
			public override string MessageType { get { return "humanoid_nav_msgs/PlanFootstepsBetweenFeet__Response"; } }
            public override bool IsServiceComponent() { return true; }

            public Response()
            {
                
            }

            public Response(byte[] serializedMessage)
            {
                Deserialize(serializedMessage);
            }

            public Response(byte[] serializedMessage, ref int currentIndex)
            {
                Deserialize(serializedMessage, ref currentIndex);
            }

	

            public override void Deserialize(byte[] serializedMessage, ref int currentIndex)
            {
                int arraylength = -1;
                bool hasmetacomponents = false;
                int piecesize = 0;
                byte[] thischunk, scratch1, scratch2;
                IntPtr h;
                object __thing;
                
                //result
                result = serializedMessage[currentIndex++]==1;
                //footsteps
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (footsteps == null)
                    footsteps = new Messages.humanoid_nav_msgs.StepTarget[arraylength];
                else
                    Array.Resize(ref footsteps, arraylength);
                for (int i=0;i<footsteps.Length; i++) {
                    //footsteps[i]
                    footsteps[i] = new Messages.humanoid_nav_msgs.StepTarget(serializedMessage, ref currentIndex);
                }
                //costs
                piecesize = Marshal.SizeOf(typeof(double));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                costs = (double)Marshal.PtrToStructure(h, typeof(double));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //final_eps
                piecesize = Marshal.SizeOf(typeof(double));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                final_eps = (double)Marshal.PtrToStructure(h, typeof(double));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //planning_time
                piecesize = Marshal.SizeOf(typeof(double));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                planning_time = (double)Marshal.PtrToStructure(h, typeof(double));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //expanded_states
                piecesize = Marshal.SizeOf(typeof(long));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                expanded_states = (long)Marshal.PtrToStructure(h, typeof(long));
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
                
                //result
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)result ? 1 : 0 );
                pieces.Add(thischunk);
                //footsteps
                hasmetacomponents |= true;
                if (footsteps == null)
                    footsteps = new Messages.humanoid_nav_msgs.StepTarget[0];
                pieces.Add(BitConverter.GetBytes(footsteps.Length));
                for (int i=0;i<footsteps.Length; i++) {
                    //footsteps[i]
                    if (footsteps[i] == null)
                        footsteps[i] = new Messages.humanoid_nav_msgs.StepTarget();
                    pieces.Add(footsteps[i].Serialize(true));
                }
                //costs
                scratch1 = new byte[Marshal.SizeOf(typeof(double))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(costs, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //final_eps
                scratch1 = new byte[Marshal.SizeOf(typeof(double))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(final_eps, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //planning_time
                scratch1 = new byte[Marshal.SizeOf(typeof(double))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(planning_time, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //expanded_states
                scratch1 = new byte[Marshal.SizeOf(typeof(long))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(expanded_states, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //combine every array in pieces into one array and return it
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
                
                //result
                result = rand.Next(2) == 1;
                //footsteps
                arraylength = rand.Next(10);
                if (footsteps == null)
                    footsteps = new Messages.humanoid_nav_msgs.StepTarget[arraylength];
                else
                    Array.Resize(ref footsteps, arraylength);
                for (int i=0;i<footsteps.Length; i++) {
                    //footsteps[i]
                    footsteps[i] = new Messages.humanoid_nav_msgs.StepTarget();
                    footsteps[i].Randomize();
                }
                //costs
                costs = (rand.Next() + rand.NextDouble());
                //final_eps
                final_eps = (rand.Next() + rand.NextDouble());
                //planning_time
                planning_time = (rand.Next() + rand.NextDouble());
                //expanded_states
                expanded_states = (System.Int64)(rand.Next() << 32) | rand.Next();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                humanoid_nav_msgs.PlanFootstepsBetweenFeet.Response other = (Messages.humanoid_nav_msgs.PlanFootstepsBetweenFeet.Response)____other;

                ret &= result == other.result;
                if (footsteps.Length != other.footsteps.Length)
                    return false;
                for (int __i__=0; __i__ < footsteps.Length; __i__++)
                {
                    ret &= footsteps[__i__].Equals(other.footsteps[__i__]);
                }
                ret &= costs == other.costs;
                ret &= final_eps == other.final_eps;
                ret &= planning_time == other.planning_time;
                ret &= expanded_states == other.expanded_states;
                // for each SingleType st:
                //    ret &= {st.Name} == other.{st.Name};
                return ret;
            }
        }
    }
}
