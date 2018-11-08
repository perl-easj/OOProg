using System.Collections.Generic;
using Data.InMemory.Interfaces;
using CarRetailDemo.Models.App;
using CarRetailDemo.ViewModels.Base;
using CarRetailDemo.ViewModels.Data;
using MVVMStarterDemoA.Data.Domain;

namespace CarRetailDemo.ViewModels.Page
{
    public class CustomerPageViewModel : PageViewModelAppBase<Customer>
    {
        public CustomerPageViewModel()
            : base(DomainModel.Catalogs.Customers,
                new List<string> { "Name" },
                new List<string> { "Image", "Address", "ZipCode", "City", "Phone", "Email", "MaxPrice", "MinPrice", "Newsletter" })
        {
        }

        public override IDataWrapper<Customer> CreateDataViewModel(Customer obj)
        {
            return new CustomerDataViewModel(obj);
        }
    }
}