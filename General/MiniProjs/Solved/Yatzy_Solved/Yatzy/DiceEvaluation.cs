using System;
using System.Collections.Generic;

namespace Yatzy
{
    public class DiceEvaluation
    {
        private List<int> _diceFaceValues;
        private Dictionary<string, int> _evaluations;

        public DiceEvaluation(List<int> diceFaceValues)
        {
            _diceFaceValues = diceFaceValues;
            _evaluations = new Dictionary<string, int>();
        }

        public List<int> DiceFaceValues
        {
            get { return _diceFaceValues; }
        }

        public Dictionary<string, int> Evaluations
        {
            get { return _evaluations; }
        }

        public void AddEvaluation(string evalName, int score)
        {
            if (_evaluations.ContainsKey(evalName))
            {
                throw new ArgumentException("Already set this evaluation");
            }

            _evaluations.Add(evalName, score);
        }

        public override string ToString()
        {
            string self = "Face values : ";
            foreach (var val in _diceFaceValues)
            {
                self = self + " " + val;
            }
            self = self + "\n";

            foreach (var eval in _evaluations)
            {
                self = self + eval.Key + " : " + eval.Value + " points\n";
            }

            return self;
        }
    }
}