namespace Data.InMemory.Interfaces
{
    /// <summary>
    /// If an object is intended to be stored in one of the 
    /// collection-oriented classes in the library, it must
    /// implement this interface. This enables the collection
    /// classes to manage unique identifiers for the objects.
    /// </summary>
    public interface IStorable
    {
        /// <summary>
        /// Get/set the Key value for a stored object.
        /// </summary>
        int Key { get; set; }
    }
}