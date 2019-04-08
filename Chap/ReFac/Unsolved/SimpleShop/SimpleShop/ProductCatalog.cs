using System.Collections.Generic;
using System.Linq;

namespace SimpleShop
{
    public class ProductCatalog
    {
        private List<Product> _products;

        public ProductCatalog()
        {
            _products = new List<Product>();
            _products.Add(new Product(1, "Beer", 8));
            _products.Add(new Product(2, "Wine", 45));
            _products.Add(new Product(3, "Cheese", 25));
            _products.Add(new Product(4, "Apple", 3));
            _products.Add(new Product(5, "T-Shirt", 60));
        }

        public Product LookupProduct(int productId)
        {
            return _products.FirstOrDefault(p => p.ID == productId);
        }
    }
}