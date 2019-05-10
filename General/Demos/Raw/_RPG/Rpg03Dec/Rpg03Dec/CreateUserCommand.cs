using System;
using System.Windows.Input;

namespace Rpg03Dec
{
    public class CreateUserCommand : ICommand
    {
        private User _newUser;
        private UserCatalog _catalog;

        public CreateUserCommand(UserCatalog catalog, User newUser)
        {
            _newUser = newUser;
            _catalog = catalog;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _catalog.Create(_newUser);
        }

        public event EventHandler CanExecuteChanged;
    }
}