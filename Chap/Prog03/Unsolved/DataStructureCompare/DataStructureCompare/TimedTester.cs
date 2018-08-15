using System;
using System.Diagnostics;

namespace DataStructureCompare
{
    /// <summary>
    /// The methods in this class can perform timed execution of
    /// the method provided as parameter
    /// </summary>
    public class TimedTester
    {
        private static Stopwatch _watch = new Stopwatch();

        /// <summary>
        /// Measures the execution time for "iterations" invocations
        /// of the given method
        /// </summary>
        public static long MeasureRunTimeLoop(Action functionToTest, int iterations)
        {
            _watch.Restart();
            for (int i = 0; i < iterations; i++)
            {
                functionToTest();
            }
            _watch.Stop();

            return _watch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Measures the execution time for a single invocation
        /// of the given method
        /// </summary>
        public static long MeasureRunTime(Action functionToTest)
        {
            return MeasureRunTimeLoop(functionToTest, 1);
        }
    }
}