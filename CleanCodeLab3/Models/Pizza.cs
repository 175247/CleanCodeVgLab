using System.Collections.Generic;

namespace CleanCodeLab3.Models
{
    public class Pizza : ServableItems
    {
        public List<Ingredient> Ingredients { get; private set; }

        public Pizza(string name, double price, List<Ingredient> ingredients)
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
        }
    }
}
