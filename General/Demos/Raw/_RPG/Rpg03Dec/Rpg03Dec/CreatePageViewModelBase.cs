using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Rpg03Dec
{
    public class CreatePageViewModelBase<T> : INotifyPropertyChanged
        where T : new()
    {
        private CatalogBase<T> _catalog;
        protected T _newObject;
        private ICommand _createCommand;

        public CreatePageViewModelBase()
        {
            _catalog = new CatalogBase<T>();
            _newObject = new T();
            _createCommand = null; // new CreateCommandBase<User>(_catalog, _newObject);

            _catalog.CatalogChanged += CatalogHasChanged;
        }

        private void CatalogOnCatalogChanged()
        {
        }

        public ObservableCollection<T> ItemCollection
        {
            get { return new ObservableCollection<T>() ; }
        }

        public ICommand CreateCommandObj
        {
            get { return _createCommand; }
        }

        private void CatalogHasChanged()
        {
            OnPropertyChanged(nameof(ItemCollection));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}