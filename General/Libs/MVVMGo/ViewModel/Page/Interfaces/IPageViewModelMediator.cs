using Data.InMemory.Interfaces;

namespace ViewModel.Page.Interfaces
{
    /// <summary>
    /// The Mediator will be associated with a Page view model object, 
    /// and manage the relations between various properties.
    /// </summary>
    public interface IPageViewModelMediator<in TViewData>
    {
        /// <summary>
        /// Invoked when the selected item changes.
        /// </summary>
        /// <param name="vdWrapper">
        /// Newly selected item
        /// </param>
        void OnItemSelectionChanged(IDataWrapper<TViewData> vdWrapper);
    }
}