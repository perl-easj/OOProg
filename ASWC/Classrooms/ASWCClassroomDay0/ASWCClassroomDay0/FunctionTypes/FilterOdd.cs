namespace ASWCClassroomDay0.FunctionTypes
{
    public class FilterOdd : ICondition
    {
        public bool Condition(int value)
        {
            return (value % 2 != 0);
        }
    }

}