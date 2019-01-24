namespace ReflectionExample
{
    /// <summary>
    /// A very simple representation of a BankAccount
    /// </summary>
    public class BankAccount
    {
        #region Properties
        public string OwnerName { get; }
        public double Balance { get; private set; } 
        #endregion

        #region Constructor
        public BankAccount(string ownerName)
        {
            OwnerName = ownerName;
            Balance = 0;
        } 
        #endregion

        #region Methods
        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Account owned by {OwnerName}, balance is {Balance:F2} kr.";
        } 
        #endregion
    }
}