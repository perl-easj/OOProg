using System;
using System.Linq;
using SimpleRPGFromScratch.Command.App;
using SimpleRPGFromScratch.Model.App;
using SimpleRPGFromScratch.ViewModel.Data;

namespace SimpleRPGFromScratch.Command.Domain
{
    public class AddJewelToWeaponCommand : ReferenceChangeCommand<Jewel>
    {
        private Weapon _weapon;
        private WeaponDataViewModel _weaponDVM;

        public AddJewelToWeaponCommand(Action<Jewel> changeReference, Weapon weapon, WeaponDataViewModel weaponDVM) 
            : base(changeReference)
        {
            _weapon = weapon;
            _weaponDVM = weaponDVM;
        }

        protected override bool CanExecute()
        {
            return base.CanExecute() && _weaponDVM.FreeJewelCollectionEnabled;
        }
    }
}