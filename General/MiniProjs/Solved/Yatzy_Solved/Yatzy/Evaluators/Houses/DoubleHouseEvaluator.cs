using System.Collections.Generic;

namespace Yatzy.Evaluators.Houses
{
    /// <summary>
    /// Implementation of the "Double House" entry in Yatzy.
    /// </summary>
    public class DoubleHouseEvaluator : IDiceEvaluator
    {
        public int Evaluate(Dictionary<int, int> diceCountByFaceValue)
        {
            return EvaluatorHelpers.HighestScoreForOAKGroups(diceCountByFaceValue, new List<int> { 3, 3 });
        }
    }
}