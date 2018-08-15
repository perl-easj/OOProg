using System;

namespace DataStructureCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            int noOfInserts = 50000;

            PerformTest("List", new ListTester(), noOfInserts);
            PerformTest("Linked List", new LinkedListTester(), noOfInserts);
            PerformTest("Hash Set", new HashSetTester(), noOfInserts);

            KeepConsoleWindowOpen();
        }

        private static void PerformTest(string description, IDataStructureTester tester, int noOfInserts)
        {
            int noOfLookups = noOfInserts / 10;
            int noOfDeletes = noOfInserts / 10;
            int noOfFinds = noOfInserts / 10;
            int maxValue = Int32.MaxValue;

            Console.WriteLine(description + " test:");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Inserting into empty:             " + tester.InsertInitial(noOfInserts, maxValue) + " ms.");
            Console.WriteLine("Inserting back into non-empty:    " + tester.InsertBack(noOfInserts, maxValue) + " ms.");
            Console.WriteLine("Inserting front into non-empty:   " + tester.InsertFront(noOfInserts, maxValue) + " ms.");
            Console.WriteLine("Random index lookup in non-empty: " + tester.LookupRandom(noOfLookups) + " ms.");
            Console.WriteLine("Random index delete in non-empty: " + tester.DeleteRandom(noOfDeletes) + " ms.");
            Console.WriteLine("Random value lookup in non-empty: " + tester.FindRandom(noOfFinds, maxValue) + " ms.");
            Console.WriteLine();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
