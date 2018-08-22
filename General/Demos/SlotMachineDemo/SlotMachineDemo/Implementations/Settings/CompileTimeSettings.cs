using SlotMachineDemo.Interfaces.Settings;
using SlotMachineDemo.Types;

namespace SlotMachineDemo.Implementations.Settings
{
    /// <summary>
    /// This class will hold the settings determined at compile-time. 
    /// The settings are initialised with a corresponding read-only settings object.
    ///  </summary>
    public class CompileTimeSettings : ICompileTimeSettings
    {
        #region Instance fields
        private ICompileTimeSettingsReadOnly _initialSettings;

        private int _noOfRotationsPerSpin;
        private int _rotationDelayMilliSecs;
        private int _initialCredits;
        private int _noOfRunsInAutoPlay;
        private int _autoPlayUpdateThreshold;

        private TickScale _tickScaleWinnings;
        private TickScale _tickScaleAutoPlay;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialise the setting from a given read-only settings object.
        /// This will typically be a "default settings" object.
        /// </summary>
        public CompileTimeSettings(ICompileTimeSettingsReadOnly initialSettings)
        {
            _initialSettings = initialSettings;

            _noOfRotationsPerSpin = initialSettings.NoOfRotationsPerSpin;
            _rotationDelayMilliSecs = initialSettings.RotationDelayMilliSecs;
            _initialCredits = initialSettings.InitialCredits;
            _noOfRunsInAutoPlay = initialSettings.NoOfRunsInAutoPlay;
            _autoPlayUpdateThreshold = initialSettings.AutoPlayUpdateThreshold;
            _tickScaleWinnings = initialSettings.TickScaleWinnings;
            _tickScaleAutoPlay = initialSettings.TickScaleAutoPlay;
        } 
        #endregion

        #region Settings properties
        public int NoOfRotationsPerSpin
        {
            get { return _noOfRotationsPerSpin; }
            set { _noOfRotationsPerSpin = value; }
        }

        public int RotationDelayMilliSecs
        {
            get { return _rotationDelayMilliSecs; }
            set { _rotationDelayMilliSecs = value; }
        }

        public int InitialCredits
        {
            get { return _initialCredits; }
            set { _initialCredits = value; }
        }

        public int NoOfRunsInAutoPlay
        {
            get { return _noOfRunsInAutoPlay; }
            set { _noOfRunsInAutoPlay = value; }
        }

        public int AutoPlayUpdateThreshold
        {
            get { return _autoPlayUpdateThreshold; }
            set { _autoPlayUpdateThreshold = value; }
        }

        public int InitialProbability(Types.Enums.WheelSymbol symbol)
        {
            return _initialSettings.InitialProbability(symbol);
        }

        public int InitialWinnings(Types.Enums.WheelSymbol symbol, int noOfSymbols)
        {
            return _initialSettings.InitialWinnings(symbol, noOfSymbols);
        }

        public TickScale TickScaleWinnings
        {
            get { return _tickScaleWinnings; }
            set { _tickScaleWinnings = value; }
        }

        public TickScale TickScaleAutoPlay
        {
            get { return _tickScaleAutoPlay; }
            set { _tickScaleAutoPlay = value; }
        }
        #endregion
    }
}
