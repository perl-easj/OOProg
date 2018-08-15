namespace GenericsDogsAndCircles
{
    public class Dog
    {
        #region Instance fields
        private string _name;
        private int _height;
        private double _weight;
        #endregion

        #region Constructor
        public Dog(string name, int height, double weight)
        {
            _name = name;
            _height = height;
            _weight = weight;
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
        }

        public int Height
        {
            get { return _height; }
        }

        public double Weight
        {
            get { return _weight; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Name} is {Height} cm tall, and weighs {Weight} kgs.";
        } 
        #endregion
    }
}