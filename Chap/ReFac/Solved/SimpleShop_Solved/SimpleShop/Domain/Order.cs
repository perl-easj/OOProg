using System.Collections.Generic;
using System.Linq;
using SimpleShop.Catalogs;

namespace SimpleShop.Domain
{
    public class Order
    {
        public ProductCatalog Products { get; }
        public Customer TheCustomer { get; }
        public Dictionary<int, int> OrderLines;

        public Order(Customer theCustomer, ProductCatalog products)
        {
            Products = products;
            TheCustomer = theCustomer;
            OrderLines = new Dictionary<int, int>();
        }

        public void AddOrderLine(int productId, int quantity)
        {
            OrderLines[productId] = quantity;
        }

        public double TotalPrice
        {
            get { return OrderLines.Select(oi => OrderLinePrice(oi.Key, oi.Value)).Sum(); }
        }

        private double OrderLinePrice(int productID, int quantity)
        {
            return Products.Lookup(productID).Price * quantity;
        }
    }
}