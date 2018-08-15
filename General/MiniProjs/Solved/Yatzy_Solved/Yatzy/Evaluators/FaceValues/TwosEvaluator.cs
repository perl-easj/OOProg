using System.Collections.Generic;

namespace Yatzy.Evaluators.FaceValues
{
    /// <summary>
    /// Finds the score for dice showing a specific face
    /// </summary>
    public class TwosEvaluator : IDiceEvaluator
    {
        public int Evaluate(Dictionary<int, int> diceCountByFaceValue)
        {
            return EvaluatorHelpers.ScoreForFaceValue(diceCountByFaceValue, 2);
        }
    }
}