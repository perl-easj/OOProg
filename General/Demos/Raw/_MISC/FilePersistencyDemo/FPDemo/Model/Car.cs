namespace Demo.Model
{
    public class Car
    {
        private string _licensePlate;
        private int _price;

        public Car(string licensePlate, int price)
        {
            _licensePlate = licensePlate;
            _price = price;
        }

        public string LicensePlate
        {
            get { return _licensePlate; }
            set { _licensePlate = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public override string ToString()
        {
            return $"{LicensePlate}, costs {Price}";
        }
    }
}