namespace FilteringV10
{
    /// <summary>
    ///  Specific filtering implementation
    /// </summary>
    class FilterBelow20 : IFilterCondition
    {
        public bool Condition(int value)
        {
            return (value < 20);
        }
    }
}
