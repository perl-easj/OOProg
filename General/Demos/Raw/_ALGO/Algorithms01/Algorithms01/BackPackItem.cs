namespace Algorithms01
{
    /// <summary>
    /// This class represents an item which can be put into e.g. a backpack.
    /// An item has a description, a weight (in kg.), and a value.
    /// </summary>
    public class BackPackItem
    {
        private string _description;
        private double _weight;
        private int _value;

        public BackPackItem(string description, double weight, int value)
        {
            _description = description;
            _weight = weight;
            _value = value;
        }

        public string Description
        {
            get { return _description; }
        }

        public double Weight
        {
            get { return _weight; }
        }

        public int Value
        {
            get { return _value; }
        }

        public override string ToString()
        {
            return Description + ": weight " + Weight + " kg, worth " + Value;
        }
    }
}