using ImprovedCatalog.CatalogBaseClasses.Catalogs;
using ImprovedCatalog.CatalogBaseClasses.Interfaces;
using ImprovedCatalog.DomainClasses;

namespace ImprovedCatalog.Model
{
    /// <summary>
    /// Class which models an entire "domain model", which is defined
    /// as consisting of collections of objects; each collection consists
    /// of objects of one specific type.
    /// </summary>
    public class DomainModel
    {
        public IAll<Car> Cars { get; }
        public IAll<Movie> Movies { get; }

        public DomainModel(bool loadTestData = false)
        {
            Cars = new CarCatalog(loadTestData);
            Movies = new MovieCatalog(loadTestData);
        }
    }
}