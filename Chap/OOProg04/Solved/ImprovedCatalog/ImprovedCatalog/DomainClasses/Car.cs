namespace ImprovedCatalog.DomainClasses
{
    /// <summary>
    /// Simple domain class. The property Plate is defined as being
    /// a key for a Car object.
    /// </summary>
    public class Car
    {
        #region Properties
        public string Plate { get; }
        public int Price { get; set; }
        public string Description { get; set; }
        #endregion

        #region Constructor
        public Car(string plate, int price, string description)
        {
            Plate = plate;
            Price = price;
            Description = description;
        } 
        #endregion

        public override string ToString()
        {
            return $"{Plate}, costs {Price} kr. ({Description})";
        }
    }
}