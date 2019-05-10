using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Demo.Model;

namespace Demo.ViewModel
{
    public class MasterDetailsViewModel : INotifyPropertyChanged
    {
        private CarCatalog _catalog;
        private Car _itemSelected;

        public MasterDetailsViewModel()
        {
            _catalog = new CarCatalog();
            SaveCatalogCommand = new SaveCommand(_catalog);
            NewCarCommand = new NewCommand(_catalog, this);

            _catalog.Load();
        }

        public ObservableCollection<Car> ItemCollection
        {
            get
            {
                ObservableCollection<Car> cars = new ObservableCollection<Car>();
                foreach (var c in _catalog.All)
                {
                    cars.Add(c);
                }
                return cars;
            }
        }

        public Car ItemSelected
        {
            get { return _itemSelected; }
            set
            {
                _itemSelected = value;
                OnPropertyChanged();
            }
        }

        public SaveCommand SaveCatalogCommand { get; }
        public NewCommand NewCarCommand { get; }

        public void Refresh()
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