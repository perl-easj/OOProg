using SlotMachineDemo.Interfaces.Messages;
using SlotMachineDemo.Interfaces.WheelImages;

namespace SlotMachineDemo.Interfaces.Settings
{
    public interface IRunTimeSettings
    {
        /// <summary>
        /// Sets the language used in the UI.
        /// </summary>
        Types.Enums.UILanguage Language { get; set; }

        /// <summary>
        /// Sets the image set used for wheel images in the UI
        /// </summary>
        Types.Enums.UIImageSet ImageSet { get; set; }

        IMessages Messages { get; }
        IWheelImage WheelImage { get; }
    }
}