using System.Collections.ObjectModel;
using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Control;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class JewelModelDataViewModel : DataViewModelAppBase<JewelModel>
    {
        #region Instance fields
        private const int BaseDamageScaleFactor = 5;

        private IntSliderDataViewModel _baseDamageSliderDVM;
        private SelectionControlDVM<RarityTier, RarityTierDataViewModel> _rarityTierSCDVM;
        #endregion

        #region Constructor
        public JewelModelDataViewModel()
        {
            _rarityTierSCDVM = new SelectionControlDVM<RarityTier, RarityTierDataViewModel>(
                () => DataObject().RarityTierId,
                val =>
                {
                    DataObject().RarityTierId = DomainClassBase<RarityTier>.IdOrNullId(val);
                    OnPropertyChanged(nameof(RaritySelected));
                });

            _baseDamageSliderDVM = new IntSliderDataViewModel(
                JewelModel.MaxBaseDamage,
                BaseDamageScaleFactor,
                () => DataObject().BaseDamage,
                val =>
                {
                    DataObject().BaseDamage = val;
                    OnPropertyChanged(nameof(BaseDamageIndex));
                    OnPropertyChanged(nameof(BaseDamage));
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
            get { return $"{Description} [{DataObject().RarityTier?.Description}]"; }
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
        #endregion

        #region Properties til understøttelse af Slider-kontroller
        public int BaseDamageIndex
        {
            get { return _baseDamageSliderDVM.SliderIndex; }
            set { _baseDamageSliderDVM.SliderIndex = value; }
        }

        public string BaseDamage
        {
            get { return _baseDamageSliderDVM.SliderText; }
        }

        public int BaseDamageScaleMax
        {
            get { return _baseDamageSliderDVM.SliderScaleMax; }
        } 
        #endregion
    }
}