using SlotMachineDemo.Configuration;
using SlotMachineDemo.Interfaces.Messages;
using SlotMachineDemo.Interfaces.Settings;
using SlotMachineDemo.Interfaces.WheelImages;
using SlotMachineDemo.Types;

namespace SlotMachineDemo.Implementations.Settings
{
    /// <summary>
    /// Provides an implementation of the default settings
    /// </summary>
    public class DefaultSettings : ICompileTimeSettingsReadOnly, IRunTimeSettingsReadOnly
    {
        public int NoOfRotationsPerSpin
        {
            get { return 20; }
        }

        public int RotationDelayMilliSecs
        {
            get { return 100; }
        }

        public int InitialCredits
        {
            get { return 10; }
        }

        public int NoOfRunsInAutoPlay
        {
            get { return 1000; }
        }

        public int AutoPlayUpdateThreshold
        {
            get { return 10000000; }
        }

        public Enums.UILanguage Language
        {
            get { return Enums.UILanguage.English; }
        }

        public Enums.UIImageSet ImageSet
        {
            get { return Enums.UIImageSet.A; }
        }

        public IMessages Messages
        {
            get { return null; }
        }

        public IWheelImage WheelImage
        {
            get { return null; }
        }

        public int InitialProbability(Enums.WheelSymbol symbol)
        {
            if (symbol == Enums.WheelSymbol.Bell) return 10;
            if (symbol == Enums.WheelSymbol.Cherry) return 30;
            if (symbol == Enums.WheelSymbol.Clover) return 60;

            return 0;
        }

        public int InitialWinnings(Enums.WheelSymbol symbol, int count)
        {
            if (symbol == Enums.WheelSymbol.Bell && count == 3) return 100;
            if (symbol == Enums.WheelSymbol.Cherry && count == 3) return 10;
            if (symbol == Enums.WheelSymbol.Clover && count == 3) return 1;
            if (symbol == Enums.WheelSymbol.Bell && count == 2) return 5;
            if (symbol == Enums.WheelSymbol.Cherry && count == 2) return 1;

            return 0;
        }

        public TickScale TickScaleWinnings
        {
            get { return new TickScale(Constants.TickScaleWinnings125Repeat); }
        }

        public TickScale TickScaleAutoPlay
        {
            get { return new TickScale(Constants.TickScaleAutoPlay10Power); }
        }
    }
}