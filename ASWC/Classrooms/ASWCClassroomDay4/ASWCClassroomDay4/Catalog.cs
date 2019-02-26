using System.Collections.Generic;
using System.Linq;

namespace ASWCClassroomDay4
{
    public class Catalog<T> : ICatalog<T>
    {
        private List<T> _objects;

        public Catalog(IEnumerable<T> objects)
        {
            _objects = objects.ToList();
        }

        public IEnumerable<T> All
        {
            get { return _objects; }
        }
    }
}