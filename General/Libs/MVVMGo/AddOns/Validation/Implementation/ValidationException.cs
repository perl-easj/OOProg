using System;

namespace AddOns.Validation.Implementation
{
    /// <summary>
    /// Validation-specific Exception class, to be 
    /// thrown when invalid domain data is detected.
    /// </summary>
    public class ValidationException : ArgumentException
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}