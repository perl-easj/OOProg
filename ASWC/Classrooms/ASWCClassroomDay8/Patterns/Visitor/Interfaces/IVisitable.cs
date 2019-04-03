namespace Patterns.Visitor.Interfaces
{
    /// <summary>
    /// Standard interface for a "visitable" object
    /// </summary>
    public interface IVisitable
    {
        void Accept(IVisitor v);
    }
}