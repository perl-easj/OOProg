using System.Collections.Generic;
using Data.InMemory.Interfaces;
using CarRetailDemo.Models.App;
using CarRetailDemo.ViewModels.Base;
using CarRetailDemo.ViewModels.Data;
using MVVMStarterDemoA.Data.Domain;

namespace CarRetailDemo.ViewModels.Page
{
    public class EmployeePageViewModel : PageViewModelAppBase<Employee>
    {
        public EmployeePageViewModel()
            : base(DomainModel.Catalogs.Employees,
                new List<string> { "Name", "CarsSold" },
                new List<string> { "Image", "Title", "Phone", "Email", "Employed" })
        {
        }

        public override IDataWrapper<Employee> CreateDataViewModel(Employee obj)
        {
            return new EmployeeDataViewModel(obj);
        }
    }
}