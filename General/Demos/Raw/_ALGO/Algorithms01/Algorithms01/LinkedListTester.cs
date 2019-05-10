using System.Collections.Generic;
using System.Linq;
// ReSharper disable UnusedVariable

namespace Algorithms01
{
    public class LinkedListTester : DataStructureTesterBase<LinkedList<int>>
    {
        public LinkedListTester(LinkedList<int> collection) : base(collection)
        {
        }

        public override void AddInitialStatement(int valueToInsert)
        {
            Collection.AddLast(valueToInsert);
        }

        public override void InsertBackStatement(int valueToInsert)
        {
            Collection.AddLast(valueToInsert);
        }

        public override void InsertFrontStatement(int valueToInsert)
        {
            Collection.AddFirst(valueToInsert);
        }

        public override void LookupRandomStatement()
        {
            int value = Collection.ElementAt(Generator.Next(Collection.Count));
        }

        public override void DeleteRandomStatement()
        {
            Collection.Remove(Collection.ElementAt(Generator.Next(Collection.Count)));
        }

        public override void FindRandomStatement(int valueToFind)
        {
            bool found = Collection.Contains(valueToFind);
        }
    }
}