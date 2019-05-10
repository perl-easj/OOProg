using System.Collections.Generic;

namespace UnitTest01
{
    public interface ISubsidyTable
    {
        List<int> GetSortedPercentages();
        double GetIntervalLow(int percentage);
        double GetIntervalHigh(int percentage);
    }
}