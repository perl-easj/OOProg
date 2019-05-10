namespace FunctionsAsParameters01
{
    public class Car
    {
        private string _licensePlate;
        private int _noOfSeats;
        private int price;

        public string LicensePlate
        {
            get { return _licensePlate; }
        }

        // Rest of class definition omitted

        public Car(string licensePlate, int noOfSeats, int price)
        {
            _licensePlate = licensePlate;
            _noOfSeats = noOfSeats;
            this.price = price;
        }

        public int NoOfSeats
        {
            get { return _noOfSeats; }
        }

        public int Price
        {
            get { return price; }
        }

        public override string ToString()
        {
            return LicensePlate + " has " + NoOfSeats + " seats, costs " + Price;
        }
    }
}