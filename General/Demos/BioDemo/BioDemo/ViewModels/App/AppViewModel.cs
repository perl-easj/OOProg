using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using BioDemo.Models.App;
using BioDemo.ViewModels.Commands;
using Commands.Implementation;
using ViewModel.App.Implementation;

namespace BioDemo.ViewModels.App
{
    /// <summary>
    /// This class will become the Data Context for the main application 
    /// view (MainPage). The class tracks the selected menu item from the
    /// main application menu, and executes the corresponding navigation
    /// command when the selection changes.
    /// </summary>
    public class AppViewModel : AppViewModelBase
    {
        #region Instance fields
        private NavigationViewItem _selectedMenuItem;
        #endregion

        #region Constructor
        public AppViewModel()
        {
            _selectedMenuItem = null;
        }
        #endregion

        #region Properties
        /// <summary>
        /// This property is used for Data Binding by the NavigationView
        /// control in the main application view.
        /// </summary>
        public NavigationViewItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                _selectedMenuItem = value;

                if (_selectedMenuItem == null) return;

                // The value of the Tag property is extracted from the selected Menu item.
                // This value should match one of the available command keys in the
                // NavigationCommands dictionary.
                string tag = _selectedMenuItem.Tag.ToString();
                if (!NavigationCommands.ContainsKey(tag))
                {
                    throw new ArgumentException($"Menu entry {tag} has no matching navigation command");
                }
                NavigationCommands[tag].Execute(null);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// This method is used for adding application-specific navigation
        /// commands into the NavigationCommands dictionary. The keys used
        /// for the commands should match Tag values on menu items from the
        /// main application view.
        /// </summary>
        public override void AddCommands()
        {
            NavigationCommands.Add("OpenMovieView", new NavigationCommand(AppFrame, typeof(Views.Domain.MovieView)));
            NavigationCommands.Add("OpenTheaterView", new NavigationCommand(AppFrame, typeof(Views.Domain.TheaterView)));
            NavigationCommands.Add("OpenShowView", new NavigationCommand(AppFrame, typeof(Views.Domain.ShowView)));
            NavigationCommands.Add("OpenTicketView", new NavigationCommand(AppFrame, typeof(Views.Domain.TicketView)));
            NavigationCommands.Add("OpenBuyTicketFlow", new NavigationCommand(AppFrame, typeof(Views.Domain.BuyTicketViewStart)));
            NavigationCommands.Add("Load", new LoadCommand());
            NavigationCommands.Add("Save", new SaveCommand());
            NavigationCommands.Add("Quit", new QuitCommand());
        } 
        #endregion
    }
}