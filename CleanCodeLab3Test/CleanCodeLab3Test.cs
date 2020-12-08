using CleanCodeLab3.Models;
using CleanCodeLab3.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CleanCodeLab3Test
{
    [TestClass]
    public class CleanCodeLab3Test
    {
        // Some tests have been omitted as other tests do the same thing, just names and classes are different.
        [TestMethod]
        public void pizza_factory_should_return_a_pizza_when_called()
        {
            var pizzaFactory = new PizzaFactory();
            var expected = typeof(Pizza);
            var actual = pizzaFactory.CreateMargerita();

            Assert.AreEqual(expected, actual.GetType());
        }

        [TestMethod]
        public void ingredients_names_get_and_set_should_work()
        {
            var ingredient = new Ingredient { Name = "Mamma mu" };
            var expected = "Mamma mu";
            var actual = ingredient.Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void pizza_properties_should_work()
        {
            var ingredientList = new List<Ingredient>
            {
                new Ingredient { Name = "Vitlök", Price = 30 }
            };

            var pizza = new Pizza("Kebaben", 3, ingredientList);
            var expected = new Ingredient { Name = "Vitlök", Price = 30 };
            var actual = pizza.Ingredients[0];

            Assert.AreEqual(expected.Name, actual.Name);
        }

        [TestMethod]
        public void pizza_builder_should_build_pizzas_using_properties()
        {
            var pizzaBuilder = new PizzaBuilder();
            var expected = "JockesPizza";
            var actual = pizzaBuilder
                         .SetName("JockesPizza")
                         .BuildPizza();

            Assert.AreEqual(expected, actual.Name);
        }

        [TestMethod]
        public void test_the_kebab_creation()
        {
            var factory = new PizzaFactory();
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Kebab", Price = 0 }
            };

            var expected = new Pizza("Kebabpizza", 105, ingredients)
                               .Ingredients[0].Name;

            var actual = factory.CreateKebabPizza()
                                .Ingredients[2].Name;
            Assert.AreEqual(expected, actual);
        }
    }
}
