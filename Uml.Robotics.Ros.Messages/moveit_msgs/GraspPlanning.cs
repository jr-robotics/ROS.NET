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
    public class GraspPlanning : RosService
    {
        public override string ServiceType { get { return "moveit_msgs/GraspPlanning"; } }
        public override string ServiceDefinition() { return @"string group_name
CollisionObject target
string[] support_surfaces
Grasp[] candidate_grasps
CollisionObject[] movable_obstacles
---
Grasp[] grasps
MoveItErrorCodes error_code"; }
        public override string MD5Sum() { return "6c1eec2555db251f88e13e06d2a82f0f"; }

        public GraspPlanning()
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
				public string group_name = "";
				public Messages.moveit_msgs.CollisionObject target = new Messages.moveit_msgs.CollisionObject();
				public string[] support_surfaces;
				public Messages.moveit_msgs.Grasp[] candidate_grasps;
				public Messages.moveit_msgs.CollisionObject[] movable_obstacles;


            public override string MD5Sum() { return "c234e9a645708cc86b57a43999746ae6"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"string group_name
CollisionObject target
string[] support_surfaces
Grasp[] candidate_grasps
CollisionObject[] movable_obstacles"; }
			public override string MessageType { get { return "moveit_msgs/GraspPlanning__Request"; } }
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
                
                //group_name
                group_name = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                group_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //target
                target = new Messages.moveit_msgs.CollisionObject(serializedMessage, ref currentIndex);
                //support_surfaces
                hasmetacomponents |= false;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (support_surfaces == null)
                    support_surfaces = new string[arraylength];
                else
                    Array.Resize(ref support_surfaces, arraylength);
                for (int i=0;i<support_surfaces.Length; i++) {
                    //support_surfaces[i]
                    support_surfaces[i] = "";
                    piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                    currentIndex += 4;
                    support_surfaces[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                    currentIndex += piecesize;
                }
                //candidate_grasps
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (candidate_grasps == null)
                    candidate_grasps = new Messages.moveit_msgs.Grasp[arraylength];
                else
                    Array.Resize(ref candidate_grasps, arraylength);
                for (int i=0;i<candidate_grasps.Length; i++) {
                    //candidate_grasps[i]
                    candidate_grasps[i] = new Messages.moveit_msgs.Grasp(serializedMessage, ref currentIndex);
                }
                //movable_obstacles
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (movable_obstacles == null)
                    movable_obstacles = new Messages.moveit_msgs.CollisionObject[arraylength];
                else
                    Array.Resize(ref movable_obstacles, arraylength);
                for (int i=0;i<movable_obstacles.Length; i++) {
                    //movable_obstacles[i]
                    movable_obstacles[i] = new Messages.moveit_msgs.CollisionObject(serializedMessage, ref currentIndex);
                }
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
                //target
                if (target == null)
                    target = new Messages.moveit_msgs.CollisionObject();
                pieces.Add(target.Serialize(true));
                //support_surfaces
                hasmetacomponents |= false;
                if (support_surfaces == null)
                    support_surfaces = new string[0];
                pieces.Add(BitConverter.GetBytes(support_surfaces.Length));
                for (int i=0;i<support_surfaces.Length; i++) {
                    //support_surfaces[i]
                    if (support_surfaces[i] == null)
                        support_surfaces[i] = "";
                    scratch1 = Encoding.ASCII.GetBytes((string)support_surfaces[i]);
                    thischunk = new byte[scratch1.Length + 4];
                    scratch2 = BitConverter.GetBytes(scratch1.Length);
                    Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                    Array.Copy(scratch2, thischunk, 4);
                    pieces.Add(thischunk);
                }
                //candidate_grasps
                hasmetacomponents |= true;
                if (candidate_grasps == null)
                    candidate_grasps = new Messages.moveit_msgs.Grasp[0];
                pieces.Add(BitConverter.GetBytes(candidate_grasps.Length));
                for (int i=0;i<candidate_grasps.Length; i++) {
                    //candidate_grasps[i]
                    if (candidate_grasps[i] == null)
                        candidate_grasps[i] = new Messages.moveit_msgs.Grasp();
                    pieces.Add(candidate_grasps[i].Serialize(true));
                }
                //movable_obstacles
                hasmetacomponents |= true;
                if (movable_obstacles == null)
                    movable_obstacles = new Messages.moveit_msgs.CollisionObject[0];
                pieces.Add(BitConverter.GetBytes(movable_obstacles.Length));
                for (int i=0;i<movable_obstacles.Length; i++) {
                    //movable_obstacles[i]
                    if (movable_obstacles[i] == null)
                        movable_obstacles[i] = new Messages.moveit_msgs.CollisionObject();
                    pieces.Add(movable_obstacles[i].Serialize(true));
                }
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
                
                //group_name
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                group_name = Encoding.ASCII.GetString(strbuf);
                //target
                target = new Messages.moveit_msgs.CollisionObject();
                target.Randomize();
                //support_surfaces
                arraylength = rand.Next(10);
                if (support_surfaces == null)
                    support_surfaces = new string[arraylength];
                else
                    Array.Resize(ref support_surfaces, arraylength);
                for (int i=0;i<support_surfaces.Length; i++) {
                    //support_surfaces[i]
                    strlength = rand.Next(100) + 1;
                    strbuf = new byte[strlength];
                    rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                    for (int __x__ = 0; __x__ < strlength; __x__++)
                        if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                            strbuf[__x__] = (byte)(rand.Next(254) + 1);
                    strbuf[strlength - 1] = 0; //null terminate
                    support_surfaces[i] = Encoding.ASCII.GetString(strbuf);
                }
                //candidate_grasps
                arraylength = rand.Next(10);
                if (candidate_grasps == null)
                    candidate_grasps = new Messages.moveit_msgs.Grasp[arraylength];
                else
                    Array.Resize(ref candidate_grasps, arraylength);
                for (int i=0;i<candidate_grasps.Length; i++) {
                    //candidate_grasps[i]
                    candidate_grasps[i] = new Messages.moveit_msgs.Grasp();
                    candidate_grasps[i].Randomize();
                }
                //movable_obstacles
                arraylength = rand.Next(10);
                if (movable_obstacles == null)
                    movable_obstacles = new Messages.moveit_msgs.CollisionObject[arraylength];
                else
                    Array.Resize(ref movable_obstacles, arraylength);
                for (int i=0;i<movable_obstacles.Length; i++) {
                    //movable_obstacles[i]
                    movable_obstacles[i] = new Messages.moveit_msgs.CollisionObject();
                    movable_obstacles[i].Randomize();
                }
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                moveit_msgs.GraspPlanning.Request other = (Messages.moveit_msgs.GraspPlanning.Request)____other;

                ret &= group_name == other.group_name;
                ret &= target.Equals(other.target);
                if (support_surfaces.Length != other.support_surfaces.Length)
                    return false;
                for (int __i__=0; __i__ < support_surfaces.Length; __i__++)
                {
                    ret &= support_surfaces[__i__] == other.support_surfaces[__i__];
                }
                if (candidate_grasps.Length != other.candidate_grasps.Length)
                    return false;
                for (int __i__=0; __i__ < candidate_grasps.Length; __i__++)
                {
                    ret &= candidate_grasps[__i__].Equals(other.candidate_grasps[__i__]);
                }
                if (movable_obstacles.Length != other.movable_obstacles.Length)
                    return false;
                for (int __i__=0; __i__ < movable_obstacles.Length; __i__++)
                {
                    ret &= movable_obstacles[__i__].Equals(other.movable_obstacles[__i__]);
                }
                return ret;
            }
        }

        public class Response : RosMessage
        {
				public Messages.moveit_msgs.Grasp[] grasps;
				public Messages.moveit_msgs.MoveItErrorCodes error_code = new Messages.moveit_msgs.MoveItErrorCodes();



            public override string MD5Sum() { return "c234e9a645708cc86b57a43999746ae6"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"Grasp[] grasps
MoveItErrorCodes error_code"; }
			public override string MessageType { get { return "moveit_msgs/GraspPlanning__Response"; } }
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
                
                //grasps
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (grasps == null)
                    grasps = new Messages.moveit_msgs.Grasp[arraylength];
                else
                    Array.Resize(ref grasps, arraylength);
                for (int i=0;i<grasps.Length; i++) {
                    //grasps[i]
                    grasps[i] = new Messages.moveit_msgs.Grasp(serializedMessage, ref currentIndex);
                }
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
                
                //grasps
                hasmetacomponents |= true;
                if (grasps == null)
                    grasps = new Messages.moveit_msgs.Grasp[0];
                pieces.Add(BitConverter.GetBytes(grasps.Length));
                for (int i=0;i<grasps.Length; i++) {
                    //grasps[i]
                    if (grasps[i] == null)
                        grasps[i] = new Messages.moveit_msgs.Grasp();
                    pieces.Add(grasps[i].Serialize(true));
                }
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
                
                //grasps
                arraylength = rand.Next(10);
                if (grasps == null)
                    grasps = new Messages.moveit_msgs.Grasp[arraylength];
                else
                    Array.Resize(ref grasps, arraylength);
                for (int i=0;i<grasps.Length; i++) {
                    //grasps[i]
                    grasps[i] = new Messages.moveit_msgs.Grasp();
                    grasps[i].Randomize();
                }
                //error_code
                error_code = new Messages.moveit_msgs.MoveItErrorCodes();
                error_code.Randomize();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                moveit_msgs.GraspPlanning.Response other = (Messages.moveit_msgs.GraspPlanning.Response)____other;

                if (grasps.Length != other.grasps.Length)
                    return false;
                for (int __i__=0; __i__ < grasps.Length; __i__++)
                {
                    ret &= grasps[__i__].Equals(other.grasps[__i__]);
                }
                ret &= error_code.Equals(other.error_code);
                // for each SingleType st:
                //    ret &= {st.Name} == other.{st.Name};
                return ret;
            }
        }
    }
}
