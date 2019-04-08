using System;

namespace ReFac.Simple.ExtractClass.After
{
    public class PhoneNo
    {
        public string No { get; }

        public PhoneNo(string no)
        {
            CheckPhoneNo(no);
            No = no;
        }

        private void CheckPhoneNo(string phoneNo)
        {
            if (phoneNo.Length == 8) return;
            if (phoneNo.Length == 11 && phoneNo[0] == '+') return;

            throw new ArgumentException($"{phoneNo} is not a valid phone number");
        }
    }
}