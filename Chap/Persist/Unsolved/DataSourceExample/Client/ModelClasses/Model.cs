using System;

namespace Client
{
    /// <summary>
    /// Implementation of the data model.
    /// Responsibilities:
    /// 1) Perform model-wide operations like Load and Print
    /// 2) Provide an access point to all Catalogs in model
    /// 3) Ensure that all Catalogs use the same data source
    /// </summary>
    public class Model : IModel
    {
        private ICatalog<Movie> _movieCatalog;
        private ICatalog<Studio> _studioCatalog;

        public Model(IDataSourceFactory sourceFactory)
        {
            _movieCatalog = new Catalog<Movie>(sourceFactory.MovieDataSource());
            _studioCatalog = new Catalog<Studio>(sourceFactory.StudioDataSource());
        }

        public ICatalog<Movie> MovieCatalog
        {
            get { return _movieCatalog; }
            set { _movieCatalog = value; }
        }

        public ICatalog<Studio> StudioCatalog
        {
            get { return _studioCatalog; }
            set { _studioCatalog = value; }
        }

        public void LoadModel()
        {
            _movieCatalog?.Load();
            _studioCatalog?.Load();
        }

        public void PrintModelContent()
        {
            Console.WriteLine("Movies:");
            if (_movieCatalog == null)
            {
                Console.WriteLine("Oops, Movie catalog was not initialised...");
            }
            else
            {
                foreach (Movie m in _movieCatalog.All)
                {
                    Console.WriteLine(m);
                }
            }

            Console.WriteLine("Studios:");
            if (_studioCatalog == null)
            {
                Console.WriteLine("Oops, Studio catalog was not initialised...");
            }
            else
            {
                foreach (Studio s in _studioCatalog.All)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}