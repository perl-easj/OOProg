namespace Client
{
    /// <summary>
    /// Implementation of data source factory interface,
    /// using database/entity framework implementation.
    /// Responsibilities:
    /// 1) Providing data source implementations of the 
    ///    same kind for different object types, without
    ///    exposing the specific implementation
    /// </summary>
    public class EntityFrameworkSourceFactory : IDataSourceFactory
    {
        MovieDBContext _movieDBC;

        public EntityFrameworkSourceFactory()
        {
            _movieDBC = new MovieDBContext();
        }

        public IDataSourceAsync<Movie> MovieDataSource()
        {
            return new EntityFrameworkSourceAsync<Movie>(_movieDBC, _movieDBC.Movies);
        }

        public IDataSourceAsync<Studio> StudioDataSource()
        {
            return new EntityFrameworkSourceAsync<Studio>(_movieDBC, _movieDBC.Studios);
        }
    }
}