namespace AdvLINQ
{
    public class Car
    {
        public string Plate { get;}
        public int Price { get; set; }
        public string Description{ get; set; }

        public Car(string plate, int price, string description)
        {
            Plate = plate;
            Price = price;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Plate}, costs {Price} kr. ({Description})";
        }
    }
}