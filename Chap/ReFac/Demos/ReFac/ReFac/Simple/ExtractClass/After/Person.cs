using System;

namespace ReFac.Simple.ExtractClass.After
{
    public class Person
    {
        private PhoneNo _privatePhoneNo;
        private PhoneNo _workPhoneNo;

        public string Name { get; }
        public string PrivatePhoneNo { get { return _privatePhoneNo.No; } }
        public string WorkPhoneNo { get { return _workPhoneNo.No; } }
        public Person(string name, PhoneNo privatePhoneNo, PhoneNo workPhoneNo)
        {
            Name = name;
            _privatePhoneNo = privatePhoneNo;
            _workPhoneNo = workPhoneNo;
        }
    }
}