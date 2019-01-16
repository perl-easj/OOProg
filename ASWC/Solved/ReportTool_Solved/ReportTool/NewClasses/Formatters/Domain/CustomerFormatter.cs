using System.Collections.Generic;
using System.Linq;
using ReportTool.DomainClasses;
using ReportTool.NewClasses.Formatters.Base;
using ReportTool.NewClasses.Formatters.Interfaces;

namespace ReportTool.NewClasses.Formatters.Domain
{
    /// <summary>
    /// Formatter for Customer objects.
    /// </summary>
    public class CustomerFormatter : ItemFormatterAppBase<Customer>
    {
        public CustomerFormatter(ITextElementFormatterFactory formatterFactory, int totalWidth) 
            : base(formatterFactory, totalWidth)
        {
        }

        protected override void SetElementWidths()
        {
            ElementWidths = new List<int> { 10, 30, 30, 10 };
        }

        protected override List<ITextElementFormatter> ColumnHeaderTextElements()
        {
            List<ITextElementFormatter> elements = new List<ITextElementFormatter>();
            elements.Add(FormatterFactory.Create("ID", ElementWidths[0]));
            elements.Add(FormatterFactory.Create("NAME", ElementWidths[1]));
            elements.Add(FormatterFactory.Create("ADDRESS", ElementWidths[2]));
            elements.Add(FormatterFactory.Create("ZIPCODE", ElementWidths[3]));
            return elements;
        }

        protected override List<ITextElementFormatter> RowTextElements(Customer item)
        {
            List<ITextElementFormatter> elements = new List<ITextElementFormatter>();
            elements.Add(FormatterFactory.Create(item.CustomerId.ToString(), ElementWidths[0]));
            elements.Add(FormatterFactory.Create(item.Name, ElementWidths[1]));
            elements.Add(FormatterFactory.Create(item.Address, ElementWidths[2]));
            elements.Add(FormatterFactory.Create(item.ZipCode.ToString(), ElementWidths[3]));
            return elements;
        }

        public override string CreateFooter(IEnumerable<Customer> collection)
        {
            return $"Summary: a total of {collection.Count()} Customers are in the system";
        }
    }
}