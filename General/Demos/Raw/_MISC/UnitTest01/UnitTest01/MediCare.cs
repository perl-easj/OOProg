using System;
using System.Collections.Generic;

namespace UnitTest01
{
    public class MediCare
    {
        private ISubsidyTable _subsidyTable;

        public MediCare(ISubsidyTable subsidyTable)
        {
            _subsidyTable = subsidyTable;
        }

        // Rest of class omitted
        public double SubsidisedExpense(double expense)
        {
            if (expense < 0)
            {
                throw new ArgumentException("Negative amount not allowed");
            }

            double subsidy = 0;
            List<int> percentages = _subsidyTable.GetSortedPercentages();

            for (int index = 0; index < percentages.Count; index++)
            {
                int percentage = percentages[index];

                double low = _subsidyTable.GetIntervalLow(percentage);
                double high = _subsidyTable.GetIntervalHigh(percentage);

                if (expense >= high) // Expense is fully in bracket
                {
                    subsidy = subsidy + ((high - low) * percentage) / 100;
                }
                else if (expense > low) // Expense is partially in bracket
                {
                    subsidy = subsidy + ((expense - low) * percentage) / 100;
                }
            }

            return expense - subsidy;
        }
    }
}