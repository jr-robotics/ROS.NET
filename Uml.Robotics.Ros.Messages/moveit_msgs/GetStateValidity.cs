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
    public class GetStateValidity : RosService
    {
        public override string ServiceType { get { return "moveit_msgs/GetStateValidity"; } }
        public override string ServiceDefinition() { return @"RobotState robot_state
string group_name
Constraints constraints
---
bool valid
ContactInformation[] contacts
CostSource[] cost_sources
ConstraintEvalResult[] constraint_result"; }
        public override string MD5Sum() { return "0c7c937b6a056e7ae5fded13d8e9b242"; }

        public GetStateValidity()
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
				public Messages.moveit_msgs.RobotState robot_state = new Messages.moveit_msgs.RobotState();
				public string group_name = "";
				public Messages.moveit_msgs.Constraints constraints = new Messages.moveit_msgs.Constraints();


            public override string MD5Sum() { return "b569c609cafad20ba7d0e46e70e7cab1"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"RobotState robot_state
string group_name
Constraints constraints"; }
			public override string MessageType { get { return "moveit_msgs/GetStateValidity__Request"; } }
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
                
                //robot_state
                robot_state = new Messages.moveit_msgs.RobotState(serializedMessage, ref currentIndex);
                //group_name
                group_name = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                group_name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
                //constraints
                constraints = new Messages.moveit_msgs.Constraints(serializedMessage, ref currentIndex);
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
                
                //robot_state
                if (robot_state == null)
                    robot_state = new Messages.moveit_msgs.RobotState();
                pieces.Add(robot_state.Serialize(true));
                //group_name
                if (group_name == null)
                    group_name = "";
                scratch1 = Encoding.ASCII.GetBytes((string)group_name);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
                //constraints
                if (constraints == null)
                    constraints = new Messages.moveit_msgs.Constraints();
                pieces.Add(constraints.Serialize(true));
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
                
                //robot_state
                robot_state = new Messages.moveit_msgs.RobotState();
                robot_state.Randomize();
                //group_name
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                group_name = Encoding.ASCII.GetString(strbuf);
                //constraints
                constraints = new Messages.moveit_msgs.Constraints();
                constraints.Randomize();
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                moveit_msgs.GetStateValidity.Request other = (Messages.moveit_msgs.GetStateValidity.Request)____other;

                ret &= robot_state.Equals(other.robot_state);
                ret &= group_name == other.group_name;
                ret &= constraints.Equals(other.constraints);
                return ret;
            }
        }

        public class Response : RosMessage
        {
				public bool valid;
				public Messages.moveit_msgs.ContactInformation[] contacts;
				public Messages.moveit_msgs.CostSource[] cost_sources;
				public Messages.moveit_msgs.ConstraintEvalResult[] constraint_result;



            public override string MD5Sum() { return "b569c609cafad20ba7d0e46e70e7cab1"; }
            public override bool HasHeader() { return false; }
            public override bool IsMetaType() { return true; }
            public override string MessageDefinition() { return @"bool valid
ContactInformation[] contacts
CostSource[] cost_sources
ConstraintEvalResult[] constraint_result"; }
			public override string MessageType { get { return "moveit_msgs/GetStateValidity__Response"; } }
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
                
                //valid
                valid = serializedMessage[currentIndex++]==1;
                //contacts
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (contacts == null)
                    contacts = new Messages.moveit_msgs.ContactInformation[arraylength];
                else
                    Array.Resize(ref contacts, arraylength);
                for (int i=0;i<contacts.Length; i++) {
                    //contacts[i]
                    contacts[i] = new Messages.moveit_msgs.ContactInformation(serializedMessage, ref currentIndex);
                }
                //cost_sources
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (cost_sources == null)
                    cost_sources = new Messages.moveit_msgs.CostSource[arraylength];
                else
                    Array.Resize(ref cost_sources, arraylength);
                for (int i=0;i<cost_sources.Length; i++) {
                    //cost_sources[i]
                    cost_sources[i] = new Messages.moveit_msgs.CostSource(serializedMessage, ref currentIndex);
                }
                //constraint_result
                hasmetacomponents |= true;
                arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += Marshal.SizeOf(typeof(System.Int32));
                if (constraint_result == null)
                    constraint_result = new Messages.moveit_msgs.ConstraintEvalResult[arraylength];
                else
                    Array.Resize(ref constraint_result, arraylength);
                for (int i=0;i<constraint_result.Length; i++) {
                    //constraint_result[i]
                    constraint_result[i] = new Messages.moveit_msgs.ConstraintEvalResult(serializedMessage, ref currentIndex);
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
                
                //valid
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)valid ? 1 : 0 );
                pieces.Add(thischunk);
                //contacts
                hasmetacomponents |= true;
                if (contacts == null)
                    contacts = new Messages.moveit_msgs.ContactInformation[0];
                pieces.Add(BitConverter.GetBytes(contacts.Length));
                for (int i=0;i<contacts.Length; i++) {
                    //contacts[i]
                    if (contacts[i] == null)
                        contacts[i] = new Messages.moveit_msgs.ContactInformation();
                    pieces.Add(contacts[i].Serialize(true));
                }
                //cost_sources
                hasmetacomponents |= true;
                if (cost_sources == null)
                    cost_sources = new Messages.moveit_msgs.CostSource[0];
                pieces.Add(BitConverter.GetBytes(cost_sources.Length));
                for (int i=0;i<cost_sources.Length; i++) {
                    //cost_sources[i]
                    if (cost_sources[i] == null)
                        cost_sources[i] = new Messages.moveit_msgs.CostSource();
                    pieces.Add(cost_sources[i].Serialize(true));
                }
                //constraint_result
                hasmetacomponents |= true;
                if (constraint_result == null)
                    constraint_result = new Messages.moveit_msgs.ConstraintEvalResult[0];
                pieces.Add(BitConverter.GetBytes(constraint_result.Length));
                for (int i=0;i<constraint_result.Length; i++) {
                    //constraint_result[i]
                    if (constraint_result[i] == null)
                        constraint_result[i] = new Messages.moveit_msgs.ConstraintEvalResult();
                    pieces.Add(constraint_result[i].Serialize(true));
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
                int arraylength = -1;
                Random rand = new Random();
                int strlength;
                byte[] strbuf, myByte;
                
                //valid
                valid = rand.Next(2) == 1;
                //contacts
                arraylength = rand.Next(10);
                if (contacts == null)
                    contacts = new Messages.moveit_msgs.ContactInformation[arraylength];
                else
                    Array.Resize(ref contacts, arraylength);
                for (int i=0;i<contacts.Length; i++) {
                    //contacts[i]
                    contacts[i] = new Messages.moveit_msgs.ContactInformation();
                    contacts[i].Randomize();
                }
                //cost_sources
                arraylength = rand.Next(10);
                if (cost_sources == null)
                    cost_sources = new Messages.moveit_msgs.CostSource[arraylength];
                else
                    Array.Resize(ref cost_sources, arraylength);
                for (int i=0;i<cost_sources.Length; i++) {
                    //cost_sources[i]
                    cost_sources[i] = new Messages.moveit_msgs.CostSource();
                    cost_sources[i].Randomize();
                }
                //constraint_result
                arraylength = rand.Next(10);
                if (constraint_result == null)
                    constraint_result = new Messages.moveit_msgs.ConstraintEvalResult[arraylength];
                else
                    Array.Resize(ref constraint_result, arraylength);
                for (int i=0;i<constraint_result.Length; i++) {
                    //constraint_result[i]
                    constraint_result[i] = new Messages.moveit_msgs.ConstraintEvalResult();
                    constraint_result[i].Randomize();
                }
            }

            public override bool Equals(RosMessage ____other)
            {
                if (____other == null)
					return false;

                bool ret = true;
                moveit_msgs.GetStateValidity.Response other = (Messages.moveit_msgs.GetStateValidity.Response)____other;

                ret &= valid == other.valid;
                if (contacts.Length != other.contacts.Length)
                    return false;
                for (int __i__=0; __i__ < contacts.Length; __i__++)
                {
                    ret &= contacts[__i__].Equals(other.contacts[__i__]);
                }
                if (cost_sources.Length != other.cost_sources.Length)
                    return false;
                for (int __i__=0; __i__ < cost_sources.Length; __i__++)
                {
                    ret &= cost_sources[__i__].Equals(other.cost_sources[__i__]);
                }
                if (constraint_result.Length != other.constraint_result.Length)
                    return false;
                for (int __i__=0; __i__ < constraint_result.Length; __i__++)
                {
                    ret &= constraint_result[__i__].Equals(other.constraint_result[__i__]);
                }
                // for each SingleType st:
                //    ret &= {st.Name} == other.{st.Name};
                return ret;
            }
        }
    }
}
