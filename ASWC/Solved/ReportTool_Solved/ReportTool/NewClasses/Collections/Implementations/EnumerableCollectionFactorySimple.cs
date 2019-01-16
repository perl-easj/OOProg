using System.Collections.Generic;
using ReportTool.DomainClasses;
using ReportTool.Model;
using ReportTool.NewClasses.Collections.Interfaces;

namespace ReportTool.NewClasses.Collections.Implementations
{
    /// <summary>
    /// Specific collection factory implementation. Simply extracts the item collection
    /// from the given container, by whatever method the specific item collection offers.
    /// </summary>
    public class EnumerableCollectionFactorySimple : IEnumerableCollectionFactory
    {
        public IEnumerable<Customer> CreateCustomerCollection(List<Customer> allCustomers)
        {
            return allCustomers;
        }

        public IEnumerable<Product> CreateProductCollection(ProductCatalog prodCat)
        {
            return prodCat.GetProducts();
        }

        public IEnumerable<ShippingBox> CreateShippingBoxCollection(ShippingBoxes boxes)
        {
            return boxes.AllBoxes();
        }
    }
}