using System;
using InvoiceGenerator.DomainModel;

namespace InvoiceGenerator.Printing
{
    /// <summary>
    /// This class contains constants and methods used by
    /// the Invoice and Overview printing tools.
    /// </summary>
    public class PrintTool
    {
        protected const int DescriptionFieldLength = 20;
        protected const int MiscFieldLength = 12;
        protected const int TotalLinelength = DescriptionFieldLength + (5 * MiscFieldLength);

        public PrintTool()
        {
            ProductDiscounts = new Discounts();
        }

        protected Discounts ProductDiscounts { get; }

        protected string AddTrailingSpaces(string text, int desiredLength)
        {
            if (text.Length > desiredLength)
            {
                throw new ArgumentException($"Called AddTrailingSpaces with a string of length {text.Length} and desired length {desiredLength}");
            }

            return text.PadRight(desiredLength);
        }

        protected string CreateSeparator(int desiredLength)
        {
            return "".PadRight(desiredLength, '-');
        }

        protected void PrintBlankLines(int noOfLines)
        {
            for (int i = 0; i < noOfLines; i++)
            {
                Console.WriteLine();
            }
        }

        protected string ConvertAmountToString(double amount, string currency = "kr.")
        {
            return $"{amount:F2} {currency}";
        }
    }
}