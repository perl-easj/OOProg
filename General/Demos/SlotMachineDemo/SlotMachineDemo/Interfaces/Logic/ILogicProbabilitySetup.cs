using System.Collections.Generic;

namespace SlotMachineDemo.Interfaces.Logic
{
    /// <summary>
    /// Interface for managing the setup of 
    /// probabilities for wheel symbols.
    /// </summary>
    public interface ILogicProbabilitySetup
    {
        /// <summary>
        /// Retrieve the current probability settings
        /// </summary>
        Dictionary<Types.Enums.WheelSymbol, int> ProbabilitySettings { get; }

        /// <summary>
        /// Retrieve the probability for generating the specified symbol.
        /// </summary>
        int GetProbability(Types.Enums.WheelSymbol symbol);

        /// <summary>
        /// Set the probability for generating the specified symbol.
        /// </summary>
        void SetProbability(Types.Enums.WheelSymbol symbol, int percentage);

        /// <summary>
        /// Set the probabilities to the default probabilities.
        /// </summary>
        void SetDefaultProbabilities();
    }
}