using CompositePattern.VisitorLibrary;

namespace CompositePattern.Visitors
{
    public abstract class PersonValueAggregatorBase<TVal> : IVisitor<Person>
    {
        protected TVal _val;

        public TVal GetValue(Person p)
        {
            _val = default(TVal);
            p.Accept(this);
            return _val;
        }

        public abstract void Visit(Person element);
    }
}