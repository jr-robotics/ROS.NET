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

namespace Messages.dynamic_reconfigure
{
    public class ConfigDescription : RosMessage
    {

			public Messages.dynamic_reconfigure.Group[] groups;
			public Messages.dynamic_reconfigure.Config max = new Messages.dynamic_reconfigure.Config();
			public Messages.dynamic_reconfigure.Config min = new Messages.dynamic_reconfigure.Config();
			public Messages.dynamic_reconfigure.Config dflt = new Messages.dynamic_reconfigure.Config();


        public override string MD5Sum() { return "757ce9d44ba8ddd801bb30bc456f946f"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Group[] groups
Config max
Config min
Config dflt"; }
        public override string MessageType { get { return "dynamic_reconfigure/ConfigDescription"; } }
        public override bool IsServiceComponent() { return false; }

        public ConfigDescription()
        {
            
        }

        public ConfigDescription(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public ConfigDescription(byte[] serializedMessage, ref int currentIndex)
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
            
            //groups
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (groups == null)
                groups = new Messages.dynamic_reconfigure.Group[arraylength];
            else
                Array.Resize(ref groups, arraylength);
            for (int i=0;i<groups.Length; i++) {
                //groups[i]
                groups[i] = new Messages.dynamic_reconfigure.Group(serializedMessage, ref currentIndex);
            }
            //max
            max = new Messages.dynamic_reconfigure.Config(serializedMessage, ref currentIndex);
            //min
            min = new Messages.dynamic_reconfigure.Config(serializedMessage, ref currentIndex);
            //dflt
            dflt = new Messages.dynamic_reconfigure.Config(serializedMessage, ref currentIndex);
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
            
            //groups
            hasmetacomponents |= true;
            if (groups == null)
                groups = new Messages.dynamic_reconfigure.Group[0];
            pieces.Add(BitConverter.GetBytes(groups.Length));
            for (int i=0;i<groups.Length; i++) {
                //groups[i]
                if (groups[i] == null)
                    groups[i] = new Messages.dynamic_reconfigure.Group();
                pieces.Add(groups[i].Serialize(true));
            }
            //max
            if (max == null)
                max = new Messages.dynamic_reconfigure.Config();
            pieces.Add(max.Serialize(true));
            //min
            if (min == null)
                min = new Messages.dynamic_reconfigure.Config();
            pieces.Add(min.Serialize(true));
            //dflt
            if (dflt == null)
                dflt = new Messages.dynamic_reconfigure.Config();
            pieces.Add(dflt.Serialize(true));
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
            
            //groups
            arraylength = rand.Next(10);
            if (groups == null)
                groups = new Messages.dynamic_reconfigure.Group[arraylength];
            else
                Array.Resize(ref groups, arraylength);
            for (int i=0;i<groups.Length; i++) {
                //groups[i]
                groups[i] = new Messages.dynamic_reconfigure.Group();
                groups[i].Randomize();
            }
            //max
            max = new Messages.dynamic_reconfigure.Config();
            max.Randomize();
            //min
            min = new Messages.dynamic_reconfigure.Config();
            min.Randomize();
            //dflt
            dflt = new Messages.dynamic_reconfigure.Config();
            dflt.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.dynamic_reconfigure.ConfigDescription;
            if (other == null)
                return false;
            if (groups.Length != other.groups.Length)
                return false;
            for (int __i__=0; __i__ < groups.Length; __i__++)
            {
                ret &= groups[__i__].Equals(other.groups[__i__]);
            }
            ret &= max.Equals(other.max);
            ret &= min.Equals(other.min);
            ret &= dflt.Equals(other.dflt);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
