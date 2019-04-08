using SimpleShop.Domain;

namespace SimpleShop.Catalogs
{
    public class ProductCatalog : Catalog<Product>
    {
        public ProductCatalog()
        {
            _items.Add(new Product(1, "Beer", 8));
            _items.Add(new Product(2, "Wine", 45));
            _items.Add(new Product(3, "Cheese", 25));
            _items.Add(new Product(4, "Apple", 3));
            _items.Add(new Product(5, "T-Shirt", 60));
        }
    }
}