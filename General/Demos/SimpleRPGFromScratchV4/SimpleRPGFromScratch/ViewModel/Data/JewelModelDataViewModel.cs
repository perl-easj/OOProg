using System.Collections.ObjectModel;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Control;
using SimpleRPGFromScratch.ViewModel.Page;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class JewelModelDataViewModel : DataViewModelAppBase<JewelModel>
    {
        private const int BaseDamageScaleFactor = 5;

        private IntSliderDataViewModel _baseDamageSliderDVM;
        private ComboBoxDataViewModel<RarityTier, RarityTierDataViewModel, RarityTierPageViewModel> _rarityTierCBDVM;

        public JewelModelDataViewModel() : this(null)
        {
        }

        public JewelModelDataViewModel(JewelModel dataObject) : base(dataObject)
        {
            _rarityTierCBDVM = new ComboBoxDataViewModel<RarityTier, RarityTierDataViewModel, RarityTierPageViewModel>(
                () => DataObject().RarityTierId,
                val =>
                {
                    DataObject().RarityTierId = val;
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

        protected override string ItemDescription
        {
            get { return $"{Description} [{DataObject().RarityTier?.Description}]" ; }
        }
    }
}