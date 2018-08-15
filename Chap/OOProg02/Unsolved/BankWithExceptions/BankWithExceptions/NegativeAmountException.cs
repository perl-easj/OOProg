using System;

namespace BankWithExceptions
{
    /// <summary>
    /// This exception is to be thrown in case it is 
    /// attempted to withdraw or deposit a negative amount
    /// </summary>
    public class NegativeAmountException : Exception
    {
        public NegativeAmountException()
        {
        }

        public NegativeAmountException(string message)
            : base(message)
        {
        }
    }
}
