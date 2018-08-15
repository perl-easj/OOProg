using System.Collections.Generic;

namespace Yatzy.Evaluators.Houses
{
    /// <summary>
    /// Implementation of the "Tower" entry in Yatzy.
    /// </summary>
    public class TowerEvaluator : IDiceEvaluator
    {
        public int Evaluate(Dictionary<int, int> diceCountByFaceValue)
        {
            return EvaluatorHelpers.HighestScoreForOAKGroups(diceCountByFaceValue, new List<int> { 4, 2 });
        }
    }
}