using System;
using Windows.UI.Xaml;
using ViewModel.App.Implementation;

namespace Extensions.ViewModel.Implementation
{
    /// <summary>
    /// Top-level navigation based on selection of a FrameworkElement
    /// (e.g. a Menu item), where the Tag property is used to look up
    /// a corresponding navigation command object, and execute it.
    /// </summary>
    public abstract class AppViewModelMenu : AppViewModelBase
    {
        private FrameworkElement _selectedMenuItem;

        public AppViewModelMenu()
        {
            _selectedMenuItem = null;
        }

        public FrameworkElement SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                _selectedMenuItem = value;
                if (_selectedMenuItem == null) return;

                string tag = _selectedMenuItem.Tag.ToString();

                if (!NavigationCommands.ContainsKey(tag))
                {
                    throw new ArgumentException(NoCommandMessage(tag));
                }

                NavigationCommands[tag].Execute(null);
            }
        }

        protected virtual string NoCommandMessage(string tag)
        {
            return $"Menu entry {tag} has no matching navigation command";
        }
    }
}