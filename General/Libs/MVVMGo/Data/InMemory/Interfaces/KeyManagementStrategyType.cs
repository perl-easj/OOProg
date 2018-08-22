namespace Data.InMemory.Interfaces
{
    /// <summary>
    /// Identifies strategies for selecting a new key
    /// for a newly created domain object
    /// </summary>
    public enum KeyManagementStrategyType
    {
        CollectionDecides,
        CallerDecides,
        DataSourceDecides
    }
}