using System;
using System.Collections.Generic;

namespace SchoolAdministrationV15
{
    /// <summary>
    /// This class represents a student, 
    /// with an id, name and a set of test scores
    /// </summary>
    public class Student
    {
        #region Instance fields
        private int _id;
        private string _name;
        private Dictionary<string, int> _testScores;
        #endregion

        #region Constructor
        public Student(int id, String name)
        {
            _id = id;
            _name = name;
            _testScores = new Dictionary<string, int>();
        }
        #endregion

        #region Properties
        public int ID
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Returns the average of the test scores for the student.
        /// If no scores are present, an average of -1 is returned.
        /// </summary>
        public double ScoreAverage
        {
            get
            {
                if (_testScores.Count == 0)
                {
                    return -1;
                }
                else
                {
                    double sum = 0;

                    foreach (var kvp in _testScores)
                    {
                        sum = sum + kvp.Value;
                    }

                    return (sum / _testScores.Count);
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Insert a single test result
        /// </summary>
        public void AddTestResult(String courseName, int score)
        {
            _testScores.Add(courseName, score);
        }

        public override string ToString()
        {
            return $"{Name} (id: {ID})";
        }
        #endregion
    }
}