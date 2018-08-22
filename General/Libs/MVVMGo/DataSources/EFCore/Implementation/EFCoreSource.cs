using System.Collections.Generic;
using System.Threading.Tasks;
using Data.InMemory.Interfaces;
using Data.Persistent.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataSources.EFCore.Implementation
{
    /// <summary>
    /// Implementation of IDataSource... interfaces, using 
    /// Entity Framework Core 2.0. for interaction with a relational database. 
    /// The database itself is supplied via the TDbContext type parameter.
    /// </summary>
    /// <typeparam name="TPersistentData">Type of objects to persist</typeparam>
    /// <typeparam name="TDbContext">Type for database context, i.e. database specification</typeparam>
    public class EFCoreSource<TDbContext, TPersistentData> : IDataSourceCRUD<TPersistentData>, IDataSourceLoad<TPersistentData>
        where TPersistentData : class, IStorable 
        where TDbContext : DbContext, new()
    {
        public async Task<List<TPersistentData>> Load()
        {
            using (var context = new TDbContext())
            {
                return await context.Set<TPersistentData>().ToListAsync();
            }
        }

        public async Task<int> Create(TPersistentData obj)
        {
            using (var context = new TDbContext())
            {
                await context.Set<TPersistentData>().AddAsync(obj);
                context.SaveChanges();
                return obj.Key; // TODO
            }
        }

        public async Task<TPersistentData> Read(int key)
        {
            using (var context = new TDbContext())
            {
                return await context.Set<TPersistentData>().FindAsync(key);
            }
        }

        public async Task Update(int key, TPersistentData obj)
        {
            using (var context = new TDbContext())
            {
                TPersistentData oldObj = await context.Set<TPersistentData>().FindAsync(key);
                if (oldObj != null)
                {
                    context.Set<TPersistentData>().Remove(oldObj);
                    obj.Key = key;
                    await context.Set<TPersistentData>().AddAsync(obj);
                    context.SaveChanges();
                }
            }
        }

        public async Task Delete(int key)
        {
            using (var context = new TDbContext())
            {
                TPersistentData obj = await context.Set<TPersistentData>().FindAsync(key);
                if (obj != null)
                {
                    context.Set<TPersistentData>().Remove(obj);
                    context.SaveChanges();
                }
            }
        }
    }
}