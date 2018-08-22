using BioDemo.Data.Domain;
using BioDemo.Models.App;
using BioDemo.ViewModels.Base;
using BioDemo.ViewModels.Data;
using Data.InMemory.Interfaces;

namespace BioDemo.ViewModels.Page
{
    /// <summary>
    /// Page view model class for Show objects.
    /// Will be used as Data Context in the Show view.
    /// </summary>
    public class ShowPageViewModel : PageViewModelAppBase<Show>
    {
        #region Constructor
        public ShowPageViewModel() : base(DomainModel.Instance.ShowCatalog)
        {
        }
        #endregion

        #region Methods
        public override IDataWrapper<Show> CreateDataViewModel(Show obj)
        {
            return new ShowDataViewModel(obj);
        } 
        #endregion
    }
}