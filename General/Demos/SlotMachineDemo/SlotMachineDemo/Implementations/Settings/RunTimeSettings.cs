using System;
using SlotMachineDemo.Implementations.Messages;
using SlotMachineDemo.Implementations.WheelImages;
using SlotMachineDemo.Interfaces.Messages;
using SlotMachineDemo.Interfaces.Settings;
using SlotMachineDemo.Interfaces.WheelImages;

namespace SlotMachineDemo.Implementations.Settings
{
    /// <summary>
    /// This class will hold the settings that may change at run-time.. 
    /// The settings are initialised with a corresponding read-only settings object.
    ///  </summary>
    public class RunTimeSettings : IRunTimeSettings
    {
        private Types.Enums.UILanguage _language;
        private Types.Enums.UIImageSet _imageSet;

        public RunTimeSettings(IRunTimeSettingsReadOnly initialSettings)
        {
            _language = initialSettings.Language;
            _imageSet = initialSettings.ImageSet;
        }

        #region Settings related to implementation objects
        public Types.Enums.UILanguage Language
        {
            get { return _language; }
            set { _language = value; }
        }

        public Types.Enums.UIImageSet ImageSet
        {
            get { return _imageSet; }
            set { _imageSet = value; }
        }

        public IMessages Messages
        {
            get { return MessagesFactory(_language); }
        }

        public IWheelImage WheelImage
        {
            get { return WheelImageFactory(_imageSet); }
        }
        #endregion

        #region Factory methods for implementation objects
        /// <summary>
        /// Produces a specific implementation of 
        /// the IMessages interface
        /// </summary>
        private IMessages MessagesFactory(Types.Enums.UILanguage language)
        {
            switch (language)
            {
                case Types.Enums.UILanguage.Danish:
                    return new MessagesDanish();
                case Types.Enums.UILanguage.English:
                    return new MessagesEnglish();
                default:
                    throw new ArgumentException(nameof(MessagesFactory));
            }
        }

        /// <summary>
        /// Produces a specific implementation of 
        /// the IWheelImage interface
        /// </summary>
        private IWheelImage WheelImageFactory(Types.Enums.UIImageSet imageSet)
        {
            switch (imageSet)
            {
                case Types.Enums.UIImageSet.A:
                    return new WheelImageA();
                case Types.Enums.UIImageSet.B:
                    return new WheelImageB();
                default:
                    throw new ArgumentException(nameof(WheelImageFactory));
            }
        }
        #endregion
    }
}