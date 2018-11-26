using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class JewelModelDataViewModel : DataViewModelAppBase<JewelModel>
    {
        public JewelModelDataViewModel() { }

        public JewelModelDataViewModel(JewelModel dataObject) : base(dataObject)
        {
        }

        public string Description
        {
            get { return DataObject().Description; }
        }

        public string RarityDesc
        {
            get { return $"Rarity :  {DataObject().RarityTier?.Description}"; }
        }

        public string DamageDesc
        {
            get { return $"Base damage :  {DataObject().BaseDamage}"; }
        }

        protected override string ItemDescription
        {
            get { return Description; }
        }
    }
}