using System.Collections.Generic;
using System.Linq;
using ReportTool.DomainClasses;
using ReportTool.Model;
using ReportTool.NewClasses.Formatters.Base;
using ReportTool.NewClasses.Formatters.Interfaces;

namespace ReportTool.NewClasses.Formatters.Domain
{
    /// <summary>
    /// Formatter for ShippingBox objects.
    /// </summary>
    public class ShippingBoxFormatter : ItemFormatterAppBase<ShippingBox>
    {
        public ShippingBoxFormatter(ITextElementFormatterFactory formatterFactory, int totalWidth) 
            : base(formatterFactory, totalWidth)
        {
        }

        protected override void SetElementWidths()
        {
            ElementWidths = new List<int> { 20, 30, 30 };
        }

        public override string CreateDescription()
        {
            return "SHIPPING BOXES";
        }

        protected override List<ITextElementFormatter> ColumnHeaderTextElements()
        {
            List<ITextElementFormatter> elements = new List<ITextElementFormatter>();
            elements.Add(FormatterFactory.Create("MATERIAL", ElementWidths[0]));
            elements.Add(FormatterFactory.Create("WIDTH x HEIGHT x DEPTH", ElementWidths[1]));
            elements.Add(FormatterFactory.Create("MAX. WEIGHT", ElementWidths[2]));
            return elements;
        }

        protected override List<ITextElementFormatter> RowTextElements(ShippingBox item)
        {
            List<ITextElementFormatter> elements = new List<ITextElementFormatter>();
            elements.Add(FormatterFactory.Create(item.Material, ElementWidths[0]));
            elements.Add(FormatterFactory.Create($"{item.Width} x {item.Height} x {item.Depth}", ElementWidths[1]));
            elements.Add(FormatterFactory.Create($"(Max. {item.MaxWeight:F3} kgs.)", ElementWidths[2]));
            return elements;
        }

        public override string CreateFooter(IEnumerable<ShippingBox> collection)
        {
            IEnumerable<ShippingBox> enumeratedCollection = collection.ToList();

            return $"Summary: a total of {enumeratedCollection.Count()} Shipping Boxes are available\n" +
                   $"         with a total volume of {TotalLiters(enumeratedCollection)} liters";
        }

        // Yuck...
        private int TotalLiters(IEnumerable<ShippingBox> collection)
        {
            ShippingBoxes boxes = new ShippingBoxes();
            foreach (ShippingBox aBox in collection)
            {
                boxes.AddOneBox(aBox);
            }

            return boxes.TotalVolumeInLiters();
        }
    }
}