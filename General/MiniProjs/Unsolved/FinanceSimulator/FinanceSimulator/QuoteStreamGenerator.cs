using System;
using System.Collections.Generic;

namespace FinanceSimulator
{
    /// <summary>
    /// Class which can generate quote streams for a set of
    /// FinancialInstrumentSimulator objects.
    /// </summary>
    public class QuoteStreamGenerator : IQuoteStream
    {
        public event Action<Quote> Quotes;

        #region Instance fields
        private Dictionary<string, FinancialInstrumentSimulator> _simulators;
        #endregion

        #region Constructor
        public QuoteStreamGenerator()
        {
            _simulators = new Dictionary<string, FinancialInstrumentSimulator>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add a new FI-simulator to the set of simulators.
        /// </summary>
        /// <param name="sim">FI-simulator to add</param>
        public void Add(FinancialInstrumentSimulator sim)
        {
            _simulators[sim.FIID] = sim;
        }

        /// <summary>
        /// Generate new quotes for all financial 
        /// instruments being simulated.
        /// </summary>
        /// <param name="tick">Current time</param>
        public void Update(int tick)
        {
            foreach (var sim in _simulators.Values)
            {
                if (sim.UpdatePrice(tick))
                {
                    Quotes?.Invoke(new Quote(sim.FIID, sim.CurrentPrice));
                }
            }
        } 
        #endregion
    }
}