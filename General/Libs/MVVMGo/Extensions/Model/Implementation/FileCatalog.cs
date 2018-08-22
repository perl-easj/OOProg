using Data.InMemory.Interfaces;

namespace Extensions.Model.Implementation
{
    /// <summary>
    /// Simplified version of FilePersistableCatalogAsync, where the domain data classes will  
    /// also act as both view data and persistent data classes, i.e. no data transformations.
    /// All transformation methods are therefore trivial.
    /// </summary>
    public class FileCatalog<T> : FileCatalogFull<T, T, T> where T : class, IStorable
    {
        public FileCatalog(bool saveOnChanges = false) : base(saveOnChanges)
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