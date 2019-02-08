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
    public class PlannerParams : RosMessage
    {

			public string[] keys;
			public string[] values;
			public string[] descriptions;


        public override string MD5Sum() { return "cebdf4927996b9026bcf59a160d64145"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"string[] keys
string[] values
string[] descriptions"; }
        public override string MessageType { get { return "moveit_msgs/PlannerParams"; } }
        public override bool IsServiceComponent() { return false; }

        public PlannerParams()
        {
            
        }

        public PlannerParams(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public PlannerParams(byte[] serializedMessage, ref int currentIndex)
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
            
            //keys
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (keys == null)
                keys = new string[arraylength];
            else
                Array.Resize(ref keys, arraylength);
            for (int i=0;i<keys.Length; i++) {
                //keys[i]
                keys[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                keys[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
            }
            //values
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (values == null)
                values = new string[arraylength];
            else
                Array.Resize(ref values, arraylength);
            for (int i=0;i<values.Length; i++) {
                //values[i]
                values[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                values[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
            }
            //descriptions
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (descriptions == null)
                descriptions = new string[arraylength];
            else
                Array.Resize(ref descriptions, arraylength);
            for (int i=0;i<descriptions.Length; i++) {
                //descriptions[i]
                descriptions[i] = "";
                piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
                currentIndex += 4;
                descriptions[i] = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
                currentIndex += piecesize;
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
            
            //keys
            hasmetacomponents |= false;
            if (keys == null)
                keys = new string[0];
            pieces.Add(BitConverter.GetBytes(keys.Length));
            for (int i=0;i<keys.Length; i++) {
                //keys[i]
                if (keys[i] == null)
                    keys[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)keys[i]);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
            }
            //values
            hasmetacomponents |= false;
            if (values == null)
                values = new string[0];
            pieces.Add(BitConverter.GetBytes(values.Length));
            for (int i=0;i<values.Length; i++) {
                //values[i]
                if (values[i] == null)
                    values[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)values[i]);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
                pieces.Add(thischunk);
            }
            //descriptions
            hasmetacomponents |= false;
            if (descriptions == null)
                descriptions = new string[0];
            pieces.Add(BitConverter.GetBytes(descriptions.Length));
            for (int i=0;i<descriptions.Length; i++) {
                //descriptions[i]
                if (descriptions[i] == null)
                    descriptions[i] = "";
                scratch1 = Encoding.ASCII.GetBytes((string)descriptions[i]);
                thischunk = new byte[scratch1.Length + 4];
                scratch2 = BitConverter.GetBytes(scratch1.Length);
                Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
                Array.Copy(scratch2, thischunk, 4);
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
            
            //keys
            arraylength = rand.Next(10);
            if (keys == null)
                keys = new string[arraylength];
            else
                Array.Resize(ref keys, arraylength);
            for (int i=0;i<keys.Length; i++) {
                //keys[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                keys[i] = Encoding.ASCII.GetString(strbuf);
            }
            //values
            arraylength = rand.Next(10);
            if (values == null)
                values = new string[arraylength];
            else
                Array.Resize(ref values, arraylength);
            for (int i=0;i<values.Length; i++) {
                //values[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                values[i] = Encoding.ASCII.GetString(strbuf);
            }
            //descriptions
            arraylength = rand.Next(10);
            if (descriptions == null)
                descriptions = new string[arraylength];
            else
                Array.Resize(ref descriptions, arraylength);
            for (int i=0;i<descriptions.Length; i++) {
                //descriptions[i]
                strlength = rand.Next(100) + 1;
                strbuf = new byte[strlength];
                rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
                for (int __x__ = 0; __x__ < strlength; __x__++)
                    if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                        strbuf[__x__] = (byte)(rand.Next(254) + 1);
                strbuf[strlength - 1] = 0; //null terminate
                descriptions[i] = Encoding.ASCII.GetString(strbuf);
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.moveit_msgs.PlannerParams;
            if (other == null)
                return false;
            if (keys.Length != other.keys.Length)
                return false;
            for (int __i__=0; __i__ < keys.Length; __i__++)
            {
                ret &= keys[__i__] == other.keys[__i__];
            }
            if (values.Length != other.values.Length)
                return false;
            for (int __i__=0; __i__ < values.Length; __i__++)
            {
                ret &= values[__i__] == other.values[__i__];
            }
            if (descriptions.Length != other.descriptions.Length)
                return false;
            for (int __i__=0; __i__ < descriptions.Length; __i__++)
            {
                ret &= descriptions[__i__] == other.descriptions[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
