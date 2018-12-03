using System;
using System.Collections.Generic;

namespace SimpleRPGFromScratch.Model.Base
{
    /// <summary>
    /// Denne klasse definerer et generelt interface for et Catalog:
    /// 1) En All-property, som returnerer alle objekter af typen T
    /// 2) CRUD-metoder
    /// 3) En event, som bliver aktiveret når indholdet af kataloget ændres.
    /// </summary>
    /// <typeparam name="T">Typen af objekter i kataloget (typisk domæne-klasser)</typeparam>
    public interface ICatalog<T>
    {
        List<T> All { get; }
        void Create(T obj);
        T Read(int id);
        void Update(int id, T obj);
        void Delete(int id);
        event Action<int> CatalogChanged;
    }
}