namespace FilteringV10
{
    /// <summary>
    /// Minimal interface for filtering 
    /// integers on a condition
    /// </summary>
    public interface IFilterCondition
    {
        bool Condition(int value);
    }
}