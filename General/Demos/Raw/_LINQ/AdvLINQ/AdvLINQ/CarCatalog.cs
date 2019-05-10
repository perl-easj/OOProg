using System;
using System.Collections;
using System.Collections.Generic;

namespace AdvLINQ
{
    public class CarCatalog : Catalog<string, Car>
    {
        public CarCatalog(Func<Car, bool> selectorFunc, bool loadTestData = false)
            : base(selectorFunc, loadTestData)
        {          
        }

        public CarCatalog(bool loadTestData = false)
            : base(loadTestData)
        {
        }

        //private Dictionary<string, Car> _cars;

        //public CarCatalog(bool loadTestData = false)
        //{
        //    _cars = new Dictionary<string, Car>();

        //    if (loadTestData) LoadTestData();
        //}

        //public IEnumerable<Car> All
        //{
        //    get { return _cars.Values; }
        //}

        //public void Insert(Car aCar)
        //{
        //    if (!_cars.ContainsKey(aCar.Plate))
        //    {
        //        _cars.Add(aCar.Plate, aCar);
        //    }
        //}

        //public void Delete(string plate)
        //{
        //    _cars.Remove(plate);
        //}

        //public Car Read(string plate)
        //{
        //    return _cars.ContainsKey(plate) ? _cars[plate] : null;
        //}

        //public Car this[string plate]
        //{
        //    get { return Read(plate); }
        //}

        protected override void LoadTestData()
        {
            Car carA = new Car("AA 111", 10000, "Car A");
            Car carB = new Car("BB 222", 20000, "Car B");
            Car carC = new Car("CC 333", 30000, "Car C");
            Car carD = new Car("DD 444", 40000, "Car D");
            Car carE = new Car("EE 555", 50000, "Car E");

            Insert(carA.Plate, carA);
            Insert(carB.Plate, carB);
            Insert(carC.Plate, carC);
            Insert(carD.Plate, carD);
            Insert(carE.Plate, carE);
        }

        //public virtual IEnumerator<Car> GetEnumerator()
        //{
        //    foreach (Car c in All)
        //    {
        //        yield return c;
        //    }
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }
}