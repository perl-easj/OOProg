namespace Palindrome
{
    /// <summary>
    /// This class provides an implementation of the (simple)
    /// IPalindromeChecker interface.
    /// </summary>
    public class PalindromeChecker : IPalindromeChecker
    {
        /// <summary>
        /// This methods performs a pre-processing of the string,
        /// by stripping away spaces, and converting the string
        /// to lowercase characters.
        /// </summary>
        public bool IsPalindrome(string phrase)
        {
            string noSpacePhrase = phrase.Replace(" ", string.Empty);
            string noSpaceLowerPhrase = noSpacePhrase.ToLower();

            return IsPalindromeInternal(noSpaceLowerPhrase);
        }


        /// <summary>
        /// This method determines whether or not the given 
        /// string is a palindrome.
        /// REMEMBER that spaces are stripped away, and all
        /// characters are lowercase at this point
        /// </summary>
        private bool IsPalindromeInternal(string phrase)
        {
            // HINT: Think recursively before starting to code!!
            // Find: a) A trivial case
            //       b) A division strategy
            //       c) A combination strategy
            // EXTRA HINT: The method Substring - which you can call
            // on any variable of type string - will be useful...

            return false;
        }
    }
}