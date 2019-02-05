namespace ASWCClassroomDay1
{
    public class StringConcatenator : AggregateCalculator<string, string>
    {
        protected override string InitialAggregateValue()
        {
            return "";
        }

        protected override string UpdateAggregateValue(string value, string item)
        {
            return value + item;
        }
    }

}