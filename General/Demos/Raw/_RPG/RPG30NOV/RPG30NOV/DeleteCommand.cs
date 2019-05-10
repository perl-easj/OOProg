using System;
using System.Windows.Input;

namespace RPG30NOV
{
    public class DeleteCommand : ICommand
    {
        private CharacterCatalog _catalog;
        private CharacterPageViewModel _pvm;

        public DeleteCommand(
            CharacterCatalog catalog, 
            CharacterPageViewModel pvm)
        {
            _catalog = catalog;
            _pvm = pvm;
        }


        public bool CanExecute(object parameter)
        {
            return _pvm.CharacterSelected != null;
        }

        public void Execute(object parameter)
        {
            _catalog.Delete(_pvm.CharacterSelected.Id);
            _pvm.Refresh();

        }

        public virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}