using Patterns.Visitor.Interfaces;

namespace Patterns.Visitor.Items
{
    /// <summary>
    /// Base class for all items, making all items visitable.
    /// </summary>
    public abstract class ItemBase : IVisitable
    {
        public double Price { get; }
        public double Weight { get; }

        protected ItemBase(double price, double weight)
        {
            Price = price;
            Weight = weight;
        }

        public abstract void Accept(IVisitor v);
    }
}