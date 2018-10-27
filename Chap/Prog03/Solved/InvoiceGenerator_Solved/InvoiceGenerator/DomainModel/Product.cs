namespace InvoiceGenerator.DomainModel
{
    /// <summary>
    /// This class represents a very simple product, defined only
    /// by a description and a name.
    /// </summary>
    public class Product
    {
        public Product(string description, double price)
        {
            Description = description;
            Price = price;
        }

        public string Description { get; }
        public double Price { get; }
    }
}