using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Persistent.Interfaces
{
    public interface IDataSourceLoad<TPersistentData>
    {
        /// <summary>
        /// Load a List of objects from the source.
        /// </summary>
        /// <returns>
        /// List of loaded objects, wrapped in an awaitable Task object.
        /// </returns>
        Task<List<TPersistentData>> Load();
    }
}