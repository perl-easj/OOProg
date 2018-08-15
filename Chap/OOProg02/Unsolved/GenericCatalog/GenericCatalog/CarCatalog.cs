using System.Collections.Generic;
using System.Linq;

namespace GenericCatalog
{
    public class CarCatalog
    {
        private Dictionary<string, Car> _cars;

        public CarCatalog()
        {
            _cars = new Dictionary<string, Car>();
        }

        public List<Car> All
        {
            get { return _cars.Values.ToList(); }
        }

        public void Insert(string licensePlate, Car aCar)
        {
            if (!_cars.ContainsKey(licensePlate))
            {
                _cars.Add(licensePlate,aCar);
            }
        }

        public void Delete(string licensePlate)
        {
            _cars.Remove(licensePlate);
        }
    }
}