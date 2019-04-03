using Patterns.Visitor.Items;

namespace Patterns.Visitor.Interfaces
{
    /// <summary>
    /// Interface for a visitor capable of visiting
    /// objects of these specific types.
    /// </summary>
    public interface IVisitor
    {
        void Visit(Beer item);
        void Visit(Cheese item);
        void Visit(Shirt item);
    }
}