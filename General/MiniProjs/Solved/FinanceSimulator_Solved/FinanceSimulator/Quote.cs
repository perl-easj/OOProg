namespace FinanceSimulator
{
    /// <summary>
    /// This class represents a "quote", which is the 
    /// (current) price of a financial instrument.
    /// </summary>
    public class Quote
    {
        #region Instance fields
        private string _fiID;
        private double _price;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fiID">ID for financial instrument</param>
        /// <param name="price">Initial price for financial instrument</param>
        public Quote(string fiID, double price)
        {
            _fiID = fiID;
            _price = price;
        }
        #endregion

        #region Properties
        public string FiID
        {
            get { return _fiID; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        } 
        #endregion
    }
}