using System.Collections.Generic;
using Data.InMemory.Interfaces;
using CarRetailDemo.Data.Domain;
using CarRetailDemo.Models.App;
using CarRetailDemo.ViewModels.Base;
using CarRetailDemo.ViewModels.Data;

namespace CarRetailDemo.ViewModels.Page
{
    public class SalePageViewModel : PageViewModelAppBase<Sale>
    {
        public SalePageViewModel()
            : base(DomainModel.Catalogs.Sales,
                new List<string> { "Car", "Customer", "Employee" },
                new List<string> { "Date", "Price" })
        {
        }

        public override IDataWrapper<Sale> CreateDataViewModel(Sale obj)
        {
            return new SaleDataViewModel(obj);
        }
    }
}