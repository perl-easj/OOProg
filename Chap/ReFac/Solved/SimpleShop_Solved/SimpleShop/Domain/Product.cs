using SimpleShop.Catalogs;

namespace SimpleShop.Domain
{
    public class Product : IHasID
    {
        public int ID { get; }
        public string Description { get; }
        public double Price { get; }

        public Product(int id, string description, double price)
        {
            ID = id;
            Description = description;
            Price = price;
        }
    }
}