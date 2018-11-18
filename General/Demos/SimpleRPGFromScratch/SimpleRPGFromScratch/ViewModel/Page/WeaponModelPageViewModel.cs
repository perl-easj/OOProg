// HISTORIK:
// v.1.0 : Oprettet, skrevet ved copy/paste/tilret fra WeaponPageViewModel
// v.2.0 : Omskrevet ved brug af PageViewModelBase
//

using SimpleRPGFromScratch.Model.Base;
using SimpleRPGFromScratch.Model.Catalog;
using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Data;

namespace SimpleRPGFromScratch.ViewModel.Page
{
    public class WeaponModelPageViewModel : PageViewModelBase<WeaponModel, WeaponModelDataViewModel>
    {
        protected override WeaponModelDataViewModel GenerateDataViewModel(WeaponModel obj)
        {
            return new WeaponModelDataViewModel(obj);
        }

        protected override ICatalog<WeaponModel> GenerateCatalog()
        {
            return new WeaponModelCatalog();
        }
    }

    #region Version 1.0
    //Version 1.0
    //
    //public class WeaponModelPageViewModel : INotifyPropertyChanged
    //{
    //    private WeaponModelCatalog _weaponModelCatalog;
    //    private WeaponModelDataViewModel _weaponModelSelected;

    //    public WeaponModelPageViewModel()
    //    {
    //        _weaponModelCatalog = new WeaponModelCatalog();
    //        _weaponModelSelected = null;
    //    }

    //    public List<WeaponModelDataViewModel> WeaponModelCollection
    //    {
    //        get { return _weaponModelCatalog.All.Select(w => new WeaponModelDataViewModel(w)).ToList(); }
    //    }

    //    public WeaponModelDataViewModel WeaponModelSelected
    //    {
    //        get { return _weaponModelSelected; }
    //        set
    //        {
    //            _weaponModelSelected = value;
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
}