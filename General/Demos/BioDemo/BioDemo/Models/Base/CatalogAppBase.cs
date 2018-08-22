using Data.InMemory.Interfaces;
using Extensions.Model.Implementation;

namespace BioDemo.Models.Base
{
    /// <summary>
    /// This class will be the class used when defining specific catalogs.
    /// This is preferred instead of letting specific catalogs refer
    /// directly to a specific library catalog class, since we can then
    /// change the catalog "setup" for all catalog instances by changing
    /// this single class.
    /// 
    /// The catalogs are currently set to using file-based persistency.
    /// </summary>
    /// <typeparam name="T">Type of objects stored in the Catalog</typeparam>
    public class CatalogAppBase<T> : FileCatalog<T>
        where T : class, IStorable, ICopyable, new()
    {
    }
}