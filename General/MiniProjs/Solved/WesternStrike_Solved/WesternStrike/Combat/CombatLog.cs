using System;
using System.Collections.Generic;

namespace WesternStrike.Combat
{
    public class CombatLog
    {
        private static List<string> _log = new List<string>();

        #region Public methods
        public static void Save(string message)
        {
            _log.Add(message);
        }

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

        public static void Reset()
        {
            _log.Clear();
        } 
        #endregion
    }
}