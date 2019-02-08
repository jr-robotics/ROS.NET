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
    public class AllowedCollisionMatrix : RosMessage
    {

			public string[] entry_names;
			public Messages.moveit_msgs.AllowedCollisionEntry[] entry_values;
			public string[] default_entry_names;
			public bool[] default_entry_values;


        public override string MD5Sum() { return "aedce13587eef0d79165a075659c1879"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"string[] entry_names
AllowedCollisionEntry[] entry_values
string[] default_entry_names
bool[] default_entry_values"; }
        public override string MessageType { get { return "moveit_msgs/AllowedCollisionMatrix"; } }
        public override bool IsServiceComponent() { return false; }

        public AllowedCollisionMatrix()
        {
            
        }

        public AllowedCollisionMatrix(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public AllowedCollisionMatrix(byte[] serializedMessage, ref int currentIndex)
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
            
            //entry_names
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (entry_names == null)
                entry_names = new string[arraylength];
            else
                Array.Resize(ref entry_names, arraylength);
            for (int i=0;i<entry_names.Length; i++) {
                //entry_names[i]
                entry_names[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                entry_names[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
            }
            //entry_values
            hasmetacomponents |= true;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (entry_values == null)
                entry_values = new Messages.moveit_msgs.AllowedCollisionEntry[arraylength];
            else
                Array.Resize(ref entry_values, arraylength);
            for (int i=0;i<entry_values.Length; i++) {
                //entry_values[i]
                entry_values[i] = new Messages.moveit_msgs.AllowedCollisionEntry(serializedMessage, ref currentIndex);
            }
            //default_entry_names
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (default_entry_names == null)
                default_entry_names = new string[arraylength];
            else
                Array.Resize(ref default_entry_names, arraylength);
            for (int i=0;i<default_entry_names.Length; i++) {
                //default_entry_names[i]
                default_entry_names[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                default_entry_names[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
            }
            //default_entry_values
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (default_entry_values == null)
                default_entry_values = new bool[arraylength];
            else
                Array.Resize(ref default_entry_values, arraylength);
            for (int i=0;i<default_entry_values.Length; i++) {
                //default_entry_values[i]
                default_entry_values[i] = serializedMessage[currentIndex++]==1;
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
            
            //entry_names
            hasmetacomponents |= false;
            if (entry_names == null)
                entry_names = new string[0];
            pieces.Add(BitConverter.GetBytes(entry_names.Length));
            for (int i=0;i<entry_names.Length; i++) {
                //entry_names[i]
                if (entry_names[i] == null)
                    entry_names[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)entry_names[i]);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
            }
            //entry_values
            hasmetacomponents |= true;
            if (entry_values == null)
                entry_values = new Messages.moveit_msgs.AllowedCollisionEntry[0];
            pieces.Add(BitConverter.GetBytes(entry_values.Length));
            for (int i=0;i<entry_values.Length; i++) {
                //entry_values[i]
                if (entry_values[i] == null)
                    entry_values[i] = new Messages.moveit_msgs.AllowedCollisionEntry();
                pieces.Add(entry_values[i].Serialize(true));
            }
            //default_entry_names
            hasmetacomponents |= false;
            if (default_entry_names == null)
                default_entry_names = new string[0];
            pieces.Add(BitConverter.GetBytes(default_entry_names.Length));
            for (int i=0;i<default_entry_names.Length; i++) {
                //default_entry_names[i]
                if (default_entry_names[i] == null)
                    default_entry_names[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)default_entry_names[i]);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
            }
            //default_entry_values
            hasmetacomponents |= false;
            if (default_entry_values == null)
                default_entry_values = new bool[0];
            pieces.Add(BitConverter.GetBytes(default_entry_values.Length));
            for (int i=0;i<default_entry_values.Length; i++) {
                //default_entry_values[i]
                thischunk = new byte[1];
                thischunk[0] = (byte) ((bool)default_entry_values[i] ? 1 : 0 );
                pieces.Add(thischunk);
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
            
            //entry_names
            arraylength = rand.Next(10);
            if (entry_names == null)
                entry_names = new string[arraylength];
            else
                Array.Resize(ref entry_names, arraylength);
            for (int i=0;i<entry_names.Length; i++) {
                //entry_names[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                entry_names[i] = Encoding.ASCII.GetString(strbuf);
            }
            //entry_values
            arraylength = rand.Next(10);
            if (entry_values == null)
                entry_values = new Messages.moveit_msgs.AllowedCollisionEntry[arraylength];
            else
                Array.Resize(ref entry_values, arraylength);
            for (int i=0;i<entry_values.Length; i++) {
                //entry_values[i]
                entry_values[i] = new Messages.moveit_msgs.AllowedCollisionEntry();
                entry_values[i].Randomize();
            }
            //default_entry_names
            arraylength = rand.Next(10);
            if (default_entry_names == null)
                default_entry_names = new string[arraylength];
            else
                Array.Resize(ref default_entry_names, arraylength);
            for (int i=0;i<default_entry_names.Length; i++) {
                //default_entry_names[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                default_entry_names[i] = Encoding.ASCII.GetString(strbuf);
            }
            //default_entry_values
            arraylength = rand.Next(10);
            if (default_entry_values == null)
                default_entry_values = new bool[arraylength];
            else
                Array.Resize(ref default_entry_values, arraylength);
            for (int i=0;i<default_entry_values.Length; i++) {
                //default_entry_values[i]
                default_entry_values[i] = rand.Next(2) == 1;
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.AllowedCollisionMatrix;
            if (other == null)
                return false;
            if (entry_names.Length != other.entry_names.Length)
                return false;
            for (int __i__=0; __i__ < entry_names.Length; __i__++)
            {
                ret &= entry_names[__i__] == other.entry_names[__i__];
            }
            if (entry_values.Length != other.entry_values.Length)
                return false;
            for (int __i__=0; __i__ < entry_values.Length; __i__++)
            {
                ret &= entry_values[__i__].Equals(other.entry_values[__i__]);
            }
            if (default_entry_names.Length != other.default_entry_names.Length)
                return false;
            for (int __i__=0; __i__ < default_entry_names.Length; __i__++)
            {
                ret &= default_entry_names[__i__] == other.default_entry_names[__i__];
            }
            if (default_entry_values.Length != other.default_entry_values.Length)
                return false;
            for (int __i__=0; __i__ < default_entry_values.Length; __i__++)
            {
                ret &= default_entry_values[__i__] == other.default_entry_values[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
