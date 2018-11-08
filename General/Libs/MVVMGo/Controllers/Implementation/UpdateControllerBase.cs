using Data.InMemory.Interfaces;
using Model.Interfaces;

namespace Controllers.Implementation
{
    /// <summary>
    /// Implementation of a generic Update operation.
    /// </summary>
    public class UpdateControllerBase<TData> : CRUDControllerBase<TData>
        where TData : class, ICopyable, IStorable
    {
        public UpdateControllerBase(IDataWrapper<TData> source, ICatalog<TData> target)
            : base(source, target)
        {
        }

        /// <summary>
        /// Update is performed by deleting the existing 
        /// data object with the corresponding Key, and 
        /// then inserting the updated object.
        /// </summary>
        public override void Run()
        {
            TData updateObj = Source.DataObject.Copy() as TData;
            Target.Update(updateObj, Source.DataObject.Key);
        }
    }
}