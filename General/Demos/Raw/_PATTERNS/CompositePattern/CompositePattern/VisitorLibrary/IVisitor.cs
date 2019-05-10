namespace CompositePattern.VisitorLibrary
{
    public interface IVisitor<in T>
    {
        void Visit(T element);
    }
}