using System.Collections.Generic;

namespace SlotMachineDemo.Interfaces.WheelImages
{
    /// <summary>
    /// Defines an interface for mapping wheel symbols
    /// to specific sources for wheel images.
    /// </summary>
    public interface IWheelImage
    {
        /// <summary>
        /// Retrieves the actual image source for the 
        /// specified wheel symbol.
        /// </summary>
        string GetImageSource(Types.Enums.WheelSymbol symbol);

        /// <summary>
        /// Retrieves the entire set of image sources for the 
        /// available wheel symbols.
        /// </summary>
        Dictionary<string, string> GetAllImageSources();
    }
}
