using System.Collections.Generic;

namespace Yatzy.Evaluators.Pairs
{
    /// <summary>
    /// Implementation of the "Two Pairs" entry in Yatzy.
    /// </summary>
    public class TwoPairsEvaluator : IDiceEvaluator
    {
        public int Evaluate(Dictionary<int, int> diceCountByFaceValue)
        {
            return EvaluatorHelpers.HighestScoreForOAKGroups(diceCountByFaceValue, new List<int> { 2,2 });
        }
    }
}