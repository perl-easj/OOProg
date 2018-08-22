using System;
using System.Collections.Generic;
using AddOns.Filtering.Interfaces;

namespace AddOns.Filtering.Implementation
{
    /// <inheritdoc />
    /// <summary>
    /// Implementation of the IFilterCollection interface.
    /// </summary>
    public class FilterCollection<T> : IFilterCollection<T>
    {
        private Dictionary<string, IFilter<T>> _filters;

        public FilterCollection()
        {
            _filters = new Dictionary<string, IFilter<T>>();
        }

        /// <inheritdoc />
        public void Add(IFilter<T> filter)
        {
            if (filter == null || _filters.ContainsKey(filter.ID))
            {
                throw new ArgumentException(nameof(Add));
            }

            _filters.Add(filter.ID, filter);
        }

        /// <inheritdoc />
        public void Remove(string filterID)
        {
            _filters.Remove(filterID);
        }

        /// <inheritdoc />
        public IFilter<T> Get(string filterID)
        {
            if (!_filters.ContainsKey(filterID))
            {
                throw new ArgumentException(nameof(Get));
            }

            return _filters[filterID];
        }

        /// <inheritdoc />
        public List<T> Apply(List<T> list)
        {
            return list.FindAll(SatisfiesAll);
        }

        /// <summary>
        /// Performs the actual filtering of a single object.
        /// </summary>
        /// <param name="obj">
        /// Object to apply the filters to.
        /// </param>
        /// <returns>
        /// True if object passed all filters, otherwise false.
        /// </returns>
        private bool SatisfiesAll(T obj)
        {
            foreach (IFilter<T> filter in _filters.Values)
            {
                if (!filter.Condition(obj)) return false;
            }

            return true;
        }
    }
}