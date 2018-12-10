using System.Collections.ObjectModel;
using System.Windows.Input;
using SimpleRPGFromScratch.Command.Base;
using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Control;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class CharacterConfigDataViewModel : DataViewModelAppBase<CharacterConfig>
    {
        #region Instance fields
        private SelectionControlDVM<Character, CharacterDataViewModel> _characterSCDVM;
        private SelectionControlDVM<Weapon, WeaponDataViewModel> _leftWeaponSCDVM;
        private SelectionControlDVM<Weapon, WeaponDataViewModel> _rightWeaponSCDVM;
        private DequipWeaponCommand _dropLeftWeaponCommand;
        private DequipWeaponCommand _dropRightWeaponCommand;
        #endregion

        #region Initialise
        public override void Initialise()
        {
            _characterSCDVM = new SelectionControlDVM<Character, CharacterDataViewModel>(
                () => DataObject().CharacterId,
                val =>
                {
                    DataObject().CharacterId = DomainClassBase<Character>.IdOrNullId(val);
                    OnPropertyChanged(nameof(CharacterSelected));
                });

            _leftWeaponSCDVM = new SelectionControlDVM<Weapon, WeaponDataViewModel>(
                () => DataObject().WeaponIdLeft,
                val =>
                {
                    DataObject().WeaponIdLeft = val;
                    OnPropertyChanged(nameof(LeftWeaponSelected));
                },
                w => w.CharacterId == DataObject().CharacterId);

            _rightWeaponSCDVM = new SelectionControlDVM<Weapon, WeaponDataViewModel>(
                () => DataObject().WeaponIdRight,
                val =>
                {
                    DataObject().WeaponIdRight = val;
                    OnPropertyChanged(nameof(RightWeaponSelected));
                },
                w => w.CharacterId == DataObject().CharacterId);

            _dropLeftWeaponCommand = new DequipWeaponCommand(_leftWeaponSCDVM);
            _dropRightWeaponCommand = new DequipWeaponCommand(_rightWeaponSCDVM);
        }
        #endregion

        #region Simple properties
        protected override string ItemDescription
        {
            get { return $"{CharacterSelected?.Name}, using {WeaponDescription(LeftWeaponSelected)} / {WeaponDescription(RightWeaponSelected)})"; }
        } 
        #endregion

        #region Properties til understøttelse af Collection-kontroller
        public ObservableCollection<CharacterDataViewModel> CharacterCollection
        {
            get { return _characterSCDVM.ItemCollection; }
        }

        public ObservableCollection<WeaponDataViewModel> LeftWeaponCollection
        {
            get { return _leftWeaponSCDVM.ItemCollection; }
        }

        public ObservableCollection<WeaponDataViewModel> RightWeaponCollection
        {
            get { return _rightWeaponSCDVM.ItemCollection; }
        }

        public CharacterDataViewModel CharacterSelected
        {
            get { return _characterSCDVM.ItemSelected; }
            set
            {
                _characterSCDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }

        public WeaponDataViewModel LeftWeaponSelected
        {
            get { return _leftWeaponSCDVM.ItemSelected; }
            set
            {
                _leftWeaponSCDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }

        public WeaponDataViewModel RightWeaponSelected
        {
            get { return _rightWeaponSCDVM.ItemSelected; }
            set
            {
                _rightWeaponSCDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        } 
        #endregion

        #region Properties til understøttelse af Command-kontroller
        public ICommand DropLeftWeaponCommandObj
        {
            get { return _dropLeftWeaponCommand; }
        }

        public ICommand DropRightWeaponCommandObj
        {
            get { return _dropRightWeaponCommand; }
        }
        #endregion

        #region Hjælpe-metoder
        private string WeaponDescription(WeaponDataViewModel weaponDVM)
        {
            if (weaponDVM == null) return "(no weapon)";

            return $"{weaponDVM.Description},  {weaponDVM.DamageDescription}";
        }
        #endregion

        #region Hjælpeklasse
        private class DequipWeaponCommand : CommandBase
        {
            private SelectionControlDVM<Weapon, WeaponDataViewModel> _scdvm;

            public DequipWeaponCommand(SelectionControlDVM<Weapon, WeaponDataViewModel> scdvm)
            {
                _scdvm = scdvm;
            }

            protected override void Execute()
            {
                _scdvm.NullifySelection();
            }
        } 
        #endregion
    }
}