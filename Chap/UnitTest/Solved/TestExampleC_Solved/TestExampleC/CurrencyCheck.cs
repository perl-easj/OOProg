namespace TestExampleC
{
    public class CurrencyCheck : ICurrencyCheck
    {
        // A currency identifier must
        // 1) Not be null
        // 2) Be exactly three characters long
        // 3) Must not contain spaces
        public bool IsValidCurrencyID(string currencyID)
        {
            return (!string.IsNullOrWhiteSpace(currencyID) && (currencyID.Length == 3) && !currencyID.Contains(" "));
        }

        // A currency cross must
        // 1) Not be null
        // 2) Be exactly six characters long
        // 3) Consists of two valid, different currency identifiers
        public bool IsValidCurrencyCross(string currencyCross)
        {
            if (!string.IsNullOrWhiteSpace(currencyCross) && currencyCross.Length == 6)
            {
                string firstID = currencyCross.Substring(0, 3);
                string secondID = currencyCross.Substring(3, 3);

                return IsValidCurrencyID(firstID) && IsValidCurrencyID(secondID) && (firstID != secondID);
            }

            return false;
        }
    }
}