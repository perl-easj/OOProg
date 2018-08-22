using System.Collections.Generic;
using SlotMachineDemo.Types;

namespace SlotMachineDemo.Interfaces.Logic
{
    /// <summary>
    /// Interface for calculate winnings, either for a single game outcome,
    /// or a set of game outcome data. The current winnings settings are used.
    /// </summary>
    public interface ILogicCalculateWinnings
    {
        /// <summary>
        /// Calculate winnings for a single game outcome.
        /// </summary>
        int CalculateWinnings(WheelSymbolList symbols);

        /// <summary>
        /// Calculate total winnings for a set of game outcomes.
        /// </summary>
        int CalculateTotalWinnings(Dictionary<int, int> runData);
    }
}