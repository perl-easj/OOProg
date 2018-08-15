namespace DataStructureCompare
{
    /// <summary>
    /// This interface should be implemented by any class
    /// participating in the comparative test. All implementations
    /// should return the running time measured in milliseconds.
    /// </summary>
    public interface IDataStructureTester
    {
        /// <summary>
        /// Insert values into an empty collection object
        /// </summary>
        long InsertInitial(int noOfToInserts, int maxValue);

        /// <summary>
        /// Insert values at the back of a collection object.
        /// (note that "back" may not be well-defined for
        /// all collection classes).
        /// </summary>
        long InsertBack(int noOfToInserts, int maxValue);

        /// <summary>
        /// Insert values at the front of a collection object.
        /// (note that "front" may not be well-defined for
        /// all collection classes).
        /// </summary>
        long InsertFront(int noOfToInserts, int maxValue);

        /// <summary>
        /// Perform randomised lookup of values
        /// </summary>
        long LookupRandom(int noOfLookups);

        /// <summary>
        /// Perform randomised deletion of values
        /// </summary>
        long DeleteRandom(int noOfDeletes);

        /// <summary>
        /// Find random values in collection object.
        /// </summary>
        long FindRandom(int noOfFinds, int maxValue);
    }
}