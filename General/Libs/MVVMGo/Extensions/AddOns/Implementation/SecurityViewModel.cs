using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml;
using AddOns.Security.Implementation;
using Commands.Implementation;

namespace Extensions.AddOns.Implementation
{
    /// <summary>
    /// This class is a ViewModel class for the Security service. 
    /// If you wish to include a GUI for the Security service in 
    /// an application, you can bind the view controls to properties 
    /// in this class.
    /// </summary>
    public class SecurityViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private RelayCommand _loginCommand;

        public SecurityViewModel()
        {
            _username = SecurityService.AdminUserName;
            _password = "";
            _loginCommand = new RelayCommand(DoLogin, CanLogin);
        }

        /// <summary>
        /// Property for detecting visibility in 
        /// GUI of login service
        /// </summary>
        public virtual Visibility LoginVisible
        {
            get { return ServiceProvider.Security.UseLogin ? Visibility.Visible : Visibility.Collapsed; }
        }

        /// <summary>
        /// Property for tracking the currently entered username. 
        /// Changing the username may cause changes in the 
        /// can-execute state of the Login command.
        /// </summary>
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                ServiceProvider.Security.CurrentUserName = _username;
                OnPropertyChanged();
                _loginCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Property for tracking the currently entered password. 
        /// Changing the password may cause changes in the 
        /// can-execute state of the Login command.
        /// </summary>
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

        /// <summary>
        /// Status is currently just defined as the username of 
        /// the currently logged in user.
        /// </summary>
        public string Status
        {
            get { return ServiceProvider.Security.CurrentUserName; }
        }

        public ICommand LoginCommand
        {
            get { return _loginCommand; }
        }

        /// <summary>
        /// DoLogin will only be executable when username 
        /// and password are valid. It will therefore just 
        /// change the status
        /// </summary>
        public void DoLogin()
        {
            OnPropertyChanged(nameof(Status));
        }

        /// <summary>
        /// CanLogin will only return true when the entered 
        /// username/password combination is valid.
        /// </summary>
        public bool CanLogin()
        {
            return ServiceProvider.Security.CheckPassword(_username, _password);
        }

        #region INotifyPropertyChanged code
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}