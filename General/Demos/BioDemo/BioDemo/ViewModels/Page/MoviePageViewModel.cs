using BioDemo.Data.Domain;
using BioDemo.Models.App;
using BioDemo.ViewModels.Base;
using BioDemo.ViewModels.Data;
using Data.InMemory.Interfaces;

namespace BioDemo.ViewModels.Page
{
    /// <summary>
    /// Page view model class for Movie objects.
    /// Will be used as Data Context in the Movie view.
    /// </summary>
    public class MoviePageViewModel : PageViewModelAppBase<Movie>
    {
        #region Constructor
        public MoviePageViewModel() : base(DomainModel.Instance.MovieCatalog)
        {
        }
        #endregion

        #region Methods
        public override IDataWrapper<Movie> CreateDataViewModel(Movie obj)
        {
            return new MovieDataViewModel(obj);
        } 
        #endregion
    }
}