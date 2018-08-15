using System.Collections.ObjectModel;

namespace FinanceSimulator
{
    /// <summary>
    /// This class is a view model for the entire stock simulation.
    /// </summary>
    public class StockSimulationViewModel
    {
        #region Instance fields
        private StockSimulationModel _stockModel;
        private ObservableCollection<QuoteViewModel> _stockQuotes;
        private ObservableCollection<StockViewModel> _stockDetails;
        #endregion

        #region Properties for Data Binding
        public ObservableCollection<QuoteViewModel> Quotes
        {
            get { return _stockQuotes; }
        }

        public ObservableCollection<StockViewModel> Details
        {
            get { return _stockDetails; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor. Sets up the stock simulation. Note that all
        /// Quote and Stock view model objects are hooked up to the
        /// Quotes event from the Stock model quote generator.
        /// </summary>
        public StockSimulationViewModel()
        {
            // Create model and collections for data binding
            _stockModel = new StockSimulationModel();
            _stockQuotes = new ObservableCollection<QuoteViewModel>();
            _stockDetails = new ObservableCollection<StockViewModel>();

            foreach (Stock sd in _stockModel.Stocks)
            {
                // Create Quote view model objects, and hook their ConsumeQuote
                // method up to the Quotes event from the quote generator.
                QuoteViewModel qvm = new QuoteViewModel(new Quote(sd.FiID, sd.InitialPrice));
                _stockModel.QuoteGenerator.Quotes += qvm.ConsumeQuote;
                _stockQuotes.Add(qvm);

                // Create Stock view model objects, and hook their ConsumeQuote
                // method up to the Quotes event from the quote generator.
                StockViewModel sdvm = new StockViewModel(sd, sd.InitialPrice);
                _stockModel.QuoteGenerator.Quotes += sdvm.ConsumeQuote;
                _stockDetails.Add(sdvm);
            }

            // Start the simulation!
            _stockModel.Start();
        } 
        #endregion
    }
}