using System.Collections.Generic;
using System.Collections.ObjectModel;
using SlotMachineDemo.Implementations.ViewModels;

namespace SlotMachineDemo.Interfaces.ViewModels
{
    /// <summary>
    /// Interface for the view model for the winnings part
    /// of the setup. 
    /// </summary>
    public interface IViewModelWinningsSetup
    {
        /// <summary>
        /// Retrieves a collection of winnings specification objects,
        /// to display in a list-oriented control (e.g. a ListView).
        /// </summary>
        ObservableCollection<ItemViewModelWinningsEntry> WinningsList { get; }
        ObservableCollection<ItemViewModelWinningsEntry> WinningsListCopy { get; }

        /// <summary>
        /// Tracks the winnings specification currently selected by the user.
        /// </summary>
        ItemViewModelWinningsEntry WinningsSelected { get; set; }

        /// <summary>
        /// Tracks the setting of a ticker-based control
        /// (e.g. a Slider) for setting the winnings amount 
        /// for the currently selected winnings entry.
        /// </summary>
        int WinningsTick { get; set; }

        /// <summary>
        /// The winnings amount for the currently selected winnings entry.
        /// </summary>
        int WinningsAmount { get; }

        /// <summary>
        /// Retrieves the set of currently active wheel symbol images.
        /// </summary>
        Dictionary<string, string> WheelSymbolImages { get; }
    }
}