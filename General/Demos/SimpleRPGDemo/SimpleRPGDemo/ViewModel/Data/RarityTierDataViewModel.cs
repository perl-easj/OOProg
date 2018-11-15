using SimpleRPGDemo.Data;
using SimpleRPGDemo.ViewModel.Base;

namespace SimpleRPGDemo.ViewModel.Data
{
    public class RarityTierDataViewModel : DataViewModelAppBase<RarityTier>
    {
        public RarityTierDataViewModel(RarityTier obj) : base(obj)
        {
        }

        public string Description
        {
            get { return DataObject.Description; }
            set
            {
                DataObject.Description = value;
                OnPropertyChanged();
            }
        }

        public override string HeaderText
        {
            get { return Description; }
        }

        public override string ContentText
        {
            get { return ""; }
        }
    }
}