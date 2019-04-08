namespace ReFac.Simple.MoveField.After
{
    public class AccountType
    {
        public string Description { get; }
        public double InterestRate { get; }

        public AccountType(string description, double interestRate)
        {
            Description = description;
            InterestRate = interestRate;
        }

        public double CalculateInterest(BankAccount account)
        {
            return account.Balance * InterestRate / 100.0;
        }
    }
}