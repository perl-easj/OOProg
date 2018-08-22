using System.Collections.Generic;

namespace AddOns.Filtering.Interfaces
{
    /// <summary>
    /// Interface for managing a collection of filters.
    /// </summary>
    /// <typeparam name="T">
    /// Type of object to which the filters are applied.
    /// </typeparam>
    public interface IFilterCollection<T>
    {
        /// <summary>
        /// Add a single filter to the filter collection.
        /// </summary>
        /// <param name="filter">
        /// Filter to add.
        /// </param>
        void Add(IFilter<T> filter);

        /// <summary>
        /// Removes a single filter from the collection.
        /// </summary>
        /// <param name="filterID">
        /// Identifier for filter to remove.
        /// </param>
        void Remove(string filterID);

        /// <summary>
        /// Retrieve the filter matching the given ID.
        /// </summary>
        /// <param name="filterID">
        /// ID for filter to retrieve
        /// </param>
        /// <returns>
        /// Filter matching the given ID.
        /// </returns>
        IFilter<T> Get(string filterID);

        /// <summary>
        /// Apply the filters to all elements in the given list.
        /// Only the objects passing through all the filters are returned.
        /// </summary>
        /// <param name="list">
        /// List of objects to apply the filters to.
        /// </param>
        /// <returns>
        /// List of objects that passed all filters.
        /// </returns>
        List<T> Apply(List<T> list);
    }
}