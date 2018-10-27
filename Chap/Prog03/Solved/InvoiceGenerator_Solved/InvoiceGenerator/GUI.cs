using System;
using System.Collections.Generic;
using InvoiceGenerator.DomainModel;
using InvoiceGenerator.Printing;

namespace InvoiceGenerator
{
    /// <summary>
    /// This class runs a very simple GUI. A character input is read from the user,
    /// on which three actions can be taken:
    /// q    : The application quits
    /// a    : An overview of all orders is displayed
    /// 1 - n: A specific invoice is displayed
    /// </summary>
    public class GUI
    {
        public static void RunGUI(List<Order> orders)
        {
            InvoiceTool ivTool = new InvoiceTool();
            OverviewTool ovTool = new OverviewTool();
            bool quit = false;

            Console.WriteLine();
            Console.WriteLine($"{orders.Count} orders in system, type 1 - {orders.Count} to see order invoice: ");
            Console.WriteLine("(Type a to see all orders, type q to Quit)");
            Console.Write("> ");
            string input = Console.ReadLine();

            // Check for quitting
            quit = (input == "q");

            while (!quit)
            {
                // Check for orders overview
                if (input == "a")
                {
                    ovTool.PrintOverview(orders);
                }

                // Check for specific invoice
                if (Int32.TryParse(input, out var orderChosen) && (orderChosen > 0) && (orderChosen <= orders.Count))
                {
                    ivTool.PrintInvoice(orders[orderChosen - 1]);
                    Console.WriteLine();
                }

                // Re-run GUI recursively
                RunGUI(orders);
                quit = true;
            }

        }
    }
}