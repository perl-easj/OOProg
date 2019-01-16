using System.Collections.Generic;
using System.Linq;
using ReportTool.DomainClasses;

namespace ReportTool.Model
{
    /// <summary>
    /// A ProductCatalog is a class which can store a set of Product objects.
    /// It has been written without any consideration for reusability...
    /// </summary>
    public class ProductCatalog
    {
        #region Instance fields and Constructor
        private Dictionary<int, Product> _products;

        public ProductCatalog()
        {
            _products = new Dictionary<int, Product>();
        }
        #endregion

        #region Methods
        public List<Product> GetProducts()
        {
            return _products.Values.ToList();
        }

        public Product GetProduct(int productId)
        {
            return _products.ContainsKey(productId) ? _products[productId] : null;
        }

        public void AddProduct(Product p)
        {
            if (!_products.ContainsKey(p.ProductId))
            {
                _products.Add(p.ProductId, p);
            }
        }

        public void RemoveProduct(Product p)
        {
            _products.Remove(p.ProductId);
        } 
        #endregion
    }
}