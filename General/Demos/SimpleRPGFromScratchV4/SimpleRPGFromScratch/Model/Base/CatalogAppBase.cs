using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch.Model.Base
{
    /// <summary>
    /// Dette er den Catalog-klasse, som alle de klasse-specifikke Catalog-klasser
    /// i denne applikation skal arve fra. Her beslutter vi, at alle kataloger skal
    /// benytte SimpleRPGDBContext som DbContext.
    /// </summary>
    /// <typeparam name="T">Typen af de domæne-objekter, som kataloget rummer.</typeparam>
    public abstract class CatalogAppBase<T> : CatalogEFBase<T, SimpleRPGDBContext> 
        where T : class, IDomainClass
    {
    }
}