using CarRetailDemo.Data.Base;

namespace CarRetailDemo.Data.Domain
{
    public class Car : DomainClassAppBase
    {
        public Car(int key, int imageKey, string licensePlate, string brand, string model, int year, int engineSize,
            int horsePower, int seats, int price)
            : base(imageKey)
        {
            Key = key;
            LicensePlate = licensePlate;
            Brand = brand;
            Model = model;
            Year = year;
            EngineSize = engineSize;
            HorsePower = horsePower;
            Seats = seats;
            Price = price;
        }

        public Car() : base(NullKey)
        {
        }

        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int EngineSize { get; set; }
        public int HorsePower { get; set; }
        public int Seats { get; set; }
        public int Price { get; set; }

        public override void SetDefaultValues()
        {
            Key = NullKey;
            ImageKey = NullKey;
            LicensePlate = "(not set)";
            Brand = "(not set)";
            Model = "(not set)";
            Year = 2000;
            EngineSize = 0;
            HorsePower = 0;
            Seats = 0;
            Price = 0;
        }
    }
}