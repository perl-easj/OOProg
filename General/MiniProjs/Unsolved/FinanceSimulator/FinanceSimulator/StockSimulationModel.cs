using System.Collections.Generic;

namespace FinanceSimulator
{
    /// <summary>
    /// This class contains the data and logic for the stock simulation.
    /// </summary>
    public class StockSimulationModel
    {
        #region Constants
        private const double MinPercentageChange = 0.5;
        private const double MaxPercentageChange = 5.0;
        private const int MinUpdateTime = 1;
        private const int MaxUpdateTime = 5;
        #endregion

        #region Instance fields
        private List<Stock> _stocks;
        private QuoteStreamGenerator _quoteGenerator;
        private Clock _clock;
        #endregion

        #region Constructor
        public StockSimulationModel()
        {
            _stocks = new List<Stock>();
            _quoteGenerator = new QuoteStreamGenerator();
            _clock = new Clock();

            SetupStocks();
            SetupQuoteGenerator();

            // Hook up the Update method from the Quote Generator,
            // such that it will be called at every Tick.
            _clock.Tick += _quoteGenerator.Update;
        }
        #endregion

        #region Properties
        public List<Stock> Stocks
        {
            get { return _stocks; }
        }

        public QuoteStreamGenerator QuoteGenerator
        {
            get { return _quoteGenerator; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Starts the simulation
        /// </summary>
        public void Start()
        {
            _clock.Start();
        }

        /// <summary>
        /// Sets up the stocks we wish to simulate. This data could
        /// in principle also be read from an external source.
        /// </summary>
        private void SetupStocks()
        {
            _stocks.Add(new Stock("NOVO", "Novo Nordisk    ", 200, 400));
            _stocks.Add(new Stock("DABK", "Danske Bank     ", 200, 300));
            _stocks.Add(new Stock("VEST", "Vestas          ", 300, 500));
            _stocks.Add(new Stock("CARL", "Carlsberg       ", 400, 900));
            _stocks.Add(new Stock("GNSN", "GN Store Nord   ", 150, 350));
            _stocks.Add(new Stock("BAVA", "Bavarian Nordic ", 150, 300));
            _stocks.Add(new Stock("COLO", "Coloplast       ", 150, 350));
            _stocks.Add(new Stock("TRYG", "Tryg Forsikring ", 120, 200));
        }

        /// <summary>
        /// Add simulators to the quote generator; one for 
        /// each stock we wish to simulate.
        /// </summary>
        private void SetupQuoteGenerator()
        {
            foreach (Stock sd in _stocks)
            {
                IPriceGenerator ipg = new PriceGeneratorLinear(sd.MinPrice, sd.MaxPrice, GeneratePercentageChange());
                _quoteGenerator.Add(new FinancialInstrumentSimulator(sd.FiID, ipg, GenerateUpdateTime()));
            }
        }

        /// <summary>
        /// Helper method for generating a maximal percentage 
        /// change for a specific stock.
        /// </summary>
        private double GeneratePercentageChange()
        {
            return RandomNumberGenerator.Next(MinPercentageChange, MaxPercentageChange);
        }

        /// <summary>
        /// Helper method for generating an update time 
        /// interval for a specific stock.
        /// </summary>
        private int GenerateUpdateTime()
        {
            return RandomNumberGenerator.NextInt(MinUpdateTime, MaxUpdateTime);
        } 
        #endregion
    }
}