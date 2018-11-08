using Data.InMemory.Interfaces;
using Data.Persistent.Implementation;

namespace DataSources.RestAPI
{
    /// <summary>
    /// Since a RestAPI data source does not support the Save operation,
    /// that source is configured with a "Not Supported" strategy object.
    /// </summary>
    public class ConfiguredRestAPISource<TData> : ConfiguredPersistentSource<TData> 
        where TData : IStorable
    {
        public ConfiguredRestAPISource(string serverURL, string apiID, string apiPrefix = "api")
        {
            RestAPISource<TData> webAPISource = new RestAPISource<TData>(serverURL, apiID, apiPrefix);

            DataSourceLoad = webAPISource;
            DataSourceSave = new DataSourceSaveNotSupported<TData>();
            DataSourceCRUD = webAPISource;
        }
    }
}