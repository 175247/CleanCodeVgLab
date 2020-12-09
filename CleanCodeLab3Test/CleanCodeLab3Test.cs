using CleanCodeLab3;
using CleanCodeLab3.Models;
using CleanCodeLab3.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CleanCodeLab3Test
{
    [TestClass]
    public class CleanCodeLab3Test
    {
        private readonly PizzaFactory _pizzaFactory;
        private readonly DrinkFactory _drinkFactory;
        private readonly PizzaBuilder _pizzaBuilder;
        private Menu _menuInstance;

        public CleanCodeLab3Test()
        {
            _pizzaFactory = new PizzaFactory();
            _drinkFactory = new DrinkFactory();
            _pizzaBuilder = new PizzaBuilder();
            _menuInstance = Menu.Instance;
    }

        // Some tests have been omitted as other tests
        // do the same thing, just names and classes differ.
        // Examples: Models > Ingredient, Drink
        [TestMethod]
        public void pizza_factory_should_return_a_pizza_when_called()
        {
            var expected = typeof(Pizza);
            var actual = _pizzaFactory.CreateMargerita();

            Assert.AreEqual(expected, actual.GetType());
        }

        [TestMethod]
        public void menu_instance_should_contain_item_instances()
        {
            // Arrange
            _menuInstance.ClearMenu();
            // Act
            _menuInstance = Menu.Instance;
            _menuInstance.GenerateMenuItems();
            // Assert
            Assert.IsNotNull(_menuInstance);
            Assert.IsNotNull(_menuInstance.PizzaMenu);
            Assert.IsNotNull(_menuInstance.DrinksMenu);
            Assert.IsNotNull(_menuInstance.ExtraIngredientsTenCrowns);
            Assert.IsNotNull(_menuInstance.ExtraIngredientsFifteenCrowns);
            Assert.IsNotNull(_menuInstance.ExtraIngredientsTwentyCrowns);
        }

        [TestMethod]
        public void menu_instance_items_can_be_edited()
        {
            // Arrange
            _menuInstance.ClearMenu();
            // Act
            _menuInstance = Menu.Instance;
            _menuInstance.GenerateMenuItems();
            var countBeforeAddingTestPizza = _menuInstance.PizzaMenu.Count;
            _menuInstance.PizzaMenu.Add(new MenuItems
            {
                Name = "Test",
            });
            var countAfterAddingTestPizza = _menuInstance.PizzaMenu.Count;
            // Assert
            Assert.IsTrue(countAfterAddingTestPizza == countBeforeAddingTestPizza + 1);
        }

        [TestMethod]
        public void menu_instance_should_contain_items_with_correct_count()
        {
            // Arrange
            _menuInstance.ClearMenu();
            // Act
            _menuInstance = Menu.Instance;
            _menuInstance.GenerateMenuItems();
            // Assert
            Assert.IsTrue(_menuInstance.PizzaMenu.Count == 4);
            Assert.IsTrue(_menuInstance.DrinksMenu.Count == 3);
            Assert.IsTrue(_menuInstance.ExtraIngredientsTenCrowns.Count == 5);
            Assert.IsTrue(_menuInstance.ExtraIngredientsFifteenCrowns.Count == 3);
            Assert.IsTrue(_menuInstance.ExtraIngredientsTwentyCrowns.Count == 2);
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
                new Ingredient { Name = "Vitl�k", Price = 30 }
            };

            var pizza = new Pizza("Kebaben", 3, ingredientList);
            var expected = "Vitl�k";
            var actual = pizza.Ingredients[0];

            Assert.AreEqual(expected, actual.Name);
        }

        [TestMethod]
        public void pizza_builder_should_build_pizzas_using_properties()
        {
            var expected = "JockesPizza";
            var actual = _pizzaBuilder
                         .SetName("JockesPizza")
                         .BuildPizza();

            Assert.AreEqual(expected, actual.Name);
        }

        [TestMethod]
        public void test_the_kebab_creation()
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Kebab", Price = 0 }
            };

            var expected = new Pizza("Kebabpizza", 105, ingredients)
                               .Ingredients[0].Name;

            var actual = _pizzaFactory.CreateKebabPizza()
                                .Ingredients[2].Name;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void drink_factory_should_return_a_coke_when_requested()
        {
            var expected = "Coca cola";
            var actual = _drinkFactory.CreateCocaCola();
            Assert.AreEqual(expected, actual.Name);
        }

        [TestMethod]
        public void adding_extra_topping_through_factory_and_builder_should_add_additional_topping()
        {
            var extraIngredient = new Ingredient { Name = "Ham", Price = 10 };
            var pizza = _pizzaFactory.CreateHawaii();
            pizza.Ingredients.Add(extraIngredient);
            var expected = pizza.Ingredients.Last();

            var initialPizza = _pizzaFactory.CreateHawaii();
            var pizzaWithExtraTopping = _pizzaFactory.AddToppingToPizza(initialPizza, extraIngredient);
            var actual = pizzaWithExtraTopping.Ingredients.Last();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void adding_extra_topping_should_recreate_pizza_as_new_pizza_with_the_additional_topping()
        {
            var extraIngredient = new Ingredient { Name = "Ham", Price = 10 };
            var expected = _pizzaFactory.CreateHawaii();
            expected.Ingredients.Add(extraIngredient);

            var initialPizza = _pizzaFactory.CreateHawaii();
            var pizzaWithExtraTopping = _pizzaFactory.AddToppingToPizza(initialPizza, extraIngredient);
            var actual = pizzaWithExtraTopping;

            Assert.AreNotSame(initialPizza, actual);
        }

        [TestMethod]
        public void inspecting_an_orders_total_price_should_return_correct_amount()
        {
            var drink = _drinkFactory.CreateSprite();
            var pizza = _pizzaFactory.CreateKebabPizza();
            var extraIngredient = new Ingredient { Name = "Ham", Price = 10 };
            pizza = _pizzaFactory.AddToppingToPizza(pizza, extraIngredient);

            var order = new Order
            {
                CustomerName = "Steffe",
                Pizzas = new List<Pizza> { pizza },
                Drinks = new List<Drink> { drink }
            };

            var expected = 140;
            var actual = order.TotalPrice;
            Assert.AreEqual(expected, actual);
        }
    }
}