using Data.InMemory.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Extensions.Model.Implementation
{
    public class EFCoreCatalog<TDbContext, T> : EFCoreCatalogFull<TDbContext,T,T,T> 
        where TDbContext : DbContext, new() 
        where T : class, IStorable
    {
        public EFCoreCatalog(KeyManagementStrategyType kms) : base(kms)
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