namespace AddOns.Filtering.Interfaces
{
    /// <summary>
    /// Interface for a filtering service. Note that an instance
    /// of the service only applies to objects of type T.
    /// </summary>
    /// <typeparam name="T">
    /// Type of objects to which the service applies.
    /// </typeparam>
    public interface IFilterService<T>
    {
        /// <summary>
        /// Adds a filter collection with the given ID.
        /// </summary>
        /// <param name="filterCollId">
        /// Filter collection identifier
        /// </param>
        void Add(string filterCollId);

        /// <summary>
        /// Remove the filter collection with the given ID.
        /// </summary>
        /// <param name="filterCollId">
        /// Filter collection identifier
        /// </param>
        void Remove(string filterCollId);

        /// <summary>
        /// Gets the filter collection with the given ID.
        /// </summary>
        /// <param name="filterCollId">
        /// Filter collection identifier
        /// </param>
        IFilterCollection<T> Get(string filterCollId);
    }
}