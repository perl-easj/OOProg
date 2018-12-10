using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class WeaponTypeDataViewModel : DataViewModelAppBase<WeaponType>
    {
        #region Initialise
        public override void Initialise()
        {
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

        public bool IsTwoHanded
        {
            get { return DataObject().IsTwoHanded(); }
            set
            {
                DataObject().HandsRequired = value ? 2 : 1;
                OnPropertyChanged();
            }
        }

        protected override string ItemDescription
        {
            get { return $"{Description} ({(IsTwoHanded ? "Two" : "One")}-handed)"; }
        } 
        #endregion
    }
}