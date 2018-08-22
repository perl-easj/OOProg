using System;
using System.Collections.Generic;
using AddOns.Filtering.Interfaces;

namespace AddOns.Filtering.Implementation
{
    /// <summary>
    /// Implementation of the IFilterService interface
    /// </summary>
    public class FilterService<T> : IFilterService<T>
    {
        private Dictionary<string, IFilterCollection<T>> _filterCollections;

        public FilterService()
        {
            _filterCollections = new Dictionary<string, IFilterCollection<T>>();
        }

        /// <inheritdoc />
        public void Add(string filterCollId)
        {
            if (_filterCollections.ContainsKey(filterCollId))
            {
                throw new ArgumentException(nameof(Add));
            }

            _filterCollections.Add(filterCollId, new FilterCollection<T>());
        }

        /// <inheritdoc />
        public void Remove(string filterCollId)
        {
            _filterCollections.Remove(filterCollId);
        }

        /// <inheritdoc />
        public IFilterCollection<T> Get(string filterCollId)
        {
            if (!_filterCollections.ContainsKey(filterCollId))
            {
                throw new ArgumentException(nameof(Get));
            }

            return _filterCollections[filterCollId];
        }
    }
}