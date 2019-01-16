using System;
using System.Collections.Generic;
using System.Linq;
using ReportTool.NewClasses.Formatters.Interfaces;

namespace ReportTool.NewClasses.Reports
{
    /// <summary>
    /// Central new class, which handles report generation for a single item type.
    /// Responsibilities:
    /// 1) Contains a template method for report generation (GenerateReport)
    /// </summary>
    /// <typeparam name="T">Type of items for which a report is generated</typeparam>
    public class ItemReportGenerator<T>
    {
        #region Properties and Constructor
        private int TotalLineWidth { get; }

        public ItemReportGenerator(int totalLineWidth)
        {
            TotalLineWidth = totalLineWidth;
        }
        #endregion

        #region Public method for Report Generation
        public void GenerateReport(IEnumerable<T> collection, IItemFormatter<T> formatter)
        {
            IEnumerable<T> enumeratedCollection = collection.ToList();

            PrintHeader(formatter);
            PrintColumnHeader(formatter);
            PrintRows(enumeratedCollection, formatter);
            PrintFooter(enumeratedCollection, formatter);
        } 
        #endregion

        #region Helper Methods
        private void PrintHeader(IItemFormatter<T> formatter)
        {
            int fillerLength = (TotalLineWidth - formatter.CreateDescription().Length) / 2 - 1;
            string filler = "".PadLeft(fillerLength, '-');

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(filler + " " + formatter.CreateDescription() + " " + filler);
            Console.WriteLine(CreateSeparator());
        }

        private void PrintColumnHeader(IItemFormatter<T> formatter)
        {
            Console.WriteLine(formatter.CreateColumnHeader());
        }

        private void PrintRows(IEnumerable<T> collection, IItemFormatter<T> formatter)
        {
            foreach (T item in collection)
            {
                Console.WriteLine(formatter.CreateItemText(item));
            }
        }

        private void PrintFooter(IEnumerable<T> collection, IItemFormatter<T> formatter)
        {
            Console.WriteLine(CreateSeparator());
            Console.WriteLine(formatter.CreateFooter(collection));
        }

        private string CreateSeparator()
        {
            return "".PadLeft(TotalLineWidth, '-');
        }
        #endregion
    }
}