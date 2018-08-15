using System.Collections.Generic;

namespace LINQCocktails
{
    /// <summary>
    /// This class represents a cocktail, which is simply
    /// a name, and a list of ingredients.
    /// For each ingredient, the name and amount (in cl.) 
    /// is specified
    /// </summary>
    public class Cocktail
    {
        #region Instance fields
        private string _name;
        private Dictionary<string, int> _ingredients;
        #endregion

        #region Constructor
        public Cocktail(string name)
        {
            _name = name;
            _ingredients = new Dictionary<string, int>();
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
        }

        public Dictionary<string, int> Ingredients
        {
            get { return _ingredients; }
        }
        #endregion

        #region Methods
        public void AddIngredient(string ingredientName, int amount)
        {
            _ingredients.Add(ingredientName, amount);
        } 
        #endregion
    }
}