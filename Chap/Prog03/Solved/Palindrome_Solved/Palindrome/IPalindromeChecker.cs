namespace Palindrome
{
    public interface IPalindromeChecker
    {
        /// <summary>
        /// Returns true if the provided string is a
        /// Palindrome, otherwise false.
        /// </summary>
        bool IsPalindrome(string phrase);
    }
}