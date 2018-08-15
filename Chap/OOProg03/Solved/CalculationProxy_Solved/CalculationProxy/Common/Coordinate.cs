using System;
// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local

namespace CalculationProxy.Common
{
    /// <summary>
    /// Class representing an integer coordinate.
    /// A valid coordinate must have x and y larger than zero,
    /// but not larger than XMax and YMax, respectively.
    /// </summary>
    public class Coordinate
    {
        #region Instance fields
        private static int _xMax = 5; // Default, can be changed by client
        private static int _yMax = 5; // Default, can be changed by client

        private int _x;
        private int _y;
        #endregion

        #region Constructor
        public Coordinate(int x, int y)
        {
            ValidateCoordinate(x, y);
            _x = x;
            _y = y;
        }
        #endregion

        #region Properties
        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public static int XMax
        {
            get { return _xMax; }
            set
            {
                ValidateValue("x", value);
                _xMax = value;
            }
        }

        public static int YMax
        {
            get { return _yMax; }
            set
            {
                ValidateValue("y", value);
                _yMax = value;
            }
        }
        #endregion

        #region Methods for validation
        private static void ValidateValue(string coord, int val)
        {
            if (val < 1)
            {
                throw new ArgumentException($"(Coordinate) {coord}Max must be at least 1");
            }
        }

        private static void ValidateCoordinate(int x, int y)
        {
            if ((x < 1) || (x > XMax))
            {
                throw new ArgumentException($"(Coordinate) x must be between 1 and {XMax}");
            }
            if ((y < 1) || (y > YMax))
            {
                throw new ArgumentException($"(Coordinate) y must be between 1 and {YMax}");
            }
        }
        #endregion

        #region Method overrides (to use Coordinate as key in Dictionary)
        public override int GetHashCode()
        {
            return (X * YMax) + Y;
        }

        public override bool Equals(object obj)
        {
            Coordinate other = (Coordinate)obj;
            if (other == null)
            {
                return false;
            }

            return (X == other.X) && (Y == other.Y);
        }
        #endregion
    }
}