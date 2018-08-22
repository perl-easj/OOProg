namespace SlotMachineDemo.Interfaces.Logic
{
    /// <summary>
    /// Interface for generating a wheel symbol, based
    /// on current probability settings
    /// </summary>
    public interface ILogicSymbolGenerator
    {
        /// <summary>
        /// Generate a single wheel symbol, using the current probability settings
        /// </summary>
        Types.Enums.WheelSymbol GetWheelSymbol();

        void Reset();
    }
}