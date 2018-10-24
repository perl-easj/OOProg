using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceGenerator.DomainModel;

namespace InvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Products
            // Create some products
            Product shirt = new Product("Shirt", 149);
            Product sweater = new Product("Sweater", 299);
            Product belt = new Product("Belt", 89);
            Product gloves = new Product("Gloves", 179);
            Product sunglasses = new Product("Sunglasses", 499);
            Product sneakers = new Product("Sneakers", 399);
            Product wallet = new Product("Wallet", 199);
            Product keyring = new Product("Keyring", 229);
            #endregion

            #region Orders
            // Create some orders
            Order orderA = new Order("Anton Jensen", "Foldager 17", 3520);
            Order orderB = new Order("Britta Holm", "Søvangen 3", 4000);
            Order orderC = new Order("Carsten Jørgensen", "Niels Andersens Vej 192", 4720);
            Order orderD = new Order("Dan Ilskov", "Ved kæret 11", 4720);
            Order orderE = new Order("Elisa Ejlersen", "Ådalen 30", 3520);
            #endregion

            #region OrderLines
            // Add OrderLines to orders
            orderA.AddOrderLine(new OrderLine(orderA, shirt, 2));
            orderA.AddOrderLine(new OrderLine(orderA, sweater, 1));
            orderA.AddOrderLine(new OrderLine(orderA, wallet, 1));
            orderA.AddOrderLine(new OrderLine(orderA, keyring, 2));

            orderB.AddOrderLine(new OrderLine(orderB, belt, 3));
            orderB.AddOrderLine(new OrderLine(orderB, gloves, 1));

            orderC.AddOrderLine(new OrderLine(orderC, sunglasses, 1));
            orderC.AddOrderLine(new OrderLine(orderC, sneakers, 2));
            orderC.AddOrderLine(new OrderLine(orderC, shirt, 4));

            orderD.AddOrderLine(new OrderLine(orderD, shirt, 3));
            orderD.AddOrderLine(new OrderLine(orderD, sweater, 2));
            orderD.AddOrderLine(new OrderLine(orderD, gloves, 2));
            orderD.AddOrderLine(new OrderLine(orderD, keyring, 1));

            orderE.AddOrderLine(new OrderLine(orderE, sweater, 1));
            orderE.AddOrderLine(new OrderLine(orderE, sneakers, 1));
            orderE.AddOrderLine(new OrderLine(orderE, belt, 3));
            orderE.AddOrderLine(new OrderLine(orderE, wallet, 2)); 
            #endregion

            List<Order> allOrders = new List<Order>{orderA, orderB, orderC, orderD, orderE};
            GUI.RunGUI(allOrders);

            KeepConsoleWindowOpen();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Done - press any key to close application.");
            Console.ReadKey();
        }
    }
}
