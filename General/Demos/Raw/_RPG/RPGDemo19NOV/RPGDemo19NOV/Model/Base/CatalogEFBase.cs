using System.Collections.Generic;
using System.Linq;

namespace RPGDemo19NOV.Model.Base
{
    public class CatalogEFBase<T> : ICatalog<T> 
        where T : class
    {
        private RPGDBContext _context;

        public CatalogEFBase()
        {
            _context = new RPGDBContext();  
        }

        public List<T> All
        {
            get { return _context.Set<T>().ToList(); }
        }

        public void Create(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            T obj = _context.Set<T>().Find(id);
            if (obj != null)
            {
                _context.Set<T>().Remove(obj);
                _context.SaveChanges();
            }
        }

        public T Read(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}