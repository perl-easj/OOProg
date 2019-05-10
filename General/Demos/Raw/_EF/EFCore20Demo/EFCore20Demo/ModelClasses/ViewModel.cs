using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EFCore20Demo.DomainClasses;

namespace EFCore20Demo.ModelClasses
{
    public class ViewModel : INotifyPropertyChanged
    {
        public List<CarClass> CarList
        {
            get { return DomainModel.Catalogs.Cars; }
        }

        public List<CustomerClass> CustomerList
        {
            get { return DomainModel.Catalogs.Customers; }
        }

        public List<EmployeeClass> EmployeeList
        {
            get { return DomainModel.Catalogs.Employees; }
        }

        public List<SaleClass> SaleList
        {
            get { return DomainModel.Catalogs.Sales; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}