using System;
using System.Collections.Generic;

namespace RolePlayV21
{
    /// <summary>
    /// This class implements a simple logging system, where strings can be collected
    /// one by one. The entire set of strings can then be printed.
    /// </summary>
    public class BattleLog
    {
        List<string> _log;

        public BattleLog()
        {
            _log = new List<string>();
        }

        /// <summary>
        /// Save a single string
        /// </summary>
        public void Save(string message)
        {
            _log.Add(message);
        }

        /// <summary>
        /// Print out all the strings saved in the log
        /// </summary>
        public void PrintLog()
        {
            Console.WriteLine("Battle log :");
            Console.WriteLine("======================================");
            foreach (string s in _log)
            {
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Clear all strings from the log
        /// </summary>
        public void Reset()
        {
            _log.Clear();
        }
    }
}