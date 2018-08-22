using SlotMachineDemo.Interfaces.Messages;
using SlotMachineDemo.Interfaces.WheelImages;

namespace SlotMachineDemo.Interfaces.Settings
{
    public interface IRunTimeSettingsReadOnly
    {
        /// <summary>
        /// Sets the language used in the UI.
        /// </summary>
        Types.Enums.UILanguage Language { get; }

        /// <summary>
        /// Sets the image set used for wheel images in the UI
        /// </summary>
        Types.Enums.UIImageSet ImageSet { get; }

        IMessages Messages { get; }
        IWheelImage WheelImage { get; }
    }
}