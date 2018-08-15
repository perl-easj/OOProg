namespace StaticExamples
{
    /// <summary>
    /// A very simple representation of a car
    /// </summary>
    public class Car
    {
        #region Instance fields
        private string _licensePlate;
        private int _price;
        #endregion

        #region Constructor
        public Car(string licensePlate, int price)
        {
            _licensePlate = licensePlate;
            _price = price;
        }
        #endregion

        #region Properties
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
        #endregion
    }
}