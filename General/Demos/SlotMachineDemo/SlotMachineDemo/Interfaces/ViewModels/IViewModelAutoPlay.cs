using System.Collections.Generic;
using Windows.UI.Xaml;
using SlotMachineDemo.Interfaces.Controllers;

namespace SlotMachineDemo.Interfaces.ViewModels
{
    /// <summary>
    /// Interface for the view model corresponding 
    /// to the auto-play model
    /// </summary>
    public interface IViewModelAutoPlay
    {
        /// <summary>
        /// Text to display on the control to start/cancel
        /// an auto-play session
        /// </summary>
        string AutoPlayGoText { get; }

        /// <summary>
        /// Text informing about the state of the
        /// current auto-play session
        /// </summary>
        string AutoPlayStatusText { get; }

        /// <summary>
        /// Progress (measured in percent) of the current
        /// auto-play session
        /// </summary>
        int AutoPlayPercentCompleted { get; }

        /// <summary>
        /// Retrieves the visibility setting of the progress bar.
        /// The intention is that the progress bar should only be
        /// visible during the actual auto-play
        /// </summary>
        Visibility AutoPlayProgressBarVisibility { get; }

        /// <summary>
        /// Text informing about the number of runs to perform
        /// when an auto-play session is initiated
        /// </summary>
        string NoOfRunsText { get; }

        /// <summary>
        /// Tracks the setting of a ticker-based control
        /// (e.g. a Slider) for setting the number of runs.
        /// </summary>
        int NoOfRunsTick { get; set; }

        /// <summary>
        /// Retrives text data for the most recent auto-play session
        /// </summary>
        Dictionary<string, string> AutoRunDataText { get; }

        /// <summary>
        /// Property for initiating an auto-play session.
        /// </summary>
        ICommandExtended AutoCommand { get; }
    }
}