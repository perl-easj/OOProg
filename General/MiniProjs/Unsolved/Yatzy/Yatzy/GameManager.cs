using System;
using System.Collections.Generic;
using Yatzy.Evaluators;

namespace Yatzy
{
    /// <summary>
    /// This class manages - i.e. sets up and runs - a
    /// game of Yatzy. The class should be extended
    /// considerably to implement a full game of Yatzy.
    /// </summary>
    public class GameManager
    {
        #region Instance fields
        private DiceCup _cup;
        private Dictionary<string, IDiceEvaluator> _diceEvaluators;
        #endregion

        #region Constructor
        public GameManager(int numberOfDice, int noOfFaces)
        {
            _cup = new DiceCup(numberOfDice, noOfFaces);

            _diceEvaluators = new Dictionary<string, IDiceEvaluator>();
            _diceEvaluators.Add("Chance", new ChanceEvaluator());
            _diceEvaluators.Add("One Pair", new OnePairEvaluator());
        }
        #endregion

        #region Methods
        public void Run()
        {
            // Test: Roll dice 10 times, and run all evaluators for each roll
            for (int i = 0; i < 10; i++)
            {
                // Roll and print dice
                _cup.Shake();
                Console.WriteLine(_cup);

                // Run each evaluator against the dice
                foreach (var eval in _diceEvaluators)
                {
                    string evalDescription = eval.Key;
                    IDiceEvaluator diceEval = eval.Value;
                    Console.WriteLine($"{evalDescription} evaluated to {diceEval.Evaluate(_cup.DiceCountByFaceValue)} points");
                }

                Console.WriteLine();
            }
        } 
        #endregion
    }
}