// HISTORIK:
// v.1.0 : Oprettet, kun entry for Weapon View
// v.1.1 : Tilføjet entry for WeaponModel View
// v.1.2 : Tilføjet entry for Character View
//

using System;
using Windows.UI.Xaml.Controls;
using SimpleRPGFromScratch.View.Domain;

namespace SimpleRPGFromScratch.ViewModel.App
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

                if (_selectedMenuItem.Tag.ToString() == "OpenWeaponModelView")
                {
                    NavigateToView(typeof(WeaponModelView));
                }

                if (_selectedMenuItem.Tag.ToString() == "OpenCharacterView")
                {
                    NavigateToView(typeof(CharacterView));
                }
            }
        }

        private void NavigateToView(Type viewType)
        {
            AppFrameInstance?.Navigate(viewType);
        }
    }
}