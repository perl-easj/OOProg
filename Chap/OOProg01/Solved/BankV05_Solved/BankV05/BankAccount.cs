namespace BankV05
{
    /// <summary>
    /// This class represents a very simple bank account.
    /// Only the amount of money on the account AND the
    /// name of the account holder is represented.
    /// </summary>
    public class BankAccount
    {
        private double _balance;
        private string _name; // Added

        public BankAccount(string name) // Updated
        {
            _balance = 0.0;
            _name = name; // Added
        }

        public double Balance
        {
            get { return _balance; }
        }

        public string Name // Added
        {
            get { return _name; }
        }

        public void Deposit(double amount)
        {
            _balance = _balance + amount;
        }

        public void Withdraw(double amount)
        {
            _balance = _balance - amount;
        }
    }
}