using Patterns.CompositeVisitor.Interfaces;

namespace Patterns.CompositeVisitor.Visitors
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

        public void Visit(ICompositable item)
        {
            // Hmmm, how can this be implemented...?
            // TotalTax += item.Price * tax;
        }
    }
}