using System;

namespace BankWithExceptions
{
    /// <summary>
    /// This exception is to be thrown in case the bank account 
    /// is defined with an illegal interest rate
    /// </summary>
    public class IllegalInterestRateException : Exception
    {
        public IllegalInterestRateException()
        {
        }

        public IllegalInterestRateException(string message)
            : base(message)
        {
        }
    }
}
