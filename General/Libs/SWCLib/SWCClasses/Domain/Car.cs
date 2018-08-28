namespace SWCClasses.Domain
{
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
            set { _price = value; }
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"{LicensePlate}: A {Brand} {Model}, price is {Price} kr.";
        }
        #endregion
    }
}