using System.Collections.Generic;
// ReSharper disable UnusedVariable

namespace DataStructureCompare
{
    /// <summary>
    /// Specific test of List collection class
    /// </summary>
    public class ListTester : DataStructureTesterBase<List<int>>
    {

        /// <summary>
        /// Adds an element using the Insert(0,...) method, 
        /// i.e. adds to front of list
        /// </summary>
        public override void InsertFrontStatement(int valueToInsert)
        {
            Collection.Insert(0, valueToInsert);
        }

        /// <summary>
        /// Performs a lookup using the index operator []
        /// </summary>
        public override void LookupRandomStatement()
        {
            int value = Collection[Generator.Next(Collection.Count)];
        }

        /// <summary>
        /// Performs a deletion using the RemoveAt method.
        /// </summary>
        public override void DeleteRandomStatement()
        {
            Collection.RemoveAt(Generator.Next(Collection.Count));
        }
    }
}