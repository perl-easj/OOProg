using System;
using System.Collections.Generic;
using Data.InMemory.Interfaces;
using Data.Persistent.Interfaces;
using Data.Transformed.Interfaces;
using Model.Interfaces;

namespace Model.Implementation
{
    /// <summary>
    /// Main implementation of the ICatalog interface,
    /// which contains CRUD operations. This version of
    /// a catalog supports data transformations.
    /// </summary>
    /// <typeparam name="T">Domain class</typeparam>
    /// <typeparam name="TViewData">View data type</typeparam>
    /// <typeparam name="TPersistentData">Persistent data type</typeparam>
    public abstract class CatalogFull<T, TViewData, TPersistentData> :
        ICatalog<TViewData>,
        IViewDataTransform<T, TViewData>,
        IPersistentDataTransform<T, TPersistentData>
        where T : IStorable
        where TViewData : IStorable
    {
        protected IInMemoryCollection<T> _collection;
        protected IDataSourceCRUD<TPersistentData> _source;
        protected List<PersistencyOperations> _supportedOperations;
        protected KeyManagementStrategyType _keyManagementStrategy;

        public event Action<int> CatalogChanged;

        protected CatalogFull(
            IInMemoryCollection<T> collection,
            IDataSourceCRUD<TPersistentData> source,
            List<PersistencyOperations> supportedOperations,
            KeyManagementStrategyType keyManagementStrategy = KeyManagementStrategyType.CollectionDecides)
        {
            _collection = collection;
            _source = source;
            _supportedOperations = supportedOperations;
            _keyManagementStrategy = keyManagementStrategy;
        }

        /// <inheritdoc />
        public List<TViewData> All
        {
            get
            {
                List<TViewData> vdAll = new List<TViewData>();
                foreach (T obj in _collection.All)
                {
                    vdAll.Add(CreateViewDataObject(obj));
                }
                return vdAll;
            }
        }

        /// <inheritdoc />
        public void Create(TViewData vdObj)
        {
            // Create the new domain object (this is where it happens :-)).
            T obj = CreateDomainObjectFromViewDataObject(vdObj);

            // Strategy for key selection (DataSource decides)
            // 1) Throw exception if Create operation is not supported,
            //    since choosing DataSourceDecides is then meaningless.
            // 2) Call Create on data source, and use returned key value 
            //    as the new key for the object.
            // 3) Call Insert on the in-memory collection.
            if (_keyManagementStrategy == KeyManagementStrategyType.DataSourceDecides)
            {
                if (!_supportedOperations.Contains(PersistencyOperations.Create))
                {
                    throw new NotSupportedException("The referenced data source does not support Create.");
                }

                obj.Key = _source.Create(CreatePersistentDataObject(obj)).Result;
                _collection.Insert(obj, _keyManagementStrategy);
            }

            // Strategy for key selection (Caller decides)
            // 1) If the data source supports the Create operation,
            //    call Create on data source. It is assumed that it
            //    is NOT an error to call this method, even if the
            //    data source does not support it.
            // 2) Call Insert on the in-memory collection.
            if (_keyManagementStrategy == KeyManagementStrategyType.CallerDecides)
            {
                if (_supportedOperations.Contains(PersistencyOperations.Create))
                {
                    _source.Create(CreatePersistentDataObject(obj));
                }
                _collection.Insert(obj, _keyManagementStrategy);
            }

            // Strategy for key selection (Collection decides)
            // 1) Throw exception if Create operation is not supported,
            //    since choosing DataSourceDecides is then meaningless.
            // 2) If the data source supports the Create operation,
            //    call Create on data source. It is assumed that it
            //    is NOT an error to call this method, even if the
            //    data source does not support it.
            if (_keyManagementStrategy == KeyManagementStrategyType.CollectionDecides)
            {
                obj.Key = _collection.Insert(obj, _keyManagementStrategy);
                if (_supportedOperations.Contains(PersistencyOperations.Create))
                {
                    _source.Create(CreatePersistentDataObject(obj));
                }
            }

            CatalogChanged?.Invoke(obj.Key);
        }

        /// <inheritdoc />
        public TViewData Read(int key)
        {
            return CreateViewDataObject(_collection[key]);
        }

        /// <inheritdoc />
        public void Update(TViewData vdObj, int key)
        {
            T obj = CreateDomainObjectFromViewDataObject(vdObj);

            _collection.Replace(key, obj);
            if (_supportedOperations.Contains(PersistencyOperations.Update))
            {
                _source.Update(key, CreatePersistentDataObject(obj));
            }

            CatalogChanged?.Invoke(key);
        }

        /// <inheritdoc />
        public void Delete(int key)
        {
            _collection.Remove(key);
            if (_supportedOperations.Contains(PersistencyOperations.Delete))
            {
                _source.Delete(key);
            }

            CatalogChanged?.Invoke(key);
        }

        /// <summary>
        /// Override these methods in domain-specific catalog class, 
        /// to define transformation from/to domain object.
        /// </summary>
        public abstract T CreateDomainObjectFromViewDataObject(TViewData vmObj);
        public abstract TPersistentData CreatePersistentDataObject(T obj);
        public abstract T CreateDomainObjectFromPersistentDataObject(TPersistentData vmObj);
        public abstract TViewData CreateViewDataObject(T obj);
    }
}