namespace SlotMachineDemo.Interfaces.ViewModels
{
    /// <summary>
    /// Interface for a view model handling the 
    /// slot machine general settings
    /// </summary>
    public interface IViewModelMachineSettings
    {
        /// <summary>
        /// Toggle the currently chosen UI language
        /// </summary>
        bool UILanguage { get; set; }

        /// <summary>
        /// Toggle the currently chosen UI image set
        /// </summary>
        bool UIImageSet { get; set; }
    }
}