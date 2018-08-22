using SlotMachineDemo.Types;

namespace SlotMachineDemo.Interfaces.Logic
{
    /// <summary>
    /// Interface for analytically calculating a winnings percentage
    /// </summary>
    public interface ILogicAnalyticalCalculation
    {
        /// <summary>
        /// Calculate the payback percentage. The current 
        /// probability and winnings settings are used.
        /// </summary>
        double CalculatePaybackPercentage();

        /// <summary>
        /// Calculate the probability for an outcome containing
        /// the specified number of the specified symbol.
        /// </summary>
        double ProbabilityForSymbolCount(WheelSymbolCount wsCount);
    }
}