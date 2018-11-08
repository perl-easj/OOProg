using System;
using System.Collections.ObjectModel;
using AddOns.Images.Implementation;
using AddOns.Images.Interfaces;
using Data.InMemory.Implementation;
using Data.InMemory.Interfaces;
using Extensions.AddOns.Implementation;
using CarRetailDemo.Models.App;
using MVVMStarterDemoA.Data.Domain;
using ViewModel.Data.Implementation;

namespace CarRetailDemo.ViewModels.Data
{
    public class SaleDataViewModel : DataViewModelBase<Sale>
    {
        private IImage _notFoundImage;
        private ObservableCollection<CarDataViewModel> _observableCollectionCars;
        private ObservableCollection<CustomerDataViewModel> _observableCollectionCustomers;
        private ObservableCollection<EmployeeDataViewModel> _observableCollectionEmployees;

        public SaleDataViewModel(Sale obj) : base(obj)
        {
            _notFoundImage = new TaggedImage("Image not found", ServiceProvider.Images.GetAppImageSource(AppImageType.NotFound));

            _observableCollectionCars = new ObservableCollection<CarDataViewModel>();
            _observableCollectionCustomers = new ObservableCollection<CustomerDataViewModel>();
            _observableCollectionEmployees = new ObservableCollection<EmployeeDataViewModel>();

            foreach (var carData in DomainModel.Catalogs.Cars.All)
            {
                _observableCollectionCars.Add(new CarDataViewModel(carData));
            }

            foreach (var customerData in DomainModel.Catalogs.Customers.All)
            {
                _observableCollectionCustomers.Add(new CustomerDataViewModel(customerData));
            }

            foreach (var employeeData in DomainModel.Catalogs.Employees.All)
            {
                _observableCollectionEmployees.Add(new EmployeeDataViewModel(employeeData));
            }
        }

        public string ImageSource
        {
            get { return ServiceProvider.Images.Read(ImageKey, _notFoundImage).Source; }
        }

        public int ImageKey
        {
            get { return GetCar() != null ? GetCar().ImageKey : StorableBase.NullKey; }
        }

        public DateTimeOffset Date
        {
            get { return DataObject.SalesDate; }
            set
            {
                DataObject.SalesDate = value.Date;
                OnPropertyChanged();
            }
        }

        public int Price
        {
            get { return DataObject.FinalPrice; }
            set
            {
                DataObject.FinalPrice = value;
                OnPropertyChanged();
            }
        }

        public string DescriptionCar
        {
            get { return GetCar() == null ? string.Empty : GetCar().LicensePlate; }
        }

        public string DescriptionCustomer
        {
            get { return GetCustomer() == null ? string.Empty : "( " + GetCustomer().FullName + ")"; }
        }

        public string DescriptionEmployee
        {
            get { return GetEmployee() == null ? string.Empty : "Sold by " + GetEmployee().FullName; }
        }

        public string DescriptionPrice
        {
            get { return Price + " kr."; }
        }

        public ObservableCollection<CarDataViewModel> CollectionCars
        {
            get { return _observableCollectionCars; }
        }

        public ObservableCollection<CustomerDataViewModel> CollectionCustomers
        {
            get { return _observableCollectionCustomers; }
        }

        public ObservableCollection<EmployeeDataViewModel> CollectionEmployees
        {
            get { return _observableCollectionEmployees; }
        }

        public CarDataViewModel SelectedCar
        {
            get { return GetItemViewModel<CarDataViewModel, Car>(DataObject.CarKey, _observableCollectionCars); }
            set
            {
                if (value != null)
                {
                    DataObject.CarKey = value.DataObject.Key;
                }
                OnPropertyChanged();
            }
        }

        public CustomerDataViewModel SelectedCustomer
        {
            get { return GetItemViewModel<CustomerDataViewModel, Customer>(DataObject.CustomerKey, _observableCollectionCustomers); }
            set
            {
                if (value != null)
                {
                    DataObject.CustomerKey = value.DataObject.Key;
                }
                OnPropertyChanged();
            }
        }

        public EmployeeDataViewModel SelectedEmployee
        {
            get { return GetItemViewModel<EmployeeDataViewModel, Employee>(DataObject.EmployeeKey, _observableCollectionEmployees); }
            set
            {
                if (value != null)
                {
                    DataObject.EmployeeKey = value.DataObject.Key;
                }
                OnPropertyChanged();
            }
        }

        private Car GetCar()
        {
            return DomainModel.Catalogs.Cars.Read(DataObject.CarKey);
        }

        private Customer GetCustomer()
        {
            return DomainModel.Catalogs.Customers.Read(DataObject.CustomerKey);
        }

        private Employee GetEmployee()
        {
            return DomainModel.Catalogs.Employees.Read(DataObject.EmployeeKey);
        }

        private TDataViewModel GetItemViewModel<TDataViewModel, TViewData>(int key, ObservableCollection<TDataViewModel> collection)
            where TViewData : IStorable
            where TDataViewModel : class, IDataWrapper<TViewData>
        {
            foreach (var dataViewModel in collection)
            {
                if (dataViewModel.DataObject.Key == key)
                {
                    return dataViewModel;
                }
            }

            return null;
        }
    }
}