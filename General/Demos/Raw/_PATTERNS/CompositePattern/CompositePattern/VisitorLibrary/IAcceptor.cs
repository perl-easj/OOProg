namespace CompositePattern.VisitorLibrary
{
    public interface IAcceptor<out T>
    {
        void Accept(IVisitor<T> visitor);
    }
}