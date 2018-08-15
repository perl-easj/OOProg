namespace DataAccess.DomainClasses
{
    /// <summary>
    /// Domain class representing a car. Note that 
    /// this domain class does NOT implement IHasKey.
    /// </summary>
    public class Car
    {
        #region Instance fields
        private string _plate;
        private int _price;
        #endregion

        #region Constructor
        public Car(string plate, int price)
        {
            _plate = plate;
            _price = price;
        }
        #endregion

        #region Properties
        public string Plate
        {
            get { return _plate; }
        }

        public int Price
        {
            get { return _price; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Car: Plate = {Plate}, Price = {Price}";
        } 
        #endregion
    }
}