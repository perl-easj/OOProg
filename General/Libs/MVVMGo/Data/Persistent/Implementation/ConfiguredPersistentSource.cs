using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Persistent.Interfaces;

namespace Data.Persistent.Implementation
{
    /// <summary>
    /// Since a specific data source may not support all data
    /// operations (CRUD + Load/Save), this class makes it 
    /// possible to configure different data operations to be 
    /// wired to different "strategies". A strategy will either
    /// be the actual data source implementation, or a "stub"
    /// object which can e.g. throw an exception.
    /// </summary>
    public class ConfiguredPersistentSource<TPersistentData> : IPersistentSource<TPersistentData>
    {
        private IDataSourceCRUD<TPersistentData> _dataSourceCRUD;
        private IDataSourceLoad<TPersistentData> _dataSourceLoad;
        private IDataSourceSave<TPersistentData> _dataSourceSave;

        public IDataSourceCRUD<TPersistentData> DataSourceCRUD
        {
            get { return _dataSourceCRUD; }
            protected set { _dataSourceCRUD = value; }
        }

        public IDataSourceLoad<TPersistentData> DataSourceLoad
        {
            get { return _dataSourceLoad; }
            protected set { _dataSourceLoad = value; }
        }

        public IDataSourceSave<TPersistentData> DataSourceSave
        {
            get { return _dataSourceSave; }
            protected set { _dataSourceSave = value; }
        }

        public Task Save(List<TPersistentData> objects)
        {
            return _dataSourceSave.Save(objects);
        }

        public Task<List<TPersistentData>> Load()
        {
            return _dataSourceLoad.Load();
        }

        public Task<int> Create(TPersistentData obj)
        {
            return _dataSourceCRUD.Create(obj);
        }

        public Task<TPersistentData> Read(int key)
        {
            return _dataSourceCRUD.Read(key);
        }

        public Task Update(int key, TPersistentData obj)
        {
            return _dataSourceCRUD.Update(key, obj);
        }

        public Task Delete(int key)
        {
            return _dataSourceCRUD.Delete(key);
        }
    }
}