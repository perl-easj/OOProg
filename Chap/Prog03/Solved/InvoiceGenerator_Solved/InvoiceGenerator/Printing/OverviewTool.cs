using System;
using System.Collections.Generic;
using System.Linq;
using InvoiceGenerator.DomainModel;

namespace InvoiceGenerator.Printing
{
    public class OverviewTool : PrintTool
    {
        // This method is responsible for printing some
        // overview information relating to the entire
        // set of Orders.
        public void PrintOverview(List<Order> orders)
        {
            // The variable orderLines will contain a single collection
            // of all order lines from the entire set of orders.
            var orderLines = orders.SelectMany(order => order.OrderLines).ToList();

            // Part 2.a: Print the total number of Orders.
            PrintBlankLines(2);
            Console.WriteLine($"Total number of orders: {orders.Count}");

            // Part 2.b: Print the total number of OrderLines.
            PrintBlankLines(2);
            Console.WriteLine($"Total number of order lines: {orderLines.Count}");

            // Part 2.c: Print the total amount for all Orders
            PrintBlankLines(2);
            double totalAmount = orders.Select(order => order.OrderLines.Select(ol => ol.DiscountedPrice).Sum()).Sum();
            Console.WriteLine($"Total amount ordered {ConvertAmountToString(totalAmount)}");

            PrintBlankLines(2);
            Console.WriteLine(CreateProductsHeader());
            Console.WriteLine(CreateSeparator(TotalLinelength));

            // Part 2.d: Step #1: Select (unique) descriptions
            // of all products in orders
            var productDescriptions = orderLines
                .Select(ol => ol.OrderedProduct.Description)
                .Distinct()
                .OrderBy(m => m);

            // Part 2.d: Step #2: For each product description... 
            foreach (string productDescription in productDescriptions)
            {
                // Select sum of quantities for the specified product
                int totalQuantity = orderLines
                    .Where(ol => ol.OrderedProduct.Description == productDescription)
                    .Select(ol => ol.Quantity)
                    .Sum();

                // Create a string representation, and print it.
                Console.WriteLine(CreateProductsLineText(productDescription, totalQuantity));
            }
        }

        // Creates the product amount header.
        private string CreateProductsHeader()
        {
            string header = "";
            header += AddTrailingSpaces("PRODUCTS ORDERED", DescriptionFieldLength);
            return header;
        }

        // Creates a single product amount line.
        private string CreateProductsLineText(string productDescription, int quantity)
        {
            string text = "";
            text += AddTrailingSpaces(productDescription, DescriptionFieldLength);
            text += AddTrailingSpaces($"{quantity} ordered.", MiscFieldLength);
            return text;
        }
    }
}