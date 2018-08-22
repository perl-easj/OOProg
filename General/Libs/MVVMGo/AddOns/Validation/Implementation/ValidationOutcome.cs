namespace AddOns.Validation.Implementation
{
    /// <summary>
    /// Result of a validation operation. The idea is that
    /// any validation will produce a ValidationOutcome
    /// object, which will then indicate the outcome of
    /// the performed validation
    /// </summary>
    public class ValidationOutcome
    {
        #region Constructors
        /// <summary>
        /// Use this constructor is the validation 
        /// did NOT find any errors.
        /// </summary>
        public ValidationOutcome()
        {
            Valid = true;
        }

        /// <summary>
        /// Use this constructor is the validation 
        /// DID find errors.
        /// </summary>
        /// <param name="message">
        /// Message detailing the validation error.
        /// </param>
        public ValidationOutcome(string message)
        {
            Message = message;
            Valid = false;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns true if no errors were found, 
        /// otherwise false.
        /// </summary>
        public bool Valid { get; }

        /// <summary>
        /// Message containing validation details.
        /// </summary>
        public string Message { get; }
        #endregion
    }
}