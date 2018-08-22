using System;
using System.Collections.Generic;
using SlotMachineDemo.Configuration;

namespace SlotMachineDemo.Types
{
    /// <summary>
    /// This class represents a symbol/count pair, 
    /// used e.g. when specifying winnings entries.
    /// </summary>
    public class WheelSymbolCount
    {
        private readonly Enums.WheelSymbol _symbol;
        private readonly int _count;

        public WheelSymbolCount(Enums.WheelSymbol symbol, int count)
        {
            _symbol = symbol;
            _count = count;
        }

        /// <summary>
        /// Retrieves the symbol stored in the object
        /// </summary>
        public Enums.WheelSymbol Symbol
        {
            get { return _symbol; }
        }

        /// <summary>
        /// Retrieves the count stored in the object
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Retrieves the numeric key corresponding to the wheel symbols
        /// </summary>
        public int NumericKey
        {
            get
            {
                int multiplier = 1;
                int result = 0;

                for (int i = 0; i < _count; i++)
                {
                    result = result + multiplier * (int)_symbol;
                    multiplier = multiplier * 10;
                }

                return result;
            }
        }

        /// <summary>
        /// Check if the given wheel symbols match the symbol/count pair,
        /// i.e. do the wheel symbols contain "count" instances of "symbol"
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        public bool Match(WheelSymbolList symbols)
        {
            return (symbols.Symbols.FindAll(wheelSymbol => wheelSymbol == _symbol).Count == Count);
        }

        /// <summary>
        /// Generates a list of all symbol/count combinations, combining all 
        /// symbols with counts from the number of wheels down to the given limit.
        /// </summary>
        public static List<WheelSymbolCount> All(int minCount)
        {
            List<WheelSymbolCount> all = new List<WheelSymbolCount>();

            for (int count = Constants.NoOfWheels; count >= minCount; count--)
            {
                foreach (Enums.WheelSymbol symbol in Enum.GetValues(typeof(Enums.WheelSymbol)))
                {
                    all.Add(new WheelSymbolCount(symbol, count));
                }
            }

            return all;
        }

        public override bool Equals(object obj)
        {
            WheelSymbolCount other = (WheelSymbolCount) obj;

            if (other != null)
            {
                return (Symbol == other.Symbol && Count == other.Count);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return NumericKey;
        }
    }
}