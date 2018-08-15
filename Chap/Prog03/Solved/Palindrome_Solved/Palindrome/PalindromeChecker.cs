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
            // Trivial case
            if (phrase.Length < 2)
            {
                return true;
            }

            // Division :
            //   Subproblem 1: Are the first and last letters equal to each other?
            //   Subproblem 2: Is the remaining phrase (i.e. minus first and last letter)
            //                 also a palindrome?
            // Example: rotor

            string firstLetter = phrase.Substring(0, 1); // = "r"
            string lastLetter = phrase.Substring(phrase.Length - 1, 1); // = "r"
            string remainingPhrase = phrase.Substring(1, phrase.Length - 2); // = "oto"

            bool firstLastEqual = (firstLetter == lastLetter); // "r" == "r", so true
            bool isRestPalindrome = IsPalindromeInternal(remainingPhrase); // called with "oto", so true

            // Combination :
            //   phrase is a palindrome if BOTH subproblems are true.
            return firstLastEqual && isRestPalindrome;
        }
    }
}