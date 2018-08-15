using System.Collections.Generic;

namespace Yatzy.Evaluators.Special
{
    /// <summary>
    /// Implementation of the "Yatzy" entry in Yatzy.
    /// </summary>
    public class YatzyEvaluator : IDiceEvaluator
    {
        public int Evaluate(Dictionary<int, int> diceCountByFaceValue)
        {
            int score = EvaluatorHelpers.HighestScoreForOAKGroups(diceCountByFaceValue, new List<int> { diceCountByFaceValue.Count });
            return  score == 0 ? 0 : score + 100;
        }
    }
}