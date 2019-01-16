using System.Collections.Generic;
using ReportTool.DomainClasses;
using ReportTool.Model;

namespace ReportTool.Reporting
{
    /// <summary>
    /// Interface for report generation. Just contains a method for
    /// each of the three domain classes.
    /// </summary>
    public interface IReportGenerator
    {
        void GenerateProductReport(ProductCatalog prodCat);
        void GenerateShippingBoxReport(ShippingBoxes boxes);
        void GenerateCustomerReport(List<Customer> allCustomers);
    }
}