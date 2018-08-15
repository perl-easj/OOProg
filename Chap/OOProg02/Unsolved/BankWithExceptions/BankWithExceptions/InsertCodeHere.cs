using System;
// ReSharper disable RedundantAssignment

namespace BankWithExceptions
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            BankAccount theAccount = null;

            // Create a new bank account with 25 % interest rate
            // (is that legal...?)
            try
            {
                theAccount = new BankAccount(25.0);
            }
            catch (IllegalInterestRateException e)
            {
                Console.WriteLine("You tried to use an illegal interest rate: " + e.Message);
            }


            theAccount = new BankAccount(5.0);
            theAccount.Deposit(2000);

            try
            {
                theAccount.Deposit(-1000);
            }
            catch (NegativeAmountException e)
            {
                Console.WriteLine("You tried to deposit a negative amount: " + e.Message);
            }
                
            try
            {
                theAccount.Withdraw(3000);
            }
            catch (WithdrawAmountTooLargeException e)
            {
                Console.WriteLine("You tried to withdraw too much money: " + e.Message);
            }

            Console.WriteLine($"Balance is now : {theAccount.Balance}");

            // The LAST line of code should be ABOVE this line
        }
    }
}