namespace CompositePattern.Visitors
{
    public class FamilyTreeSizeVisitor : PersonValueAggregatorBase<int>
    {
        public override void Visit(Person p)
        {
            _val ++;
        }
    }
}