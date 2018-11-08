using System.Collections.Generic;
using Data.InMemory.Interfaces;
using CarRetailDemo.Models.App;
using CarRetailDemo.ViewModels.Base;
using CarRetailDemo.ViewModels.Data;
using MVVMStarterDemoA.Data.Domain;

namespace CarRetailDemo.ViewModels.Page
{
    public class CarPageViewModel : PageViewModelAppBase<Car>
    {
        public CarPageViewModel()
            : base(DomainModel.Catalogs.Cars,
                new List<string> { "Plate", "Model", "Brand", "Year" },
                new List<string> { "CCM", "HK", "Seats", "Price", "Image" })
        {
        }

        public override IDataWrapper<Car> CreateDataViewModel(Car obj)
        {
            return new CarDataViewModel(obj);
        }
    }
}