using System;
using System.Collections.Generic;
using SlotMachineDemo.Configuration;
using SlotMachineDemo.Implementations.Properties;
using SlotMachineDemo.Interfaces.Logic;
using SlotMachineDemo.Interfaces.Settings;
using SlotMachineDemo.Types;

namespace SlotMachineDemo.Implementations.Logic
{
    /// <summary>
    /// This class contains logic for managing the setup of 
    /// winnings for wheel symbol combinations.
    /// </summary>
    public class LogicWinningsSetup : PropertySource, ILogicWinningsSetup
    {
        private Dictionary<WheelSymbolCount, int> _winningsSettings;
        private ICompileTimeSettings _compileTimeSettings;

        #region Constructor
        public LogicWinningsSetup(ICompileTimeSettings compileTimeSettings)
        {
            _compileTimeSettings = compileTimeSettings;
            _winningsSettings = new Dictionary<WheelSymbolCount, int>();
            SetDefaultWinnings();
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Retrieve the current winnings settings, only including
        /// combinations paying a non-zero winning
        /// </summary>
        public Dictionary<WheelSymbolCount, int> WinningsSettings
        {
            get { return _winningsSettings; }
        }

        /// <summary>
        /// Retrieve the current winnings settings, also including
        /// combinations paying zero winnings
        /// </summary>
        public Dictionary<WheelSymbolCount, int> WinningsSettingsComplete
        {
            get
            {
                Dictionary<WheelSymbolCount, int> completeWinnings = new Dictionary<WheelSymbolCount, int>();

                // Iterate over all wheel symbol, and all "count" values equal to
                // total number of wheels, and total number of wheels minus 1.
                foreach (WheelSymbolCount item in WheelSymbolCount.All(Constants.NoOfWheels - 1))
                {
                    int winnings = GetWinnings(item.Symbol, item.Count);
                    completeWinnings.Add(new WheelSymbolCount(item.Symbol, item.Count), winnings);
                }

                return completeWinnings;
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Retrieve the winning amount for an outcome containing the
        /// specified number of the specified symbol.
        /// </summary>
        public int GetWinnings(Enums.WheelSymbol symbol, int count)
        {
            WheelSymbolCount entry = new WheelSymbolCount(symbol, count);
            if (!_winningsSettings.ContainsKey(entry))
            {
                return 0;
            }

            return _winningsSettings[entry];
        }

        /// <summary>
        /// Set the winning amount for an outcome containing the
        /// specified number of the specified symbol.
        /// </summary>
        public void SetWinnings(Enums.WheelSymbol symbol, int count, int winAmount)
        {
            if (count < 1 || winAmount < 0)
            {
                throw new ArgumentException(nameof(SetWinnings));
            }

            WheelSymbolCount entry = new WheelSymbolCount(symbol, count);
            if (!_winningsSettings.ContainsKey(entry))
            {
                _winningsSettings.Add(entry, winAmount);
            }
            else
            {
                _winningsSettings[entry] = winAmount;
            }

            OnPropertyChanged(nameof(WinningsSettings));
        }

        /// <summary>
        /// Set the winnings to the default winnings.
        /// </summary>
        public void SetDefaultWinnings()
        {
            for (int count = 1; count <= Constants.NoOfWheels; count++)
            {
                foreach (Enums.WheelSymbol symbol in Enum.GetValues(typeof(Enums.WheelSymbol)))
                {
                    int winnings = _compileTimeSettings.InitialWinnings(symbol, count);
                    if (winnings > 0)
                    {
                        SetWinnings(symbol, count, winnings);
                    }
                }
            }
        } 
        #endregion
    }
}
