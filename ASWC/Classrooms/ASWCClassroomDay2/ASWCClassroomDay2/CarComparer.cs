using System.Collections.Generic;

namespace ASWCClassroomDay2
{
    public class CarComparer : IEqualityComparer<Car>
    {
        public bool Equals(Car x, Car y)
        {
            return x.LicensePlate == y.LicensePlate;
        }

        public int GetHashCode(Car obj)
        {
            return new { obj.LicensePlate, obj.Price, obj.Description }.GetHashCode();
        }
    }

}