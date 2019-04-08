using System;

namespace SimpleShop.Util
{
    public class Email
    {
        public string Name { get; }
        public string Domain { get; }
        public string TopLevelDomain { get; }

        public Email(string name, string domain, string topLevelDomain)
        {
            Name = name;
            Domain = domain;
            TopLevelDomain = topLevelDomain;
        }

        public string Address
        {
            get { return $"{Name}@{Domain}.{TopLevelDomain}"; }
        }

        public override string ToString()
        {
            return Address;
        }

        public static void CheckEmail(string emailStr)
        {
            bool validEmail = emailStr.Contains("@") && 
                              emailStr.Contains(".") && 
                              (emailStr.IndexOf('@') < emailStr.IndexOf('.'));

            if (!validEmail)
            {
                throw new ArgumentException($"Email {emailStr} is not a valid email address");
            }
        }
    }
}