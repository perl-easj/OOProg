using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Persistent.Interfaces;

namespace Data.Persistent.Implementation
{
    /// <summary>
    /// This class represents a "Not Supported" 
    /// strategy object for the Load operation.
    /// </summary>
    public class DataSourceLoadNotSupported<TPersistentData> : IDataSourceLoad<TPersistentData>
    {
        public Task<List<TPersistentData>> Load()
        {
            throw new DataSourceOperationNotSupportedException("Load");
        }
    }
}