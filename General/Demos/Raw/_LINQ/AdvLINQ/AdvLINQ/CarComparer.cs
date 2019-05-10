using System;
using System.Collections;
using System.Collections.Generic;

namespace AdvLINQ
{
    public class CarComparer : IEqualityComparer<Car>
    {
        public bool Equals(Car x, Car y)
        {
            return x.Plate == y.Plate;
        }

        public int GetHashCode(Car obj)
        {
            return new {obj.Plate, obj.Price, obj.Description}.GetHashCode();
        }
    }
}