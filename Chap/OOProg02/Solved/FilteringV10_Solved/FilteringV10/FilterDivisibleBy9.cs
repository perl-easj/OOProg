namespace FilteringV10
{
    /// <summary>
    ///  Specific filtering implementation
    /// </summary>
    public class FilterDivisibleBy9 : IFilterCondition
    {
        public bool Condition(int value)
        {
            return ((value % 9) == 0);
        }
    }
}