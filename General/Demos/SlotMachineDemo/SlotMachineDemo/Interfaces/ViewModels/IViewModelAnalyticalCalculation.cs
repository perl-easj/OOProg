namespace SlotMachineDemo.Interfaces.ViewModels
{
    /// <summary>
    /// Interface for the view model corresponding to the logic
    /// for analytically calculating a winnings percentage
    /// </summary>
    public interface IViewModelAnalyticalCalculation
    {
        /// <summary>
        /// Text for the theoretical winnings percentage for the
        /// current probability/winnings setup.
        /// </summary>
        string TheoreticalWinningsPercentageText { get; }
    }
}