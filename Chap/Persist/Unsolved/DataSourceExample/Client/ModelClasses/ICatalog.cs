using System.Collections.Generic;

namespace Client
{
    /// <summary>
    /// Defines a very simple interface for a Catalog
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICatalog<T>
    {
        /// <summary>
        /// Read all objects from a persistent source, 
        /// and store the object in the Catalog
        /// </summary>
        void Load();

        /// <summary>
        /// Retrieve all objects currently in the Catalog
        /// </summary>
        List<T> All { get; }
    }
}