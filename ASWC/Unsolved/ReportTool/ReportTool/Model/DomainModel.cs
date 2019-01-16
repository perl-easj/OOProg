using System.Collections.Generic;
using ReportTool.DomainClasses;
using ReportTool.Reporting;

namespace ReportTool.Model
{
    /// <summary>
    /// This class represents the entire domain model for the scenario.
    /// The domain model consists of collections of Customer, Product
    /// and ShippingBox objects.
    /// </summary>
    public class DomainModel
    {
        #region Instance fields
        private List<Customer> _customers;
        private ProductCatalog _products;
        private ShippingBoxes _boxes;
        #endregion

        #region Constructor
        public DomainModel()
        {
            _customers = new List<Customer>();
            _products = new ProductCatalog();
            _boxes = new ShippingBoxes();

            GenerateTestData();
        }
        #endregion

        #region Methods
        public void GenerateReports(IReportGenerator reportGenerator)
        {
            reportGenerator.GenerateCustomerReport(_customers);
            reportGenerator.GenerateProductReport(_products);
            reportGenerator.GenerateShippingBoxReport(_boxes);
        }

        private void GenerateTestData()
        {
            Customer c1 = new Customer(1, "Allan Bentsen", "Øresundsvej 56", 2100);
            Customer c2 = new Customer(2, "Carl Dyrberg", "Kirkestræde 6", 2300);
            Customer c3 = new Customer(3, "Erik Frisch", "Ved Søen 14", 2750);
            Customer c4 = new Customer(4, "Gerda Holm", "Algade 119", 2300);
            Customer c5 = new Customer(5, "Ida Jensen", "Broholmen 80", 2750);
            Customer c6 = new Customer(6, "Klaus Larsen", "Broholmen 71", 2750);

            _customers.Add(c1);
            _customers.Add(c2);
            _customers.Add(c3);
            _customers.Add(c4);
            _customers.Add(c5);
            _customers.Add(c6);


            Product p1 = new Product(1, "Chair", 12);
            Product p2 = new Product(2, "Table", 18);
            Product p3 = new Product(3, "Sofa", 55);
            Product p4 = new Product(4, "Daybed", 15);
            Product p5 = new Product(5, "TV stand", 6);

            _products.AddProduct(p1);
            _products.AddProduct(p2);
            _products.AddProduct(p3);
            _products.AddProduct(p4);
            _products.AddProduct(p5);


            ShippingBox sb1 = new ShippingBox(140, 80, 25, "Wood", 80);
            ShippingBox sb2 = new ShippingBox(140, 80, 25, "Wood", 80);
            ShippingBox sb3 = new ShippingBox(140, 80, 25, "Wood", 80);
            ShippingBox sb4 = new ShippingBox(80, 60, 20, "Cardboard", 25);
            ShippingBox sb5 = new ShippingBox(80, 60, 20, "Cardboard", 25);
            ShippingBox sb6 = new ShippingBox(80, 60, 20, "Cardboard", 25);
            ShippingBox sb7 = new ShippingBox(80, 60, 20, "Cardboard", 25);

            _boxes.AddOneBox(sb1);
            _boxes.AddOneBox(sb2);
            _boxes.AddOneBox(sb3);
            _boxes.AddOneBox(sb4);
            _boxes.AddOneBox(sb5);
            _boxes.AddOneBox(sb6);
            _boxes.AddOneBox(sb7);
        } 
        #endregion
    }
}