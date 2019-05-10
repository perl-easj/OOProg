using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQAggr
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 17;
            int b = 25;
            int c = a + b;

            string firstName = "Per";
            string lastName = "Laursen";
            string fullname = firstName + lastName;

            Car carA = new Car("AB 123", 50000);
            Car carB = new Car("CD 345", 80000);

            // Car carC = carA + carB; // NB: Not valid code


            Time timeA = new Time(2, 25);
            Time timeB = new Time(1, 45);
            Time timeC = new Time(3, 10);
            Time timeD = new Time(6, 55);

            Time timeSum = timeA + timeB + timeC + timeD; // NB: Not valid code (yet...)

            Time timeMult3A = 3 * timeA; // OK
            Time timeMultA3 = timeA * 3; // Error

            timeA++; // OK
            ++timeA; // Also OK

            bool aVSb = timeA <= timeB;

            Time tX = new Time(3, 45);
            Time tY = new Time(3, 45);
            Console.WriteLine($"tX == tY is {tX == tY}");
            Console.WriteLine($"tX Equals tY is {tX.Equals(tY)}");


            //Console.WriteLine(timeA);

            //Console.WriteLine(timeSum);

            NPC npcA = new NPC();
            npcA[NPC.NPCStateTypes.aggressive] = 12;

            npcA.Hungry = 3;
            npcA[NPC.NPCStateTypes.aggressive] = 12;
            npcA[NPC.NPCStateTypes.hungry] = 4;
            npcA[NPC.NPCStateTypes.rested] = 8;
            npcA[NPC.NPCStateTypes.fear] = 2;
            npcA[NPC.NPCStateTypes.gullible] = 5;

            Console.WriteLine(npcA[NPC.NPCStateTypes.aggressive]);

            List<NPC.NPCStateTypes> stateTypes = new List<NPC.NPCStateTypes>
            {
                NPC.NPCStateTypes.aggressive,
                NPC.NPCStateTypes.hungry,
                NPC.NPCStateTypes.rested,
                NPC.NPCStateTypes.fear,
                NPC.NPCStateTypes.gullible
            };

            List<NPC.NPCStateTypes> stateTypes2 =
                Enum.GetValues(typeof(NPC.NPCStateTypes))
                    .Cast<NPC.NPCStateTypes>()
                    .ToList();

            foreach (var state in stateTypes)
            {
                Console.WriteLine(npcA[state]);
            }

            foreach (var entry in npcA)
            {
                Console.WriteLine($"{entry.Item1} -> {entry.Item2}");
            }

            int sumOfValues = npcA.Sum(n => n.Item2);

            Car aCar = new Car("AB 12 345", 80000);
            var obj = new {aCar.LicensePlate, IsCheap = (aCar.Price < 100000) };
            Console.WriteLine($"obj = {obj.LicensePlate} {obj.IsCheap}");

            // MethodA(obj);
            MethodB(obj);

            Console.ReadKey();
        }

        private static void MethodA(object obj)
        {
            Console.WriteLine(((Car)obj).LicensePlate);
        }

        private static void MethodB(dynamic obj)
        {
            Console.WriteLine(obj.WooHooLetsParty);
        }


        public static string Test()
        {
            IEnumerable<int> numbers = new List<int> { 14, 2, 39, 64 };
            IEnumerable<int> over30 = numbers.Where(n => n > 30);

            List<string> numbersAsStr = numbers.Select(val => val.ToString()).ToList();

            //Object aRef = new object();
            //Type aType = aRef.GetType();

            Time aTime = new Time(12, 00);
            Type aType = typeof(Time);

            foreach (MethodInfo mi in aType.GetMethods())
            {
                Console.WriteLine(mi.Name);
            }

            //Assembly anAssembly = typeof(string).Assembly;
            //foreach (Type aType in anAssembly.GetTypes())
            //{
            //    Console.WriteLine(aType.FullName);
            //}



            string result = numbersAsStr.Aggregate((s1, s2) => s1 + " and then " + s2);
            return result;
        }
    }
}
    