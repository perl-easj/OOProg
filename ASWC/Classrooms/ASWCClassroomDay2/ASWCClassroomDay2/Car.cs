namespace ASWCClassroomDay2
{
    public class Car
    {
        public string LicensePlate { get; }
        public int Price { get; }
        public string Description { get; }

        public Car(string licensePlate, int price, string description)
        {
            LicensePlate = licensePlate;
            Price = price;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Description}: [{LicensePlate}], costs {Price}";
        }
    }
}