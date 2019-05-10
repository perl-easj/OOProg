using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Rpg03Dec
{
    public class UserPageViewModel : CreatePageViewModelBase<User>
    {
        public string UserName
        {
            get { return _newObject.Name; }
            set
            {
                _newObject.Name = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _newObject.Password; }
            set
            {
                _newObject.Password = value;
                OnPropertyChanged();
            }
        }
    }
}