namespace Client
{
    /// <summary>
    /// Interface for a factory class, which can produce
    /// data source implementations for different objects
    /// using the same implementation, without assuming 
    /// a specific implementation.
    /// </summary>
    public interface IDataSourceFactory
    {
        IDataSourceAsync<Movie> MovieDataSource();
        IDataSourceAsync<Studio> StudioDataSource();
    }
}