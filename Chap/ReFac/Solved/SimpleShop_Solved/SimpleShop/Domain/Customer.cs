using SimpleShop.Catalogs;
using SimpleShop.Util;

namespace SimpleShop.Domain
{
    public class Customer : IHasID
    {
        public int ID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; }
        public Email EmailAddress { get; }

        public Customer(int id, string firstName, string lastName, string address, Email emailAddress)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            EmailAddress = emailAddress;
        }
    }
}