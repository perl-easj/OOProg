using Data.InMemory.Interfaces;

namespace Extensions.Model.Implementation
{
    public class RestApiCatalog<T> : RestApiCatalogFull<T,T,T> where T : class, IStorable
    {
        public RestApiCatalog(string url, string apiID, KeyManagementStrategyType kms) : base(url, apiID, kms)
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