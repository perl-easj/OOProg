using System;

namespace FunctionsAsParameters01
{
    public class Stock
    {
        private string _id;
        private double _price;
        private double _lowerLimit;
        private double _upperLimit;
        private Random _generator;
        public event Action<string, double> PriceChanged;

        public Stock(string id, double lowerLimit, double upperLimit)
        {
            if (lowerLimit > upperLimit)
            {
                throw new ArgumentException("lowerLimit must be lower than upperLimit!");    
            }

            _id = id;
            _lowerLimit = lowerLimit;
            _upperLimit = upperLimit;
            _generator = new Random();
            PriceChanged = null;

            Price = (_upperLimit + _lowerLimit) / 2;
        }

        public double Price
        {
            get { return _price; }
            private set { _price = value; }
        }

        public string ID
        {
            get { return _id; }
        }

        public void GenerateNewPrice()
        {
            int percentChange = 10 - _generator.Next(21);
            double factor = 1 + (percentChange / 100.0);

            double newPrice = _price * factor;

            if (newPrice > _upperLimit)
            {
                newPrice = _upperLimit;
            }

            if (newPrice < _lowerLimit)
            {
                newPrice = _lowerLimit;
            }

            Price = newPrice;
            PriceChanged?.Invoke(ID, Price);
        }

        public override string ToString()
        {
            return $"{ID} : {Price:0.00}";
        }
    }
}