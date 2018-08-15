namespace CalculationProxy.Common
{
    /// <summary>
    /// Interface for performing a calculation.
    /// </summary>
    public interface ICalculate
    {
        /// The calculation takes a Coordinate object
        /// as input, and returns an integer value.
        int Calculate(Coordinate c);
    }
}