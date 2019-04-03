using Patterns.CompositeVisitor.Interfaces;

namespace Patterns.CompositeVisitor.Visitors
{
    /// <summary>
    /// Specific Visitor implementation. Responsible for
    /// deciding if items are heavy or not, and
    /// accumulating the number of heavy items.
    /// </summary>
    public class IsHeavyVisitor : IVisitor
    {
        public const double isHeavyLimit = 0.4;

        public int TotalHeavyItems { get; private set; }

        public IsHeavyVisitor()
        {
            TotalHeavyItems = 0;
        }

        public void Visit(ICompositable item)
        {
            TotalHeavyItems += (item.Weight > isHeavyLimit) ? 1 : 0;
        }
    }
}