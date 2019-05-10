using System;
using System.Collections.Generic;
using CompositePattern.Visitors;

// ReSharper disable UnusedParameter.Local

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Person pA = new Person("Allan", 25000);
            Person pB = new Person("Bente", 35000);
            Person pC = new Person("Carl", 80000);
            Person pD = new Person("Dorthe", 50000);
            Person pE = new Person("Erik", -25000);
            Person pF = new Person("Freja", 70000);
            Person pG = new Person("Gerda", -120000);
            Person pH = new Person("Hans", -45000);
            Person pI = new Person("Ida", 55000);
            Person pJ = new Person("Jens", 85000);

            pD.Add(pA);
            pD.Add(pB);
            pE.Add(pD);
            pE.Add(pC);
            pF.Add(pG);
            pF.Add(pH);
            pI.Add(pE);
            pI.Add(pF);
            pI.Add(pJ);

            List<Person> all = new List<Person> {pA, pB, pC, pD, pE, pF, pG, pH, pI, pJ};

            RunTest("TestFamilyTreeSize", TestFamilyTreeSize, all);
            RunTest("TestFamilyFunds", TestFamilyFunds, all);
            RunTest("TestFamilyTreeIteration", TestFamilyTreeIteration, all);

            FamilyTreeSizeVisitor ftsv = new FamilyTreeSizeVisitor();
            RunTest("FamilyTreeSizeVisitor", p => { TestFamilyTreeSizeVisitor(ftsv, p); }, all);

            FamilyFundsVisitor ffv = new FamilyFundsVisitor();
            RunTest("FamilyFundsVisitor", p => { TestFamilyFundsVisitor(ffv, p); }, all);


            Console.ReadKey();
        }

        private static void RunTest(string desc, Action<Person> methodUnderTest, List<Person> persons)
        {
            Console.WriteLine();
            Console.WriteLine($"Testing {desc}");
            persons.ForEach(methodUnderTest);
            Console.WriteLine();
        }

        public static void TestFamilyTreeSize(Person p)
        {
            Console.WriteLine($"Familiy tree size for {p.Name} is {p.FamilyTreeSize()}");
        }

        public static void TestFamilyFunds(Person p)
        {
            Console.WriteLine($"Familiy funds for {p.Name} is {p.FamilyFunds()}");
        }

        public static void TestFamilyTreeIteration(Person p)
        {
            Console.WriteLine($"{p.Name}'s familiy members");
            foreach (Person member in p)
            {
                Console.WriteLine($"{member.Name}");
            }
        }

        public static void TestFamilyTreeSizeVisitor(FamilyTreeSizeVisitor ftsv, Person p)
        {
            Console.WriteLine($"Familiy tree size (using Visitor) for {p.Name} is {ftsv.GetValue(p)}");
        }

        public static void TestFamilyFundsVisitor(FamilyFundsVisitor ffv, Person p)
        {
            Console.WriteLine($"Familiy funds (using Visitor) for {p.Name} is {ffv.GetValue(p)}");
        }
    }
}
