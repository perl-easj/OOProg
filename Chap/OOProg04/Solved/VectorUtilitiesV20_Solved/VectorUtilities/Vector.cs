using System;

namespace VectorUtilities
{
    /// <summary>
    /// This class models a simple 2-dimensional vector,
    /// with an X- and Y-coordinate.
    /// </summary>
    public class Vector
    {
        #region Standard Vector functionality
        public double X { get; }
        public double Y { get; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Length
        {
            get { return Math.Sqrt(X * X + Y * Y); }
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
        #endregion

        #region Operator Overloads
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }

        public static double operator *(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public static bool operator >=(Vector a, Vector b)
        {
            return a.Length >= b.Length;
        }

        public static bool operator <=(Vector a, Vector b)
        {
            return a.Length <= b.Length;
        }
        #endregion

        #region Equality Overloads and Overrides
        // Three cases
        // 1) If other is null => false
        // 2) If other is of a different type => false
        // 3) Other is a valid Vector; check that coordinates are equal.
        public override bool Equals(object other)
        {
            if (other is null) return false;
            if (other.GetType() != GetType()) return false;

            Vector vOther = (Vector)other;
            // return (X == vOther.X) && (Y == vOther.Y); // Why does the compiler not like this?
            return X.CloseEnough(vOther.X) && Y.CloseEnough(vOther.Y); // Now the compiler is happy...
        }

        // Should be overrided as well, if you override Equals (why?)
        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        //Four cases:
        // 1) Both are null => true
        // 2) Only a is null => false
        // 3) Only b is null => false
        // 4) Both are not null => Equals decides.
        public static bool operator ==(Vector a, Vector b)
        {
            return a?.Equals(b) ?? (b is null);
        }

        // Oh, wow...
        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b);
        } 
        #endregion
    }
}