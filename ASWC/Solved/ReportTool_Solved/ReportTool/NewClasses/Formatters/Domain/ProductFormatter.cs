using System.Collections.Generic;
using System.Linq;
using ReportTool.DomainClasses;
using ReportTool.NewClasses.Formatters.Base;
using ReportTool.NewClasses.Formatters.Interfaces;

namespace ReportTool.NewClasses.Formatters.Domain
{
    /// <summary>
    /// Formatter for Product objects.
    /// </summary>
    public class ProductFormatter : ItemFormatterAppBase<Product>
    {
        public ProductFormatter(ITextElementFormatterFactory formatterFactory, int totalWidth) 
            : base(formatterFactory, totalWidth)
        {
        }

        protected override void SetElementWidths()
        {
            ElementWidths = new List<int> { 10, 50, 20 };
        }

        protected override List<ITextElementFormatter> ColumnHeaderTextElements()
        {
            List<ITextElementFormatter> elements = new List<ITextElementFormatter>();
            elements.Add(FormatterFactory.Create("ID", ElementWidths[0]));
            elements.Add(FormatterFactory.Create("DESCRIPTION", ElementWidths[1]));
            elements.Add(FormatterFactory.Create("WEIGHT", ElementWidths[2]));
            return elements;
        }

        protected override List<ITextElementFormatter> RowTextElements(Product item)
        {
            List<ITextElementFormatter> elements = new List<ITextElementFormatter>();
            elements.Add(FormatterFactory.Create(item.ProductId.ToString(), ElementWidths[0]));
            elements.Add(FormatterFactory.Create(item.Description, ElementWidths[1]));
            elements.Add(FormatterFactory.Create($"{item.Weight:F3}", ElementWidths[2]));
            return elements;
        }

        public override string CreateFooter(IEnumerable<Product> collection)
        {
            return $"Summary: a total of {collection.Count()} Products are available";
        }
    }
}