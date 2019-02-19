using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable UnusedVariable

namespace ASWCClassroomDay3
{
    class Program
    {
        static void Main(string[] args)
        {
            IndexerTest();

            EnumerableTest();

            OperatorOverloadTest();

            Console.WriteLine();
            Console.WriteLine("Done...");
            Console.ReadKey();
        }


        private static void IndexerTest()
        {
            Console.WriteLine("IndexerTest");
            Console.WriteLine();

            NPC anNPC = new NPC();
            anNPC[NPC.NPCStateTypes.aggressive] = 35;


            List<NPC.NPCStateTypes> stateTypes = Enum
                    .GetValues(typeof(NPC.NPCStateTypes))
                    .Cast<NPC.NPCStateTypes>()
                    .ToList();

            foreach (var st in stateTypes)
            {
                Console.WriteLine(anNPC[st]);
            }
            Console.WriteLine();
        }

        private static void EnumerableTest()
        {
            Console.WriteLine("EnumerableTest");
            Console.WriteLine();

            NPC anNPC = new NPC();
            foreach (var entry in anNPC)
            {
                Console.WriteLine($"{entry.Item1} -> {entry.Item2}");
            }
            Console.WriteLine();

            int limit = 1000;
            PrimesContainer pc = new PrimesContainer(limit);

            Console.WriteLine($"# of primes between 2 and {limit} :   {pc.Count()}");
            Console.WriteLine();

            //foreach (var v in pc)
            //{
            //    Console.WriteLine(v);
            //}
            //Console.WriteLine();
        }

        private static void OperatorOverloadTest()
        {
            Console.WriteLine("OperatorOverloadTest");
            Console.WriteLine();

            Time timeA = new Time(2, 25);
            Time timeB = new Time(1, 45);

            Time timeC = timeA + timeB;

            Time timeMult3A = 3 * timeA;
            Time timeMultA3 = timeA * 3;

            timeA++;

            bool aVSb = timeA <= timeB;

            Time tX = new Time(3, 45);
            Time tY = new Time(3, 45);

            Console.WriteLine($"tX == tY is {tX == tY}");
            Console.WriteLine($"tX Equals tY is {tX.Equals(tY)}");
        }
    }
}
