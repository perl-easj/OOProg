using System;
using System.Windows.Input;
using Demo.Model;

namespace Demo.ViewModel
{
    public class NewCommand : ICommand
    {
        private CarCatalog _catalog;
        private MasterDetailsViewModel _mdvm;

        public NewCommand(CarCatalog catalog, MasterDetailsViewModel mdvm)
        {
            _catalog = catalog;
            _mdvm = mdvm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _catalog.Create(new Car("(license plate)", 25000));
            _mdvm.Refresh();
        }

        public event EventHandler CanExecuteChanged;      
    }
}