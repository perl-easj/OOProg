using System;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace Rpg03Dec
{
    public class LoginCommand : ICommand
    {
        private Frame _rootFrame;
        private UserCatalog _catalog;
        private LoginPageViewModel _pvm;

        public LoginCommand(Frame rootFrame, UserCatalog catalog, LoginPageViewModel pvm)
        {
            _rootFrame = rootFrame;
            _catalog = catalog;
            _pvm = pvm;
        }

        public bool CanExecute(object parameter)
        {
            return _catalog.OkUser(_pvm.UserName, _pvm.Password);
        }

        public void Execute(object parameter)
        {
            _rootFrame.Navigate(typeof(MainPage), null);
        }

        public event EventHandler CanExecuteChanged;

        public virtual void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}