using SlotMachineDemo.Implementations.Properties;
using SlotMachineDemo.Interfaces.ViewModels;

namespace SlotMachineDemo.Implementations.ViewModels
{
    /// <summary>
    /// View model for handling the general settings
    /// for the slot machine 
    /// </summary>
    public class ViewModelMachineSettings : PropertySource, IViewModelMachineSettings
    {
        /// <summary>
        /// Toggles the currently chosen UI language
        /// </summary>
        public bool UILanguage
        {
            get { return Configuration.Setup.RunTimeSettings.Language == Types.Enums.UILanguage.English; }
            set { Configuration.Setup.RunTimeSettings.Language = value ? Types.Enums.UILanguage.English : Types.Enums.UILanguage.Danish; }
        }

        /// <summary>
        /// Toggles the currently chosen UI image set
        /// </summary>
        public bool UIImageSet
        {
            get { return Configuration.Setup.RunTimeSettings.ImageSet == Types.Enums.UIImageSet.A; }
            set { Configuration.Setup.RunTimeSettings.ImageSet = value ? Types.Enums.UIImageSet.A : Types.Enums.UIImageSet.B; }
        }
    }
}