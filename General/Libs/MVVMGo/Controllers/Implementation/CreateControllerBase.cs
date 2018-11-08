using Data.InMemory.Interfaces;
using Model.Interfaces;

namespace Controllers.Implementation
{
    /// <summary>
    /// Implementation of a generic Insert operation.
    /// </summary>
    public class CreateControllerBase<TData> : CRUDControllerBase<TData>
    {
        public CreateControllerBase(IDataWrapper<TData> source, ICatalog<TData> target)
            : base(source, target)
        {
        }

        /// <summary>
        /// Inserts the retrieved view data object
        /// into the target collection.
        /// </summary>
        public override void Run()
        {
            Target.Create(Source.DataObject);
        }
    }
}