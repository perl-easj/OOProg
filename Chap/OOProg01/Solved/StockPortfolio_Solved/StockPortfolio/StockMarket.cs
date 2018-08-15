using System;

namespace StockPortfolio
{
    /// <summary>
    /// This class contain a very simple simulation of a stock market.
    /// A single stock portfolio is associated with the market.
    /// Once created, the market can have either good days or bad days.
    /// On a good day, prices can increase from 0 % to GoodDayPercent %
    /// On a bad day, prices can decrease from 0 % to BadDayPercent %
    /// </summary>
    public class StockMarket
    {
        #region Constants
        private const int GoodDayPercent = 5;
        private const int BadDayPercent = 3;
        #endregion

        #region Instance fields
        private Portfolio _portfolio;
        private Random _generator;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor. This is where the content of 
        /// the stock portfolio is decided.
        /// </summary>
        public StockMarket()
        {
            Stock s1 = new Stock("Novo", 100, 300);
            Stock s2 = new Stock("Vestas", 50, 500);
            Stock s3 = new Stock("DSV", 60, 400);

            _portfolio = new Portfolio(s1, s2, s3);
            _generator = new Random();
        }
        #endregion

        #region Properties
        public double PortfolioEarningsPercentage
        {
            get { return _portfolio.TotalEarningsPercentage; }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// It was a good day. Prices for all stocks
        /// are updated accordingly.
        /// </summary>
        public void GoodDay()
        {
            _portfolio.UpdateCurrentPrices(GoodDayPercentage(), GoodDayPercentage(), GoodDayPercentage());
        }

        /// <summary>
        /// It was a bad day. Prices for all stocks 
        /// are updated accordingly.
        /// </summary>
        public void BadDay()
        {
            _portfolio.UpdateCurrentPrices(BadDayPercentage(), BadDayPercentage(), BadDayPercentage());
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Generates a percentage change for a good day:
        /// A percentage between 0 % and GoodDayPercent %
        /// </summary>
        private double GoodDayPercentage()
        {
            return _generator.NextDouble() * GoodDayPercent;
        }

        /// <summary>
        /// Generates a percentage change for a bad day:
        /// A percentage between -BadDayPercent % and 0 %
        /// </summary>
        private double BadDayPercentage()
        {
            return (_generator.NextDouble() - 1.0) * BadDayPercent;
        }
        #endregion
    }
}