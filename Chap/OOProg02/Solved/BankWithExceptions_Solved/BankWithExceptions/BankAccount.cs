namespace BankWithExceptions
{
    class BankAccount
    {
        private double _balance;
        private double _interestRate;

        public BankAccount(double interestRate)
        {
            if (interestRate < 0.0 || interestRate > 20.0)
            {
                IllegalInterestRateException e = new IllegalInterestRateException($"Interest rate was {interestRate} %");
                throw e;
            }

            _interestRate = interestRate;
            _balance = 0.0;
        }

        /// <summary>
        /// Balance of the account; must not become negative
        /// </summary>
        public double Balance
        {
            get { return _balance; }
        }

        /// <summary>
        /// Interest rate of the account; must be between 0.0 and 20.0
        /// </summary>
        public double InterestRate
        {
            get { return _interestRate; }
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                NegativeAmountException e = new NegativeAmountException($"Amount was {amount} kr.");
                throw e;
            }

            _balance = _balance + amount;
        }

        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                NegativeAmountException e = new NegativeAmountException($"Amount was {amount} kr.");
                throw e;
            }

            if (_balance < amount)
            {
                WithdrawAmountTooLargeException e = new WithdrawAmountTooLargeException($"Amount was {amount} kr., balance was {_balance} kr.");
                throw e;
            }

            _balance = _balance - amount;
        }
    }
}
