using System.Collections.ObjectModel;
using System.Linq;
using SimpleRPGFromScratch.Helpers;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Control;
using SimpleRPGFromScratch.ViewModel.Page;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class WeaponModelDataViewModel : DataViewModelAppBase<WeaponModel>
    {
        private SliderDataViewModel<int> _minDamageSliderDVM;
        private SliderDataViewModel<int> _maxDamageSliderDVM;
        private IntSliderDataViewModel _jewelSocketsSliderDVM;
        private ComboBoxDataViewModel<RarityTier, RarityTierDataViewModel, RarityTierPageViewModel> _rarityTierCBDVM;
        private ComboBoxDataViewModel<WeaponType, WeaponTypeDataViewModel, WeaponTypePageViewModel> _weaponTypeCBDVM;

        public WeaponModelDataViewModel() : this(null)
        {
        }

        public WeaponModelDataViewModel(WeaponModel weaponModel) : base(weaponModel)
        {
            _minDamageSliderDVM = new SliderDataViewModel<int>(
                new Scaler<int>(WeaponModel.LegalDamageValues, (a, b) => a < b),
                WeaponModel.LegalDamageValues.Count - 1,
                () => DataObject().MinDamage,
                val =>
                {
                    DataObject().MinDamage = val;
                    OnPropertyChanged(nameof(MinDamageIndex));
                    OnPropertyChanged(nameof(MinDamage));
                });

            _maxDamageSliderDVM = new SliderDataViewModel<int>(
                new Scaler<int>(WeaponModel.LegalDamageValues, (a, b) => a < b),
                WeaponModel.LegalDamageValues.Count - 1,
                () => DataObject().MaxDamage,
                val =>
                {
                    DataObject().MaxDamage = val;
                    OnPropertyChanged(nameof(MaxDamageIndex));
                    OnPropertyChanged(nameof(MaxDamage));
                });

            _jewelSocketsSliderDVM = new IntSliderDataViewModel(
                WeaponModel.MaxNoOfJewelSockets,
                () => DataObject().JewelSockets,
                val =>
                {
                    DataObject().JewelSockets = val;
                    OnPropertyChanged(nameof(JewelSocketsIndex));
                    OnPropertyChanged(nameof(JewelSockets));
                });

            _rarityTierCBDVM = new ComboBoxDataViewModel<RarityTier, RarityTierDataViewModel, RarityTierPageViewModel>(
                () => DataObject().RarityTierId,
                val =>
                {
                    DataObject().RarityTierId = val;
                    OnPropertyChanged(nameof(RaritySelected));
                });

            _weaponTypeCBDVM = new ComboBoxDataViewModel<WeaponType, WeaponTypeDataViewModel, WeaponTypePageViewModel>(
                () => DataObject().WeaponTypeId,
                val =>
                {
                    DataObject().WeaponTypeId = val;
                    OnPropertyChanged(nameof(WeaponTypeSelected));
                });
        }

        public string Description
        {
            get { return DataObject().Description; }
            set
            {
                DataObject().Description = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<RarityTierDataViewModel> RarityCollection
        {
            get { return _rarityTierCBDVM.ItemCollection; }
        }

        public RarityTierDataViewModel RaritySelected
        {
            get { return _rarityTierCBDVM.ItemSelected; }
            set
            {
                _rarityTierCBDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<WeaponTypeDataViewModel> WeaponTypeCollection
        {
            get { return _weaponTypeCBDVM.ItemCollection; }
        }

        public WeaponTypeDataViewModel WeaponTypeSelected
        {
            get { return _weaponTypeCBDVM.ItemSelected; }
            set
            {
                _weaponTypeCBDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }

        public int MinDamageIndex
        {
            get { return _minDamageSliderDVM.SliderIndex; }
            set { _minDamageSliderDVM.SliderIndex = value; }
        }

        public int MaxDamageIndex
        {
            get { return _maxDamageSliderDVM.SliderIndex; }
            set { _maxDamageSliderDVM.SliderIndex = value; }
        }

        public int JewelSocketsIndex
        {
            get { return _jewelSocketsSliderDVM.SliderIndex; }
            set { _jewelSocketsSliderDVM.SliderIndex = value; }
        }

        public int MinDamageScaleMax
        {
            get { return _minDamageSliderDVM.SliderScaleMax; }
        }

        public int MaxDamageScaleMax
        {
            get { return _maxDamageSliderDVM.SliderScaleMax; }
        }

        public int JewelSocketsScaleMax
        {
            get { return _jewelSocketsSliderDVM.SliderScaleMax; }
        }

        public string MinDamage
        {
            get { return _minDamageSliderDVM.SliderText; }
        }

        public string MaxDamage
        {
            get { return _maxDamageSliderDVM.SliderText; }
        }

        public string JewelSockets
        {
            get { return _jewelSocketsSliderDVM.SliderText; }
        }

        protected override string ItemDescription
        {
            get { return $"{Description}  ({WeaponTypeSelected?.Description}) [{RaritySelected?.Description}]"; }
        }
    }
}