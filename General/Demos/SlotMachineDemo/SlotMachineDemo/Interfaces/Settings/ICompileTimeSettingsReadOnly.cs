using SlotMachineDemo.Types;

namespace SlotMachineDemo.Interfaces.Settings
{
    /// <summary>
    /// Interface for reading all value-based settings 
    /// </summary>
    public interface ICompileTimeSettingsReadOnly
    {
        /// <summary>
        /// Number of "rotations" performed when playing a single
        /// game. The UI will simulate a rotation by updating the 
        /// wheel symbol images
        /// </summary>
        int NoOfRotationsPerSpin { get; }

        /// <summary>
        /// Delay between each rotation.
        /// </summary>
        int RotationDelayMilliSecs { get; }

        /// <summary>
        /// Number of credits assigned to the player 
        /// at the start of a game session
        /// </summary>
        int InitialCredits { get; }

        /// <summary>
        /// Initial setting for the number of runs (i.e.) games 
        /// played when running an auto-play session
        /// </summary>
        int NoOfRunsInAutoPlay { get; }

        /// <summary>
        /// Sets the threshold for when to use continuous
        /// updating of numbers during an auto-play session
        /// </summary>
        int AutoPlayUpdateThreshold { get; }

        /// <summary>
        /// Initial settings for the probability for
        /// generating a specific wheel symbol
        /// </summary>
        int InitialProbability(Types.Enums.WheelSymbol symbol);

        /// <summary>
        /// Initial settings for the winnings for
        /// a specific wheel symbol combination
        /// </summary>
        int InitialWinnings(Types.Enums.WheelSymbol symbol, int noOfSymbols);

        /// <summary>
        /// Tick scale used for the winnings setup
        /// </summary>
        TickScale TickScaleWinnings { get; }

        /// <summary>
        /// Tick scale used for the auto-play setup
        /// </summary>
        TickScale TickScaleAutoPlay { get; }
    }
}