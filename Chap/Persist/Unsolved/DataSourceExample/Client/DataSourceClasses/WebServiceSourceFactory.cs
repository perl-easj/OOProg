namespace Client
{
    /// <summary>
    /// Implementation of data source factory interface,
    /// using a web service implementation.
    /// Responsibilities:
    /// 1) Providing data source implementations of the 
    ///    same kind for different object types, without
    ///    exposing the specific implementation
    /// </summary>
    public class WebServiceSourceFactory : IDataSourceFactory
    {
        private string _url;

        public WebServiceSourceFactory(string url)
        {
            _url = url;
        }

        public IDataSourceAsync<Movie> MovieDataSource()
        {

            return new WebServiceSourceAsync<Movie>(_url, "api", "Movies");
        }

        public IDataSourceAsync<Studio> StudioDataSource()
        {
            return new WebServiceSourceAsync<Studio>(_url, "api", "Studios");
        }
    }
}