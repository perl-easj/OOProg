using System.Collections.Generic;

namespace LINQ01
{
    public class Cocktail
    {
        private string _name;
        private Dictionary<Ingredient, int> _ingredients;

        public Cocktail(string name)
        {
            _name = name;
            _ingredients = new Dictionary<Ingredient, int>();
        }

        public string Name
        {
            get { return _name; }
        }

        public Dictionary<Ingredient, int> Ingredients
        {
            get { return _ingredients; }
        }

        public void AddIngredient(Ingredient anIngredient, int amount)
        {
            _ingredients.Add(anIngredient, amount);
        }
    }
}