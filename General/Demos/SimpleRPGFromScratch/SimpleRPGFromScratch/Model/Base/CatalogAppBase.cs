// HISTORIK:
// v.1.0 : Oprettet, skal agere base-klasse for alle kataloger
//         i denne applikation (fast DBContext-klasse)
//

namespace SimpleRPGFromScratch.Model.Base
{
    public abstract class CatalogAppBase<T> : CatalogEFBase<T, SimpleRPGDBContext> where T : class
    {
    }
}