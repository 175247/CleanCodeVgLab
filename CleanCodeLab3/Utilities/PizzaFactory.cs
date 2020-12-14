using CleanCodeLab3.Interfaces;
using CleanCodeLab3.Models;
using System.Collections.Generic;

namespace CleanCodeLab3.Utilities
{
    public class PizzaFactory : IPizzaFactory
    {
        public Pizza AddToppingToPizza(Pizza pizza, Ingredient ingredient)
        {
            Pizza pizzaWithExtraTopping = null;
            List<Ingredient> existingIngredients = pizza.Ingredients;
            
            existingIngredients.Add(ingredient);

            switch (pizza.Name)
            {
                case "Margerita":
                    pizzaWithExtraTopping = CreateMargerita();
                    break;

                case "Hawaii":
                    pizzaWithExtraTopping = CreateHawaii();
                    break;

                case "Kebabpizza":
                    pizzaWithExtraTopping = CreateKebabPizza();
                    break;

                case "Quattro Stagioni":
                    pizzaWithExtraTopping = CreateQuattroStagioni();
                    break;

                default:
                    pizzaWithExtraTopping = null;
                    break;
            }

            pizzaWithExtraTopping = new PizzaBuilder()
                                        .PreparePizzaForChanges(pizzaWithExtraTopping)
                                        .SetExtraTopping(existingIngredients)
                                        .BuildPizza();

            return pizzaWithExtraTopping;
        }

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

        public Pizza CreateQuattroStagioni()
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

            var pizzaQuattroStagioni = new PizzaBuilder()
                                          .SetName("Quattro Stagioni")
                                          .SetPrice(115)
                                          .SetIngredients(ingredients)
                                          .BuildPizza();

            return pizzaQuattroStagioni;
        }
    }
}
