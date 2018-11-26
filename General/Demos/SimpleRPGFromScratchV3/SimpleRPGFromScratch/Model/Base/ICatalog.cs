// HISTORIK:
// v.1.0 : Oprettet, definerer simpelt Catalog-interface
//

using System;
using System.Collections.Generic;

namespace SimpleRPGFromScratch.Model.Base
{
    /// <summary>
    /// Denne klasse definerer et generelt interface for et Catalog:
    /// 1) En All-property, som returnerer alle objekter af typen T
    /// 2) CRUD-metoden (uden Update indtil videre)
    /// 3) En event, som bliver aktiveret når indholdet af kataloget ændres.
    /// </summary>
    /// <typeparam name="T">Typen af objekter i kataloget (typisk domæne-klasser)</typeparam>
    public interface ICatalog<T>
    {
        List<T> All { get; }
        void Create(T obj);
        T Read(int id);
        void Delete(int id);
        event Action<int> CatalogChanged;
    }
}