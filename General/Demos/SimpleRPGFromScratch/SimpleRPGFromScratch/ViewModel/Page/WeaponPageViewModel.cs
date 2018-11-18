// HISTORIK:
// v.1.0 : Oprettet, ingen data view model
// v.2.0 : Omskrevet til at implementere INotifyPropertyChanged
// v.3.0 : Omskrevet til at benytte WeaponDataViewModel
// v.4.0 : Omskrevet til at benytte PageViewModelBase
//

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using SimpleRPGFromScratch.Model.Base;
using SimpleRPGFromScratch.Model.Catalog;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Data;

namespace SimpleRPGFromScratch.ViewModel.Page
{
    public class WeaponPageViewModel : PageViewModelBase<Weapon, WeaponDataViewModel>
    {
        protected override WeaponDataViewModel GenerateDataViewModel(Weapon obj)
        {
            return new WeaponDataViewModel(obj);
        }

        protected override ICatalog<Weapon> GenerateCatalog()
        {
            return new WeaponCatalog();
        }
    }

    #region Version 3.0
    //Version 3.0
    //
    //public class WeaponPageViewModelv3 : INotifyPropertyChanged
    //{
    //    private WeaponCatalog _weaponCatalog;
    //    private WeaponDataViewModel _weaponSelected;

    //    public WeaponPageViewModelv3()
    //    {
    //        _weaponCatalog = new WeaponCatalog();
    //        _weaponSelected = null;
    //    }

    //    public List<WeaponDataViewModel> WeaponCollection
    //    {
    //        get { return _weaponCatalog.All.Select(w => new WeaponDataViewModel(w)).ToList(); }
    //    }

    //    public WeaponDataViewModel WeaponSelected
    //    {
    //        get { return _weaponSelected; }
    //        set
    //        {
    //            _weaponSelected = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //} 
    #endregion

    #region Version 2.0
    //Version 2.0
    //
    //public class WeaponPageViewModelv2 : INotifyPropertyChanged
    //{
    //    private WeaponCatalog _weaponCatalog;
    //    private Weapon _weaponSelected;

    //    public WeaponPageViewModelv2()
    //    {
    //        _weaponCatalog = new WeaponCatalog();
    //        _weaponSelected = null;
    //    }

    //    public List<Weapon> WeaponCollection
    //    {
    //        get { return _weaponCatalog.All; }
    //    }

    //    public Weapon WeaponSelected
    //    {
    //        get { return _weaponSelected; }
    //        set
    //        {
    //            _weaponSelected = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //} 
    #endregion

    #region Version 1.0
    //Version 1.0
    //
    //public class WeaponPageViewModelv1
    //{
    //    private WeaponCatalog _weaponCatalog;
    //    private Weapon _weaponSelected;

    //    public WeaponPageViewModelv1()
    //    {
    //        _weaponCatalog = new WeaponCatalog();
    //        _weaponSelected = null;
    //    }

    //    public List<Weapon> WeaponCollection
    //    {
    //        get { return _weaponCatalog.All; }
    //    }

    //    public Weapon WeaponSelected
    //    {
    //        get { return _weaponSelected; }
    //        set { _weaponSelected = value; }
    //    }
    //} 
    #endregion
}