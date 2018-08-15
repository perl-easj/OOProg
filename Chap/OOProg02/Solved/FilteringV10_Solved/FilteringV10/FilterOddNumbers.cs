namespace FilteringV10
{
    /// <summary>
    ///  Specific filtering implementation
    /// </summary>
    class FilterOddNumbers : IFilterCondition
    {
        public bool Condition(int value)
        {
            return ((value % 2) != 0);
        }
    }
}
