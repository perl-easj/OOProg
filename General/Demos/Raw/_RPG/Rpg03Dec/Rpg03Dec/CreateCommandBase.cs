using System;
using System.Windows.Input;

namespace Rpg03Dec
{
    public class CreateCommandBase<T> : ICommand
    {
        private T _newObject;
        private CatalogBase<T> _catalog;

        public CreateCommandBase(CatalogBase<T> catalog, T newObject)
        {
            _catalog = catalog;
            _newObject = newObject;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _catalog.Create(_newObject);
        }

        public event EventHandler CanExecuteChanged;
    }
}