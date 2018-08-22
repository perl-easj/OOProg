using System.Collections.Generic;
using Data.InMemory.Implementation;
using Data.InMemory.Interfaces;
using Data.Persistent.Interfaces;
using DataSources.RestAPI;
using Model.Implementation;

namespace Extensions.Model.Implementation
{
    /// <summary>
    /// This class injects specific dependencies into 
    /// the PersistableCatalog class:
    /// 1) Data is read from a RESTful web service, 
    ///    supporting Load + CRUD operations
    /// 2) The InMemoryCollection implementation is used.
    /// </summary>
    public abstract class RestApiCatalogFull<TDomainData, TViewData, TPersistentData> : PersistableCatalogFull<TDomainData, TViewData, TPersistentData>
        where TDomainData : class, IStorable
        where TPersistentData : IStorable
        where TViewData : IStorable
    {
        protected RestApiCatalogFull(string url, string apiID, KeyManagementStrategyType kms)
            : base(new InMemoryCollection<TDomainData>(), new ConfiguredRestAPISource<TPersistentData>(url, apiID),
                new List<PersistencyOperations>
                {
                    PersistencyOperations.Load,
                    PersistencyOperations.Create,
                    PersistencyOperations.Read,
                    PersistencyOperations.Update,
                    PersistencyOperations.Delete
                },
                kms)
        {
        }
    }   
}