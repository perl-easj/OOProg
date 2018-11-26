// HISTORIK:
// v.1.0 : Oprettet, simpel implementation af ICatalog-interface
//         ved brug af Entity Framework Core
//

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch.Model.Base
{
    /// <summary>
    /// Dette er en Entity Framework Core 2.x - specifik implementation af
    /// en Catalog klasse. Her tager vi beslutning om at benytte EF Core 2.x
    /// som vores data-kilde. Dett gøres ved at have datakilden med som en
    /// type-parameter, som skal arve fra DbContext.
    /// </summary>
    /// <typeparam name="T">Typen på de domæne-objekter, som opbevares i kataloget.</typeparam>
    /// <typeparam name="TDBContext">Typen på den DBContext-klasse, som repræsenterer databasen.</typeparam>
    public abstract class CatalogEFBase<T, TDBContext> : CatalogBase<T> 
        where TDBContext : DbContext, new() 
        where T : class, IDomainClass
    {
        private TDBContext _dbContext;

        protected CatalogEFBase()
        {
            _dbContext = new TDBContext();
        }

        /// <summary>
        /// All laver først en simpel query: _dbContext.Set<T>().
        /// Dette returnerer alle objekter af typen T, men UDEN
        /// eventuelle referencer til objekter af andre typen.
        /// Disse skal hægtes på i de nedarvede Catalog-klassen,
        /// som netop netop vil være specifikke for en domæne-klasse.
        /// Denne "påhægtning" foretages ved at implementere metoden
        /// BuildObjects, som altså er abstract her.
        /// </summary>
        public override List<T> All
        {
            get { return BuildObjects(_dbContext.Set<T>()); }
        }

        /// <summary>
        /// Read kalder blot LINQ-metoden Find på den collection
        /// som All returnerer, og giver kriteriet for udvælgelse
        /// af det rette objekt med. 
        /// </summary>
        /// <param name="id">Id for det objekt vi gerne vi læse</param>
        /// <returns>Objektet som matcher det givne id (eller null)</returns>
        public override T Read(int id)
        {
            return All.Find(obj => (obj.GetId() == id));
        }

        /// <summary>
        /// Insert udføres blot ved at kalde Add på det DbSet
        /// som rummer objekter af typen T.
        /// </summary>
        /// <param name="obj">Objekt som ønskes indsat i databasen</param>
        protected override void Insert(T obj)
        {
            int id = All.Select(o => o.GetId()).Max() + 1;
            obj.SetId(id);

            _dbContext.Set<T>().Add(obj);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Remove udføres ved først at finde det matchende objekt.
        /// Hvis et sådant findes, fjernes det fra det det DbSet
        /// som rummer objekter af typen T.
        /// </summary>
        /// <param name="id">Id for den objekt som ønskes fjernet fra databasen</param>
        protected override void Remove(int id)
        {
            T obj = Read(id);
            if (obj != null)
            {
                _dbContext.Set<T>().Remove(obj);
                _dbContext.SaveChanges();
            }
        }

        // Denne metode skal implementeres i nedarvede,
        // domæne-specifikke klasser. Skal rumme de
        // nødvendige kald af Include/ThenInclude, afsluttet
        // med kald af ToList.
        public abstract List<T> BuildObjects(DbSet<T> objects);
    }
}