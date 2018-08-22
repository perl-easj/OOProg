using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Persistent.Interfaces
{
    public interface IDataSourceSave<TPersistentData>
    {
        /// <summary>
        /// Save the given List of objects to the source
        /// </summary>
        /// <param name="objects">
        /// List of objects to save
        /// </param>
        Task Save(List<TPersistentData> objects);
    }
}