using System;
using System.Collections.Generic;

namespace ASWCClassroomDay0.FunctionTypes
{
    public class Filterer
    {
        public static List<int> FilterValuesV1(List<int> values)
        {
            List<int> filteredValues = new List<int>();

            foreach (int v in values)
            {
                if (v < 20)
                {
                    filteredValues.Add(v);
                }
            }

            return filteredValues;
        }

        public static List<int> FilterValuesV2(List<int> values, ICondition condObj)
        {
            List<int> filteredValues = new List<int>();

            foreach (int v in values)
            {
                if (condObj.Condition(v))
                {
                    filteredValues.Add(v);
                }
            }

            return filteredValues;
        }

        public static List<int> FilterValuesV3(List<int> values, Func<int, bool> condFunc)
        {
            List<int> filteredValues = new List<int>();

            foreach (int v in values)
            {
                if (condFunc(v))
                {
                    filteredValues.Add(v);
                }
            }

            return filteredValues;
        }
    }
}