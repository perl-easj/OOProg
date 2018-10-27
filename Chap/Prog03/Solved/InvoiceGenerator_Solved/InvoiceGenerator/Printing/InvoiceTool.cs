using System;
using InvoiceGenerator.DomainModel;

namespace InvoiceGenerator.Printing
{
    public class InvoiceTool : PrintTool
    {
        // This method is responsible for printing an
        // Invoice for a single Order.
        public void PrintInvoice(Order anOrder)
        {
            // Part 3.a: Print customer information
            PrintBlankLines(2);
            Console.WriteLine(anOrder.Name);
            Console.WriteLine(anOrder.Address);
            Console.WriteLine($"{anOrder.ZipCode} {Constants.ZipCodes[anOrder.ZipCode]}");

            // Create some space, and print the order line header
            PrintBlankLines(2);
            Console.WriteLine(CreateInvoiceOrderLineHeader());
            Console.WriteLine(CreateSeparator(TotalLinelength));

            // Part 3.b: Print each individual order line,
            // by calling CreateOrderLineText.
            foreach (OrderLine ol in anOrder.OrderLines)
            {
                Console.WriteLine(CreateOrderLineText(ol));
            }
            Console.WriteLine(CreateSeparator(TotalLinelength));
            PrintBlankLines(1);

            // Caluclate sub-total, tax and total
            double subTotal = anOrder.DiscountedPrice;
            double tax = subTotal * Constants.TaxPercentage / 100.0;
            double total = subTotal + tax;

            // Part 3.c+d+e: Print sub-total, tax and total.
            Console.WriteLine(CreateTotalsLineText("SUB TOTAL", subTotal));
            Console.WriteLine(CreateTotalsLineText("TAX", tax));
            Console.WriteLine(CreateTotalsLineText("TOTAL", total));
        }

        // Creates the order line header. Each part is formatted to have
        // a specific length, and then added to the header string.
        private string CreateInvoiceOrderLineHeader()
        {
            string header = "";
            header += AddTrailingSpaces("DESCRIPTION", DescriptionFieldLength);
            header += AddTrailingSpaces("QUANTITY", MiscFieldLength);
            header += AddTrailingSpaces("UNIT PRICE", MiscFieldLength);
            header += AddTrailingSpaces("DISC. (%)", MiscFieldLength);
            header += AddTrailingSpaces("DISCOUNT", MiscFieldLength);
            header += AddTrailingSpaces("TOTAL PRICE", MiscFieldLength);
            return header;
        }

        // Creates a single order line. Note that the formatting follows the
        // same pattern as for the order line header. This ensures that the
        // order line text is aligned with the header text.
        private string CreateOrderLineText(OrderLine ol)
        {
            // Note that there is not really any LINQ left here,
            // since we have added some useful properties to the
            // Orderline class
            string text = "";
            text += AddTrailingSpaces(ol.OrderedProduct.Description, DescriptionFieldLength);
            text += AddTrailingSpaces(ol.Quantity.ToString(), MiscFieldLength);
            text += AddTrailingSpaces(ConvertAmountToString(ol.OrderedProduct.Price), MiscFieldLength);
            text += AddTrailingSpaces(ol.DiscountPercent.ToString(), MiscFieldLength);
            text += AddTrailingSpaces(ConvertAmountToString(ol.Price - ol.DiscountedPrice), MiscFieldLength);
            text += AddTrailingSpaces(ConvertAmountToString(ol.DiscountedPrice), MiscFieldLength);

            return text;
        }

        // Creates a single line for the "totals" part of the Invoice.
        // This part is right-aligned with the order line section,
        // which is why the first part is an empty string of length
        // TotalLinelength - (2 * MiscFieldLength)
        private string CreateTotalsLineText(string desc, double amount)
        {
            string text = "";
            text += AddTrailingSpaces("", TotalLinelength - (2 * MiscFieldLength));
            text += AddTrailingSpaces(desc, MiscFieldLength);
            text += AddTrailingSpaces(ConvertAmountToString(amount), MiscFieldLength);
            return text;
        }
    }
}