using System.Collections.Generic;

namespace ImprovedCatalog.CatalogBaseClasses.Interfaces
{
    /// <summary>
    /// This interface defines enumerability for a catalog, simply by
    /// inheriting from the IEnumerable interface.
    /// </summary>
    /// <typeparam name="K">Type for key for values stored in catalog</typeparam>
    /// <typeparam name="V">Type for values stored in catalog</typeparam>
    public interface IEnumerableCatalog<out V> : IEnumerable<V>
    {      
    }
}