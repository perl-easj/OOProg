using System;
using System.Collections.Generic;

namespace RolePlayV23
{
    /// <summary>
    /// This class implements a simple logging system, where strings can be collected
    /// one by one. The entire set of strings can then be printed.
    /// </summary>
    public static class BattleLog
    {
        private static List<string> _log = new List<string>();

        /// <summary>
        /// Save a single string
        /// </summary>
        public static void Save(string message)
        {
            _log.Add(message);
        }

        /// <summary>
        /// Print out all the strings saved in the log
        /// </summary>
        public static void PrintLog()
        {
            Console.WriteLine("Battle log :");
            Console.WriteLine("======================================");
            foreach (string s in _log)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Clear all strings from the log
        /// </summary>
        public static void Reset()
        {
            _log.Clear();
        }
    }
}
