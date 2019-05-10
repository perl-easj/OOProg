using System.Collections.Generic;

namespace RPGDemo19NOV.Model.Base
{
    public interface ICatalog<T>
    {
        List<T> All { get; }
        void Create(T obj);
        void Delete(int id);
        T Read(int id);
    }
}