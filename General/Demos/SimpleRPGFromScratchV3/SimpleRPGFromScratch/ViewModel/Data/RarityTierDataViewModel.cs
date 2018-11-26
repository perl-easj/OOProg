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
            set
            {
                DataObject().Description = value;
                OnPropertyChanged();
            }
        }

        protected override string ItemDescription
        {
            get { return Description; }
        }
    }
}