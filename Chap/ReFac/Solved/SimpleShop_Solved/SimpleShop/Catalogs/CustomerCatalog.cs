using SimpleShop.Domain;
using SimpleShop.Util;

namespace SimpleShop.Catalogs
{
    public class CustomerCatalog : Catalog<Customer>
    {
        public CustomerCatalog()
        {
            _items.Add(new Customer(1, "Anne", "Andersen", "Solvej 12", new Email("anne","mail","dk")));
            _items.Add(new Customer(2, "Bent", "Benthin", "Violhaven 29", new Email("bent_benthin", "waoo", "dk")));
            _items.Add(new Customer(3, "Carina", "Cortsen", "Algade 80", new Email("carina_32", "mail", "dk")));
        }
    }
}