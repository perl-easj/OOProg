using System;
using Windows.UI.Xaml.Controls;
using RPGDemo19NOV.View.Domain;

namespace RPGDemo19NOV.ViewModel.App
{
    public class MainPageViewModel
    {
        public static Frame AppFrameInstance = null;
        private NavigationViewItem _selectedMenuItem;

        public MainPageViewModel()
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

                if (_selectedMenuItem.Tag.ToString() == "OpenWeaponView")
                {
                    NavigateToView(typeof(WeaponView));
                }

            }
        }

        private void NavigateToView(Type viewType)
        {
            AppFrameInstance?.Navigate(viewType);
        }
    }
}