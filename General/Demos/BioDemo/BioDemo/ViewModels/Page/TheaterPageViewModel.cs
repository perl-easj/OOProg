using BioDemo.Data.Domain;
using BioDemo.Models.App;
using BioDemo.ViewModels.Base;
using BioDemo.ViewModels.Data;
using Data.InMemory.Interfaces;

namespace BioDemo.ViewModels.Page
{
    /// <summary>
    /// Page view model class for Theater objects.
    /// Will be used as Data Context in the Theater view.
    /// </summary>
    public class TheaterPageViewModel : PageViewModelAppBase<Theater>
    {
        #region Constructor
        public TheaterPageViewModel() : base(DomainModel.Instance.TheaterCatalog)
        {
        }
        #endregion

        #region Methods
        public override IDataWrapper<Theater> CreateDataViewModel(Theater obj)
        {
            return new TheaterDataViewModel(obj);
        } 
        #endregion
    }
}