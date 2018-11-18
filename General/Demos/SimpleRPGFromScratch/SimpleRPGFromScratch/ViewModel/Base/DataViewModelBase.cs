// HISTORIK:
// v.1.0 : Oprettet, implementerer relevante interfaces for
//         DataViewModel-klasser
//

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleRPGFromScratch.ViewModel.Base
{
    public class DataViewModelBase<T> : IDataViewModel<T>, INotifyPropertyChanged
    {
        public T DataObject { get; }

        public DataViewModelBase(T dataObject)
        {
            DataObject = dataObject;
        }

        // Denne constructor er defineret for at kunne benytte
        // klassen som type-parameter.
        public DataViewModelBase()
        {
            DataObject = default(T);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}