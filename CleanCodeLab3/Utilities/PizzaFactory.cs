using CleanCodeLab3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLab3.Utilities
{
    public class PizzaFactory
    {
        public Pizza CreateMargerita()
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Ost", Price = 0},
                new Ingredient { Name = "Tomatsås", Price = 0},
            };

            var pizzaMargerita = new PizzaBuilder()
                                     .SetName("Margerita")
                                     .SetPrice(85)
                                     .SetIngredients(ingredients)
                                     .BuildPizza();

            return pizzaMargerita;
        }
    }
}
