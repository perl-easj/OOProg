using System;
using System.Linq;
using InvoiceGenerator.DomainModel;

namespace InvoiceGenerator.Printing
{
    public class InvoiceTool : PrintTool
    {
        public void PrintInvoice(Order anOrder)
        {
            PrintBlankLines(2);
            Console.WriteLine("Here should be customer information...");

            PrintBlankLines(2);
            Console.WriteLine(CreateInvoiceOrderLineHeader());
            Console.WriteLine(CreateSeparator(TotalLinelength));
            Console.WriteLine("Here should be information for each order line...");

            PrintBlankLines(1);
            Console.WriteLine("Here should be information about totals and tax...");
        }

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

        private string CreateOrderLineText(OrderLine ol)
        {
            // This method needs to be implemented
            string text = "";
            return text;
        }

        private double CalculateSubTotal(Order anOrder)
        {
            // This method may be useful to implement...
            return 0.0;
        }

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