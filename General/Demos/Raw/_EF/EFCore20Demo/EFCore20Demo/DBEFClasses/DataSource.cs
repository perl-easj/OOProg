using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCore20Demo.DBEFClasses
{
    public class DataSource
    {
        private DbContext _context;

        public DataSource(DbContext context)
        {
            _context = context;
        }

        public List<T> LoadTable<T>() where T : class
        {
            return _context.Set<T>().ToList();
        }
    }

    public class WebAPISource<TPersistentData> where TPersistentData : class
    {
        private enum APIMethod { Load, Create, Read, Update, Delete }

        #region Instance fields
        private DbContext _context;
        #endregion

        #region Constructor
        public WebAPISource(DbContext context)
        {
            _context = context;
        }
        #endregion

        #region Implementation of IPersistentSource
        /// <summary>
        /// Implementation of Load method
        /// </summary>
        /// <returns>List of domain objects</returns>
        public async Task<List<TPersistentData>> Load()
        {
            return await _context.Set<TPersistentData>().ToListAsync();
        }

        /// <summary>
        /// Implementation of Create method. Create is a bit atypical,
        /// since we need to return the key value associated with the
        /// newly created object. This is relevant if the data is saved
        /// in a database table, where the table itself chooses the next
        /// key for the object (e.g. an auto-increment setting)
        /// </summary>
        /// <param name="obj">Persistent data object to create</param>
        public async Task<int> Create(TPersistentData obj)
        {
            await _context.Set<TPersistentData>().AddAsync(obj);
            _context.SaveChanges();
            return 42; // TODO
        }

        /// <summary>
        /// Implementation of Read method
        /// </summary>
        /// <param name="key">Key for object to read</param>
        /// <returns>DTO matching key</returns>
        public async Task<TPersistentData> Read(int key)
        {
            return await _context.Set<TPersistentData>().FindAsync(key);
        }

        /// <summary>
        /// Implementation of Update method
        /// </summary>
        /// <param name="key">Key for object to update</param>
        /// <param name="obj">Persistent data object to update</param>
        public async Task Update(int key, TPersistentData obj)
        {
        }

        /// <summary>
        /// Implementation of Delete method
        /// </summary>
        /// <param name="key">Key for persistent data object to delete</param>
        public async Task Delete(int key)
        {
            TPersistentData obj = await _context.Set<TPersistentData>().FindAsync(key);

            if (obj != null)
            {
                _context.Set<TPersistentData>().Remove(obj);
                _context.SaveChanges();
            }
        }
        #endregion
    }
}