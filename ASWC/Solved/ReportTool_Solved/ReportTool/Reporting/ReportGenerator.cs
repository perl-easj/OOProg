using System;
using System.Collections.Generic;
using ReportTool.DomainClasses;
using ReportTool.Model;

namespace ReportTool.Reporting
{
    /// <summary>
    /// Legacy report generator.
    /// Mostly written by 2.semester students...
    /// </summary>
    public class ReportGenerator : IReportGenerator
    {
        public void GenerateProductReport(ProductCatalog prodCat)
        {
            MakeRoom();
            MakeHeader("PRODUCTS");

            Console.Write("ID".PadRight(10));
            Console.Write("DESCRIPTION".PadRight(50));
            Console.Write("WEIGHT".PadRight(20));
            Console.WriteLine();

            foreach (Product aProd in prodCat.GetProducts())
            {
                Console.Write($"{aProd.ProductId}".PadRight(10));
                Console.Write($"{aProd.Description}".PadRight(50));
                Console.Write($"{aProd.Weight:F3}".PadRight(15));
                Console.WriteLine(" kgs.");
            }

            MakeFooter();
            Console.WriteLine($"Summary: a total of {prodCat.GetProducts().Count} Products are available");
            Console.WriteLine();
        }

        public void GenerateShippingBoxReport(ShippingBoxes boxes)
        {
            MakeRoom();
            MakeHeader("SHIPPING BOXES");

            Console.Write("MATERIAL".PadRight(20));
            Console.Write("WIDTH x HEIGHT x DEPTH".PadRight(30));
            Console.Write("MAX. WEIGHT".PadRight(30));
            Console.WriteLine();

            foreach (ShippingBox box in boxes.AllBoxes())
            {
                Console.Write($"{box.Material}".PadRight(20));
                Console.Write($"{box.Width} x {box.Height} x {box.Depth}".PadRight(30));
                Console.Write($"(Max. {box.MaxWeight:F3} kgs.)".PadRight(30));
                Console.WriteLine();
            }

            MakeFooter();
            Console.WriteLine($"Summary: a total of {boxes.NumberOfBoxes()} Shipping Boxes are available");
            Console.WriteLine($"         with a total volume of {boxes.TotalVolumeInLiters()} liters");
        }

        public void GenerateCustomerReport(List<Customer> allCustomers)
        {
            MakeRoom();
            MakeHeader("CUSTOMERS");

            Console.Write("ID".PadRight(10));
            Console.Write("NAME".PadRight(30));
            Console.Write("ADDRESS".PadRight(30));
            Console.WriteLine("ZIPCODE".PadRight(10));

            foreach (Customer cust in allCustomers)
            {
                Console.Write($"{cust.CustomerId}".PadRight(10));
                Console.Write($"{cust.Name}".PadRight(30));
                Console.Write($"{cust.Address}".PadRight(30));
                Console.WriteLine($"{cust.ZipCode}".PadRight(10));
            }

            MakeFooter();
            Console.WriteLine($"Summary: a total of {allCustomers.Count} Customers are in the system");
            Console.WriteLine();
        }

        private void MakeRoom()
        {
            Console.WriteLine();
            Console.WriteLine();
        }

        private void MakeHeader(string description)
        {
            int fillerLength = (80 - description.Length)/2 - 1;
            string filler = "".PadLeft(fillerLength, '-');
            Console.WriteLine(filler + " " + description + " " + filler);
            string separator = "".PadLeft(80, '-');
            Console.WriteLine(separator);
        }

        private void MakeFooter()
        {
            string separator = "".PadLeft(80, '-');
            Console.WriteLine(separator);
        }
    }
}