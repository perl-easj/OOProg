using System;
using AddOns.Filtering.Interfaces;

namespace AddOns.Filtering.Implementation
{
    /// <inheritdoc />
    /// <summary>
    /// Implementation of IFilter interface.
    /// </summary>
    public class Filter<T> : IFilter<T>
    {
        #region Instance fields
        private bool _on;
        private string _id;
        private Func<T, bool> _filter;
        #endregion

        #region Constructor
        public Filter(string id, Func<T, bool> filter)
        {
            _id = id;
            _filter = filter;
            _on = false;
        }
        #endregion

        #region Properties
        /// <inheritdoc />
        public string ID
        {
            get { return _id; }
        }

        /// <inheritdoc />
        public bool On
        {
            get { return _on; }
            set { _on = value; }
        }
        #endregion

        #region Methods
        /// <inheritdoc />
        public void Toggle()
        {
            _on = !_on;
        }

        /// <inheritdoc />
        public bool Condition(T obj)
        {
            return !_on || _filter(obj);
        }
        #endregion
    }
}