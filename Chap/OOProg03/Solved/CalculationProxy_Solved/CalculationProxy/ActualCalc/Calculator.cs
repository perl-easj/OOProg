using System;
using CalculationProxy.Common;

namespace CalculationProxy.ActualCalc
{
    /// <summary>
    /// Class for simulating a complex calculation.
    /// </summary>
    public class Calculator : ICalculate
    {
        #region Instance fields
        private static Random _generator = new Random(Guid.NewGuid().GetHashCode());
        #endregion

        #region Constructor
        public Calculator()
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Simulate a calculation based on given (x,y).
        /// The calculation will return a integer value.
        /// </summary>
        public int Calculate(Coordinate c)
        {
            // Pause between 300ms and 700ms, to simulate a complex calculation
            System.Threading.Thread.Sleep(_generator.Next(300, 700));

            // Result is a deterministic function of x and y, i.e. the
            // result is always the same, given a speficic (x,y) pair.
            return (237 * c.X) + (1197 * c.Y);
        } 
        #endregion
    }
}