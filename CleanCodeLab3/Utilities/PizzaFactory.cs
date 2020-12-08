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

        public Pizza CreateHawaii()
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Ost", Price = 0},
                new Ingredient { Name = "Tomatsås", Price = 0},
                new Ingredient { Name = "Skinka", Price = 0},
                new Ingredient { Name = "Ananas", Price = 0},
            };

            var pizzaHawaii = new PizzaBuilder()
                                  .SetName("Hawaii")
                                  .SetPrice(95)
                                  .SetIngredients(ingredients)
                                  .BuildPizza();

            return pizzaHawaii;
        }

        public Pizza CreateKebabPizza()
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Ost", Price = 0},
                new Ingredient { Name = "Tomatsås", Price = 0},
                new Ingredient { Name = "Kebab", Price = 0},
                new Ingredient { Name = "Champinjoner", Price = 0},
                new Ingredient { Name = "Lök", Price = 0},
                new Ingredient { Name = "Feferoni", Price = 0},
                new Ingredient { Name = "Isbergssallad", Price = 0},
                new Ingredient { Name = "Tomat", Price = 0},
                new Ingredient { Name = "Kebabsås", Price = 0},
            };

            var pizzaKebab = new PizzaBuilder()
                                 .SetName("Kebabpizza")
                                 .SetPrice(105)
                                 .SetIngredients(ingredients)
                                 .BuildPizza();

            return pizzaKebab;
        }

        public Pizza CreateQuatroStagioni()
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Ost", Price = 0},
                new Ingredient { Name = "Tomatsås", Price = 0},
                new Ingredient { Name = "Skinka", Price = 0},
                new Ingredient { Name = "Räkor", Price = 0},
                new Ingredient { Name = "Musslor", Price = 0},
                new Ingredient { Name = "Champinjoner", Price = 0},
                new Ingredient { Name = "Kronärtskocka", Price = 0},
            };

            var pizzaQuatroStagioni = new PizzaBuilder()
                                          .SetName("Quatro Stagioni")
                                          .SetPrice(115)
                                          .SetIngredients(ingredients)
                                          .BuildPizza();

            return pizzaQuatroStagioni;
        }
    }
}
