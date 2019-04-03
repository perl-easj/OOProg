using Patterns.Visitor.Interfaces;
using Patterns.Visitor.Items;

namespace Patterns.Visitor.Visitors
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

        public void Visit(Beer item)
        {
            VisitInternal(item);
        }

        public void Visit(Cheese item)
        {
            VisitInternal(item);
        }

        public void Visit(Shirt item)
        {
            VisitInternal(item);
        }

        private void VisitInternal(ItemBase item)
        {
            TotalHeavyItems += (item.Weight > isHeavyLimit) ? 1 : 0;
        }
    }
}