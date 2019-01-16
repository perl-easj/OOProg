using System.Collections.Generic;

namespace ImprovedCatalog.CatalogBaseClasses.Interfaces
{
    /// <summary>
    /// Interface supporting an All property. All that is assumed is that
    /// when invoking All, a collection of values of type V is returned.
    /// </summary>
    /// <typeparam name="V">Type of values in the returned collection</typeparam>
    public interface IAll<out V>
    {
        /// <summary>
        /// Returns a collection of values of type V. The collection may be empty.
        /// </summary>
        IEnumerable<V> All { get; }
    }
}