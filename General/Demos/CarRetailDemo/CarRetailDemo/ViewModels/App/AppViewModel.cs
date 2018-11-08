using CarRetailDemo.Views.App;
using Commands.Implementation;
using CarRetailDemo.Views.Domain;
using Extensions.ViewModel.Implementation;

namespace CarRetailDemo.ViewModels.App
{
    public class AppViewModel : AppViewModelMenu
    {
        public override void AddCommands()
        {
            NavigationCommands.Add("OpenFileView",     new NavigationCommand(AppFrame, typeof(FileView)));
            NavigationCommands.Add("OpenCarView",      new NavigationCommand(AppFrame, typeof(CarView)));
            NavigationCommands.Add("OpenCustomerView", new NavigationCommand(AppFrame, typeof(CustomerView)));
            NavigationCommands.Add("OpenEmployeeView", new NavigationCommand(AppFrame, typeof(EmployeeView)));
            NavigationCommands.Add("OpenSaleView",     new NavigationCommand(AppFrame, typeof(SaleView)));
        }
    }
}