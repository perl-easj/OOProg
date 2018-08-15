using System;
using System.Collections.Generic;
using Yatzy.Evaluators;
using Yatzy.Evaluators.FaceValues;
using Yatzy.Evaluators.Houses;
using Yatzy.Evaluators.OfAKind;
using Yatzy.Evaluators.Pairs;
using Yatzy.Evaluators.Special;
using Yatzy.Evaluators.Straights;

namespace Yatzy
{
    /// <summary>
    /// This class manages - i.e. sets up and runs - a
    /// game of Yatzy. The class should be extended
    /// considerably to implement a full game of Yatzy.
    /// </summary>
    public class GameManager
    {
        private DiceCup _cup;
        private Dictionary<string, IDiceEvaluator> _diceEvaluators;
        private DiceEvaluationStatistics _evaluationStats;

        public GameManager(int numberOfDice, int noOfFaces)
        {
            _cup = new DiceCup(numberOfDice, noOfFaces);
            _diceEvaluators = new Dictionary<string, IDiceEvaluator>();

            _diceEvaluators.Add("Ones", new OnesEvaluator());
            _diceEvaluators.Add("Twos", new TwosEvaluator());
            _diceEvaluators.Add("Threes", new ThreesEvaluator());
            _diceEvaluators.Add("Fours", new FoursEvaluator());
            _diceEvaluators.Add("Fives", new FivesEvaluator());
            _diceEvaluators.Add("Sixes", new SixesEvaluator());

            _diceEvaluators.Add("One Pair", new OnePairEvaluator());
            _diceEvaluators.Add("Two Pairs", new TwoPairsEvaluator());
            _diceEvaluators.Add("Three Pairs", new ThreePairsEvaluator());

            _diceEvaluators.Add("Three of a Kind", new ThreeOfAKindEvaluator());
            _diceEvaluators.Add("Four of a Kind", new FourOfAKindEvaluator());
            _diceEvaluators.Add("Five of a Kind", new FiveOfAKindEvaluator());

            _diceEvaluators.Add("Small Straight", new SmallStraightEvaluator());
            _diceEvaluators.Add("Big Straight", new BigStraightEvaluator());
            _diceEvaluators.Add("Full Straight", new FullStraightEvaluator());

            _diceEvaluators.Add("Full House", new FullHouseEvaluator());
            _diceEvaluators.Add("Double House", new DoubleHouseEvaluator());
            _diceEvaluators.Add("Tower", new TowerEvaluator());

            _diceEvaluators.Add("Chance", new ChanceEvaluator());
            _diceEvaluators.Add("Yatzy", new YatzyEvaluator());

            _evaluationStats = new DiceEvaluationStatistics();
        }

        public void Run()
        {
            // Test: Roll dice several times, and run all evaluators for each roll
            for (int i = 0; i < 1000; i++)
            {
                // Roll dice
                _cup.Shake();

                // Pick up evaluations
                DiceEvaluation diceEval = new DiceEvaluation(_cup.DiceFaceValues);

                // Run each evaluator against the dice
                foreach (var eval in _diceEvaluators)
                {
                    string evalDescription = eval.Key;
                    IDiceEvaluator iDiceEval = eval.Value;
                    int points = iDiceEval.Evaluate(_cup.DiceCountByFaceValue);

                    diceEval.AddEvaluation(evalDescription, points);
                }

                // Add this evaluation to stats
                _evaluationStats.AddEvaluation(diceEval);
            }

            // Print total evaluations
            Console.WriteLine(_evaluationStats);
            // Console.WriteLine(_evaluationStats.FilterStats(new List<string>{ "Tower" }));
        }
    }
}