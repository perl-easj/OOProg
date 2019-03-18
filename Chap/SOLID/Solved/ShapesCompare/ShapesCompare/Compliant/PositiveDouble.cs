using System;

namespace ShapesCompare.Compliant
{
    public class PositiveDouble
    {
        private const double defaultLowerLimit = 0.0000000001;
        public double Value { get; }

        public PositiveDouble(double value, double lowerLimit = defaultLowerLimit)
        {
            if (value < lowerLimit)
            {
                throw new ArgumentException($"Value {value} is below limit of {lowerLimit}");
            }

            Value = value;
        }
    }
}