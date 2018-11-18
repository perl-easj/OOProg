// HISTORIK:
// v.1.0 : Oprettet
// v.2.0 : Omskrevet ved brug af DataViewModelBase
//

using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class WeaponDataViewModel : DataViewModelBase<Weapon>
    {
        public WeaponDataViewModel() { }

        public WeaponDataViewModel(Weapon dataObject) : base(dataObject)
        {
        }

        public string WeaponModelDesc
        {
            get { return DataObject.WeaponModel?.Description; }
        }

        public string WeaponTypeDesc
        {
            get { return DataObject.WeaponModel?.WeaponType?.Description; }
        }

        public string WeaponDamageDesc
        {
            get { return $"Damage : {DataObject.WeaponModel?.MinDamage} - {DataObject.WeaponModel?.MaxDamage}"; }
        }

        public string WeaponOwner
        {
            get { return $"Owned by {DataObject.Character?.Name}"; }
        }

        public override string ToString()
        {
            return $"{WeaponModelDesc}  ({WeaponOwner})";
        }
    }

    #region Version 1.0
    //Version 1.0
    // 
    //public class WeaponDataViewModel : INotifyPropertyChanged
    //{
    //    private Weapon _weapon;

    //    public WeaponDataViewModel(Weapon weapon)
    //    {
    //        _weapon = weapon;
    //    }

    //    public WeaponDataViewModel()
    //    {
    //        _weapon = null;
    //    }

    //    public string WeaponModelDesc
    //    {
    //        get { return _weapon.WeaponModel?.Description; }
    //    }

    //    public string WeaponTypeDesc
    //    {
    //        get { return _weapon.WeaponModel?.WeaponType?.Description; }
    //    }

    //    public string WeaponDamageDesc
    //    {
    //        get { return $"Damage : {_weapon.WeaponModel?.MinDamage} - {_weapon.WeaponModel?.MaxDamage}"; }
    //    }

    //    public string WeaponOwner
    //    {
    //        get { return $"Owned by {_weapon.Character?.Name}"; }
    //    }

    //    public override string ToString()
    //    {
    //        return $"{WeaponModelDesc}  ({WeaponOwner})";
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //} 
    #endregion
}