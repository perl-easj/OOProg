namespace ReFac.Simple.MoveField.After
{
    public class BankAccount
    {
        public double Balance { get; set; }
        public AccountType AccType { get; }

        public BankAccount(
            double balance, 
            AccountType accType)
        {
            Balance = balance;
            AccType = accType;
        }

        public void AddInterest()
        {
            Balance += AccType.CalculateInterest(this);
        }
    }
}