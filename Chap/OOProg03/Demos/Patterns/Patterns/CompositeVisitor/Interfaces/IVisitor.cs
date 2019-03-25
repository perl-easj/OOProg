namespace Patterns.CompositeVisitor.Interfaces
{
    public interface IVisitor
    {
        void Visit(ICompositable item);
    }
}