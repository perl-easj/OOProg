namespace GenericCatalog
{
    public class Phone
    {
        public Phone(int number, string brand)
        {
            Number = number;
            Brand = brand;
        }

        public int Number { get; set; }
        public string Brand { get; set; }

        public override string ToString()
        {
            return $"{Number} ({Brand})";
        }
    }
}