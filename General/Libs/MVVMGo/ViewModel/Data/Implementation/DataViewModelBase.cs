using System.ComponentModel;
using System.Runtime.CompilerServices;
using Data.InMemory.Implementation;

namespace ViewModel.Data.Implementation
{
    /// <summary>
    /// Base class for data view model classes. Just adds INotifyPropertyChanged
    /// functionality to the DataWrapper class.
    /// </summary>
    public class DataViewModelBase<TViewData> : DataWrapper<TViewData>, INotifyPropertyChanged
    {
        protected DataViewModelBase(TViewData obj) : base(obj)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}