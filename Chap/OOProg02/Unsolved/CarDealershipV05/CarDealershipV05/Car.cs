namespace CarDealershipV05
{
    /// <summary>
    /// This class represents a car, for instance
    /// a car sold in a car dealership
    /// </summary>
    public class Car
    {
        #region Instance fields
        private string _licensePlate;
        private string _brand;
        private string _model;
        private int _price;
        #endregion

        #region Constructor
        public Car(string licensePlate, string brand, string model, int price)
        {
            _licensePlate = licensePlate;
            _brand = brand;
            _model = model;
            _price = price;
        } 
        #endregion

        #region Properties
        public string LicensePlate
        {
            get { return _licensePlate; }
        }

        public string Brand
        {
            get { return _brand; }
        }

        public string Model
        {
            get { return _model; }
        }

        public int Price
        {
            get { return _price; }
        }
        #endregion

        //public override bool Equals(object obj)
        //{
        //    return (obj != null && LicensePlate.Equals(((Car)obj).LicensePlate));
        //}

        //public static bool operator ==(Car c1, Car c2)
        //{
        //    // If both are null, or both are same instance, return true.
        //    if (System.Object.ReferenceEquals(c1, c2))
        //    {
        //        return true;
        //    }

        //    // If one is null, but not both, return false.
        //    if (((object)c1 == null) || ((object)c2 == null))
        //    {
        //        return false;
        //    }

        //    // Return true if the fields match:
        //    return (c1.LicensePlate == c2.LicensePlate);
        //}

        //public static bool operator !=(Car c1, Car c2)
        //{
        //    return !(c1 == c2);
        //}

        public override int GetHashCode()
        {
            return LicensePlate?.GetHashCode() ?? 0;
        }
    }
}
