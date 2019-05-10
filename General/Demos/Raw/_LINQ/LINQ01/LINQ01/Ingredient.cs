namespace LINQ01
{
    public class Ingredient
    {
        private string _name;
        private int _pricePerCl;
        private double _alcoholPercent;

        public Ingredient(string name, int pricePerCl, double alcoholPercent)
        {
            _name = name;
            _pricePerCl = pricePerCl;
            _alcoholPercent = alcoholPercent;
        }

        public string Name
        {
            get { return _name; }
        }

        public int PricePerCl
        {
            get { return _pricePerCl; }
        }

        public double AlcoholPercent
        {
            get { return _alcoholPercent; }
        }
    }
}