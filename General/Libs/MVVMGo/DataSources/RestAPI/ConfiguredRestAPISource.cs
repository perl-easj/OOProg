using Data.InMemory.Interfaces;
using Data.Persistent.Implementation;

namespace DataSources.RestAPI
{
    /// <summary>
    /// Since a RestAPI data source does not support the Save operation,
    /// that source is configured with a "Not Supported" strategy object.
    /// </summary>
    public class ConfiguredRestAPISource<TPersistentData> : ConfiguredPersistentSource<TPersistentData> 
        where TPersistentData : IStorable
    {
        public ConfiguredRestAPISource(string serverURL, string apiID, string apiPrefix = "api")
        {
            RestAPISource<TPersistentData> webAPISource = new RestAPISource<TPersistentData>(serverURL, apiID, apiPrefix);

            DataSourceLoad = webAPISource;
            DataSourceSave = new DataSourceSaveNotSupported<TPersistentData>();
            DataSourceCRUD = webAPISource;
        }
    }
}