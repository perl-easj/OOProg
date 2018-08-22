using System;
using System.Collections.Generic;
using SlotMachineDemo.Interfaces.WheelImages;

namespace SlotMachineDemo.Implementations.WheelImages
{
    /// <summary>
    /// This class contains functionality for managing image sources
    /// for images to display in the UI. Actual image sources are
    /// specified in derived classes.
    /// </summary>
    public abstract class WheelImageBase : IWheelImage
    {
        private Dictionary<Types.Enums.WheelSymbol, string> _imageSources;

        protected WheelImageBase()
        {
            _imageSources = new Dictionary<Types.Enums.WheelSymbol, string>();
        }

        /// <summary>
        /// Retrieves the image source corresponding to the 
        /// specified wheel symbol.
        /// Trying to retrieve the source for a wheel symbol for which 
        /// no source has been specificed will cause an exception.
        /// </summary>
        public string GetImageSource(Types.Enums.WheelSymbol symbol)
        {
            if (_imageSources.ContainsKey(symbol))
            {
                return _imageSources[symbol];
            }

            throw new ArgumentException(nameof(GetImageSource));
        }

        /// <summary>
        /// Retrieves the entire set of image sources. The string 
        /// representations of the wheel symbols are used as keys.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAllImageSources()
        {
            Dictionary<string, string> imageSources = new Dictionary<string, string>();
            foreach (Types.Enums.WheelSymbol symbol in Enum.GetValues(typeof(Types.Enums.WheelSymbol)))
            {
                imageSources.Add(Enum.GetName(typeof(Types.Enums.WheelSymbol), symbol), GetImageSource(symbol));
            }

            return imageSources;
        }

        /// <summary>
        /// Set an image source for a specific wheel symbol.
        /// Trying to set the image source twice for the same 
        /// symbol will cause an exception.
        /// </summary>
        protected void SetImageSource(Types.Enums.WheelSymbol symbol, string imageSource)
        {
            if (_imageSources.ContainsKey(symbol))
            {
                throw new ArgumentException(nameof(SetImageSource));
            }

            _imageSources.Add(symbol, imageSource);
        }
    }
}
