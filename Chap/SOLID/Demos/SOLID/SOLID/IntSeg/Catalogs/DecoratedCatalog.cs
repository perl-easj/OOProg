using SOLID.IntSeg.Interfaces;

namespace SOLID.IntSeg.Catalogs
{
    /// <summary>
    /// Implements a "decoratable" version of a catalog (does it need to be a "catalog"...?)
    /// NB: Note that the class
    ///   1) Implements the full ICreateReadUpdateDelete interface, but
    ///   2) does this by composition, using four implementations of the "segregated" interfaces
    /// Hello, Facade pattern!
    /// Hello, Dependency Injection!
    /// </summary>
    public class DecoratedCatalog<T> : ICreateReadUpdateDelete<T>
    {
        private ICreate<T> _create;
        private IRead<T> _read;
        private IUpdate<T> _update;
        private IDelete<T> _delete;

        public DecoratedCatalog(ICreate<T> create, IRead<T> read, IUpdate<T> update, IDelete<T> delete)
        {
            _create = create;
            _read = read;
            _update = update;
            _delete = delete;
        }

        public void Create(int key, T obj)
        {
            _create.Create(key, obj);
        }

        public T Read(int key)
        {
            return _read.Read(key);
        }

        public void Update(int key, T obj)
        {
            _update.Update(key, obj);
        }

        public void Delete(int key)
        {
            _delete.Delete(key);
        }
    }
}