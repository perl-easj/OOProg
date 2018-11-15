using System;
using System.Threading.Tasks;
using SimpleRPGDemo.Model.Catalog;

namespace SimpleRPGDemo.Model.App
{
    public class DomainModel
    {
        #region Instance fields
        public RarityTierCatalog RarityTiers { get; }
        #endregion

        #region Events
        public event Action LoadBegins;
        public event Action LoadEnds;
        #endregion

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

        public static DomainModel Catalogs { get { return Instance; } }
        #endregion

        #region Constructor
        private DomainModel()
        {
            RarityTiers = new RarityTierCatalog();
        }
        #endregion


        #region Persistency methods
        public async Task LoadAsync()
        {
            LoadBegins?.Invoke();

            await RarityTiers.LoadAsync();

            LoadEnds?.Invoke();
        }
        #endregion
    }
}