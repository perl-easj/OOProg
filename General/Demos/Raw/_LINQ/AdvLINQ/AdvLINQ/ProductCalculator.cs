namespace AdvLINQ
{
    public class ProductCalculator : AggregateCalculator<int, int>
    {
        protected override int InitialAggregateValue()
        {
            return 1;
        }

        protected override int UpdateAggregateValue(int value, int item)
        {
            return value * item;
        }
    }
}