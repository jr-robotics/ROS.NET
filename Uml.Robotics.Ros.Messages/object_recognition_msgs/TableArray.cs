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

namespace Messages.object_recognition_msgs
{
    public class TableArray : RosMessage
    {

			public Header header = new Header();
			public Messages.object_recognition_msgs.Table[] tables;


        public override string MD5Sum() { return "d1c853e5acd0ed273eb6682dc01ab428"; }
        public override bool HasHeader() { return true; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"Header header
object_recognition_msgs/Table[] tables"; }
        public override string MessageType { get { return "object_recognition_msgs/TableArray"; } }
        public override bool IsServiceComponent() { return false; }

        public TableArray()
        {
            
        }

        public TableArray(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public TableArray(byte[] serializedMessage, ref int currentIndex)
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
            
            //header
            header = new Header(serializedMessage, ref currentIndex);
            //tables
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (tables == null)
                tables = new Messages.object_recognition_msgs.Table[arraylength];
            else
                Array.Resize(ref tables, arraylength);
            for (int i=0;i<tables.Length; i++) {
                //tables[i]
                tables[i] = new Messages.object_recognition_msgs.Table(serializedMessage, ref currentIndex);
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
            
            //header
            if (header == null)
                header = new Header();
            pieces.Add(header.Serialize(true));
            //tables
            hasmetacomponents |= true;
            if (tables == null)
                tables = new Messages.object_recognition_msgs.Table[0];
            pieces.Add(BitConverter.GetBytes(tables.Length));
            for (int i=0;i<tables.Length; i++) {
                //tables[i]
                if (tables[i] == null)
                    tables[i] = new Messages.object_recognition_msgs.Table();
                pieces.Add(tables[i].Serialize(true));
            }
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
            
            //header
            header = new Header();
            header.Randomize();
            //tables
            arraylength = rand.Next(10);
            if (tables == null)
                tables = new Messages.object_recognition_msgs.Table[arraylength];
            else
                Array.Resize(ref tables, arraylength);
            for (int i=0;i<tables.Length; i++) {
                //tables[i]
                tables[i] = new Messages.object_recognition_msgs.Table();
                tables[i].Randomize();
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.object_recognition_msgs.TableArray;
            if (other == null)
                return false;
            ret &= header.Equals(other.header);
            if (tables.Length != other.tables.Length)
                return false;
            for (int __i__=0; __i__ < tables.Length; __i__++)
            {
                ret &= tables[__i__].Equals(other.tables[__i__]);
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
