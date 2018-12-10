using System.Collections.ObjectModel;
using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.Helpers;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Control;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class WeaponJewelMatchDataViewModel : DataViewModelAppBase<WeaponJewelMatch>
    {
        #region Instance fields
        private SliderDataViewModel<double> _factorSliderDVM;
        private SelectionControlDVM<JewelModel, JewelModelDataViewModel> _jewelModelSCDVM;
        private SelectionControlDVM<WeaponModel, WeaponModelDataViewModel> _weaponModelSCDVM;
        #endregion

        #region Initialise
        public override void Initialise()
        {
            _jewelModelSCDVM = new SelectionControlDVM<JewelModel, JewelModelDataViewModel>(
                () => DataObject().JewelModelId,
                val =>
                {
                    DataObject().JewelModelId = DomainClassBase<JewelModel>.IdOrNullId(val);
                    OnPropertyChanged(nameof(JewelModelSelected));
                });

            _weaponModelSCDVM = new SelectionControlDVM<WeaponModel, WeaponModelDataViewModel>(
                () => DataObject().WeaponModelId,
                val =>
                {
                    DataObject().WeaponModelId = DomainClassBase<WeaponModel>.IdOrNullId(val);
                    OnPropertyChanged(nameof(WeaponModelSelected));
                });

            _factorSliderDVM = new SliderDataViewModel<double>(
                new Scaler<double>(WeaponJewelMatch.LegalMatchFactors, (a, b) => a < b),
                WeaponJewelMatch.LegalMatchFactors.Count - 1,
                () => DataObject().Factor,
                val =>
                {
                    DataObject().Factor = val;
                    OnPropertyChanged(nameof(FactorIndex));
                    OnPropertyChanged(nameof(Factor));
                });
        }
        #endregion

        #region Simple properties
        protected override string ItemDescription
        {
            get { return $"{DataObject().WeaponModel?.Description} / {DataObject().JewelModel?.Description}"; }
        }
        #endregion

        #region Properties til understøttelse af Collection-kontroller
        public ObservableCollection<WeaponModelDataViewModel> WeaponModelCollection
        {
            get { return _weaponModelSCDVM.ItemCollection; }
        }

        public WeaponModelDataViewModel WeaponModelSelected
        {
            get { return _weaponModelSCDVM.ItemSelected; }
            set
            {
                _weaponModelSCDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<JewelModelDataViewModel> JewelModelCollection
        {
            get { return _jewelModelSCDVM.ItemCollection; }
        }

        public JewelModelDataViewModel JewelModelSelected
        {
            get { return _jewelModelSCDVM.ItemSelected; }
            set
            {
                _jewelModelSCDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Properties til understøttelse af Slider-kontroller
        public int FactorIndex
        {
            get { return _factorSliderDVM.SliderIndex; }
            set { _factorSliderDVM.SliderIndex = value; }
        }

        public string Factor
        {
            get { return _factorSliderDVM.SliderText; }
        }

        public int FactorScaleMax
        {
            get { return _factorSliderDVM.SliderScaleMax; }
        }
        #endregion
    }
}