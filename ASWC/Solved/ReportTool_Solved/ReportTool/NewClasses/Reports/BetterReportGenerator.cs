using System.Collections.Generic;
using ReportTool.DomainClasses;
using ReportTool.Model;
using ReportTool.NewClasses.Collections.Interfaces;
using ReportTool.NewClasses.Formatters.Interfaces;
using ReportTool.Reporting;

namespace ReportTool.NewClasses.Reports
{
    /// <summary>
    /// Revised - and hopefully better - implementation of the
    /// IReportGenerator interface.
    /// Responsibilities:
    /// 1) Implements IReportGenerator, using fixed generators and variable formatters.
    /// </summary>
    public class BetterReportGenerator : IReportGenerator
    {
        #region Instance fields
        private IItemFormatter<Customer> _customerFormatter;
        private IItemFormatter<Product> _productFormatter;
        private IItemFormatter<ShippingBox> _shippingBoxFormatter;

        private ItemReportGenerator<Customer> _customerReportGenerator;
        private ItemReportGenerator<Product> _productReportGenerator;
        private ItemReportGenerator<ShippingBox> _shippingBoxGenerator;

        private IEnumerableCollectionFactory _collectionFactory;
        #endregion

        #region Constructor
        public BetterReportGenerator(
            IItemFormatter<Customer> customerFormatter,
            IItemFormatter<Product> productFormatter,
            IItemFormatter<ShippingBox> shippingBoxFormatter, 
            IEnumerableCollectionFactory collectionFactory)
        {
            _customerReportGenerator = new ItemReportGenerator<Customer>(ReportGeneratorSetup.ReportWidth);
            _productReportGenerator = new ItemReportGenerator<Product>(ReportGeneratorSetup.ReportWidth);
            _shippingBoxGenerator = new ItemReportGenerator<ShippingBox>(ReportGeneratorSetup.ReportWidth);

            _customerFormatter = customerFormatter;
            _productFormatter = productFormatter;
            _shippingBoxFormatter = shippingBoxFormatter;
            _collectionFactory = collectionFactory;
        }
        #endregion

        #region IReportGenerator implementation
        public void GenerateProductReport(ProductCatalog prodCat)
        {
            _productReportGenerator.GenerateReport(_collectionFactory.CreateProductCollection(prodCat), _productFormatter);
        }

        public void GenerateShippingBoxReport(ShippingBoxes boxes)
        {
            _shippingBoxGenerator.GenerateReport(_collectionFactory.CreateShippingBoxCollection(boxes), _shippingBoxFormatter);
        }

        public void GenerateCustomerReport(List<Customer> allCustomers)
        {
            _customerReportGenerator.GenerateReport(_collectionFactory.CreateCustomerCollection(allCustomers), _customerFormatter);
        }
        #endregion
    }
}