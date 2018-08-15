using System.Collections.Generic;
// ReSharper disable UnusedVariable

namespace DataStructureCompare
{
    /// <summary>
    /// Specific test of HashSet collection class
    /// </summary>
    public class HashSetTester : DataStructureTesterBase<HashSet<int>>
    {
        /// <summary>
        /// Performs a lookup using the Contains method.
        /// Not really comparable to index-based lookups.
        /// </summary>
        public override void LookupRandomStatement()
        {
            // Not really "lookup" - same code as "find"
            bool found = Collection.Contains(Generator.Next());
        }

        /// <summary>
        /// Performs a deletion using the Remove method.
        /// </summary>
        public override void DeleteRandomStatement()
        {
            Collection.Remove(Generator.Next());
        }
    }
}