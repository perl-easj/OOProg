using Data.InMemory.Interfaces;
using Model.Interfaces;

namespace Controllers.Implementation
{
    /// <summary>
    /// Implementation of a generic Update operation.
    /// </summary>
    public class UpdateControllerBase<TViewData> : CRUDControllerBase<TViewData>
        where TViewData : class, ICopyable, IStorable
    {
        public UpdateControllerBase(IDataWrapper<TViewData> source, ICatalog<TViewData> target)
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
            TViewData updateObj = Source.DataObject.Copy() as TViewData;
            Target.Update(updateObj, Source.DataObject.Key);
        }
    }
}