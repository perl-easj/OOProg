using System.Collections.Generic;

namespace SWCClasses.DataStructures
{
    public interface IGenericCatalog<in TKey, TValue>
    {
        int Count { get; }
        List<TValue> All { get; }
        void Insert(TKey key, TValue val);
        TValue Read(TKey key);
        void Update(TKey key, TValue val);
        void Delete(TKey key);
    }
}