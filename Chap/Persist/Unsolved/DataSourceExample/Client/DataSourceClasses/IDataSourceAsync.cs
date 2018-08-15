using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Interface (API) for a data source supporting CRUD
    /// (Create, Read, Update and Delete) operations, as
    /// well as the Load operation
    /// </summary>
    /// <typeparam name="T">
    /// Type of objects in data source
    /// </typeparam>
    public interface IDataSourceAsync<T>
    {
        Task<List<T>> Load();
        Task Create(T obj);
        Task<T> Read(int key);
        Task Update(int key, T obj);
        Task Delete(int key);
    }
}