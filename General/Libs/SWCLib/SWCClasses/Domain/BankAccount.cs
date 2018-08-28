namespace SWCClasses.Domain
{
    public class BankAccount
    {
        #region Instance fields
        private double _balance;
        #endregion

        #region Constructor
        public BankAccount()
        {
            _balance = 0.0;
        }
        #endregion

        #region Properties
        public double Balance
        {
            get { return _balance; }
        }
        #endregion

        #region Methods
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                _balance = _balance + amount;
            }
        }

        public void Withdraw(double amount)
        {
            if ((amount > 0) && (amount <= _balance))
            {
                _balance = _balance - amount;
            }
        }
        #endregion
    }
}