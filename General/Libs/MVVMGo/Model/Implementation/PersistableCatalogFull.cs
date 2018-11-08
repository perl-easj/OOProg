using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.InMemory.Interfaces;
using Data.Persistent.Interfaces;
using Model.Interfaces;

namespace Model.Implementation
{
    /// <summary>
    /// Implementation of a persistable Catalog, with 
    /// asynchronous Load and Save operations.
    /// Note that the implementation inherits from Catalog, 
    /// and thus also contains CRUD methods.
    /// </summary>
    public abstract class PersistableCatalogFull<TDomainData, TViewData, TPersistentData>
        : CatalogFull<TDomainData, TViewData, TPersistentData>, IPersistableCatalog
          where TViewData : IStorable
          where TDomainData : IStorable
    {
        private IPersistentSource<TPersistentData> _persistentSource;
        public event Action LoadBegins;
        public event Action LoadEnds;
        public event Action SaveBegins;
        public event Action SaveEnds;

        #region Constructor
        protected PersistableCatalogFull(
            IInMemoryCollection<TDomainData> collection,
            IPersistentSource<TPersistentData> source,
            List<PersistencyOperations> supportedOperations,
            KeyManagementStrategyType keyManagementStrategy = KeyManagementStrategyType.CollectionDecides)
            : base(collection, source, supportedOperations, keyManagementStrategy)
        {
            _persistentSource = source;
        }
        #endregion

        #region IPersistableCatalog implementation
        /// <inheritdoc />
        /// <summary>
        /// Relays call of Load to data source, if the data 
        /// source supports the Load operation
        /// </summary>
        public async Task LoadAsync(bool suppressException = true)
        {

            if (_supportedOperations.Contains(PersistencyOperations.Load))
            {
                LoadBegins?.Invoke();
                List<TPersistentData> objects = await _persistentSource.Load();
                _collection.ReplaceAll(CreateDomainObjects(objects), KeyManagementStrategyType.DataSourceDecides);
                LoadEnds?.Invoke();
            }
            else
            {
                if (!suppressException)
                {
                    throw new NotSupportedException();
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Relays call of Save to data source, if the data 
        /// source supports the Load operation
        /// </summary>
        public async Task SaveAsync(bool suppressException = true)
        {
            if (_supportedOperations.Contains(PersistencyOperations.Save))
            {
                SaveBegins?.Invoke();
                await _persistentSource.Save(CreatePersistentDataObjects(_collection.All));
                SaveEnds?.Invoke();
            }
            else
            {
                if (!suppressException)
                {
                    throw new NotSupportedException();
                }
            }
        }
        #endregion

        #region Private helper methods
        /// <summary>
        /// Transforms a list of domain objects into a 
        /// list of corresponding persistent data objects.
        /// </summary>
        private List<TPersistentData> CreatePersistentDataObjects(IEnumerable<TDomainData> objects)
        {
            List<TPersistentData> pdObjects = new List<TPersistentData>();
            foreach (TDomainData obj in objects)
            {
                pdObjects.Add(CreatePersistentDataObject(obj));
            }
            return pdObjects;
        }

        /// <summary>
        /// Transforms a list of persistent data objects into 
        /// a list of corresponding domain objects.
        /// </summary>
        private List<TDomainData> CreateDomainObjects(IEnumerable<TPersistentData> pdObjects)
        {
            List<TDomainData> objects = new List<TDomainData>();
            foreach (TPersistentData pdObj in pdObjects)
            {
                objects.Add(CreateDomainObjectFromPersistentDataObject(pdObj));
            }
            return objects;
        }
        #endregion
    }
}