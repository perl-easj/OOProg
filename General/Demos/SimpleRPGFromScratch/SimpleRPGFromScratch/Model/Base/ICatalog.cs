// HISTORIK:
// v.1.0 : Oprettet, definerer simpelt Catalog-interface
//

using System.Collections.Generic;

namespace SimpleRPGFromScratch.Model.Base
{
    public interface ICatalog<T>
    {
        List<T> All { get; }
        void Create(T obj);
        T Read(int id);
        void Delete(int id);
    }
}