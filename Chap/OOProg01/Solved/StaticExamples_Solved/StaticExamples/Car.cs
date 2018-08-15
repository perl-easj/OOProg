using System;

namespace StaticExamples
{
    /// <summary>
    /// A very simple representation of a car
    /// </summary>
    public class Car
    {
        // Added
        #region Static instance fields 
        private static int _noOfCarsObjectsCreated = 0;
        private static int _noOfCallsToLicensePlate = 0;
        private static int _noOfCallsToPrice = 0; 
        #endregion

        #region Instance fields
        private string _licensePlate;
        private int _price;
        #endregion

        #region Constructor
        public Car(string licensePlate, int price)
        {
            _noOfCarsObjectsCreated++; // Added
            _licensePlate = licensePlate;
            _price = price;
        }
        #endregion

        #region Properties
        public string LicensePlate
        {
            get
            {
                _noOfCallsToLicensePlate++; // Added
                return _licensePlate;
            }
            set
            {
                _noOfCallsToLicensePlate++; // Added
                _licensePlate = value;
            }
        }

        public int Price
        {
            get
            {
                _noOfCallsToPrice++; // Added
                return _price;
            }
            set
            {
                _noOfCallsToPrice++; // Added
                _price = value;
            }
        }
        #endregion

        // Added
        #region Static methods
        public static void PrintUsageStatistics() 
        {
            Console.WriteLine($"Cars objects created : {_noOfCarsObjectsCreated}");
            Console.WriteLine($"Use of LicensePlate property: {_noOfCallsToLicensePlate}");
            Console.WriteLine($"Use of Price property: {_noOfCallsToPrice}");
        } 
        #endregion
    }
}