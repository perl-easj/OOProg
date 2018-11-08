namespace Data.Transformed.Interfaces
{
    /// <summary>
    /// Interface for converting between domain data representation
    /// and persistent data representation.
    /// </summary>
    public interface IPersistentDataTransform<T, TPersistentData>
    {
        T CreateDomainObjectFromPersistentDataObject(TPersistentData pdObj);
        TPersistentData CreatePersistentDataObject(T obj);
    }
}