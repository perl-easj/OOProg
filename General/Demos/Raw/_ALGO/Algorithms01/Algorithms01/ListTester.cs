using System.Collections.Generic;
// ReSharper disable UnusedVariable

namespace Algorithms01
{
    public class ListTester : DataStructureTesterBase<List<int>>
    {
        public ListTester(List<int> collection) : base(collection)
        {
        }

        public override void AddInitialStatement(int valueToInsert)
        {
            Collection.Add(valueToInsert);
        }

        public override void InsertBackStatement(int valueToInsert)
        {
            Collection.Add(valueToInsert);
        }

        public override void InsertFrontStatement(int valueToInsert)
        {
            Collection.Insert(0, valueToInsert);
        }

        public override void LookupRandomStatement()
        {
            int value = Collection[Generator.Next(Collection.Count)];
        }

        public override void DeleteRandomStatement()
        {
            Collection.RemoveAt(Generator.Next(Collection.Count));
        }

        public override void FindRandomStatement(int valueToFind)
        {
            bool found = Collection.Contains(valueToFind);
        }
    }
}