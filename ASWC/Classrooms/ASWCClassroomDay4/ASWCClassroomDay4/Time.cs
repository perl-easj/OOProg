namespace ASWCClassroomDay4.TimeLib
{
    public class Time
    {
        public int Hours { get; private set; }
        public int Minutes { get; private set; }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public int Length
        {
            get { return Hours * 60 + Minutes; }
        }

        public void Reset(int hours)
        {
            Hours = hours;
            Minutes = 0;
        }


        #region Overrides
        public override string ToString()
        {
            return $"The time is {Hours}:{Minutes}";
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
            unchecked { return (Hours * 397) ^ Minutes; }
        }
        #endregion

        #region Overload of +, * and ++
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

        public static Time operator ++(Time t)
        {
            return (t + new Time(0, 1));
        }
        #endregion

        #region Overload comparison operators
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
        #endregion
    }
}