using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Data.InMemory.Interfaces;

namespace ViewModel.Page.Interfaces
{
    /// <summary>
    /// Interface for a view model for a Page. The model is primarily aimed
    /// at pages containing a Master/Details view of a collection of objects.
    /// </summary>
    /// <typeparam name="TViewData"></typeparam>
    public interface IPageViewModel<TViewData> : INotifyPropertyChanged, IItemSelectionChangedEvent<TViewData>
    {
        /// <summary>
        /// Collection of view-oriented objects corresponding to underlying 
        /// domain data, e.g. to be presented in a collection-oriented GUI control.
        /// </summary>
        ObservableCollection<IDataWrapper<TViewData>> ItemCollection { get; }

        /// <summary>
        /// Item currently selected in collection-oriented GUI control.
        /// </summary>
        IDataWrapper<TViewData> ItemSelected { get; set; }

        /// <summary>
        /// Item for which details should be displayed in part of the Page.
        /// </summary>
        IDataWrapper<TViewData> ItemDetails { get; set; }

        void OnPropertyChanged([CallerMemberName] string propertyName = null);
    }
}