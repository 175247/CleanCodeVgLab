using CleanCodeLab3.Models;
using System.Collections.Generic;

namespace CleanCodeLab3.Utilities
{
    public class PizzaBuilder
    {
        private string _name;
        private double _price;
        private List<Ingredient> _ingredients;

        public PizzaBuilder()
        {
            _ingredients = new List<Ingredient>();
        }

        public PizzaBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public PizzaBuilder SetPrice(double price)
        {
            _price = price;
            return this;
        }

        public PizzaBuilder SetIngredients(List<Ingredient> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                _ingredients.Add(ingredient);
            }
            return this;
        }

        public PizzaBuilder PreparePizzaForChanges(Pizza pizza)
        {
            _name = pizza.Name;
            _price = pizza.Price;
            _ingredients = pizza.Ingredients;
            return this;
        }

        public PizzaBuilder SetExtraTopping(Ingredient ingredient)
        {
            _ingredients.Add(ingredient);
            return this;
        }

        /// <summary>
        /// Fai la pizza amico mio!
        /// </summary>
        public Pizza BuildPizza()
        {
            return new Pizza(_name, _price, _ingredients);
        }
    }
}
