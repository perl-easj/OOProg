using System;
using System.Collections.Generic;
using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch.Model.Base
{
    /// <summary>
    /// Generel base-klasse for alle slags Catalog-klasser.
    /// Her tages tre beslutninger:
    /// 1) Create består af at indsætte et objekt, og derefter aktivere CatalogChanged-eventet
    /// 2) Delete består af at fjerne et objekt, og derefter aktivere CatalogChanged-eventet
    /// 3) T skal implementere interfacet IDomainClassBase, d.v.s. alle domæne-klasser bliver
    ///    pålagt at implementere dette interface, hvis de vil benytte et Catalog.
    /// </summary>
    /// <typeparam name="T">Typen på de domæne-objekter, som opbevares i kataloget</typeparam>
    public abstract class CatalogBase<T> : ICatalog<T> 
        where T : IDomainClass
    {
        public event Action<int> CatalogChanged;

        // Disse fire metoder kan vi ikke implementere generelt, derfor må
        // vi erklære dem abstract, og implementere dem i nedarvede klasser
        // 
        public abstract List<T> All { get; }
        public abstract T Read(int id);
        protected abstract void Insert(T obj);
        protected abstract void Remove(int id);

        // Den generelle algoritme for Create. Dette er et (meget lille)
        // eksempel på en Template Method.
        public void Create(T obj)
        {
            Insert(obj);
            OnCatalogChanged(obj.GetId());
        }

        // Den generelle algoritme for Delete. Dette er et (meget lille)
        // eksempel på en Template Method.
        public void Delete(int id)
        {
            Remove(id);
            OnCatalogChanged(id);
        }

        // Hjælpe-metode til at aktivere eventet CatalogChanged.
        // Kaldes fra Create og Delete.
        protected virtual void OnCatalogChanged(int id)
        {
            CatalogChanged?.Invoke(id);
        }
    }
}