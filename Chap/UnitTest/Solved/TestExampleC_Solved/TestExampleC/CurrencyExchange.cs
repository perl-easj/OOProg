using System;
using System.Collections.Generic;

namespace TestExampleC
{
    public class CurrencyExchange : ICurrencyExchange
    {
        private Dictionary<string, double> _exchangeRates;
        private ICurrencyCheck _currencyCheck;

        public CurrencyExchange(ICurrencyCheck currencyCheck)
        {
            _exchangeRates = new Dictionary<string, double>();
            _currencyCheck = currencyCheck;
        }

        public void SetExchangeRate(string currencyCross, double exchangeRate)
        {
            if (!_currencyCheck.IsValidCurrencyCross(currencyCross))
            {
                throw new ArgumentException(currencyCross + " is not a valid currency cross");
            }

            if (exchangeRate <= 0)
            {
                throw new ArgumentException(exchangeRate + " is not a valid exchange rate");
            }

            _exchangeRates[currencyCross] = exchangeRate;
        }

        public double DoExchange(string currencyCross, double amount)
        {
            if (!_currencyCheck.IsValidCurrencyCross(currencyCross))
            {
                throw new ArgumentException(currencyCross + " is not a valid currency cross");
            }

            if (!_exchangeRates.ContainsKey(currencyCross))
            {
                throw new ArgumentException("Exchange rate has not been set for " + currencyCross);
            }

            if (amount <= 0)
            {
                throw new ArgumentException(amount + " is not a valid amount");
            }

            return _exchangeRates[currencyCross] * amount;
        }
    }
}