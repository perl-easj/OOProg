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
    /// <typeparam name="TData">Type of objects to persist</typeparam>
    /// <typeparam name="TDbContext">Type for database context, i.e. database specification</typeparam>
    public class EFCoreSource<TDbContext, TData> : IDataSourceCRUD<TData>, IDataSourceLoad<TData>
        where TData : class, IStorable 
        where TDbContext : DbContext, new()
    {
        public async Task<List<TData>> Load()
        {
            using (var context = new TDbContext())
            {
                return await context.Set<TData>().ToListAsync();
            }
        }

        public async Task<int> Create(TData obj)
        {
            using (var context = new TDbContext())
            {
                await context.Set<TData>().AddAsync(obj);
                context.SaveChanges();
                return obj.Key; // TODO
            }
        }

        public async Task<TData> Read(int key)
        {
            using (var context = new TDbContext())
            {
                return await context.Set<TData>().FindAsync(key);
            }
        }

        public async Task Update(int key, TData obj)
        {
            using (var context = new TDbContext())
            {
                TData oldObj = await context.Set<TData>().FindAsync(key);
                if (oldObj != null)
                {
                    context.Set<TData>().Remove(oldObj);
                    obj.Key = key;
                    await context.Set<TData>().AddAsync(obj);
                    context.SaveChanges();
                }
            }
        }

        public async Task Delete(int key)
        {
            using (var context = new TDbContext())
            {
                TData obj = await context.Set<TData>().FindAsync(key);
                if (obj != null)
                {
                    context.Set<TData>().Remove(obj);
                    context.SaveChanges();
                }
            }
        }
    }
}