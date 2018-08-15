using System.Collections.Generic;

namespace Yatzy
{
    public class DiceEvaluationStatistics
    {
        private List<DiceEvaluation> _evaluations;

        public DiceEvaluationStatistics()
        {
            _evaluations = new List<DiceEvaluation>();
        }

        public void AddEvaluation(DiceEvaluation diceEval)
        {
            _evaluations.Add(diceEval);
        }

        public DiceEvaluationStatistics FilterStats(List<string> positiveEvals)
        {
            DiceEvaluationStatistics filteredStats = new DiceEvaluationStatistics();

            foreach (var eval in _evaluations)
            {
                bool evalAdded = false;
                foreach (var evalName in positiveEvals)
                {
                    if (!evalAdded && eval.Evaluations.ContainsKey(evalName) && eval.Evaluations[evalName] > 0)
                    {
                        filteredStats.AddEvaluation(eval);
                        evalAdded = true;
                    }
                }
            }

            return filteredStats;
        }

        public override string ToString()
        {
            string self = "Evaluations : ";

            foreach (var eval in _evaluations)
            {
                self = self + eval + "\n";
            }

            return self;
        }
    }
}