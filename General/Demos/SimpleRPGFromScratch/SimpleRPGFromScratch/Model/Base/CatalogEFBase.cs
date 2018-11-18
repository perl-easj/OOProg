// HISTORIK:
// v.1.0 : Oprettet, simpel implementation af ICatalog-interface
//         ved brug af Entity Framework Core
//

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SimpleRPGFromScratch.Model.Base
{
    public abstract class CatalogEFBase<T, TDBContext> : ICatalog<T> 
        where TDBContext : DbContext, new() 
        where T : class
    {
        private TDBContext _dbContext;

        protected CatalogEFBase()
        {
            _dbContext = new TDBContext();
        }

        public List<T> All
        {
            get { return BuildObjects(_dbContext.Set<T>()); }
        }

        public void Create(T obj)
        {
            _dbContext.Set<T>().Add(obj);
            _dbContext.SaveChanges();
        }

        public T Read(int id)
        {
            return All.Find(obj => IdMatch(obj, id));
        }

        public void Delete(int id)
        {
            T obj = Read(id);
            if (obj != null)
            {
                _dbContext.Set<T>().Remove(obj);
            }
        }

        // Denne metode skal implementeres i nedarvede,
        // domæne-specifikke klasser.
        public abstract bool IdMatch(T obj, int id);

        // Denne metode skal implementeres i nedarvede,
        // domæne-specifikke klasser. Skal rumme de
        // nødvendige kald af Include/ThenInclude, afsluttet
        // med kald af ToList.
        public abstract List<T> BuildObjects(DbSet<T> objects);

    }
}