using System.Collections.Generic;
using Data.InMemory.Interfaces;
using Data.Persistent.Interfaces;

namespace Model.Implementation
{
    public class Catalog<T> : CatalogFull<T,T,T> where T : IStorable
    {
        public Catalog(
            IInMemoryCollection<T> collection, 
            IDataSourceCRUD<T> source, 
            List<PersistencyOperations> supportedOperations, 
            KeyManagementStrategyType keyManagementStrategy = KeyManagementStrategyType.CollectionDecides) 
            : base(collection, source, supportedOperations, keyManagementStrategy)
        {
        }

        public override T CreateDomainObjectFromViewDataObject(T obj)
        {
            return obj;
        }

        public override T CreateViewDataObject(T obj)
        {
            return obj;
        }

        public override T CreatePersistentDataObject(T obj)
        {
            return obj;
        }

        public override T CreateDomainObjectFromPersistentDataObject(T obj)
        {
            return obj;
        }
    }
}