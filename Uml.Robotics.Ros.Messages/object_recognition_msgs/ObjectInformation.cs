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
    public class ObjectInformation : RosMessage
    {

			public string name = "";
			public Messages.shape_msgs.Mesh ground_truth_mesh = new Messages.shape_msgs.Mesh();
			public Messages.sensor_msgs.PointCloud2 ground_truth_point_cloud = new Messages.sensor_msgs.PointCloud2();


        public override string MD5Sum() { return "921ec39f51c7b927902059cf3300ecde"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return true; }
        public override string MessageDefinition() { return @"string name
shape_msgs/Mesh ground_truth_mesh
sensor_msgs/PointCloud2 ground_truth_point_cloud"; }
        public override string MessageType { get { return "object_recognition_msgs/ObjectInformation"; } }
        public override bool IsServiceComponent() { return false; }

        public ObjectInformation()
        {
            
        }

        public ObjectInformation(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public ObjectInformation(byte[] serializedMessage, ref int currentIndex)
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
            
            //name
            name = "";
            piecesize = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += 4;
            name = Encoding.ASCII.GetString(serializedMessage, currentIndex, piecesize);
            currentIndex += piecesize;
            //ground_truth_mesh
            ground_truth_mesh = new Messages.shape_msgs.Mesh(serializedMessage, ref currentIndex);
            //ground_truth_point_cloud
            ground_truth_point_cloud = new Messages.sensor_msgs.PointCloud2(serializedMessage, ref currentIndex);
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
            
            //name
            if (name == null)
                name = "";
            scratch1 = Encoding.ASCII.GetBytes((string)name);
            thischunk = new byte[scratch1.Length + 4];
            scratch2 = BitConverter.GetBytes(scratch1.Length);
            Array.Copy(scratch1, 0, thischunk, 4, scratch1.Length);
            Array.Copy(scratch2, thischunk, 4);
            pieces.Add(thischunk);
            //ground_truth_mesh
            if (ground_truth_mesh == null)
                ground_truth_mesh = new Messages.shape_msgs.Mesh();
            pieces.Add(ground_truth_mesh.Serialize(true));
            //ground_truth_point_cloud
            if (ground_truth_point_cloud == null)
                ground_truth_point_cloud = new Messages.sensor_msgs.PointCloud2();
            pieces.Add(ground_truth_point_cloud.Serialize(true));
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
            
            //name
            strlength = rand.Next(100) + 1;
            strbuf = new byte[strlength];
            rand.NextBytes(strbuf);  //fill the whole buffer with random bytes
            for (int __x__ = 0; __x__ < strlength; __x__++)
                if (strbuf[__x__] == 0) //replace null chars with non-null random ones
                    strbuf[__x__] = (byte)(rand.Next(254) + 1);
            strbuf[strlength - 1] = 0; //null terminate
            name = Encoding.ASCII.GetString(strbuf);
            //ground_truth_mesh
            ground_truth_mesh = new Messages.shape_msgs.Mesh();
            ground_truth_mesh.Randomize();
            //ground_truth_point_cloud
            ground_truth_point_cloud = new Messages.sensor_msgs.PointCloud2();
            ground_truth_point_cloud.Randomize();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.object_recognition_msgs.ObjectInformation;
            if (other == null)
                return false;
            ret &= name == other.name;
            ret &= ground_truth_mesh.Equals(other.ground_truth_mesh);
            ret &= ground_truth_point_cloud.Equals(other.ground_truth_point_cloud);
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
