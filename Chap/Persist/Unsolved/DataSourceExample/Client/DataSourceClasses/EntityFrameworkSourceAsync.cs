using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Implementation of data source interface (API), using
    /// a database (accessed through the Entity Framework)
    /// as specific data source.
    /// Responsibilities:
    /// 1) Implement data source API using a Database (+ Entity Framework)
    /// </summary>
    /// <typeparam name="T">
    /// Type of objects in data source
    /// </typeparam>
    public class EntityFrameworkSourceAsync<T> : IDataSourceAsync<T> where T : class
    {
        #region Instance fields
        private DbContext _context;
        private DbSet<T> _dbSet;
        #endregion

        #region Constructor
        public EntityFrameworkSourceAsync(DbContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }
        #endregion

        #region Implementation of IDataSourceAsync
        public Task<List<T>> Load()
        {
            return Task.Run(() => _dbSet.ToList());
        }

        public Task Create(T obj)
        {
            _dbSet.Add(obj);
            return _context.SaveChangesAsync();
        }

        public Task<T> Read(int key)
        {
            return Task.Run(() => _dbSet.Find(key));
        }

        public Task Update(int key, T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task Delete(int key)
        {
            T obj = _dbSet.Find(key);
            if (obj != null)
            {
                _dbSet.Remove(obj);
                return _context.SaveChangesAsync();
            }
            return Task.CompletedTask;
        } 
        #endregion
    }
}