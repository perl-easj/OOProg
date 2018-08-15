namespace GenericCatalog
{
    public class Car
    {
        public Car(string licensePlate, int price)
        {
            LicensePlate = licensePlate;
            Price = price;
        }

        public string LicensePlate { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{LicensePlate}, costs {Price} kr.";
        }
    }
}