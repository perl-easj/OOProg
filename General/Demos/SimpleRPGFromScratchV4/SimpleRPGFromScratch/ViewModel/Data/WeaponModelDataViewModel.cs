using System.Collections.ObjectModel;
using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.Helpers;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Control;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class WeaponModelDataViewModel : DataViewModelAppBase<WeaponModel>
    {
        #region Instance fields
        private SliderDataViewModel<int> _minDamageSliderDVM;
        private SliderDataViewModel<int> _maxDamageSliderDVM;
        private IntSliderDataViewModel _jewelSocketsSliderDVM;
        private SelectionControlDVM<RarityTier, RarityTierDataViewModel> _rarityTierSCDVM;
        private SelectionControlDVM<WeaponType, WeaponTypeDataViewModel> _weaponTypeSCDVM;
        #endregion

        #region Initialise
        public override void Initialise()
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
                },
                CheckRulesMinDamage);

            _maxDamageSliderDVM = new SliderDataViewModel<int>(
                new Scaler<int>(WeaponModel.LegalDamageValues, (a, b) => a < b),
                WeaponModel.LegalDamageValues.Count - 1,
                () => DataObject().MaxDamage,
                val =>
                {
                    DataObject().MaxDamage = val;
                    OnPropertyChanged(nameof(MaxDamageIndex));
                    OnPropertyChanged(nameof(MaxDamage));
                },
                CheckRulesMaxDamage);

            _jewelSocketsSliderDVM = new IntSliderDataViewModel(
                WeaponModel.MaxNoOfJewelSockets,
                () => DataObject().JewelSockets,
                val =>
                {
                    DataObject().JewelSockets = val;
                    OnPropertyChanged(nameof(JewelSocketsIndex));
                    OnPropertyChanged(nameof(JewelSockets));
                });

            _rarityTierSCDVM = new SelectionControlDVM<RarityTier, RarityTierDataViewModel>(
                () => DataObject().RarityTierId,
                val =>
                {
                    DataObject().RarityTierId = DomainClassBase<RarityTier>.IdOrNullId(val);
                    OnPropertyChanged(nameof(RaritySelected));
                });

            _weaponTypeSCDVM = new SelectionControlDVM<WeaponType, WeaponTypeDataViewModel>(
                () => DataObject().WeaponTypeId,
                val =>
                {
                    DataObject().WeaponTypeId = DomainClassBase<WeaponType>.IdOrNullId(val);
                    OnPropertyChanged(nameof(WeaponTypeSelected));
                });
        }
        #endregion

        #region Simple properties
        public string Description
        {
            get { return DataObject().Description; }
            set
            {
                DataObject().Description = value;
                OnPropertyChanged();
            }
        }

        protected override string ItemDescription
        {
            get { return $"{Description}  ({WeaponTypeSelected?.Description}) [{RaritySelected?.Description}]"; }
        }
        #endregion

        #region Properties til understøttelse af Collection-kontroller
        public ObservableCollection<RarityTierDataViewModel> RarityCollection
        {
            get { return _rarityTierSCDVM.ItemCollection; }
        }

        public RarityTierDataViewModel RaritySelected
        {
            get { return _rarityTierSCDVM.ItemSelected; }
            set
            {
                _rarityTierSCDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<WeaponTypeDataViewModel> WeaponTypeCollection
        {
            get { return _weaponTypeSCDVM.ItemCollection; }
        }

        public WeaponTypeDataViewModel WeaponTypeSelected
        {
            get { return _weaponTypeSCDVM.ItemSelected; }
            set
            {
                _weaponTypeSCDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Properties til understøttelse af Slider-kontroller
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
        #endregion

        private bool CheckRulesMinDamage(int newVal)
        {
            return DataObject().CheckMinDamage(newVal);
        }

        private bool CheckRulesMaxDamage(int newVal)
        {
            return DataObject().CheckMaxDamage(newVal);
        }
    }
}