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

namespace Messages.moveit_msgs
{
    public class GetCartesianPath : RosService
    {
        public override string ServiceType { get { return "moveit_msgs/GetCartesianPath"; } }
        public override string ServiceDefinition() { return @"Header header
RobotState start_state
string group_name
string link_name
geometry_msgs/Pose[] waypoints
float64 max_step
float64 jump_threshold
bool avoid_collisions
Constraints path_constraints
---
RobotState start_state
RobotTrajectory solution
float64 fraction
MoveItErrorCodes error_code"; }
        public override string MD5Sum() { return "5c9a54219f0d91a804e7670bc0e118f1"; }

        public GetCartesianPath()
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
				public Header header = new Header();
				public Messages.moveit_msgs.RobotState start_state = new Messages.moveit_msgs.RobotState();
				public string group_name = "";
				public string link_name = "";
				public Messages.geometry_msgs.Pose[] waypoints;
				public double max_step;
				public double jump_threshold;
				public bool avoid_collisions;
				public Messages.moveit_msgs.Constraints path_constraints = new Messages.moveit_msgs.Constraints();


            public override string MD5Sum() { return "b37c16ad7ed838d811a270a8054276b6"; }
            public override bool HasHeader() { return true; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"Header header
RobotState start_state
string group_name
string link_name
geometry_msgs/Pose[] waypoints
float64 max_step
float64 jump_threshold
bool avoid_collisions
Constraints path_constraints"; }
			public override string MessageType { get { return "moveit_msgs/GetCartesianPath__Request"; } }
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
                
                //header
                header = new Header(serializedMessage, ref currentIndex);
                //start_state
                start_state = new Messages.moveit_msgs.RobotState(serializedMessage, ref currentIndex);
                //group_name
                group_name = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                group_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //link_name
                link_name = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                link_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //waypoints
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (waypoints == null)
                    waypoints = new Messages.geometry_msgs.Pose[arraylength];
                else
                    Array.Resize(ref waypoints, arraylength);
                for (int i=0;i<waypoints.Length; i++) {
                    //waypoints[i]
                    waypoints[i] = new Messages.geometry_msgs.Pose(serializedMessage, ref currentIndex);
                }
                //max_step
                piecesize = Marshal.SizeOf(typeof(double));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                max_step = (double)Marshal.PtrToStructure(h, typeof(double));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //jump_threshold
                piecesize = Marshal.SizeOf(typeof(double));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                jump_threshold = (double)Marshal.PtrToStructure(h, typeof(double));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //avoid_collisions
                avoid_collisions = serializedMessage[currentIndex++]==1;
                //path_constraints
                path_constraints = new Messages.moveit_msgs.Constraints(serializedMessage, ref currentIndex);
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
                
                //header
                if (header == null)
                    header = new Header();
                pieces.Add(header.Serialize(true));
                //start_state
                if (start_state == null)
                    start_state = new Messages.moveit_msgs.RobotState();
                pieces.Add(start_state.Serialize(true));
                //group_name
                if (group_name == null)
                    group_name = "";
                scratch1 = Encoding.ASCII.GetBytes((string)group_name);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //link_name
                if (link_name == null)
                    link_name = "";
                scratch1 = Encoding.ASCII.GetBytes((string)link_name);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //waypoints
                hasmetacomponents |= true;
                if (waypoints == null)
                    waypoints = new Messages.geometry_msgs.Pose[0];
                pieces.Add(BitConverter.GetBytes(waypoints.Length));
                for (int i=0;i<waypoints.Length; i++) {
                    //waypoints[i]
                    if (waypoints[i] == null)
                        waypoints[i] = new Messages.geometry_msgs.Pose();
                    pieces.Add(waypoints[i].Serialize(true));
                }
                //max_step
                scratch1 = new byte[Marshal.SizeOf(typeof(double))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(max_step, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //jump_threshold
                scratch1 = new byte[Marshal.SizeOf(typeof(double))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(jump_threshold, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //avoid_collisions
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)avoid_collisions ? 1 : 0 );
                pieces.Add(thischunk);
                //path_constraints
                if (path_constraints == null)
                    path_constraints = new Messages.moveit_msgs.Constraints();
                pieces.Add(path_constraints.Serialize(true));
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
                
                //header
                header = new Header();
                header.Randomize();
                //start_state
                start_state = new Messages.moveit_msgs.RobotState();
                start_state.Randomize();
                //group_name
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                group_name = Encoding.ASCII.GetString(strbuf);
                //link_name
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                link_name = Encoding.ASCII.GetString(strbuf);
                //waypoints
                arraylength = rand.Next(10);
                if (waypoints == null)
                    waypoints = new Messages.geometry_msgs.Pose[arraylength];
                else
                    Array.Resize(ref waypoints, arraylength);
                for (int i=0;i<waypoints.Length; i++) {
                    //waypoints[i]
                    waypoints[i] = new Messages.geometry_msgs.Pose();
                    waypoints[i].Randomize();
                }
                //max_step
                max_step = (rand.Next() + rand.NextDouble());
                //jump_threshold
                jump_threshold = (rand.Next() + rand.NextDouble());
                //avoid_collisions
                avoid_collisions = rand.Next(2) == 1;
                //path_constraints
                path_constraints = new Messages.moveit_msgs.Constraints();
                path_constraints.Randomize();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                moveit_msgs.GetCartesianPath.Request other = (Messages.moveit_msgs.GetCartesianPath.Request)____other;

                ret &= header.Equals(other.header);
                ret &= start_state.Equals(other.start_state);
                ret &= group_name == other.group_name;
                ret &= link_name == other.link_name;
                if (waypoints.Length != other.waypoints.Length)
                    return false;
                for (int __i__=0; __i__ < waypoints.Length; __i__++)
                {
                    ret &= waypoints[__i__].Equals(other.waypoints[__i__]);
                }
                ret &= max_step == other.max_step;
                ret &= jump_threshold == other.jump_threshold;
                ret &= avoid_collisions == other.avoid_collisions;
                ret &= path_constraints.Equals(other.path_constraints);
                return ret;
            }
        }

        public class Response : RosMessage
        {
				public Messages.moveit_msgs.RobotState start_state = new Messages.moveit_msgs.RobotState();
				public Messages.moveit_msgs.RobotTrajectory solution = new Messages.moveit_msgs.RobotTrajectory();
				public double fraction;
				public Messages.moveit_msgs.MoveItErrorCodes error_code = new Messages.moveit_msgs.MoveItErrorCodes();



            public override string MD5Sum() { return "b37c16ad7ed838d811a270a8054276b6"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"RobotState start_state
RobotTrajectory solution
float64 fraction
MoveItErrorCodes error_code"; }
			public override string MessageType { get { return "moveit_msgs/GetCartesianPath__Response"; } }
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
                
                //start_state
                start_state = new Messages.moveit_msgs.RobotState(serializedMessage, ref currentIndex);
                //solution
                solution = new Messages.moveit_msgs.RobotTrajectory(serializedMessage, ref currentIndex);
                //fraction
                piecesize = Marshal.SizeOf(typeof(double));
                h = IntPtr.Zero;
                if (serializedMessage.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
                fraction = (double)Marshal.PtrToStructure(h, typeof(double));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
                //error_code
                error_code = new Messages.moveit_msgs.MoveItErrorCodes(serializedMessage, ref currentIndex);
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
                
                //start_state
                if (start_state == null)
                    start_state = new Messages.moveit_msgs.RobotState();
                pieces.Add(start_state.Serialize(true));
                //solution
                if (solution == null)
                    solution = new Messages.moveit_msgs.RobotTrajectory();
                pieces.Add(solution.Serialize(true));
                //fraction
                scratch1 = new byte[Marshal.SizeOf(typeof(double))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(fraction, h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
                //error_code
                if (error_code == null)
                    error_code = new Messages.moveit_msgs.MoveItErrorCodes();
                pieces.Add(error_code.Serialize(true));
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
                
                //start_state
                start_state = new Messages.moveit_msgs.RobotState();
                start_state.Randomize();
                //solution
                solution = new Messages.moveit_msgs.RobotTrajectory();
                solution.Randomize();
                //fraction
                fraction = (rand.Next() + rand.NextDouble());
                //error_code
                error_code = new Messages.moveit_msgs.MoveItErrorCodes();
                error_code.Randomize();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                moveit_msgs.GetCartesianPath.Response other = (Messages.moveit_msgs.GetCartesianPath.Response)____other;

                ret &= start_state.Equals(other.start_state);
                ret &= solution.Equals(other.solution);
                ret &= fraction == other.fraction;
                ret &= error_code.Equals(other.error_code);
                // for each SingleType st:
                //    ret &= {st.Name} == other.{st.Name};
                return ret;
            }
        }
    }
}
