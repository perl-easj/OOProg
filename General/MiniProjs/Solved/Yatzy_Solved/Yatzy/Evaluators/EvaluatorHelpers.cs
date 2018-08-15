using System;
using System.Collections.Generic;

namespace Yatzy.Evaluators
{
    /// <summary>
    /// This class contains a number of evaluation helper methods.
    /// The helper methods are sought to be as general as possible.
    /// </summary>
    public class EvaluatorHelpers
    {
        #region Public helper methods
        /// <summary>
        /// Finds the highest score for an "OAK Group".
        /// OAK means "of a kind" (e.g. "3 of a Kind").
        /// An OAK Group is a set of OAK: the group { 3,2 } means "Three of a Kind + Two of a Kind" (i.e. Full House)
        /// The groups may NOT contain the same face values. Examples:
        /// 4-4-4-6-6-3 is a valid { 3, 2 } OAK group, with score 24
        /// 5-5-5-5-5-2 is NOT a valid { 3, 2 } OAK group
        /// </summary>
        /// <param name="diceCountByFaceValue">Dice to evaluate against OAK group</param>
        /// <param name="oakGroups">OAK specification (e.g. {2} for One Pair, {4, 2} for Tower, etc.</param>
        /// <returns>Score for highest scoring OAK group matching the given OAK specification</returns>
        public static int HighestScoreForOAKGroups(Dictionary<int, int> diceCountByFaceValue, List<int> oakGroups)
        {
            // Make a copy of dice set
            Dictionary<int, int> remainingDice = RemoveDice(diceCountByFaceValue, new Dictionary<int, int>());

            // Excludes
            List<int> excludes = new List<int>();

            // Score
            int score = 0;

            foreach (var oakGroup in oakGroups)
            {
                // Does dice set contain this OAK group?
                int highestFaceValue = HighestFaceValueForNoaKWithExclude(remainingDice, oakGroup, excludes);

                if (highestFaceValue > 0) // Yes, so proceed
                {
                    // Update score
                    score = score + oakGroup * highestFaceValue;

                    // Add the face value to excludes
                    excludes.Add(highestFaceValue);

                    // Remove dice from dice set
                    Dictionary<int, int> diceToRemove = new Dictionary<int, int>();
                    diceToRemove.Add(highestFaceValue, oakGroup);
                    remainingDice = RemoveDice(remainingDice, diceToRemove);
                }
                else // No, so we are done -> return zero score.
                {
                    return 0;
                }
            }

            return score;
        }

        /// <summary>
        /// Finds the score for a "Straight"(a sequence of face values containing all values from M to N)
        /// </summary>
        /// <param name="diceCountByFaceValue">Dice counts by face value</param>
        /// <param name="n">First face value in sequence</param>
        /// <param name="m">Last face value in sequence</param>
        /// <returns>Score for the sequence (zero means "no such sequence exist")</returns>
        public static int SequenceScore(Dictionary<int, int> diceCountByFaceValue, int m, int n)
        {
            if (m > n || m < 1 || n > diceCountByFaceValue.Count)
            {
                throw new ArgumentException("SequenceScore parameters");
            }

            int score = 0;
            bool sequenceOK = true;

            for (int i = m; i <= n; i++)
            {
                sequenceOK = sequenceOK && diceCountByFaceValue[i] > 0;
                score = score + i;
            }

            return sequenceOK ? score : 0;
        }

        /// <summary>
        /// Finds the score for dice showing a specific face value
        /// </summary>
        /// <param name="diceCountByFaceValue">Dice counts by face value</param>
        /// <param name="faceValue">Face value to find score for</param>
        /// <returns></returns>
        public static int ScoreForFaceValue(Dictionary<int, int> diceCountByFaceValue, int faceValue)
        {
            if (faceValue > diceCountByFaceValue.Count || faceValue < 1)
            {
                throw new ArgumentException("ScoreForFaceValue parameters");
            }

            return diceCountByFaceValue[faceValue] * faceValue;
        }
        #endregion

