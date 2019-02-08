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

namespace Messages.gazebo_msgs
{
    public class ODEJointProperties : RosMessage
    {

			public double[] damping;
			public double[] hiStop;
			public double[] loStop;
			public double[] erp;
			public double[] cfm;
			public double[] stop_erp;
			public double[] stop_cfm;
			public double[] fudge_factor;
			public double[] fmax;
			public double[] vel;


        public override string MD5Sum() { return "1b744c32a920af979f53afe2f9c3511f"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"float64[] damping
float64[] hiStop
float64[] loStop
float64[] erp
float64[] cfm
float64[] stop_erp
float64[] stop_cfm
float64[] fudge_factor
float64[] fmax
float64[] vel"; }
        public override string MessageType { get { return "gazebo_msgs/ODEJointProperties"; } }
        public override bool IsServiceComponent() { return false; }

        public ODEJointProperties()
        {
            
        }

        public ODEJointProperties(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public ODEJointProperties(byte[] serializedMessage, ref int currentIndex)
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
            
            //damping
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (damping == null)
                damping = new double[arraylength];
            else
                Array.Resize(ref damping, arraylength);
// Start Xamla
                //damping
                piecesize = Marshal.SizeOf(typeof(double)) * damping.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, damping, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //hiStop
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (hiStop == null)
                hiStop = new double[arraylength];
            else
                Array.Resize(ref hiStop, arraylength);
// Start Xamla
                //hiStop
                piecesize = Marshal.SizeOf(typeof(double)) * hiStop.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, hiStop, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //loStop
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (loStop == null)
                loStop = new double[arraylength];
            else
                Array.Resize(ref loStop, arraylength);
// Start Xamla
                //loStop
                piecesize = Marshal.SizeOf(typeof(double)) * loStop.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, loStop, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //erp
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (erp == null)
                erp = new double[arraylength];
            else
                Array.Resize(ref erp, arraylength);
// Start Xamla
                //erp
                piecesize = Marshal.SizeOf(typeof(double)) * erp.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, erp, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //cfm
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (cfm == null)
                cfm = new double[arraylength];
            else
                Array.Resize(ref cfm, arraylength);
// Start Xamla
                //cfm
                piecesize = Marshal.SizeOf(typeof(double)) * cfm.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, cfm, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //stop_erp
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (stop_erp == null)
                stop_erp = new double[arraylength];
            else
                Array.Resize(ref stop_erp, arraylength);
// Start Xamla
                //stop_erp
                piecesize = Marshal.SizeOf(typeof(double)) * stop_erp.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, stop_erp, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //stop_cfm
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (stop_cfm == null)
                stop_cfm = new double[arraylength];
            else
                Array.Resize(ref stop_cfm, arraylength);
// Start Xamla
                //stop_cfm
                piecesize = Marshal.SizeOf(typeof(double)) * stop_cfm.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, stop_cfm, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //fudge_factor
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (fudge_factor == null)
                fudge_factor = new double[arraylength];
            else
                Array.Resize(ref fudge_factor, arraylength);
// Start Xamla
                //fudge_factor
                piecesize = Marshal.SizeOf(typeof(double)) * fudge_factor.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, fudge_factor, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //fmax
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (fmax == null)
                fmax = new double[arraylength];
            else
                Array.Resize(ref fmax, arraylength);
// Start Xamla
                //fmax
                piecesize = Marshal.SizeOf(typeof(double)) * fmax.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, fmax, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

            //vel
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(serializedMessage, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (vel == null)
                vel = new double[arraylength];
            else
                Array.Resize(ref vel, arraylength);
// Start Xamla
                //vel
                piecesize = Marshal.SizeOf(typeof(double)) * vel.Length;
                if (currentIndex + piecesize > serializedMessage.Length) {
                    throw new Exception("Memory allocation failed: Ran out of bytes to read.");
                }
                Buffer.BlockCopy(serializedMessage, currentIndex, vel, 0, piecesize);
                currentIndex += piecesize;
// End Xamla

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
            
            //damping
            hasmetacomponents |= false;
            if (damping == null)
                damping = new double[0];
            pieces.Add(BitConverter.GetBytes(damping.Length));
// Start Xamla
                //damping
                x__size = Marshal.SizeOf(typeof(double)) * damping.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(damping, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //hiStop
            hasmetacomponents |= false;
            if (hiStop == null)
                hiStop = new double[0];
            pieces.Add(BitConverter.GetBytes(hiStop.Length));
// Start Xamla
                //hiStop
                x__size = Marshal.SizeOf(typeof(double)) * hiStop.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(hiStop, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //loStop
            hasmetacomponents |= false;
            if (loStop == null)
                loStop = new double[0];
            pieces.Add(BitConverter.GetBytes(loStop.Length));
// Start Xamla
                //loStop
                x__size = Marshal.SizeOf(typeof(double)) * loStop.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(loStop, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //erp
            hasmetacomponents |= false;
            if (erp == null)
                erp = new double[0];
            pieces.Add(BitConverter.GetBytes(erp.Length));
// Start Xamla
                //erp
                x__size = Marshal.SizeOf(typeof(double)) * erp.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(erp, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //cfm
            hasmetacomponents |= false;
            if (cfm == null)
                cfm = new double[0];
            pieces.Add(BitConverter.GetBytes(cfm.Length));
// Start Xamla
                //cfm
                x__size = Marshal.SizeOf(typeof(double)) * cfm.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(cfm, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //stop_erp
            hasmetacomponents |= false;
            if (stop_erp == null)
                stop_erp = new double[0];
            pieces.Add(BitConverter.GetBytes(stop_erp.Length));
// Start Xamla
                //stop_erp
                x__size = Marshal.SizeOf(typeof(double)) * stop_erp.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(stop_erp, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //stop_cfm
            hasmetacomponents |= false;
            if (stop_cfm == null)
                stop_cfm = new double[0];
            pieces.Add(BitConverter.GetBytes(stop_cfm.Length));
// Start Xamla
                //stop_cfm
                x__size = Marshal.SizeOf(typeof(double)) * stop_cfm.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(stop_cfm, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //fudge_factor
            hasmetacomponents |= false;
            if (fudge_factor == null)
                fudge_factor = new double[0];
            pieces.Add(BitConverter.GetBytes(fudge_factor.Length));
// Start Xamla
                //fudge_factor
                x__size = Marshal.SizeOf(typeof(double)) * fudge_factor.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(fudge_factor, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //fmax
            hasmetacomponents |= false;
            if (fmax == null)
                fmax = new double[0];
            pieces.Add(BitConverter.GetBytes(fmax.Length));
// Start Xamla
                //fmax
                x__size = Marshal.SizeOf(typeof(double)) * fmax.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(fmax, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

            //vel
            hasmetacomponents |= false;
            if (vel == null)
                vel = new double[0];
            pieces.Add(BitConverter.GetBytes(vel.Length));
// Start Xamla
                //vel
                x__size = Marshal.SizeOf(typeof(double)) * vel.Length;
                scratch1 = new byte[x__size];
                Buffer.BlockCopy(vel, 0, scratch1, 0, x__size);
                pieces.Add(scratch1);
// End Xamla

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
            
            //damping
            arraylength = rand.Next(10);
            if (damping == null)
                damping = new double[arraylength];
            else
                Array.Resize(ref damping, arraylength);
            for (int i=0;i<damping.Length; i++) {
                //damping[i]
                damping[i] = (rand.Next() + rand.NextDouble());
            }
            //hiStop
            arraylength = rand.Next(10);
            if (hiStop == null)
                hiStop = new double[arraylength];
            else
                Array.Resize(ref hiStop, arraylength);
            for (int i=0;i<hiStop.Length; i++) {
                //hiStop[i]
                hiStop[i] = (rand.Next() + rand.NextDouble());
            }
            //loStop
            arraylength = rand.Next(10);
            if (loStop == null)
                loStop = new double[arraylength];
            else
                Array.Resize(ref loStop, arraylength);
            for (int i=0;i<loStop.Length; i++) {
                //loStop[i]
                loStop[i] = (rand.Next() + rand.NextDouble());
            }
            //erp
            arraylength = rand.Next(10);
            if (erp == null)
                erp = new double[arraylength];
            else
                Array.Resize(ref erp, arraylength);
            for (int i=0;i<erp.Length; i++) {
                //erp[i]
                erp[i] = (rand.Next() + rand.NextDouble());
            }
            //cfm
            arraylength = rand.Next(10);
            if (cfm == null)
                cfm = new double[arraylength];
            else
                Array.Resize(ref cfm, arraylength);
            for (int i=0;i<cfm.Length; i++) {
                //cfm[i]
                cfm[i] = (rand.Next() + rand.NextDouble());
            }
            //stop_erp
            arraylength = rand.Next(10);
            if (stop_erp == null)
                stop_erp = new double[arraylength];
            else
                Array.Resize(ref stop_erp, arraylength);
            for (int i=0;i<stop_erp.Length; i++) {
                //stop_erp[i]
                stop_erp[i] = (rand.Next() + rand.NextDouble());
            }
            //stop_cfm
            arraylength = rand.Next(10);
            if (stop_cfm == null)
                stop_cfm = new double[arraylength];
            else
                Array.Resize(ref stop_cfm, arraylength);
            for (int i=0;i<stop_cfm.Length; i++) {
                //stop_cfm[i]
                stop_cfm[i] = (rand.Next() + rand.NextDouble());
            }
            //fudge_factor
            arraylength = rand.Next(10);
            if (fudge_factor == null)
                fudge_factor = new double[arraylength];
            else
                Array.Resize(ref fudge_factor, arraylength);
            for (int i=0;i<fudge_factor.Length; i++) {
                //fudge_factor[i]
                fudge_factor[i] = (rand.Next() + rand.NextDouble());
            }
            //fmax
            arraylength = rand.Next(10);
            if (fmax == null)
                fmax = new double[arraylength];
            else
                Array.Resize(ref fmax, arraylength);
            for (int i=0;i<fmax.Length; i++) {
                //fmax[i]
                fmax[i] = (rand.Next() + rand.NextDouble());
            }
            //vel
            arraylength = rand.Next(10);
            if (vel == null)
                vel = new double[arraylength];
            else
                Array.Resize(ref vel, arraylength);
            for (int i=0;i<vel.Length; i++) {
                //vel[i]
                vel[i] = (rand.Next() + rand.NextDouble());
            }
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.gazebo_msgs.ODEJointProperties;
            if (other == null)
                return false;
            if (damping.Length != other.damping.Length)
                return false;
            for (int __i__=0; __i__ < damping.Length; __i__++)
            {
                ret &= damping[__i__] == other.damping[__i__];
            }
            if (hiStop.Length != other.hiStop.Length)
                return false;
            for (int __i__=0; __i__ < hiStop.Length; __i__++)
            {
                ret &= hiStop[__i__] == other.hiStop[__i__];
            }
            if (loStop.Length != other.loStop.Length)
                return false;
            for (int __i__=0; __i__ < loStop.Length; __i__++)
            {
                ret &= loStop[__i__] == other.loStop[__i__];
            }
            if (erp.Length != other.erp.Length)
                return false;
            for (int __i__=0; __i__ < erp.Length; __i__++)
            {
                ret &= erp[__i__] == other.erp[__i__];
            }
            if (cfm.Length != other.cfm.Length)
                return false;
            for (int __i__=0; __i__ < cfm.Length; __i__++)
            {
                ret &= cfm[__i__] == other.cfm[__i__];
            }
            if (stop_erp.Length != other.stop_erp.Length)
                return false;
            for (int __i__=0; __i__ < stop_erp.Length; __i__++)
            {
                ret &= stop_erp[__i__] == other.stop_erp[__i__];
            }
            if (stop_cfm.Length != other.stop_cfm.Length)
                return false;
            for (int __i__=0; __i__ < stop_cfm.Length; __i__++)
            {
                ret &= stop_cfm[__i__] == other.stop_cfm[__i__];
            }
            if (fudge_factor.Length != other.fudge_factor.Length)
                return false;
            for (int __i__=0; __i__ < fudge_factor.Length; __i__++)
            {
                ret &= fudge_factor[__i__] == other.fudge_factor[__i__];
            }
            if (fmax.Length != other.fmax.Length)
                return false;
            for (int __i__=0; __i__ < fmax.Length; __i__++)
            {
                ret &= fmax[__i__] == other.fmax[__i__];
            }
            if (vel.Length != other.vel.Length)
                return false;
            for (int __i__=0; __i__ < vel.Length; __i__++)
            {
                ret &= vel[__i__] == other.vel[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
