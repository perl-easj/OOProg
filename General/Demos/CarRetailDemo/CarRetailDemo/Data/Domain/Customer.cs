using CarRetailDemo.Data.Base;

namespace CarRetailDemo.Data.Domain
{
    public class Customer : DomainClassAppBase
    {
        public Customer(int key, int imageKey, string fullName, string phone, string email, string address, int zipCode, string city, int minPrice, int maxPrice, bool newsLetter)
            : base( imageKey)
        {
            Key = key;
            FullName = fullName;
            Phone = phone;
            Email = email;
            Address = address;
            ZipCode = zipCode;
            City = city;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            NewsLetter = newsLetter;
        }

        public Customer() : base(NullKey)
        {
        }

        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public bool NewsLetter { get; set; }

        public override void SetDefaultValues()
        {
            Key = NullKey;
            ImageKey = NullKey;
            FullName = "(not set)";
            Phone = "(not set)";
            Email = "(not set)";
            Address = "(not set)";
            ZipCode = 0;
            City = "(not set)";
            MinPrice = 0;
            MaxPrice = 0;
            NewsLetter = false;
        }
    }
}
