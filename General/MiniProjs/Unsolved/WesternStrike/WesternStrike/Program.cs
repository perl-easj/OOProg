using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WesternStrike.Combat;

namespace WesternStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            CombatManager.Execute();

            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
