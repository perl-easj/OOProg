using System;
using System.Collections.Generic;
using SlotMachineDemo.Implementations.Properties;
using SlotMachineDemo.Interfaces.Logic;
using SlotMachineDemo.Interfaces.Settings;

namespace SlotMachineDemo.Implementations.Logic
{
    /// <summary>
    /// This class contains logic for managing the setup of 
    /// probabilities for wheel symbols.
    /// </summary>
    public class LogicProbabilitySetup : PropertySource, ILogicProbabilitySetup
    {
        private Dictionary<Types.Enums.WheelSymbol, int> _probabilitySettings;
        private ICompileTimeSettings _compileTimeSettings;

        #region Constructor
        public LogicProbabilitySetup(ICompileTimeSettings compileTimeSettings)
        {
            _compileTimeSettings = compileTimeSettings;
            _probabilitySettings = new Dictionary<Types.Enums.WheelSymbol, int>();
            SetDefaultProbabilities();
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Retrieves the current probability settings.
        /// </summary>
        public Dictionary<Types.Enums.WheelSymbol, int> ProbabilitySettings
        {
            get { return _probabilitySettings; }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Retrieves the probability for generating the specified symbol.
        /// An exception is thrown if the probability for the specified
        /// wheel symbol is not set.
        /// </summary>
        public int GetProbability(Types.Enums.WheelSymbol symbol)
        {
            if (!_probabilitySettings.ContainsKey(symbol))
            {
                throw new ArgumentException(nameof(GetProbability));
            }

            return _probabilitySettings[symbol];
        }

        /// <summary>
        /// Set the probability for generating the specified symbol.
        /// An exception is thrown if the probability percentage is out-of-range.
        /// Note that updating a probability will affect other probabilities, 
        /// since the sum of probability percentages is kept constant at 100.
        /// </summary>
        public void SetProbability(Types.Enums.WheelSymbol symbol, int percentage)
        {
            if (percentage < 0 || percentage > 100)
            {
                throw new ArgumentException(nameof(SetProbability));
            }

            SetProbabilityAndKeepConsistent(symbol, percentage);
            OnPropertyChanged(nameof(ProbabilitySettings));
        }

        /// <summary>
        /// Sets the probabilities to the default probabilities.
        /// </summary>
        public void SetDefaultProbabilities()
        {
            foreach (Types.Enums.WheelSymbol symbol in Enum.GetValues(typeof(Types.Enums.WheelSymbol)))
            {
                _probabilitySettings[symbol] = _compileTimeSettings.InitialProbability(symbol);
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Updates the specified probability, and adjusts other probabilities 
        /// such that the sum of probability percentages is kept constant at 100.
        /// </summary>
        private void SetProbabilityAndKeepConsistent(Types.Enums.WheelSymbol symbolChanged, int percentage)
        {
            int change = percentage - _probabilitySettings[symbolChanged];
            _probabilitySettings[symbolChanged] = percentage;

            // Adjust other probabilities with a total of "change"
            foreach (Types.Enums.WheelSymbol symbol in Enum.GetValues(typeof(Types.Enums.WheelSymbol)))
            {
                if (symbol != symbolChanged && change != 0)
                {
                    // Can we CHANGE probability for this symbol with the full change?
                    int potentialNewProb = _probabilitySettings[symbol] - change;
                    if (potentialNewProb <= 100 && potentialNewProb >= 0)
                    {
                        _probabilitySettings[symbol] = potentialNewProb;
                        change = 0;
                    }
                    else
                    {
                        // We actually decreased, so INCREASE probability for this symbol up to 100
                        if (change < 0 && _probabilitySettings[symbol] < 100)
                        {
                            change = change + (100 - _probabilitySettings[symbol]);
                            _probabilitySettings[symbol] = 100;
                        }

                        // We actually increased, so DECREASE probability for this symbol down to 0
                        if (change > 0 && _probabilitySettings[symbol] > 0)
                        {
                            change = change - _probabilitySettings[symbol];
                            _probabilitySettings[symbol] = 0;
                        }
                    }
                }
            }
        } 
        #endregion
    }
}
