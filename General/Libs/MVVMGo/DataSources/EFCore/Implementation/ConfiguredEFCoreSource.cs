using Data.InMemory.Interfaces;
using Data.Persistent.Implementation;
using Microsoft.EntityFrameworkCore;

namespace DataSources.EFCore.Implementation
{
    /// <summary>
    /// Since an EFCore data source does not support the Save operation,
    /// that source is configured with a "Not Supported" strategy object.
    /// </summary>
    public class ConfiguredEFCoreSource<TDbContext, TPersistentData> : ConfiguredPersistentSource<TPersistentData>
        where TPersistentData : class, IStorable
        where TDbContext : DbContext, new()
    {
        public ConfiguredEFCoreSource()
        {
            EFCoreSource<TDbContext, TPersistentData> efCoreSource = new EFCoreSource<TDbContext, TPersistentData>();

            DataSourceLoad = efCoreSource;
            DataSourceSave = new DataSourceSaveNotSupported<TPersistentData>();
            DataSourceCRUD = efCoreSource;
        }
    }
}