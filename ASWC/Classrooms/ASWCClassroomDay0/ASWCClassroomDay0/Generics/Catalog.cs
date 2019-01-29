using System.Collections.Generic;
using System.Linq;

namespace ASWCClassroomDay0.Generics
{
    public class Catalog<T>
    {
        private List<T> _objects;

        public Catalog()
        {
            _objects = new List<T>();
        }

        public List<T> All
        {
            get { return _objects; }
        }

        public void Create(T obj)
        {
            _objects.Add(obj);
        }

        public T Read(int id)
        {
            // return _objects.FirstOrDefault(o => o.Id == id);
            return default(T);
        }

        public void Delete(int id)
        {
            // _objects.RemoveAll(o => o.Id == id);
        }
    }
}