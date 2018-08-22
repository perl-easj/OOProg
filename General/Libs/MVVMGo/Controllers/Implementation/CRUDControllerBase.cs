using Controllers.Interfaces;
using Data.InMemory.Interfaces;
using Model.Interfaces;

namespace Controllers.Implementation
{
    /// <summary>
    /// Base class for controllers performing CRUD 
    /// (Create, Read, Update, Delete) operations.
    /// It is assumed that the controllers operate
    /// on view data objects, obtain the source 
    /// object from a view data object wrapper, 
    /// and perform the operation itself on an
    /// ICatalog implementation.
    /// </summary>
    public abstract class CRUDControllerBase<TViewData> : ISimpleController
    {
        protected IDataWrapper<TViewData> Source;
        protected ICatalog<TViewData> Target;

        protected CRUDControllerBase(IDataWrapper<TViewData> source, ICatalog<TViewData> target)
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