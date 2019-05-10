using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GUIExample
{
    public class CarViewModel : INotifyPropertyChanged
    {
        private Car _domainObject;

        public CarViewModel()
        {
            _domainObject = new Car();
        }

        public int Price
        {
            get { return _domainObject.Price; }
            set
            {
                _domainObject.Price = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}