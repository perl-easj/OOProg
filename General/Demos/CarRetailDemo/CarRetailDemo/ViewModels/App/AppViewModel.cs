using System;
using Windows.UI.Xaml.Controls;
using Commands.Implementation;
using CarRetailDemo.Views.Domain;
using ViewModel.App.Implementation;

namespace CarRetailDemo.ViewModels.App
{
    public class AppViewModel : AppViewModelBase
    {
        private NavigationViewItem _selectedMenuItem;

        public AppViewModel()
        {
            _selectedMenuItem = null;
        }

        public NavigationViewItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                _selectedMenuItem = value;
                if (_selectedMenuItem == null) return;

                string tag = _selectedMenuItem.Tag.ToString();

                if (!NavigationCommands.ContainsKey(tag))
                {
                    throw new ArgumentException($"Menu entry {tag} has no matching navigation command");
                }

                NavigationCommands[tag].Execute(null);
            }
        }

        public override void AddCommands()
        {
            NavigationCommands.Add("File", new RelayCommand(() =>
            {
                AppFrame.Navigate(typeof(Views.App.FileView));
            }));

            NavigationCommands.Add("OpenCarView", new RelayCommand(() =>
            {
                AppFrame.Navigate(typeof(CarView));
            }));

            NavigationCommands.Add("OpenCustomerView", new RelayCommand(() =>
            {
                AppFrame.Navigate(typeof(CustomerView));
            }));

            NavigationCommands.Add("OpenEmployeeView", new RelayCommand(() =>
            {
                AppFrame.Navigate(typeof(EmployeeView));
            }));

            NavigationCommands.Add("OpenSaleView", new RelayCommand(() =>
            {
                AppFrame.Navigate(typeof(SaleView));
            }));
        }
    }
}