using System;

namespace Uml.Robotics.Ros
{
    public struct TimeData
    {
        public static readonly TimeData Zero = new TimeData(0, 0);

        public int sec;
        public int nsec;

        public TimeData(int s, int ns)
        {
            sec = s;
            nsec = ns;
        }

        public bool Equals(TimeData timer)
        {
            return (sec == timer.sec && nsec == timer.nsec);
        }

        public long Ticks
        {
            get { return sec * TimeSpan.TicksPerSecond + (long)Math.Floor(nsec / 100.0); }
        }

        public TimeSpan ToTimeSpan()
        {
            return new TimeSpan(this.Ticks);
        }

        public static TimeData FromTicks(long ticks)
        {
            return FromTicks((ulong)ticks);
        }

        public static TimeData FromTicks(ulong ticks)
        {
            ulong seconds = (((ulong)Math.Floor(1.0 * ticks / TimeSpan.TicksPerSecond)));
            ulong nanoseconds = 100 * (ticks % TimeSpan.TicksPerSecond);
            return new TimeData((int)seconds, (int)nanoseconds);
        }

        public static TimeData FromTimeSpan(TimeSpan value)
        {
            return FromTicks(value.Ticks);
        }
    }
}
