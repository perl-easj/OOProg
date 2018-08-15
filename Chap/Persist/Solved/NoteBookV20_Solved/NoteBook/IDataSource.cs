using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteBook
{
    public interface IDataSource<T>
    {
        Task SaveAsync(List<T> objects);
        Task<List<T>> LoadAsync();
    }
}