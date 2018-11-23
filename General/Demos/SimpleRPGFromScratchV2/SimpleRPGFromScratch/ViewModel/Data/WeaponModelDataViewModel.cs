// HISTORIK:
// v.1.0 : Oprettet
// v.2.0 : Omskrevet ved brug af DataViewModelBase
//

using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class WeaponModelDataViewModel : DataViewModelAppBase<WeaponModel>
    {
        public WeaponModelDataViewModel() { }

        public WeaponModelDataViewModel(WeaponModel weaponModel) : base(weaponModel)
        {
        }

        public string Description
        {
            get { return DataObject().Description; }
        }

        public string WeaponTypeDesc
        {
            get { return DataObject().WeaponType?.Description; }
        }

        public string WeaponDamageDesc
        {
            get { return $"Damage : {DataObject().MinDamage} - {DataObject().MaxDamage}"; }
        }

        protected override string ItemDescription
        {
            get { return $"{Description}  ({WeaponTypeDesc}) [{DataObject().RarityTier?.Description}]"; }
        }
    }

    #region Version 1.0
    //Version 1.0
    //
    //public class WeaponModelDataViewModel : INotifyPropertyChanged
    //{
    //    private WeaponModel _weaponModel;

    //    public WeaponModelDataViewModel(WeaponModel weaponModel)
    //    {
    //        _weaponModel = weaponModel;
    //    }

    //    public WeaponModelDataViewModel()
    //    {
    //        _weaponModel = null;
    //    }

    //    public string Description
    //    {
    //        get { return _weaponModel.Description; }
    //    }

    //    public string WeaponTypeDesc
    //    {
    //        get { return _weaponModel.WeaponType?.Description; }
    //    }

    //    public string WeaponDamageDesc
    //    {
    //        get { return $"Damage : {_weaponModel.MinDamage} - {_weaponModel.MaxDamage}"; }
    //    }

    //    public override string ToString()
    //    {
    //        return $"{Description}  ({WeaponTypeDesc})";
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //} 
    #endregion
}