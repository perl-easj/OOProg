namespace Data.InMemory.Interfaces
{
    /// <summary>
    /// Interface for objects which are copyable.
    /// This can be domain objects or transformed objects.
    /// </summary>
    public interface ICopyable
    {
        /// <summary>
        /// Create an identical copy of the object. 
        /// It is up to the implementing class to 
        /// decide if the copy is deep or shallow.
        /// </summary>
        /// <returns>
        /// Copy of object.
        /// </returns>
        ICopyable Copy();
    }
}