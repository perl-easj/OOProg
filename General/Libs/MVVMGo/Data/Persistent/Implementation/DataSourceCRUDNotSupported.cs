using System.Threading.Tasks;
using Data.Persistent.Interfaces;

namespace Data.Persistent.Implementation
{
    /// <summary>
    /// This class represents a collective "Not Supported" 
    /// strategy object for all CRUD operations.
    /// </summary>
    public class DataSourceCRUDNotSupported<TPersistentData> : IDataSourceCRUD<TPersistentData>
    {
        public Task<int> Create(TPersistentData obj)
        {
            throw new DataSourceOperationNotSupportedException("Create");
        }

        public Task<TPersistentData> Read(int key)
        {
            throw new DataSourceOperationNotSupportedException("Read");
        }

        public Task Update(int key, TPersistentData obj)
        {
            throw new DataSourceOperationNotSupportedException("Update");
        }

        public Task Delete(int key)
        {
            throw new DataSourceOperationNotSupportedException("Delete");
        }
    }
}