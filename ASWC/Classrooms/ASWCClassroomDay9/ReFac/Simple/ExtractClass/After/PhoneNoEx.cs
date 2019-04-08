using System;

namespace ReFac.Simple.ExtractClass.After
{
    public class PhoneNoEx
    {
        private string _domesticNo;
        private string _countryCode;

        public string No
        {
            get { return _countryCode == null ? _domesticNo : $"+{_countryCode}{_domesticNo}"; }
        }

        public PhoneNoEx(string domesticNo)
        {
            CheckDomesticPhoneNo(domesticNo);
            _domesticNo = domesticNo;
            _countryCode = null;
        }

        public PhoneNoEx(string countryCode, string domesticNo)
        {
            CheckDomesticPhoneNo(domesticNo);
            CheckCountryCode(countryCode);
            _domesticNo = domesticNo;
            _countryCode = countryCode;
        }

        private void CheckDomesticPhoneNo(string domPhoneNo)
        {
            if (domPhoneNo.Length == 8) return;
            throw new ArgumentException($"{domPhoneNo} is not a valid domestic phone number");
        }

        private void CheckCountryCode(string countryCode)
        {
            if (countryCode.Length == 2) return;
            throw new ArgumentException($"{countryCode} is not a valid country code");
        }
    }
}