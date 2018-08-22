using System.Collections.Generic;
using Data.InMemory.Interfaces;
using Data.Persistent.Interfaces;

namespace Model.Implementation
{
    public class PersistableCatalog<T> : PersistableCatalogFull<T,T,T> where T : IStorable
    {
        public PersistableCatalog(
            IInMemoryCollection<T> collection, 
            IPersistentSource<T> source, 
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