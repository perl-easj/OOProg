namespace Data.InMemory.Interfaces
{
    /// <summary>
    /// Interface for objects which "wrap" a data-carrying object.
    /// This will typically be a transformed domain object.
    /// </summary>
    public interface IDataWrapper<out TData>
    {
        /// <summary>
        /// Returns the wrapped data object.
        /// </summary>
        TData DataObject { get; }
    }
}