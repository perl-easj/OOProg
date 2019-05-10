using System.Collections.Generic;
using RPGDemo19NOV.Model.Catalog;

namespace RPGDemo19NOV.ViewModel.Page
{
    public class WeaponPageViewModel
    {
        private WeaponCatalog _catalog;
        private Weapon _selectedWeapon;

        public WeaponPageViewModel()
        {
            _catalog = new WeaponCatalog();
        }

        public List<Weapon> WeaponCollection
        {
            get
            {
                return _catalog.All;
            }
        }

        public Weapon SelectedWeapon
        {
            get { return _selectedWeapon; }
            set { _selectedWeapon = value; }
        }
    }
}