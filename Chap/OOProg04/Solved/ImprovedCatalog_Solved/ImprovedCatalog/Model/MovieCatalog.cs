using ImprovedCatalog.DomainClasses;

namespace ImprovedCatalog.Model
{
    /// <summary>
    /// Movie-specific Catalog
    /// </summary>
    public class MovieCatalog : CatalogAppBase<int, Movie>
    {
        public MovieCatalog(bool loadTestData = false)
            : base(loadTestData)
        {
        }

        protected override void LoadTestData()
        {
            Movie movieA = new Movie(1, "Alien", 1979, "20th Century Fox");
            Movie movieB = new Movie(2, "Blade Runner", 1982, "Warner Brothers");
            Movie movieC = new Movie(3, "Contact", 1997, "Warner Brothers");
            Movie movieD = new Movie(4, "Donnie Darko", 2001, "Newmarket Films");

            Insert(movieA.ISMN, movieA);
            Insert(movieB.ISMN, movieB);
            Insert(movieC.ISMN, movieC);
            Insert(movieD.ISMN, movieD);
        }
    }
}