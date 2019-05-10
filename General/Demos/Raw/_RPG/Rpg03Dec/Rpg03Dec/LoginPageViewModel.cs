using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace Rpg03Dec
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public static Frame TheRootFrame;

        private string _userName;
        private string _password;
        private LoginCommand _loginCommand;
        private UserCatalog _userCatalog;

        public LoginPageViewModel()
        {
            _userName = "";
            _password = "";
            _userCatalog = new UserCatalog();
            _loginCommand = new LoginCommand(TheRootFrame, _userCatalog, this);
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
                _loginCommand.RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
                _loginCommand.RaiseCanExecuteChanged();
            }
        }

        public ICommand LoginCommandObj
        {
            get { return _loginCommand; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}