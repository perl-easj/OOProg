using System.Collections.Generic;
using SlotMachineDemo.Types;

namespace SlotMachineDemo.Interfaces.Logic
{
    /// <summary>
    /// Interface for managing the setup of winnings 
    /// for wheel symbol combinations.
    /// </summary>
    public interface ILogicWinningsSetup
    {
        /// <summary>
        /// Retrieve the current winnings settings, only including
        /// combinations paying a non-zero winning
        /// </summary>
        Dictionary<WheelSymbolCount, int> WinningsSettings { get; }

        /// <summary>
        /// Retrieve the current winnings settings, also including
        /// combinations paying zero winnings
        /// </summary>
        Dictionary<WheelSymbolCount, int> WinningsSettingsComplete { get; }

        /// <summary>
        /// Retrieve the winning amount for an outcome containing the
        /// specified number of the specified symbol.
        /// </summary>
        int GetWinnings(Enums.WheelSymbol symbol, int noOfSymbols);

        /// <summary>
        /// Set the winning amount for an outcome containing the
        /// specified number of the specified symbol.
        /// </summary>
        void SetWinnings(Enums.WheelSymbol symbol, int noOfSymbols, int winAmount);

        /// <summary>
        /// Set the winnings to the default winnings.
        /// </summary>
        void SetDefaultWinnings();
    }
}