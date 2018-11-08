using Data.InMemory.Interfaces;
using Data.Persistent.Implementation;
using Microsoft.EntityFrameworkCore;

namespace DataSources.EFCore.Implementation
{
    /// <summary>
    /// Since an EFCore data source does not support the Save operation,
    /// that source is configured with a "Not Supported" strategy object.
    /// </summary>
    public class ConfiguredEFCoreSource<TDbContext, TData> : ConfiguredPersistentSource<TData>
        where TData : class, IStorable
        where TDbContext : DbContext, new()
    {
        public ConfiguredEFCoreSource()
        {
            EFCoreSource<TDbContext, TData> efCoreSource = new EFCoreSource<TDbContext, TData>();

            DataSourceLoad = efCoreSource;
            DataSourceSave = new DataSourceSaveNotSupported<TData>();
            DataSourceCRUD = efCoreSource;
        }
    }
}