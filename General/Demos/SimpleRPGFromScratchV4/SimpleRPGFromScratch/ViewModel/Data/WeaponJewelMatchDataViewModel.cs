using System.Collections.ObjectModel;
using SimpleRPGFromScratch.Helpers;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Control;
using SimpleRPGFromScratch.ViewModel.Page;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class WeaponJewelMatchDataViewModel : DataViewModelAppBase<WeaponJewelMatch>
    {
        private SliderDataViewModel<double> _factorSliderDVM;
        private ComboBoxDataViewModel<JewelModel, JewelModelDataViewModel, JewelModelPageViewModel> _jewelModelCBDVM;
        private ComboBoxDataViewModel<WeaponModel, WeaponModelDataViewModel, WeaponModelPageViewModel> _weaponModelCBDVM;

        public WeaponJewelMatchDataViewModel() : this(null)
        {
        }

        public WeaponJewelMatchDataViewModel(WeaponJewelMatch dataObject) 
        {
            _jewelModelCBDVM = new ComboBoxDataViewModel<JewelModel, JewelModelDataViewModel, JewelModelPageViewModel>(
                () => DataObject().JewelModelId,
                val =>
                {
                    DataObject().JewelModelId = val;
                    OnPropertyChanged(nameof(JewelModelSelected));
                });

            _weaponModelCBDVM = new ComboBoxDataViewModel<WeaponModel, WeaponModelDataViewModel, WeaponModelPageViewModel> (
                () => DataObject().WeaponModelId,
                val =>
                {
                    DataObject().WeaponModelId = val;
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

        public ObservableCollection<WeaponModelDataViewModel> WeaponModelCollection
        {
            get { return _weaponModelCBDVM.ItemCollection; }
        }

        public WeaponModelDataViewModel WeaponModelSelected
        {
            get { return _weaponModelCBDVM.ItemSelected; }
            set
            {
                _weaponModelCBDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<JewelModelDataViewModel> JewelModelCollection
        {
            get { return _jewelModelCBDVM.ItemCollection; }
        }

        public JewelModelDataViewModel JewelModelSelected
        {
            get { return _jewelModelCBDVM.ItemSelected; }
            set
            {
                _jewelModelCBDVM.ItemSelected = value;
                OnPropertyChanged();
            }
        }

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

        protected override string ItemDescription
        {
            get { return $"{DataObject().WeaponModel?.Description} / {DataObject().JewelModel?.Description}"; }
        }
    }
}