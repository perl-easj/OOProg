using Data.InMemory.Interfaces;

namespace ViewModel.Page.Interfaces
{
    /// <summary>
    /// The Mediator will be associated with a Page view model object, 
    /// and manage the relations between various properties.
    /// </summary>
    public interface IPageViewModelMediator<in TData>
    {
        /// <summary>
        /// Invoked when the selected item changes.
        /// </summary>
        /// <param name="dataWrapper">
        /// Newly selected item
        /// </param>
        void OnItemSelectionChanged(IDataWrapper<TData> dataWrapper);
    }
}