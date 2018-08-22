using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Persistent.Interfaces;

namespace Data.Persistent.Implementation
{
    /// <summary>
    /// This class represents a "Not Supported" 
    /// strategy object for the Save operation.
    /// </summary>
    public class DataSourceSaveNotSupported<TPersistentData> : IDataSourceSave<TPersistentData>
    {
        public Task Save(List<TPersistentData> objects)
        {
            throw new DataSourceOperationNotSupportedException("Save");
        }
    }
}