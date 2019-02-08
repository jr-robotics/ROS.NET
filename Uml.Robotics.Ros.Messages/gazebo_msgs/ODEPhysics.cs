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
    public class ODEPhysics : RosMessage
    {

			public bool auto_disable_bodies;
			public uint sor_pgs_precon_iters;
			public uint sor_pgs_iters;
			public double sor_pgs_w;
			public double sor_pgs_rms_error_tol;
			public double contact_surface_layer;
			public double contact_max_correcting_vel;
			public double cfm;
			public double erp;
			public uint max_contacts;


        public override string MD5Sum() { return "667d56ddbd547918c32d1934503dc335"; }
        public override bool HasHeader() { return false; }
        public override bool IsMetaType() { return false; }
        public override string MessageDefinition() { return @"bool auto_disable_bodies
uint32 sor_pgs_precon_iters
uint32 sor_pgs_iters
float64 sor_pgs_w
float64 sor_pgs_rms_error_tol
float64 contact_surface_layer
float64 contact_max_correcting_vel
float64 cfm
float64 erp
uint32 max_contacts"; }
        public override string MessageType { get { return "gazebo_msgs/ODEPhysics"; } }
        public override bool IsServiceComponent() { return false; }

        public ODEPhysics()
        {
            
        }

        public ODEPhysics(byte[] serializedMessage)
        {
            Deserialize(serializedMessage);
        }

        public ODEPhysics(byte[] serializedMessage, ref int currentIndex)
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
            
            //auto_disable_bodies
            auto_disable_bodies = serializedMessage[currentIndex++]==1;
            //sor_pgs_precon_iters
            piecesize = Marshal.SizeOf(typeof(uint));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            sor_pgs_precon_iters = (uint)Marshal.PtrToStructure(h, typeof(uint));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //sor_pgs_iters
            piecesize = Marshal.SizeOf(typeof(uint));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            sor_pgs_iters = (uint)Marshal.PtrToStructure(h, typeof(uint));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //sor_pgs_w
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            sor_pgs_w = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //sor_pgs_rms_error_tol
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            sor_pgs_rms_error_tol = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //contact_surface_layer
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            contact_surface_layer = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //contact_max_correcting_vel
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            contact_max_correcting_vel = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //cfm
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            cfm = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //erp
            piecesize = Marshal.SizeOf(typeof(double));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            erp = (double)Marshal.PtrToStructure(h, typeof(double));
            Marshal.FreeHGlobal(h);
            currentIndex+= piecesize;
            //max_contacts
            piecesize = Marshal.SizeOf(typeof(uint));
            h = IntPtr.Zero;
            if (serializedMessage.Length - currentIndex != 0)
            {
                h = Marshal.AllocHGlobal(piecesize);
                Marshal.Copy(serializedMessage, currentIndex, h, piecesize);
            }
            if (h == IntPtr.Zero) throw new Exception("Memory allocation failed");
            max_contacts = (uint)Marshal.PtrToStructure(h, typeof(uint));
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
            
            //auto_disable_bodies
            thischunk = new byte[1];
            thischunk[0] = (byte) ((bool)auto_disable_bodies ? 1 : 0 );
            pieces.Add(thischunk);
            //sor_pgs_precon_iters
            scratch1 = new byte[Marshal.SizeOf(typeof(uint))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(sor_pgs_precon_iters, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //sor_pgs_iters
            scratch1 = new byte[Marshal.SizeOf(typeof(uint))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(sor_pgs_iters, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //sor_pgs_w
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(sor_pgs_w, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //sor_pgs_rms_error_tol
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(sor_pgs_rms_error_tol, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //contact_surface_layer
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(contact_surface_layer, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //contact_max_correcting_vel
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(contact_max_correcting_vel, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //cfm
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(cfm, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //erp
            scratch1 = new byte[Marshal.SizeOf(typeof(double))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(erp, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
            //max_contacts
            scratch1 = new byte[Marshal.SizeOf(typeof(uint))];
            h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
            Marshal.StructureToPtr(max_contacts, h.AddrOfPinnedObject(), false);
            h.Free();
            pieces.Add(scratch1);
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
            
            //auto_disable_bodies
            auto_disable_bodies = rand.Next(2) == 1;
            //sor_pgs_precon_iters
            sor_pgs_precon_iters = (uint)rand.Next();
            //sor_pgs_iters
            sor_pgs_iters = (uint)rand.Next();
            //sor_pgs_w
            sor_pgs_w = (rand.Next() + rand.NextDouble());
            //sor_pgs_rms_error_tol
            sor_pgs_rms_error_tol = (rand.Next() + rand.NextDouble());
            //contact_surface_layer
            contact_surface_layer = (rand.Next() + rand.NextDouble());
            //contact_max_correcting_vel
            contact_max_correcting_vel = (rand.Next() + rand.NextDouble());
            //cfm
            cfm = (rand.Next() + rand.NextDouble());
            //erp
            erp = (rand.Next() + rand.NextDouble());
            //max_contacts
            max_contacts = (uint)rand.Next();
        }

        public override bool Equals(RosMessage ____other)
        {
            if (____other == null)
				return false;
            bool ret = true;
            var other = ____other as Messages.gazebo_msgs.ODEPhysics;
            if (other == null)
                return false;
            ret &= auto_disable_bodies == other.auto_disable_bodies;
            ret &= sor_pgs_precon_iters == other.sor_pgs_precon_iters;
            ret &= sor_pgs_iters == other.sor_pgs_iters;
            ret &= sor_pgs_w == other.sor_pgs_w;
            ret &= sor_pgs_rms_error_tol == other.sor_pgs_rms_error_tol;
            ret &= contact_surface_layer == other.contact_surface_layer;
            ret &= contact_max_correcting_vel == other.contact_max_correcting_vel;
            ret &= cfm == other.cfm;
            ret &= erp == other.erp;
            ret &= max_contacts == other.max_contacts;
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
