using System;

namespace ReFac.Simple.ExtractClass.Before
{
    public class Person
    {
        public string Name { get; }
        public string PrivatePhoneNo { get; }
        public string WorkPhoneNo { get; }
        public Person(string name, string privatePhoneNo, string workPhoneNo)
        {
            CheckPhoneNo(privatePhoneNo);
            CheckPhoneNo(workPhoneNo);

            Name = name;
            PrivatePhoneNo = privatePhoneNo;
            WorkPhoneNo = workPhoneNo;
        }

        private void CheckPhoneNo(string phoneNo)
        {
            if (phoneNo.Length == 8) return;
            if (phoneNo.Length == 11 && phoneNo[0] == '+') return;

            throw new ArgumentException($"{phoneNo} is not a valid phone number");
        }
    }
}