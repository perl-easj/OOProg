using System;
using System.Collections.Generic;

namespace Algorithms01
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListTester lt = new ListTester(new List<int>());
            //LinkedListTester llt = new LinkedListTester(new LinkedList<int>());
            //HashSetTester hst = new HashSetTester(new HashSet<int>());

            //int noOfInserts = 100000;
            //int noOfLookups = noOfInserts / 10;
            //int noOfDeletes = noOfInserts / 10;
            //int noOfFinds = noOfInserts / 10;
            //int maxValue = Int32.MaxValue;

            //Console.WriteLine("List:");
            //Console.WriteLine("Inserting into empty with Add:                     " + lt.AddInitial(noOfInserts, maxValue) + " ms.");
            //Console.WriteLine("Inserting front into non-empty with Add:           " + lt.InsertBack(noOfInserts, maxValue) + " ms.");
            //Console.WriteLine("Inserting back into non-empty with Insert(0,...):  " + lt.InsertFront(noOfInserts, maxValue) + " ms.");
            //Console.WriteLine("Random index lookup in non-empty with []:          " + lt.LookupRandom(noOfLookups) + " ms.");
            //Console.WriteLine("Random index delete in non-empty with RemoveAt:    " + lt.DeleteRandom(noOfDeletes) + " ms.");
            //Console.WriteLine("Random value lookup in non-empty with Contains:    " + lt.FindRandom(noOfFinds, maxValue) + " ms.");
            //Console.WriteLine();

            //Console.WriteLine("LinkedList:");
            //Console.WriteLine("Inserting into empty with AddLast:                 " + llt.AddInitial(noOfInserts, maxValue) + " ms.");
            //Console.WriteLine("Inserting front into non-empty with AddLast:       " + llt.InsertBack(noOfInserts, maxValue) + " ms.");
            //Console.WriteLine("Inserting back into non-empty with AddFirst:       " + llt.InsertFront(noOfInserts, maxValue) + " ms.");
            //Console.WriteLine("Random index lookup in non-empty with ElementAt:   " + llt.LookupRandom(noOfLookups) + " ms.");
            //Console.WriteLine("Random index delete in non-empty with Remove:      " + llt.DeleteRandom(noOfDeletes) + " ms.");
            //Console.WriteLine("Random value lookup in non-empty with Contains:    " + llt.FindRandom(noOfFinds, maxValue) + " ms.");
            //Console.WriteLine();

            //Console.WriteLine("HashSet:");
            //Console.WriteLine("Inserting into empty with Add:                     " + hst.AddInitial(noOfInserts, maxValue) + " ms.");
            //Console.WriteLine("Inserting front into non-empty with Add:           " + hst.InsertBack(noOfInserts, maxValue) + " ms.");
            //Console.WriteLine("Inserting back into non-empty with Add:            " + hst.InsertFront(noOfInserts, maxValue) + " ms.");
            //Console.WriteLine("Random value lookup in non-empty with Contains:    " + hst.LookupRandom(noOfLookups) + " ms.");
            //Console.WriteLine("Random value delete in non-empty with Remove:      " + hst.DeleteRandom(noOfDeletes) + " ms.");
            //Console.WriteLine("Random value lookup in non-empty with Contains:    " + hst.FindRandom(noOfFinds, maxValue) + " ms.");
            //Console.WriteLine();

            //List<BackPackItem> items = new List<BackPackItem>();
            //items.Add(new BackPackItem("Rope", 1.5, 15));
            //items.Add(new BackPackItem("Water", 2, 30));
            //items.Add(new BackPackItem("Extra Water", 2, 20));
            //items.Add(new BackPackItem("Toilet Paper", 0.5, 8));
            //items.Add(new BackPackItem("Coffee", 0.5, 6));
            //items.Add(new BackPackItem("Mosquito Net", 1, 15));
            //items.Add(new BackPackItem("Pocket Knife", 0.3, 10));
            //items.Add(new BackPackItem("Laptop", 2, 20));
            //items.Add(new BackPackItem("Fishing Rod", 2.5, 30));
            //items.Add(new BackPackItem("Mini Stove", 1.5, 20));
            //items.Add(new BackPackItem("Tent", 5, 80));
            //items.Add(new BackPackItem("Chocolate", 0.4, 5));
            //items.Add(new BackPackItem("First Aid Kit", 1.2, 25));
            //items.Add(new BackPackItem("Sleeping Bag", 2, 25));
            //items.Add(new BackPackItem("Food", 1.5, 20));
            //items.Add(new BackPackItem("Extra Food", 1.5, 12));
            //items.Add(new BackPackItem("SunScreen", 1, 20));

            //BackPackAlgorithm bpa = new MyBackPackAlgorithm(items, 15.0);
            //bpa.Run();

            TowersOfHanoi("A", "B", "C", 3);

            KeepConsoleWindowOpen();
        }

        public static void TowersOfHanoi(string source, string extra, string target, int n)
        {
            if (n > 0)
            {
                TowersOfHanoi(source, target, extra, n - 1);
                Console.WriteLine($"Move disk {n}: {source}->{target}");
                TowersOfHanoi(extra, source, target, n - 1);
            }
        }


        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
