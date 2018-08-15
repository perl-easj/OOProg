namespace LINQCocktails
{
    /// <summary>
    /// This class represents a cocktail ingredient,
    /// limited to liquid ingredients.
    /// An ingredient has a name, a price (per cl.), 
    /// and an alcohol percentage
    /// </summary>
    public class Ingredient
    {
        #region Instance fields
        private string _name;
        private int _pricePerCl;
        private double _alcoholPercent;
        #endregion

        #region Constructor
        public Ingredient(string name, int pricePerCl, double alcoholPercent)
        {
            _name = name;
            _pricePerCl = pricePerCl;
            _alcoholPercent = alcoholPercent;
        }
        #endregion

        #region Properties
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
        #endregion
    }
}