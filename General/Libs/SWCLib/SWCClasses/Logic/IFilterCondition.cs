namespace SWCClasses.Logic
{
    public interface IFilterCondition<in T>
    {
        bool Condition(T value);
    }
}