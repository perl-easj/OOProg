namespace Data.Persistent.Interfaces
{
    /// <summary>
    /// Just a convenient interface containing a complete
    /// set of methods for CRUD and Load/Save
    /// </summary>
    public interface IPersistentSource<TPersistentData>
        : IDataSourceCRUD<TPersistentData>,
            IDataSourceLoad<TPersistentData>,
            IDataSourceSave<TPersistentData>
    {
    }
}