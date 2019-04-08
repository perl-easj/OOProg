namespace SimpleShop
{
    public class Product
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