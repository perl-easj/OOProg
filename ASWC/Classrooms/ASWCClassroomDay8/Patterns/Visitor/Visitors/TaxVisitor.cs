using Patterns.Visitor.Interfaces;
using Patterns.Visitor.Items;

namespace Patterns.Visitor.Visitors
{
    /// <summary>
    /// Specific Visitor implementation. Responsible for
    /// applying specific tax rules to specific items, and
    /// accumulating the calculated taxes.
    /// </summary>
    public class TaxVisitor : IVisitor
    {
        public const double taxOnBeer = 0.25;
        public const double taxOnCheese = 0.15; 
        public const double taxOnShirt = 0.18;

        public double TotalTax { get; private set; }

        public TaxVisitor()
        {
            TotalTax = 0;
        }

        public void Visit(Beer item)
        {
            AccumulateTax(item, taxOnBeer);
        }

        public void Visit(Cheese item)
        {
            AccumulateTax(item, taxOnCheese);
        }

        public void Visit(Shirt item)
        {
            AccumulateTax(item, taxOnShirt);
        }

        private void AccumulateTax(ItemBase item, double tax)
        {
            TotalTax += item.Price * tax;
        }
    }
}