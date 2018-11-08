using Controllers.Interfaces;
using Data.InMemory.Interfaces;
using Model.Interfaces;

namespace Controllers.Implementation
{
    /// <summary>
    /// Base class for controllers performing CRUD 
    /// (Create, Read, Update, Delete) operations.
    /// It is assumed that the controllers obtain
    /// the source object from a data wrapper, 
    /// and perform the operation itself on an
    /// ICatalog implementation.
    /// </summary>
    public abstract class CRUDControllerBase<TData> : ISimpleController
    {
        protected IDataWrapper<TData> Source;
        protected ICatalog<TData> Target;

        protected CRUDControllerBase(IDataWrapper<TData> source, ICatalog<TData> target)
        {
            Source = source;
            Target = target;
        }

        /// <summary>
        /// Override in specific controller classes.
        /// </summary>
        public abstract void Run();
    }
}