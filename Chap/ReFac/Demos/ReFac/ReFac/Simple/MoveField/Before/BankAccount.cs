namespace ReFac.Simple.MoveField.Before
{
    public class BankAccount
    {
        public double Balance { get; set; }
        public double InterestRate { get; }
        public AccountType AccType { get; }

        public BankAccount(
            double balance, 
            double interestRate, 
            AccountType accType)
        {
            Balance = balance;
            InterestRate = interestRate;
            AccType = accType;
        }

        public void AddInterest()
        {
            Balance += AccType.CalculateInterest(this);
        }
    }
}