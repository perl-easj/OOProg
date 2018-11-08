using System.ComponentModel;
using System.Runtime.CompilerServices;
using Data.InMemory.Implementation;

namespace ViewModel.Data.Implementation
{
    /// <summary>
    /// Base class for data view model classes.
    /// Just adds INotifyPropertyChanged functionality
    /// to the DataWrapper class.
    /// No specific assumption is made about the kind
    /// of the wrapped object (domain or transformed).
    /// </summary>
    public class DataViewModelBase<TData> : DataWrapper<TData>, INotifyPropertyChanged
    {
        protected DataViewModelBase(TData obj) : base(obj)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}