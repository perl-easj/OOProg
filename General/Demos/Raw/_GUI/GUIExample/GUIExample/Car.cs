using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GUIExample
{
    public class Car : INotifyPropertyChanged
    {
        private string _licensePlate;
        private string _brand;
        private string _model;
        private int _price;

        public Car()
        {
            _licensePlate = "Not set";
            _brand = "Not set";
            _model = "Not set";
            _price = 0;
        }

        public Car(string licensePlate, string brand, string model, int price)
        {
            _licensePlate = licensePlate;
            _brand = brand;
            _model = model;
            _price = price;
        }

        public string LicensePlate
        {
            get { return _licensePlate; }
            set
            {
                _licensePlate = value;
                OnPropertyChanged();
            }
        }

        public string Brand
        {
            get { return _brand; }
            set
            {
                _brand = value;
                OnPropertyChanged();
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
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