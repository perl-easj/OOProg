using BioDemo.Data.Domain;
using BioDemo.Models.Base;

namespace BioDemo.Models.App
{
    /// <summary>
    /// This class represents the entire domain model, defined as consisting
    /// of the set of catalogs in which domain objects are stored.
    /// </summary>
    public class DomainModel
    {
        #region Singleton implementation
        private static DomainModel _instance;
        public static DomainModel Instance
        {
            get
            {
                _instance = _instance ?? (_instance = new DomainModel());
                return _instance;
            }
        }
        #endregion

        #region Constructor
        private DomainModel()
        {
            MovieCatalog = new CatalogAppBase<Movie>();
            TheaterCatalog = new CatalogAppBase<Theater>();
            ShowCatalog = new CatalogAppBase<Show>();
            TicketCatalog = new CatalogAppBase<Ticket>();
        }
        #endregion

        #region Properties
        public CatalogAppBase<Movie> MovieCatalog { get; }
        public CatalogAppBase<Theater> TheaterCatalog { get; }
        public CatalogAppBase<Show> ShowCatalog { get; }
        public CatalogAppBase<Ticket> TicketCatalog { get; }

        #endregion

        #region Persistency methods
        public async void LoadAsync()
        {
            await MovieCatalog.LoadAsync();
            await TheaterCatalog.LoadAsync();
            await ShowCatalog.LoadAsync();
            await TicketCatalog.LoadAsync();
        }

        public async void SaveAsync()
        {
            await MovieCatalog.SaveAsync();
            await TheaterCatalog.SaveAsync();
            await ShowCatalog.SaveAsync();
            await TicketCatalog.SaveAsync();
        }
        #endregion
    }
}