using System.Collections.Generic;
using SlotMachineDemo.Interfaces.Controllers;

namespace SlotMachineDemo.Interfaces.ViewModels
{
    /// <summary>
    /// Interface for the view model corresponding 
    /// to the normal-play model
    /// </summary>
    public interface IViewModelNormalPlay
    {
        /// <summary>
        /// Text to display on the control 
        /// for starting a single game.
        /// </summary>
        string PlayButtonText { get; }

        /// <summary>
        /// Text for displaying the header for the 
        /// Credits section
        /// </summary>
        string CreditsText { get; }

        /// <summary>
        /// Text for displaying the number of credits available
        /// </summary>
        string NoOfCreditsText { get; }

        /// <summary>
        /// Text for the current status of the game
        /// </summary>
        string StatusText { get; }

        /// <summary>
        /// Retrieves the image sources for the wheel symbols
        /// currently showing.
        /// </summary>
        Dictionary<int, string> WheelSource { get; }

        /// <summary>
        /// Property for initiating a single game (a "spin")
        /// </summary>
        ICommandExtended SpinCommand { get; }

        /// <summary>
        /// Property for adding a single credit to
        /// the player's balance
        /// </summary>
        ICommandExtended AddCreditCommand { get; }
    }
}