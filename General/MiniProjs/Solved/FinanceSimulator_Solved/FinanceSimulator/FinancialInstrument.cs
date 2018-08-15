namespace FinanceSimulator
{
    /// <summary>
    /// Base class for any financial instrument (FI).
    /// An FI contains an identifier (FiID), and a type.
    /// </summary>
    public class FinancialInstrument
    {
        #region Enums
        /// <summary>
        /// Type identifier for the FI
        /// </summary>
        public enum Type
        {
            Stock,
            Currency,
            CryptoCurrency
        }
        #endregion

        #region Instance fields
        private string _fiID;
        private Type _fiType;
        #endregion

        #region Constructor
        public FinancialInstrument(string fiID, Type fiType)
        {
            _fiID = fiID;
            _fiType = fiType;
        }
        #endregion

        #region Properties
        public string FiID
        {
            get { return _fiID; }
        }

        public Type FiType
        {
            get { return _fiType; }
        } 
        #endregion
    }
}