using Data.InMemory.Interfaces;
using Extensions.Model.Implementation;
using CarRetailDemo.Data.Persistent;

namespace CarRetailDemo.Models.Base
{
    // File-based persistency
    //
    //public class CatalogAppBase<T> : FileCatalog<T>
    //    where T : class, IStorable, ICopyable, new()
    //{
    //    public CatalogAppBase() : base()
    //    {
    //    }
    //}

    // EFCore2.0-based persistency
    //
    public class CatalogAppBase<T> : EFCoreCatalog<CarRetailDBAzureContext, T>
        where T : class, IStorable, ICopyable, new()
    {
        public CatalogAppBase() : base(KeyManagementStrategyType.CollectionDecides)
        {
        }
    }
}