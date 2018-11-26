using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class JewelDataViewModel : DataViewModelAppBase<Jewel>
    {
        public JewelDataViewModel() { }

        public JewelDataViewModel(Jewel dataObject) : base(dataObject)
        {
        }

        public string Description
        {
            get { return DataObject().JewelModel?.Description; }
        }

        public string CutQualityDesc
        {
            get { return DataObject().CutQuality?.Description; }
        }

        public string DamageDesc
        {
            get { return $"Base damage :  {DataObject().JewelModel?.BaseDamage}"; }
        }

        public string JewelDamageDesc
        {
            get { return $"Jewel damage :  {DataObject().BaseDamage:F2}"; }
        }

        public string WeaponDesc
        {
            get { return $"Socketed on weapon:  {(DataObject().Weapon == null ? "(none)" : DataObject().Weapon.ToString())}"; }
        }

        protected override string ItemDescription
        {
            get { return $"{Description} ({CutQualityDesc})"; ; }
        }
    }
}