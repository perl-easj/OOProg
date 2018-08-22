using System;
using System.Collections.Generic;
using SlotMachineDemo.Interfaces.Logic;

namespace SlotMachineDemo.Types
{
    /// <summary>
    /// This class represents the state of the wheels in the slot machine.
    /// A set of wheel symbols can always be transformed to a unique numeric key.
    /// </summary>
    public class WheelSymbolList
    {
        private readonly List<Enums.WheelSymbol> _symbols;

        /// <summary>
        /// Create default wheel symbols
        /// </summary>
        public WheelSymbolList() 
            : this(Enums.WheelSymbol.Bell, Configuration.Constants.NoOfWheels)
        {
        }

        /// <summary>
        /// Create object based on given list of symbols
        /// </summary>
        public WheelSymbolList(List<Enums.WheelSymbol> symbols)
        {
            _symbols = symbols;
        }

        /// <summary>
        /// Create object based on a symbol/count pair
        /// </summary>
        public WheelSymbolList(Enums.WheelSymbol symbol, int count)
        {
            if (count < 0)
            {
                throw new ArgumentException(nameof(WheelSymbolList));    
            }

            _symbols = new List<Enums.WheelSymbol>();
            for (int i = 0; i < count; i++)
            {
                _symbols.Add(symbol);
            }
        }

        /// <summary>
        /// Create object from the given key value
        /// </summary>
        public WheelSymbolList(int key)
        {
            _symbols = new List<Enums.WheelSymbol>();
            int residualKey = key;

            while (residualKey > 0)
            {
                int symbol = residualKey % 10;
                residualKey = residualKey / 10;
                _symbols.Add((Enums.WheelSymbol)symbol);
            }
        }

        /// <summary>
        /// Retrieves the list of wheel symbols stored in the object
        /// </summary>
        public List<Enums.WheelSymbol> Symbols
        {
            get { return _symbols; }
        }

        /// <summary>
        /// Retrieves the number of wheel symbols stored in the object
        /// </summary>
        public int Count
        {
            get { return _symbols.Count; }
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

                foreach (Enums.WheelSymbol symbol in _symbols)
                {
                    result = result + multiplier * (int)symbol;
                    multiplier = multiplier * 10;
                }

                return result;
            }
        }

        /// <summary>
        /// Retrieves a list of symbol/count objects, representing the number
        /// of each symbol type stored in the object.
        /// </summary>
        public List<WheelSymbolCount> WheelSymbolCounts
        {
            get
            {
                List <WheelSymbolCount> wsCounts = new List<WheelSymbolCount>();
                foreach (Enums.WheelSymbol symbol in Enum.GetValues(typeof(Enums.WheelSymbol)))
                {
                    wsCounts.Add(new WheelSymbolCount(symbol, NumberOf(symbol)));
                }

                return wsCounts;
            }
        }

        /// <summary>
        /// Indexer into the list of stored wheel symbols
        /// </summary>
        public Enums.WheelSymbol this[int index]
        {
            get
            {
                if (index > _symbols.Count)
                {
                    throw new ArgumentException("Indexer");
                }

                return _symbols[index];
            }
        }

        /// <summary>
        /// Retrieves the number of wheel symbols equal to the given symbol
        /// </summary>
        public int NumberOf(Enums.WheelSymbol symbol)
        {
            return _symbols.FindAll((wheelSymbol => wheelSymbol == symbol)).Count;
        }

        /// <summary>
        /// Rotate the wheels, using the given ILogicSymbolGenerator implementation
        /// </summary>
        /// <param name="logicSymbolGenerator"></param>
        public void Rotate(ILogicSymbolGenerator logicSymbolGenerator)
        {
            for (int wheelNo = 0; wheelNo < Configuration.Constants.NoOfWheels; wheelNo++)
            {
                _symbols[wheelNo] = logicSymbolGenerator.GetWheelSymbol();
            }
        }

        public override bool Equals(object obj)
        {
            WheelSymbolList other = (WheelSymbolList) obj;

            if (other != null)
            {
                if (Count != other.Count)
                {
                    return false;
                }

                for (int index = 0; index < other.Count; index++)
                {
                    if (other[index] != this[index])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return NumericKey;
        }
    }
}