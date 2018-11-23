using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class WeaponJewelMatchDataViewModel : DataViewModelAppBase<WeaponJewelMatch>
    {
        public WeaponJewelMatchDataViewModel() { }

        public WeaponJewelMatchDataViewModel(WeaponJewelMatch dataObject) : base(dataObject)
        {
        }

        public string JewelDesc
        {
            get { return DataObject().JewelModel?.Description; }
        }

        public string WeaponDesc
        {
            get { return DataObject().WeaponModel?.Description; }
        }

        public string MatchFactorDesc
        {
            get { return $"Match factor :  {DataObject().Factor:F2}"; }
        }

        protected override string ItemDescription
        {
            get { return $"{JewelDesc} / {WeaponDesc}"; }
        }
    }
}