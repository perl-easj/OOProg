using Patterns.Visitor.Interfaces;

namespace Patterns.Visitor.Items
{
    public class Cheese : ItemBase, IVisitable
    {
        public Cheese() : base(8, 0.5)
        {
        }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
}