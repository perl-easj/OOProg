using System;
using System.Windows.Input;
using Demo.Model;

namespace Demo.ViewModel
{
    public class SaveCommand : ICommand
    {
        private CarCatalog _catalog;

        public SaveCommand(CarCatalog catalog)
        {
            _catalog = catalog;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _catalog.Save();
        }

        public event EventHandler CanExecuteChanged;
    }
}