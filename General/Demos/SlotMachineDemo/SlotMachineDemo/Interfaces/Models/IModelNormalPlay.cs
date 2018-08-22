using System.Threading.Tasks;
using SlotMachineDemo.Interfaces.Controllers;
using SlotMachineDemo.Types;

namespace SlotMachineDemo.Interfaces.Models
{
    /// <summary>
    /// Interface for a model managing normal play.
    /// </summary>
    public interface IModelNormalPlay
    {
        /// <summary>
        /// Number of credits available for the player.
        /// </summary>
        int NoOfCredits { get; set; }

        /// <summary>
        /// Number of credits won after the most recent game.
        /// </summary>
        int CreditsWon { get; }

        /// <summary>
        /// Retrieves the wheels symbols currently showing
        /// </summary>
        WheelSymbolList WheelSymbols { get; }

        /// <summary>
        /// Current state of the game session
        /// </summary>
        Enums.NormalPlayState CurrentNormalPlayState { get; set; }

        /// <summary>
        /// Property to retrieve the command for initiating
        /// a single game (i.e. a "spin").
        /// </summary>
        ICommandExtended SpinCommand { get; }

        /// <summary>
        /// Property to retrieve the command for adding
        /// a single credit to the player's balance
        /// </summary>
        ICommandExtended AddCreditCommand { get; }

        /// <summary>
        /// Invokes a single game. The game will usually take some 
        /// seconds to complete, and should update the UI periodically
        /// </summary>
        Task Spin();
    }
}