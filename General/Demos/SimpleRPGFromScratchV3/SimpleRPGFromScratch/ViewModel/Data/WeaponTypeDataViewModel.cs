using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class WeaponTypeDataViewModel : DataViewModelAppBase<WeaponType>
    {
        public WeaponTypeDataViewModel() { }

        public WeaponTypeDataViewModel(WeaponType dataObject) : base(dataObject)
        {
        }

        public string Description
        {
            get { return DataObject().Description; }
        }

        public string HandsNeededDesc
        {
            get { return $"{DataObject().HandsRequired}-handed weapon"; }
        }

        protected override string ItemDescription
        {
            get { return Description; }
        }
    }
}