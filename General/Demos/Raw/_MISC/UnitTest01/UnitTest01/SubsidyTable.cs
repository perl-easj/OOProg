using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest01
{
    public class SubsidyTable : ISubsidyTable
    {
        private Dictionary<int, double> _subsidyLimits;

        public SubsidyTable()
        {
            _subsidyLimits = new Dictionary<int, double>();

            _subsidyLimits.Add(0, 0);
            _subsidyLimits.Add(50, 950);
            _subsidyLimits.Add(75, 1565);
            _subsidyLimits.Add(85, 3390);
            _subsidyLimits.Add(100, 18331);
        }

        public List<int> GetSortedPercentages()
        {
            List<int> percentages = _subsidyLimits.Keys.ToList();
            percentages.Sort();
            return percentages;
        }

        public double GetIntervalLow(int percentage)
        {
            if (!_subsidyLimits.ContainsKey(percentage))
            {
                throw new ArgumentException("No interval set for this percentage");
            }

            return _subsidyLimits[percentage];
        }

        public double GetIntervalHigh(int percentage)
        {
            if (!_subsidyLimits.ContainsKey(percentage))
            {
                throw new ArgumentException("No interval set for this percentage");
            }

            List<int> percentages = _subsidyLimits.Keys.ToList();
            percentages.Sort();

            int index = percentages.FindIndex(p => (p == percentage));
            return (index == percentages.Count - 1) ? Double.PositiveInfinity : _subsidyLimits[percentages[index + 1]];
        }
    }
}