using System.Collections.Generic;

namespace Yatzy
{
    /// <summary>
    /// Interface for a class implementing an evaluation
    /// of a collection of dice. 
    /// </summary>
    public interface IDiceEvaluator
    {
        /// <summary>
        /// A specific implementation should return 
        /// the point score of the evaluation
        /// </summary>
        /// <param name="diceCountByValue">Dice to evaluate</param>
        /// <returns>Point score of evaluation</returns>
        int Evaluate(Dictionary<int,int> diceCountByValue);
    }
}