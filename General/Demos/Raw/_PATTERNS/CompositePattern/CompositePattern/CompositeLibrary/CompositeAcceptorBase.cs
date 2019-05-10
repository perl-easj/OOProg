using CompositePattern.VisitorLibrary;

namespace CompositePattern.CompositeLibrary
{
    public abstract class CompositeAcceptorBase<T> : CompositeBase<T>, IAcceptor<T> where T : ICompositable
    {
        public void Accept(IVisitor<T> visitor)
        {
            ApplyOperation(comp => visitor.Visit((T)comp));
        }
    }
}