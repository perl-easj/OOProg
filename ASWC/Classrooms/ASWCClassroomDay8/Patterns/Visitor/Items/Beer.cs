using Patterns.Visitor.Interfaces;

namespace Patterns.Visitor.Items
{
    public class Beer : ItemBase, IVisitable
    {
        public Beer() : base(6, 0.33)
        {
        }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
}