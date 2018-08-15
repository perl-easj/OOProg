using CalculationProxy.ActualCalc;
using CalculationProxy.CalcByProxy;

namespace CalculationProxy.Common
{
    /// <summary>
    /// Factory class for producing a calculator
    /// object according to chosen strategy.
    /// </summary>
    public class CalculatorFactory
    {
        public static ICalculate Create(bool useProxy)
        {
            return useProxy ? (ICalculate) new CalculatorProxy() : new Calculator();
        }
    }
}