using System;
using System.Diagnostics;

namespace Algorithms01
{
    public class TimedTester
    {
        private static Stopwatch _watch = new Stopwatch();

        public static long MeasureRunTime(Action functionToTest)
        {
            _watch.Restart();
            functionToTest();
            _watch.Stop();

            return _watch.ElapsedMilliseconds;
        }

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
    }
}