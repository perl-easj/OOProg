using System.Collections.Generic;

namespace Algorithms01
{
    public class HashSetTester : DataStructureTesterBase<HashSet<int>>
    {
        public HashSetTester(HashSet<int> collection) : base(collection)
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
            Collection.Add(valueToInsert);
        }

        public override void LookupRandomStatement()
        {
            bool found = Collection.Contains(Generator.Next());
        }

        public override void DeleteRandomStatement()
        {
            Collection.Remove(Generator.Next());
        }

        public override void FindRandomStatement(int valueToFind)
        {
            bool found = Collection.Contains(valueToFind);
        }
    }
}