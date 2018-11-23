using System;
using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class JewelCutQualityDataViewModel : DataViewModelAppBase<JewelCutQuality>
    {
        public JewelCutQualityDataViewModel() { }

        public JewelCutQualityDataViewModel(JewelCutQuality dataObject) : base(dataObject)
        {
        }

        public string Description
        {
            get { return DataObject().Description; }
        }

        public string Factor
        {
            get { return $"{DataObject().Factor:F2}"; }
            set
            {
                double newFactor = Double.Parse(value); // Hmm...
                DataObject().Factor = newFactor;
                OnPropertyChanged();
            }
        }

        public string FactorDesc
        {
            get { return $"Damage factor :  {DataObject().Factor}"; }
        }

        protected override string ItemDescription
        {
            get  { return Description;}
        }
    }
}