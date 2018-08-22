using Data.Persistent.Implementation;
using DataSources.FileJSON.Interfaces;

namespace DataSources.FileJSON.Implementation
{
    /// <summary>
    /// Since a File-based data source does not support CRUD operations,
    /// that source is configured with a "Not Supported" strategy object.
    /// </summary>
    public class ConfiguredFileSource<TPersistentData> : ConfiguredPersistentSource<TPersistentData>
    {
        public ConfiguredFileSource(IStringPersistence stringPersistence, IStringConverter<TPersistentData> stringConverter)
        {
            FileSource<TPersistentData> fileSource = new FileSource<TPersistentData>(stringPersistence, stringConverter);

            DataSourceLoad = fileSource;
            DataSourceSave = fileSource;
            DataSourceCRUD = new DataSourceCRUDNotSupported<TPersistentData>();
        }
    }
}