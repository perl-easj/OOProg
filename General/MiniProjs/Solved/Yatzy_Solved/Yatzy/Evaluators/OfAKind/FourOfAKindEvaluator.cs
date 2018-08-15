using System.Collections.Generic;

namespace Yatzy.Evaluators.OfAKind
{
    /// <summary>
    /// Implementation of the "Four of a Kind" entry in Yatzy.
    /// </summary>
    public class FourOfAKindEvaluator : IDiceEvaluator
    {
        public int Evaluate(Dictionary<int, int> diceCountByFaceValue)
        {
            return EvaluatorHelpers.HighestScoreForOAKGroups(diceCountByFaceValue, new List<int> { 4 });
        }
    }
}