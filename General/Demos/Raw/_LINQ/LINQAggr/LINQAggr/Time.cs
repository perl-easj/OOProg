namespace LINQAggr
{
    public class Time
    {
        public int Hours { get; private set; }
        public int Minutes { get; private set; }

        public int Length
        {
            get { return Hours * 60 + Minutes; }
        }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public void Reset(int hours)
        {
            Hours = hours;
            Minutes = 0;
        }

        public static Time operator +(Time tA, Time tB)
        {
            int totalMin = (tA.Hours * 60 + tA.Minutes) + 
                           (tB.Hours * 60 + tB.Minutes);

            return new Time(totalMin / 60, totalMin % 60);
        }

        public static Time operator *(int val, Time t)
        {
            int totalMin = (t.Hours * 60 + t.Minutes) * val;
            return new Time(totalMin / 60, totalMin % 60);
        }

        public static Time operator *(Time t, int val)
        {
            return val * t;
        }

        // ++ will add one minute to the time
        public static Time operator ++(Time t)
        {
            return (t + new Time(0,1));
        }

        public static bool operator >=(Time tA, Time tB)
        {
            return (tA.Length >= tB.Length);
        }

        public static bool operator <=(Time tA, Time tB)
        {
            return (tA.Length <= tB.Length);
        }

        public static bool operator ==(Time tA, Time tB)
        {
            return tA?.Equals(tB) ?? (tB is null);
        }

        public static bool operator !=(Time tA, Time tB)
        {
            return !(tA == tB);
        }

        public override bool Equals(object other)
        {
            if (other is null) return false;
            if (other.GetType() != GetType()) return false;

            Time tOther = (Time)other;
            return tOther.Length == Length;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Hours * 397) ^ Minutes;
            }
        }


        public override string ToString()
        {
            return $"The time is {Hours}:{Minutes}";
        }
    }
}