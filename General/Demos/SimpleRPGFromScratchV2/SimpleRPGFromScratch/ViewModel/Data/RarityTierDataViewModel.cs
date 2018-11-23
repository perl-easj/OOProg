using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class RarityTierDataViewModel : DataViewModelAppBase<RarityTier>
    {
        public RarityTierDataViewModel() { }

        public RarityTierDataViewModel(RarityTier dataObject) : base(dataObject)
        {
        }

        public string Description
        {
            get { return DataObject().Description; }
        }

        protected override string ItemDescription
        {
            get { return Description; }
        }
    }
}