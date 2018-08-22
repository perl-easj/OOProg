namespace SlotMachineDemo.Implementations.WheelImages
{
    /// <summary>
    /// Specific set of wheel image sources
    /// </summary>
    public class WheelImageA : WheelImageBase
    {
        public WheelImageA()
        {
            SetImageSource(Types.Enums.WheelSymbol.Bell, "..\\Assets\\ImageSetA\\Bell.jpg");
            SetImageSource(Types.Enums.WheelSymbol.Cherry, "..\\Assets\\ImageSetA\\Cherry.jpg");
            SetImageSource(Types.Enums.WheelSymbol.Clover, "..\\Assets\\ImageSetA\\Clover.jpg");
            SetImageSource(Types.Enums.WheelSymbol.Melon, "..\\Assets\\ImageSetA\\Melon.jpg");
            SetImageSource(Types.Enums.WheelSymbol.Seven, "..\\Assets\\ImageSetA\\Seven.jpg");
            SetImageSource(Types.Enums.WheelSymbol.Shoe, "..\\Assets\\ImageSetA\\Shoe.jpg");
        }
    }
}
