namespace CompositePattern.Visitors
{
    public class FamilyFundsVisitor : PersonValueAggregatorBase<int>
    {
        public override void Visit(Person p)
        {
            _val += p.Funds;
        }
    }
}