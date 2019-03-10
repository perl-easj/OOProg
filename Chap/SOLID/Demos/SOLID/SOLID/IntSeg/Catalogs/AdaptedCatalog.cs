using SOLID.IntSeg.Interfaces;

namespace SOLID.IntSeg.Catalogs
{
    /// <summary>
    /// Implements an "adapted" version of CatalogV2
    /// NB: Note that the class
    ///   1) Implements the full ICreateReadUpdateDelete interface, but
    ///   2) does this by inheritance and adaptation (which is trivial in this case)
    /// Hello, Adapter pattern!
    /// </summary>
    public class AdaptedCatalog<T> : 
        CatalogV2<T>, 
        ICreateReadUpdateDelete<T>
    {
    }
}