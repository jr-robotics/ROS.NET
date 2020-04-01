using System;

namespace Uml.Robotics.Ros.Transforms
{
    public class Quaternion
    {
        public double W, X, Y, Z;

        public Quaternion()
            : this(0, 0, 0, 1)
        {
        }

        public Quaternion(double x, double y, double z, double w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public Quaternion(Quaternion shallow)
            : this(shallow.X, shallow.Y, shallow.Z, shallow.W)
        {
        }

        public Quaternion(Messages.geometry_msgs.Quaternion shallow)
            : this(shallow.x, shallow.y, shallow.z, shallow.w)
        {
        }

        public Messages.geometry_msgs.Quaternion ToMsg()
        {
            return new Messages.geometry_msgs.Quaternion { w = W, x = X, y = Y, z = Z };
        }

        public static Quaternion operator +(Quaternion v1, Quaternion v2)
        {
            return new Quaternion(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z, v1.W + v2.W);
        }

        public static Quaternion operator -(Quaternion v1)
        {
            return new Quaternion(-v1.X, -v1.Y, -v1.Z, -v1.W);
        }

        public static Quaternion operator -(Quaternion v1, Quaternion v2)
        {
            return v1 + (-v2);
        }

        public static Quaternion operator *(Quaternion v1, float d)
        {
            return v1 * (double)d;
        }

        public static Quaternion operator *(Quaternion v1, int d)
        {
            return v1 * (double)d;
        }

        public static Quaternion operator *(Quaternion v1, double d)
        {
            return new Quaternion(v1.X * d, v1.Y * d, v1.Z * d, v1.W * d);
        }

        public static Quaternion operator *(float d, Quaternion v1)
        {
            return v1 * (double)d;
        }

        public static Quaternion operator *(int d, Quaternion v1)
        {
            return v1 * (double)d;
        }

        public static Quaternion operator *(double d, Quaternion v1)
        {
            return v1 * d;
        }

        public static Quaternion operator *(Quaternion v1, Quaternion v2)
        {
            return new Quaternion(v1.X * v2.W + v1.Y * v2.Z - v1.Z * v2.Y + v1.W * v2.X,
                                    -v1.X * v2.Z + v1.Y * v2.W + v1.Z * v2.X + v1.W * v2.Y,
                                    v1.X * v2.Y - v1.Y * v2.X + v1.Z * v2.W + v1.W * v2.Z,
                                    -v1.X * v2.X - v1.Y * v2.Y - v1.Z * v2.Z + v1.W * v2.W);
        }

        public static Quaternion operator *(Quaternion v1, Vector3 v2)
        {
            return v1 * new Quaternion(v2.X, v2.Y, v2.Z, 0.0) * v1.Inverse();
        }

        public static Quaternion operator /(Quaternion v1, float s)
        {
            return v1 / (double)s;
        }

        public static Quaternion operator /(Quaternion v1, int s)
        {
            return v1 / (double)s;
        }

        public static Quaternion operator /(Quaternion v1, double s)
        {
            return v1 * (1.0 / s);
        }

        public Quaternion Inverse()
        {
            return new Quaternion(-X / Norm, -Y / Norm, -Z / Norm, W / Norm);
        }

        public double Dot(Quaternion q)
        {
            return X * q.X + Y * q.Y + Z * q.Z + W * q.W;
        }

        public double Length2 => Abs * Abs;

        public double Length =>
            Abs;

        public double Norm =>
            (X * X) + (Y * Y) + (Z * Z) + (W * W);

        public double Abs =>
            Math.Sqrt(Norm);

        public double Angle
        {
            get
            {
                if(W / Abs < -1)
                    return Math.Acos(-1) * 2.0;
                if(W / Abs > 1)
                    return Math.Acos(1) * 2.0;
                return Math.Acos(W / Abs) * 2.0;
            }
        }

        public override string ToString()
        {
            return string.Format("quat=({0:F4},{1:F4},{2:F4},{3:F4})", W, X, Y, Z);
        }

        public Vector3 RPY
        {
            get
            {
                Vector3 tmp = new Matrix3x3(this).GetYPR();
                return new Vector3(tmp.Z, tmp.Y, tmp.X);
            }
        }

        public static Quaternion FromRPY(Vector3 rpy)
        {
            double halfroll = rpy.X / 2;
            double halfpitch = rpy.Y / 2;
            double halfyaw = rpy.Z / 2;

            double sin_r2 = Math.Sin(halfroll);
            double sin_p2 = Math.Sin(halfpitch);
            double sin_y2 = Math.Sin(halfyaw);

            double cos_r2 = Math.Cos(halfroll);
            double cos_p2 = Math.Cos(halfpitch);
            double cos_y2 = Math.Cos(halfyaw);

            return new Quaternion(
                sin_r2 * cos_p2 * cos_y2 - cos_r2 * sin_p2 * sin_y2,
                cos_r2 * sin_p2 * cos_y2 + sin_r2 * cos_p2 * sin_y2,
                cos_r2 * cos_p2 * sin_y2 - sin_r2 * sin_p2 * cos_y2,
                cos_r2 * cos_p2 * cos_y2 + sin_r2 * sin_p2 * sin_y2
            );
        }

        public double AngleShortestPath(Quaternion q)
        {
            double s = Math.Sqrt(this.Length2 * q.Length2);
            if (Math.Abs(Dot(q) / s) > 1)
                return 0;
            if (Dot(q) < 0) // Take care of long angle case see http://en.wikipedia.org/wiki/Slerp
            {
                return Math.Acos(Dot(-q) / s) * 2.0;
            }
            return Math.Acos(Dot(q) / s) * 2.0;
        }

        public Quaternion Slerp(Quaternion q, double t)
        {
            double theta = AngleShortestPath(q);
            if (theta != 0)
            {
                double d = 1.0 / Math.Sin(theta);
                double s0 = Math.Sin((1.0 - t) * theta);
                double s1 = Math.Sin(t * theta);
                if (Dot(q) < 0) // Take care of long angle case see http://en.wikipedia.org/wiki/Slerp
                {
                    return new Quaternion(
                        (X * s0 + -1 * q.X * s1) * d,
                        (Y * s0 + -1 * q.Y * s1) * d,
                        (Z * s0 + -1 * q.Z * s1) * d,
                        (W * s0 + -1 * q.W * s1) * d);
                }
                return new Quaternion(
                    (X * s0 + q.X * s1) * d,
                    (Y * s0 + q.Y * s1) * d,
                    (Z * s0 + q.Z * s1) * d,
                    (W * s0 + q.W * s1) * d);
            }
            return new Quaternion(this);
        }
    }
}
