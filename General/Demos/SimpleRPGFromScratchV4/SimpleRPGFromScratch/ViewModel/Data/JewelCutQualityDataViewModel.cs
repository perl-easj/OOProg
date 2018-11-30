using SimpleRPGFromScratch.Helpers;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Control;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class JewelCutQualityDataViewModel : DataViewModelAppBase<JewelCutQuality>
    {
        private SliderDataViewModel<double> _factorSliderDVM;

        public JewelCutQualityDataViewModel() : this(null)
        {
        }

        public JewelCutQualityDataViewModel(JewelCutQuality dataObject) : base(dataObject)
        {
            _factorSliderDVM = new SliderDataViewModel<double>(
                new Scaler<double>(JewelCutQuality.LegalCutQualityValues, (a, b) => a < b),
                JewelCutQuality.LegalCutQualityValues.Count - 1,
                () => DataObject().Factor,
                val =>
                {
                    DataObject().Factor = val;
                    OnPropertyChanged(nameof(FactorIndex));
                    OnPropertyChanged(nameof(Factor));
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
            get  { return $"{Description} ({Factor})";}
        }
    }
}