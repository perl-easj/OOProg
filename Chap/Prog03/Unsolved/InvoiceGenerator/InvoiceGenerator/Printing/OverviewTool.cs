using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using InvoiceGenerator.DomainModel;

namespace InvoiceGenerator.Printing
{
    public class OverviewTool : PrintTool
    {
        public void PrintOverview(List<Order> orders)
        {
            // The variable orderLines will contain a single collection
            // of all order lines from the entire set of orders.
            var orderLines = orders.SelectMany(order => order.OrderLines).ToList();

            PrintBlankLines(2);
            Console.WriteLine("Here should be order overview information...");

            PrintBlankLines(2);
            Console.WriteLine(CreateProductsHeader());
            Console.WriteLine(CreateSeparator(TotalLinelength));
            Console.WriteLine("Here should be a list of ordered products...");
        }

        private string CreateProductsHeader()
        {
            string header = "";
            header += AddTrailingSpaces("PRODUCTS ORDERED", DescriptionFieldLength);
            return header;
        }

        private string CreateProductsLineText(string productDescription, int quantity)
        {
            string text = "";
            text += AddTrailingSpaces(productDescription, DescriptionFieldLength);
            text += AddTrailingSpaces($"{quantity} ordered.", MiscFieldLength);
            return text;
        }
    }
}