namespace LINQAggr
{
    public class Car
    {
        public string LicensePlate { get; private set; }
        public int Price { get; private set; }

        public Car(string licensePlate, int price)
        {
            LicensePlate = licensePlate;
            Price = price;
        }

        public void IncreasePrice(int amount)
        {
            Price += amount;
        }

        public override string ToString()
        {
            return $"{LicensePlate}, costs {Price} kr.";
        }
    }
}