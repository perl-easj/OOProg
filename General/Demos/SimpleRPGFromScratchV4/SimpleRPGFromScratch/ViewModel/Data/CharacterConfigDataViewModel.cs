using System.Collections.ObjectModel;
using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Control;
using SimpleRPGFromScratch.ViewModel.Page;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class CharacterConfigDataViewModel : DataViewModelAppBase<CharacterConfig>
    {
        private ComboBoxDataViewModel<Character, CharacterDataViewModel, CharacterPageViewModel> _characterCBDVM;
        private ComboBoxDataViewModel<Weapon, WeaponDataViewModel, WeaponPageViewModel> _leftWeaponCBDVM;
        private ComboBoxDataViewModel<Weapon, WeaponDataViewModel, WeaponPageViewModel> _rightWeaponCBDVM;

        public CharacterConfigDataViewModel() : this(null)
        {
        }

        public CharacterConfigDataViewModel(CharacterConfig dataObject) : base(dataObject)
        {
            _characterCBDVM = new ComboBoxDataViewModel<Character, CharacterDataViewModel, CharacterPageViewModel>(
                () => DataObject().CharacterId,
                val =>
                {
                    DataObject().CharacterId = val;
                    OnPropertyChanged(nameof(CharacterSelected));
                });

            _leftWeaponCBDVM = new ComboBoxDataViewModel<Weapon, WeaponDataViewModel, WeaponPageViewModel>(
                () => CheckedWeaponId(DataObject().WeaponIdLeft),
                val =>
                {
                    DataObject().WeaponIdLeft = val;
                    OnPropertyChanged(nameof(LeftWeaponSelected));
                });

            _rightWeaponCBDVM = new ComboBoxDataViewModel<Weapon, WeaponDataViewModel, WeaponPageViewModel>(
                () => CheckedWeaponId(DataObject().WeaponIdRight),
                val =>
                {
                    DataObject().WeaponIdRight = val;
                    OnPropertyChanged(nameof(RightWeaponSelected));
                });
        }

        public ObservableCollection<CharacterDataViewModel> CharacterCollection
        {
            get { return _characterCBDVM.ItemCollection; }
        }

        public CharacterDataViewModel CharacterSelected
        {
            get { return _characterCBDVM.ItemSelected; }
            set
            {
                _characterCBDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<WeaponDataViewModel> LeftWeaponCollection
        {
            get { return _leftWeaponCBDVM.ItemCollection; }
        }

        public ObservableCollection<WeaponDataViewModel> RightWeaponCollection
        {
            get { return _rightWeaponCBDVM.ItemCollection; }
        }

        public WeaponDataViewModel LeftWeaponSelected
        {
            get { return _leftWeaponCBDVM.ItemSelected; }
            set
            {
                _leftWeaponCBDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }

        public WeaponDataViewModel RightWeaponSelected
        {
            get { return _rightWeaponCBDVM.ItemSelected; }
            set
            {
                _rightWeaponCBDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }

        protected override string ItemDescription
        {
            get  { return $"{CharacterSelected?.Name}, using {WeaponDescription(LeftWeaponSelected)} / {WeaponDescription(RightWeaponSelected)})";}
        }

        private string WeaponDescription(WeaponDataViewModel weaponDVM)
        {
            if (weaponDVM == null) return "(no weapon)";

            return $"{weaponDVM.WeaponModelDesc},  {weaponDVM.WeaponDamageDesc}";
        }

        private int CheckedWeaponId(int? id)
        {
            return id ?? DomainClassBase<Weapon>.NullId;
        }
    }
}