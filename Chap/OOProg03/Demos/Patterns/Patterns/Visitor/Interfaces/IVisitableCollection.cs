namespace Patterns.Visitor.Interfaces
{
    /// <summary>
    /// Interface for being able to apply a given
    /// Visitor to a collection of objects.
    /// </summary>
    public interface IVisitableCollection
    {
        void ApplyVisitor(IVisitor visitor);
    }
}