        #region Private helper methods
        /// <summary>
        /// Removes the specified dice from the given dice set
        /// </summary>
        /// <param name="diceCountByFaceValue">Dice counts by face value</param>
        /// <param name="removeDiceCountByFaceValue">Dice to remove (specified by counts by face value)</param>
        /// <returns>Remaining dice (constructed from a copy of original dice set)</returns>
        private static Dictionary<int, int> RemoveDice(Dictionary<int, int> diceCountByFaceValue, Dictionary<int, int> removeDiceCountByFaceValue)
        {
            Dictionary<int, int> remainingDice = CopyDice(diceCountByFaceValue);

            // Remove specified items
            foreach (var item in removeDiceCountByFaceValue)
            {
                // Requesting to remove more than already exist...
                if (diceCountByFaceValue[item.Key] < item.Value)
                {
                    throw new ArgumentException("Trying to remove non-existing dice...");
                }
                else
                {
                    remainingDice[item.Key] = diceCountByFaceValue[item.Key] - item.Value;
                }
            }

            return remainingDice;
        }

        /// <summary>
        /// Copies the dice set, to avoid altering the original dice set
        /// </summary>
        /// <param name="diceCountByFaceValue">Dice to copy</param>
        /// <returns>Copy of dice</returns>
        private static Dictionary<int, int> CopyDice(Dictionary<int, int> diceCountByFaceValue)
        {
            Dictionary<int, int> copy = new Dictionary<int, int>();

            foreach (var item in diceCountByFaceValue)
            {
                copy.Add(item.Key, item.Value);
            }

            return copy;
        }

        /// <summary>
        /// Finds the highest face value for a "N of a Kind" (NoaK)
        /// </summary>
        /// <param name="diceCountByFaceValue">Dice counts by face value</param>
        /// <param name="n">Number of identical face values to search for</param>
        /// <returns>Face value for the best NoaK (zero means "no such combination exist")</returns>
        private static int HighestFaceValueForNoaK(Dictionary<int, int> diceCountByFaceValue, int n)
        {
            int highestNoaKFaceValue = 0;

            foreach (var dieCount in diceCountByFaceValue)
            {
                if ((dieCount.Value >= n) && (dieCount.Key > highestNoaKFaceValue))
                {
                    highestNoaKFaceValue = dieCount.Key;
                }
            }

            return highestNoaKFaceValue;
        }

        /// <summary>
        /// Finds the highest face value for a "N of a Kind" (NoaK), excluding specified face values
        /// </summary>
        /// <param name="diceCountByFaceValue">Dice counts by face value</param>
        /// <param name="n">Number of identical face values to search for</param>
        /// <param name="excludes">Face values to exclude</param>
        /// <returns>Face value for the best NoaK (zero means "no such combination exist")</returns>
        private static int HighestFaceValueForNoaKWithExclude(Dictionary<int, int> diceCountByFaceValue, int n, List<int> excludes)
        {
            Dictionary<int, int> remainingDice = CopyDice(diceCountByFaceValue);

            int highestNoaKFaceValue = HighestFaceValueForNoaK(remainingDice, n);
            bool found = false;

            while (highestNoaKFaceValue > 0 && !found)
            {
                // Part of exclude list, so remove and try again...
                if (excludes.Contains(highestNoaKFaceValue))
                {
                    Dictionary<int, int> diceToRemove = new Dictionary<int, int>();
                    diceToRemove.Add(highestNoaKFaceValue, n);
                    remainingDice = RemoveDice(remainingDice, diceToRemove);
                    highestNoaKFaceValue = HighestFaceValueForNoaK(remainingDice, n);
                }
                // Not part of exclude list, so we are done.
                else
                {
                    found = true;
                }
            }

            return found ? highestNoaKFaceValue : 0;
        } 
        #endregion
    }
}