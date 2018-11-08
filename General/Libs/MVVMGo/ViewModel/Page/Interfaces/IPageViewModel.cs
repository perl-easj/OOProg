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
    /// <typeparam name="TData">Type of the (wrapped) objects being managed</typeparam>
    public interface IPageViewModel<TData> : INotifyPropertyChanged, IItemSelectionChangedEvent<TData>
    {
        /// <summary>
        /// Collection of (wrapped) objects to e.g. be presented
        /// in a collection-oriented GUI control.
        /// </summary>
        ObservableCollection<IDataWrapper<TData>> ItemCollection { get; }

        /// <summary>
        /// Item currently selected in collection-oriented GUI control.
        /// </summary>
        IDataWrapper<TData> ItemSelected { get; set; }

        /// <summary>
        /// Item for which details should be displayed in part of the Page.
        /// </summary>
        IDataWrapper<TData> ItemDetails { get; set; }

        void OnPropertyChanged([CallerMemberName] string propertyName = null);
    }
}