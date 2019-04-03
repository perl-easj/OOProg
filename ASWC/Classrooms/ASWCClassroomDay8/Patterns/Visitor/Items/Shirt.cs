using Patterns.Visitor.Interfaces;

namespace Patterns.Visitor.Items
{
    public class Shirt : ItemBase, IVisitable
    {
        public Shirt() : base(19, 0.6)
        {
        }

        public override void Accept(IVisitor v)
        {
        }
    }
}