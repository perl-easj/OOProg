using System;

namespace AddOns.Validation.Implementation
{
    /// <summary>
    /// Contains a set of methods which can be 
    /// used as-is for validation, or as building 
    /// blocks for custom validation methods.
    /// </summary>
    public class ValidationService
    {
        /// <summary>
        /// Main validation method: If the validation 
        /// finds errors, the specified action is executed.
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of value subjected to validation
        /// </typeparam>
        /// <param name="value">
        /// Actual value subjected to validation
        /// </param>
        /// <param name="validator">
        /// Function performing the actual validation
        /// </param>
        /// <param name="outcomeHandler">
        /// Function handling the outcome in case
        /// the validation found an error
        /// </param>
        public static void ValidateValue<TValue>(
            TValue value,
            Func<TValue, ValidationOutcome> validator,
            Action<ValidationOutcome> outcomeHandler)
        {
            ValidationOutcome vo = validator(value);
            if (!vo.Valid)
            {
                outcomeHandler(vo);
            }
        }

        /// <summary>
        /// Main validation method with default handling of
        /// validation outcome: throw VaælidationException.
        /// </summary>
        public static void ValidateValue<TValue>(
            TValue value,
            Func<TValue, ValidationOutcome> validator)
        {
            ValidationOutcome vo = validator(value);
            if (!vo.Valid)
            {
                throw new ValidationException(vo.Message);
            }
        }

        /// <summary>
        /// Generic validation method
        /// </summary>
        /// <typeparam name="TValue">
        /// Type of value subjected to validation
        /// </typeparam>
        /// <param name="value">
        /// Actual value to validate
        /// </param>
        /// <param name="isValid">
        /// Function performing the actual validation
        /// </param>
        /// <param name="message">
        /// Validation error message
        /// </param>
        /// <returns>
        /// Outcome of validation.
        /// </returns>
        private static ValidationOutcome Validate<TValue>(TValue value, Func<TValue, bool> isValid, string message)
        {
            return isValid(value) ? new ValidationOutcome() : new ValidationOutcome(message);
        }

        /// <summary>
        /// Validate that a string value has a minimum length
        /// </summary>
        /// <param name="value">
        /// String value to validate
        /// </param>
        /// <param name="minLength">
        /// Minimum valid string length
        /// </param>
        /// <param name="message">
        /// Validation error message
        /// </param>
        /// <returns>
        /// Outcome of validation.
        /// </returns>
        public static ValidationOutcome ValidateStringMinLength(string value, int minLength, string message)
        {
            return Validate(value, (v => v.Length >= minLength), message);
        }

        /// <summary>
        /// Validate that a string value has a maximum length
        /// </summary>
        /// <param name="value">
        /// String value to validate
        /// </param>
        /// <param name="maxLength">
        /// Maximum valid string length
        /// </param>
        /// <param name="message">
        /// Validation error message
        /// </param>
        /// <returns>
        /// Outcome of validation.
        /// </returns>
        public static ValidationOutcome ValidateStringMaxLength(string value, int maxLength, string message)
        {
            return Validate(value, (v => v.Length <= maxLength), message);
        }

        /// <summary>
        /// Validate that a string contains a given substring
        /// </summary>
        /// <param name="value">
        /// String value to validate
        /// </param>
        /// <param name="subString">
        /// Substring to search for
        /// </param>
        /// <param name="message">
        /// Validation error message
        /// </param>
        /// <returns>
        /// Outcome of validation.
        /// </returns>
        public static ValidationOutcome ValidateStringContains(string value, string subString, string message)
        {
            return Validate(value, v => v.Contains(subString), message);
        }

        /// <summary>
        /// Validate that a string does NOT contain a given substring
        /// </summary>
        /// <param name="value">
        /// String value to validate
        /// </param>
        /// <param name="subString">
        /// Substring to search for
        /// </param>
        /// <param name="message">
        /// Validation error message
        /// </param>
        /// <returns>
        /// Outcome of validation.
        /// </returns>
        public static ValidationOutcome ValidateStringContainsNot(string value, string subString, string message)
        {
            return Validate(value, v => !v.Contains(subString), message);
        }

        /// <summary>
        /// Validate that an int value lies within a given interval.
        /// </summary>
        /// <param name="value">
        /// Int value to validate
        /// </param>
        /// <param name="minValue">
        /// Minimum valid value
        /// </param>
        /// <param name="MaxValue">
        /// Maximum valid value
        /// </param>
        /// <param name="message">
        /// Validation error message
        /// </param>
        /// <returns>
        /// Outcome of validation.
        /// </returns>
        public static ValidationOutcome ValidateIntInInterval(int value, int minValue, int MaxValue, string message)
        {
            return Validate(value, v => (v >= minValue && v <= MaxValue), message);
        }
    }
}