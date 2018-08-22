using System;
using System.Collections.Generic;
using SlotMachineDemo.Interfaces.Logic;
using SlotMachineDemo.Types;

namespace SlotMachineDemo.Implementations.Logic
{
    /// <summary>
    /// This class contains logic for generating a wheel symbol, 
    /// based on current probability settings. The implementation
    /// includes a caching functionality, mainly for speeding up
    /// the auto-play facility.
    /// </summary>
    public class LogicSymbolGenerator : ILogicSymbolGenerator
    {
        #region Instance fields
        private Random _randomGenerator;
        private Array _enumSymbols;
        private Dictionary<int, Enums.WheelSymbol> _cache;

        private ILogicProbabilitySetup _logicProbabilitySetup;
        #endregion

        #region Constructor
        public LogicSymbolGenerator(ILogicProbabilitySetup logicProbabilitySetup)
        {          
            _randomGenerator = new Random();
            _enumSymbols = Enum.GetValues(typeof(Enums.WheelSymbol));
            _cache = new Dictionary<int, Enums.WheelSymbol>();

            _logicProbabilitySetup = logicProbabilitySetup;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Generates a single wheel symbol, using the current probability settings.
        /// </summary>
        public Enums.WheelSymbol GetWheelSymbol()
        {
            int percent = _randomGenerator.Next(100);
            if (CacheContains(percent))
            {
                return CacheLookup(percent);
            }

            int accumulatedProbability = 0;
            foreach (Enums.WheelSymbol symbol in _enumSymbols)
            {
                accumulatedProbability += _logicProbabilitySetup.GetProbability(symbol);
                if (accumulatedProbability > percent)
                {
                    CacheInsert(percent, symbol);
                    return symbol;
                }
            }

            // Code will only reach this point if there is 
            // an error in the probability definitions.
            throw new ArgumentException(nameof(GetWheelSymbol));
        }

        /// <summary>
        /// Clears the cache. This method should be called whenever the
        /// probability settings are changed.
        /// </summary>
        public void Reset()
        {
            _cache.Clear();
        }
        #endregion

        #region Private methods for caching functionality
        /// <summary>
        /// Sees if the given value is present in the cache.
        /// </summary>
        private bool CacheContains(int percent)
        {
            return _cache.ContainsKey(percent);
        }

        /// <summary>
        /// Returns the cached value. For efficiency reasons, it is assumed
        /// that the caller has already checked that the value is present.
        /// </summary>
        private Enums.WheelSymbol CacheLookup(int percent)
        {
            return _cache[percent];
        }

        /// <summary>
        /// Inserts a new value into the cache.
        /// </summary>
        private void CacheInsert(int percent, Enums.WheelSymbol symbol)
        {
            _cache[percent] = symbol;
        } 
        #endregion
    }
}
