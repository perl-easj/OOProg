using System.Collections.Generic;
using ReportTool.DomainClasses;
using ReportTool.Model;

namespace ReportTool.NewClasses.Collections.Interfaces
{
    /// <summary>
    /// Interface for a factory capable of converting the heterogenous
    /// item collections into item collections implementing IEnumerable.
    /// </summary>
    public interface IEnumerableCollectionFactory
    {
        IEnumerable<Customer> CreateCustomerCollection(List<Customer> allCustomers);
        IEnumerable<Product> CreateProductCollection(ProductCatalog prodCat);
        IEnumerable<ShippingBox> CreateShippingBoxCollection(ShippingBoxes boxes);
    }
}