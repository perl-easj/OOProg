using SimpleRPGFromScratch.Helpers;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Control;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class JewelCutQualityDataViewModel : DataViewModelAppBase<JewelCutQuality>
    {
        #region Instance fields
        private SliderDataViewModel<double> _factorSliderDVM;
        #endregion

        #region Initialise
        public override void Initialise()
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
            get { return $"{Description} ({Factor})"; }
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