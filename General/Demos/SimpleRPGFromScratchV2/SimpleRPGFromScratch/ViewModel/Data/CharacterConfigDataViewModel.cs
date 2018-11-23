using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class CharacterConfigDataViewModel : DataViewModelAppBase<CharacterConfig>
    {
        private WeaponDataViewModel _leftWeaponDVM;
        private WeaponDataViewModel _rightWeaponDVM;

        public CharacterConfigDataViewModel() { }

        public CharacterConfigDataViewModel(CharacterConfig dataObject) : base(dataObject)
        {
            _leftWeaponDVM = DataObject().WeaponIdLeftNavigation == null ? null : new WeaponDataViewModel(DataObject().WeaponIdLeftNavigation);
            _rightWeaponDVM = DataObject().WeaponIdRightNavigation == null ? null : new WeaponDataViewModel(DataObject().WeaponIdRightNavigation);
        }

        public string Name
        {
            get { return DataObject().Character?.Name; }
        }

        public string LeftWeaponDesc
        {
            get { return WeaponDescription(_leftWeaponDVM); }
        }

        public string RightWeaponDesc
        {
            get { return WeaponDescription(_rightWeaponDVM); }
        }

        public string DamageDesc
        {
            get { return $"Damage in this configuration: {DataObject().MinDamage} - {DataObject().MaxDamage}"; }
        }

        protected override string ItemDescription
        {
            get  { return $"{Name} ({LeftWeaponDesc} / {RightWeaponDesc})";}
        }

        private string WeaponDescription(WeaponDataViewModel weaponDVM)
        {
            if (weaponDVM == null) return "(no weapon)";

            return $"{weaponDVM.WeaponModelDesc},  {weaponDVM.WeaponDamageDesc}";
        }
    }
}