namespace SlotMachineDemo.Implementations.WheelImages
{
    /// <summary>
    /// Specific set of wheel image sources
    /// </summary>
    public class WheelImageB : WheelImageBase
    {
        public WheelImageB()
        {
            SetImageSource(Types.Enums.WheelSymbol.Bell, "..\\Assets\\ImageSetB\\Bell.jpg");
            SetImageSource(Types.Enums.WheelSymbol.Cherry, "..\\Assets\\ImageSetB\\Cherry.jpg");
            SetImageSource(Types.Enums.WheelSymbol.Clover, "..\\Assets\\ImageSetB\\Clover.jpg");
            SetImageSource(Types.Enums.WheelSymbol.Melon, "..\\Assets\\ImageSetB\\Melon.jpg");
            SetImageSource(Types.Enums.WheelSymbol.Seven, "..\\Assets\\ImageSetB\\Seven.jpg");
            SetImageSource(Types.Enums.WheelSymbol.Shoe, "..\\Assets\\ImageSetB\\Shoe.jpg");
        }
    }
}
