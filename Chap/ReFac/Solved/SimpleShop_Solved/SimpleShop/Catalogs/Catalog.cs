using System.Collections.Generic;
using System.Linq;

namespace SimpleShop.Catalogs
{
    public class Catalog<T> where T : IHasID
    {
        protected List<T> _items;

        public Catalog()
        {
            _items = new List<T>();
        }

        public T Lookup(int id)
        {
            return _items.FirstOrDefault(i => i.ID == id);
        }
    }
}