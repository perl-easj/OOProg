namespace ReFac.Simple.MoveField.Before
{
    public class AccountType
    {
        public string Description { get; }

        public AccountType(string description)
        {
            Description = description;
        }

        public double CalculateInterest(BankAccount account)
        {
            return account.Balance * account.InterestRate / 100.0;
        }
    }
}