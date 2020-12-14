using CleanCodeLab3;
using CleanCodeLab3.Models;
using CleanCodeLab3.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CleanCodeLab3Test
{
    [TestClass]
    public class CleanCodeLab3Test
    {
        private readonly PizzaFactory _pizzaFactory;
        private readonly PizzaBuilder _pizzaBuilder;
        private readonly PizzaService _pizzaService;
        private readonly DrinkFactory _drinkFactory;
        private readonly DrinkService _drinkService;
        private readonly OrderSystem _orderSystem;
        private readonly Helpers _helpers;
        private Menu _menuInstance;

        // Add the following to all _menuInstance tests:
        // _menuInstance.ClearMenu();
        // Then proceed with _menuInstance.GenerateMenuItems();

        // Worth noting - unfortunately you have to un=comment all the Console.Clear()'s in
        // OrderSystem, otherwise the program won't run as intended.

        public CleanCodeLab3Test()
        {
            _orderSystem = new OrderSystem();
            _pizzaFactory = new PizzaFactory();
            _pizzaBuilder = new PizzaBuilder();
            _pizzaService = new PizzaService(_orderSystem);
            _drinkFactory = new DrinkFactory();
            _drinkService = new DrinkService(_orderSystem);
            _helpers = new Helpers();
            _menuInstance = Menu.Instance;
        }

        // Some tests have been omitted as other tests
        // do the same thing, just names and classes differ.
        // Examples: Models > Ingredient, Drink

        [TestMethod]
        public void pizza_factory_should_return_a_pizza_when_called()
        {
            // Arrange
            var expected = typeof(Pizza);

            // Act
            var actual = _pizzaFactory.CreateMargerita();

            // Assert
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
            Assert.IsNotNull(_menuInstance.ExtraIngredients);
        }

        [TestMethod]
        public void greeting_customer_should_print_to_console()
        {
            // Arrange
            var expected = string.Format("Hej!{0}", Environment.NewLine);

            // Act
            var actual = _orderSystem.GreetCustomer();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void print_introduction_and_menu_should_contain_correct_data()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                _orderSystem.PrintIntroductionAndMenu();

                var expected = string.Format(
                "Hej!{0}" +
                "{0}Var vänlig välj vad du vill köpa i listan med siffror." +
                "{0}1. Pizza" +
                "{0}2. Dryck{0}",
                Environment.NewLine);

                var actual = stringWriter.ToString();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void clear_all_lists_should_leave_empty_lists()
        {
            // Arrange
            var pizzaMenu = _orderSystem.PizzeriaMenu.PizzaMenu;
            var drinksMenu = _orderSystem.PizzeriaMenu.DrinksMenu;
            var extraIngredientsMenu = _orderSystem.PizzeriaMenu.ExtraIngredients;

            pizzaMenu.Add(_pizzaFactory.CreateMargerita());
            drinksMenu.Add(_drinkFactory.CreateCocaCola());
            extraIngredientsMenu.Add(new Ingredient { Name = "Koriander", Price = 1337 });

            var expected = pizzaMenu.Count + drinksMenu.Count + extraIngredientsMenu.Count;

            // Act
            _orderSystem.ClearAllLists();

            expected = pizzaMenu.Count + drinksMenu.Count + extraIngredientsMenu.Count;

            // Assert
            Assert.IsTrue(expected == 0);
        }

        [TestMethod]
        public void getting_customer_input_should_return_single_number_as_string()
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                // Arrange
                Console.SetOut(stringWriter);
                var numberInput = new StringReader("1");
                Console.SetIn(numberInput);
                var expected = 1;

                // Act
                var actual = _helpers.GetCustomerSelection(1);

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void call_to_display_selected_items_and_choice_is_pizzas_should_display_pizzas()
        {
            // Arrange
            _menuInstance.ClearMenu();
            _menuInstance.GenerateMenuItems();

            var expected = string.Format(
                "Pizzor:{0}" +
                "--------------------{0}" +
                "1. Margerita: Ost, Tomatsås, 85kr.{0}" +
                "2. Hawaii: Ost, Tomatsås, Skinka, Ananas, 95kr.{0}" +
                "3. Kebabpizza: Ost, Tomatsås, Kebab, Champinjoner, Lök, Feferoni, Isbergssallad, Tomat, Kebabsås, 105kr.{0}" +
                "4. Quattro Stagioni: Ost, Tomatsås, Skinka, Räkor, Musslor, Champinjoner, Kronärtskocka, 115kr.{0}",
                Environment.NewLine);

            // Act
            var actual = _pizzaService.PrintPizzaOptions();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void call_to_display_selected_items_and_choice_is_drinks_should_display_drinks()
        {
            // Arrange
            _menuInstance.GenerateMenuItems();

            var expected = string.Format("Drycker:{0}" +
                "--------------------{0}" +
                "1. Coca Cola, 20kr.{0}" +
                "2. Fanta, 20kr.{0}" +
                "3. Sprite, 25kr.{0}",
                Environment.NewLine);

            // Act
            var actual = _drinkService.PrintDrinksOptions();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void initiating_pizza_orders_with_user_selections_should_create_and_return_desired_pizzas()
        {
            // Arrange
            var pizza = _pizzaFactory.CreateMargerita();

            var expectedNameMargerita = "Margerita";
            var expectedNameHawaii = "Hawaii";
            var expectedNameKebabPizza = "Kebabpizza";
            var expectedNameQuattroStagioni = "Quattro Stagioni";

            var expectedNamesArray = new string[4]
            {
                expectedNameMargerita,
                expectedNameHawaii,
                expectedNameKebabPizza,
                expectedNameQuattroStagioni,
            };

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
            }

            // Act & Assert
            for (int i = 0; i < 5; i++)
            {
                var numberInput = i + 1;

                switch (i)
                {
                    case 0:
                        var actualNameMargerita = _pizzaService.GetBasePizza(numberInput);
                        Assert.AreEqual(expectedNamesArray[i], actualNameMargerita.Name);
                        break;

                    case 1:
                        var actualNameHawaii = _pizzaService.GetBasePizza(numberInput);
                        Assert.AreEqual(expectedNamesArray[i], actualNameHawaii.Name);
                        break;

                    case 2:
                        var actualNameKebabPizza = _pizzaService.GetBasePizza(numberInput);
                        Assert.AreEqual(expectedNamesArray[i], actualNameKebabPizza.Name);
                        break;

                    case 3:
                        var actualNameQuattroStagioni = _pizzaService.GetBasePizza(numberInput);
                        Assert.AreEqual(expectedNamesArray[i], actualNameQuattroStagioni.Name);
                        break;

                    default:
                        break;
                }
            }
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
            Assert.IsTrue(_menuInstance.ExtraIngredients.Count == 10);
        }

        [TestMethod]
        public void ingredients_names_get_and_set_should_work()
        {
            // Arrange
            var ingredient = new Ingredient { Name = "Mamma mu" };
            var expected = "Mamma mu";

            // Act
            var actual = ingredient.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void pizza_properties_should_work()
        {
            // Arrange
            var ingredientList = new List<Ingredient>
            {
                new Ingredient { Name = "Vitl�k", Price = 30 }
            };

            var pizza = new Pizza("Kebaben", ingredientList, 3);
            var expected = "Vitl�k";

            // Act
            var actual = pizza.Ingredients[0];

            //Assert
            Assert.AreEqual(expected, actual.Name);
        }

        [TestMethod]
        public void pizza_builder_should_build_pizzas_using_properties()
        {
            // Arrange
            var expected = "JockesPizza";
            // Act
            var actual = _pizzaBuilder
                         .SetName("JockesPizza")
                         .BuildPizza();

            //Assert
            Assert.AreEqual(expected, actual.Name);
        }

        [TestMethod]
        public void getting_customer_ingredient_choice_should_return_an_ingredient()
        {
            _menuInstance.GenerateMenuItems();

            using (StringReader stringReader = new StringReader("1"))
            {
                // Arrange
                Console.SetIn(stringReader);
                var expected = new Ingredient { Name = "Skinka", Price = 10 };

                // Act
                var actual = _pizzaService.GetCustomerIngredientChoice(1);

                // Assert
                Assert.AreEqual(expected.Name, actual.Name);
            }
        }

        [TestMethod]
        public void adding_extra_ingredient_to_pizza_should_return_a_pizza_with_the_extra_ingredient()
        {
            // Arrange
            var ingredient = new Ingredient { Name = "Loek", Price = 370 };
            var pizza = _pizzaFactory.CreateKebabPizza();
            pizza.Ingredients.Add(ingredient);
            var expected = pizza;

            // Act
            var actual = _pizzaService.AddExtraIngredientToPizza(pizza, ingredient);

            // Assert
            Assert.AreEqual(expected.Ingredients.Last(), actual.Ingredients.Last());
        }

        [TestMethod]
        public void wanting_to_edit_pizza_should_display_pizzas_available_to_edit()
        {
            // Arrange
            _orderSystem.CustomerOrder = new Order();
            _orderSystem.CustomerOrder.Pizzas.Add(_pizzaFactory.CreateHawaii());
            _orderSystem.CustomerOrder.Pizzas.Add(_pizzaFactory.CreateKebabPizza());

            var expected = string.Format(
                "Vilken pizza vill du lägga till toppings på?{0}" +
                "1. Hawaii{0}" +
                "2. Kebabpizza{0}", Environment.NewLine);

            // Act
            var actual = _pizzaService.DisplayPizzasAvailableToEdit();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void selecting_pizza_to_edit_should_return_a_selected_pizza_that_customer_wants_to_edit()
        {
            using (StringReader stringReader = new StringReader("1"))
            {
                Console.SetIn(stringReader);

                // Arrange
                var expected = _pizzaFactory.CreateMargerita();
                _orderSystem.CustomerOrder = new Order();
                _orderSystem.CustomerOrder.Pizzas.Add(expected);

                // Act
                var actual = _pizzaService.SelectPizzaToEdit();

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void calling_set_order_to_complete_should_return_a_string_message()
        {
            // Arrange
            _orderSystem.CustomerOrder = new Order();
            var expected = "Tack för ditt köp och välkommen åter!";

            // Act
            var actual = _orderSystem.SetOrderToComplete();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void calling_set_order_to_complete_should_set_order_status_to_completed()
        {
            // Arrange
            _orderSystem.CustomerOrder = new Order();
            var expected = Order.OrderStatus.Completed;

            // Act
            var actual = _orderSystem.CustomerOrder.Status;
            _orderSystem.SetOrderToComplete();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void calling_set_order_to_cancelled_should_print_message_to_screen()
        {
            // Arrange
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                _orderSystem.CustomerOrder = new Order();
                var expected = string.Format("Ordern är avbruten.{0}", Environment.NewLine);

                // Act
                _orderSystem.SetOrderToCancelled();

                // Assert
                Assert.AreEqual(expected, stringWriter.ToString());
            }
        }

        [TestMethod]
        public void calling_set_order_to_cancelled_should_set_order_status_to_cancelled()
        {
            // Arrange
            _orderSystem.CustomerOrder = new Order();
            var expected = Order.OrderStatus.Cancelled;

            // Act
            _orderSystem.SetOrderToCancelled();
            var actual = _orderSystem.CustomerOrder.Status;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void logic_that_handles_if_customer_wants_extra_ingredient_or_not_should_work_as_expected()
        {
            // Arrange 1 & 2
            var pizza = _pizzaFactory.CreateMargerita();

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    using (StringReader stringReader = new StringReader("2"))
                    {
                        Console.SetIn(stringReader);
                        var expected = pizza;
                        expected.Ingredients.Add(new Ingredient { Name = "Ananas", Price = 10 });

                        // Act
                        var actual = _pizzaService.HandleExtraIngredientOrNot(pizza, true);

                        // Assert
                        Assert.AreEqual(pizza.Ingredients.Last().Name, actual.Ingredients.Last().Name);
                    }
                }

                if (i == 1)
                {
                    var expected = pizza;

                    // Act 2
                    var actual = _pizzaService.HandleExtraIngredientOrNot(pizza, false);

                    // Assert 2
                    Assert.AreEqual(pizza, actual);
                }
            }
        }

        [TestMethod]
        public void adding_pizza_to_order_should_add_pizza_to_order()
        {
            // Arrange
            var pizza = _pizzaFactory.CreateMargerita();
            var expected = 1;

            _orderSystem.CustomerOrder = new Order();
            _orderSystem.AddPizzaToOrder(pizza);

            // Act
            var actual = _orderSystem.CustomerOrder.Pizzas.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void method_should_return_true_when_requesting_extra_ingredient()
        {
            // Arrange 1 & 2
            for (int i = 1; i < 3; i++)
            {
                using (StringReader stringReader = new StringReader(i.ToString()))
                {
                    Console.SetIn(stringReader);

                    if (i == 1)
                    {
                        // Act 1
                        var actual = _pizzaService.AskIfExtraIngredientIsWanted();

                        // Assert 1
                        Assert.IsTrue(actual == true);
                    }

                    if (i == 2)
                    {
                        // Act 2
                        var actual = _pizzaService.AskIfExtraIngredientIsWanted();

                        // Assert 2
                        Assert.IsTrue(actual == false);
                    }
                }
            }
        }

        [TestMethod]
        public void attempt_to_get_drink_should_return_drink()
        {
            // Arrange 1, 2 & 3
            for (int i = 1; i < 4; i++)
            {
                if (i == 1)
                {
                    var expected = "Coca Cola";

                    // Act 1
                    var actual = _drinkService.GetDrink(i).Name;

                    // Assert 1
                    Assert.AreEqual(expected, actual);
                }

                if (i == 2)
                {
                    var expected = "Fanta";

                    // Act 2
                    var actual = _drinkService.GetDrink(i).Name;

                    // Assert 2
                    Assert.AreEqual(expected, actual);
                }

                if (i == 3)
                {
                    var expected = "Sprite";

                    // Act 3
                    var actual = _drinkService.GetDrink(3).Name;

                    // Assert 3
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        public void display_extra_ingredients_to_customer_should_return_correct_values()
        {
            // Arrange
            _menuInstance.ClearMenu();
            _menuInstance.GenerateMenuItems();

            var expected = string.Format("Vilka extra toppings vill du ha på din pizza?{0}" +
                "1. Skinka, 10kr.{0}" +
                "2. Ananas, 10kr.{0}" +
                "3. Champinjoner, 10kr.{0}" +
                "4. Lök, 10kr.{0}" +
                "5. Kebabsås, 10kr.{0}" +
                "6. Räkor, 15kr.{0}" +
                "7. Musslor, 15kr.{0}" +
                "8. Kronärtskocka, 15kr.{0}" +
                "9. Kebab, 20kr.{0}" +
                "10. Koriander, 20kr.{0}",
                Environment.NewLine);

            // Act
            var actual = _pizzaService.DisplayExtraIngredientsToCustomer();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void removing_pizza_from_order_should_remove_pizza_from_order()
        {
            // Arrange
            _orderSystem.CustomerOrder = new Order();
            var pizza = _pizzaFactory.CreateMargerita();
            _orderSystem.CustomerOrder.Pizzas.Add(pizza);
            var expected = 0;

            _orderSystem.RemovePizzaFromOrder(pizza);

            // Act
            var actual = _orderSystem.CustomerOrder.Pizzas.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void running_full_drink_procedure_should_add_drink_to_order()
        {
            // Arrange
            using (var stringReader = new StringReader("2"))
            {
                Console.SetIn(stringReader);
                _orderSystem.CustomerOrder = new Order();
                var expected = 1;

                _drinkService.RunAddDrinkProcedure();

                // Act
                var actual = _orderSystem.CustomerOrder.Drinks.Count;

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void adding_drink_to_order_should_add_drink_to_order()
        {
            // Arrange
            var drink = _drinkFactory.CreateCocaCola();
            var expected = 1;

            _orderSystem.CustomerOrder = new Order();
            _orderSystem.AddDrinkToOrder(drink);

            // Act
            var actual = _orderSystem.CustomerOrder.Drinks.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void removing_drink_from_order_should_remove_drink_from_order()
        {
            // Arrange
            _orderSystem.CustomerOrder = new Order();
            var drink = _drinkFactory.CreateCocaCola();
            _orderSystem.CustomerOrder.Drinks.Add(drink);
            var expected = 0;

            _orderSystem.RemoveDrinkFromOrder(drink);

            // Act
            var actual = _orderSystem.CustomerOrder.Drinks.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void display_customer_order_should_display_items_in_order()
        {
            // Arrange
            _orderSystem.CustomerOrder = new Order
            {
                CustomerName = "Snyggingen",
                Pizzas = new List<Pizza>
                {
                  _pizzaFactory.CreateMargerita(),
                  _pizzaFactory.CreateKebabPizza()
                },
                Drinks = new List<Drink>
                {
                    _drinkFactory.CreateCocaCola()
                }
            };

            var expected = string.Format("Det här är din nuvarande order:{0}" +
                "{0}" +
                "Pizzor:{0}" +
                "--------------------" +
                "{0}1. Margerita, 85kr.{0}" +
                "Extra ingredienser:{0}{0}" +
                "2. Kebabpizza, 105kr.{0}" +
                "Extra ingredienser:{0}{0}" +
                "Drycker:{0}" +
                "--------------------" +
                "{0}1. Coca Cola, 20kr.{0}" +
                "{0}" +
                "{0}" +
                "Totalt pris blir: 210kr. {0}",
                Environment.NewLine);

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                // Act
                var actual = _orderSystem.DisplayCustomerOrder();

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void checking_if_order_contains_pizzas_should_return_true_when_pizzas_are_present()
        {
            // Arrange
            _orderSystem.CustomerOrder = new Order();
            _orderSystem.AddPizzaToOrder(_pizzaFactory.CreateMargerita());

            // Act
            var actual = _orderSystem.CheckIfOrderContainsPizzas();

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void checking_if_order_contains_pizzas_should_return_false_when_pizzas_are_not_present()
        {
            // Arrange
            _orderSystem.CustomerOrder = new Order();
            _orderSystem.AddDrinkToOrder(_drinkFactory.CreateCocaCola());

            // Act
            var actual = _orderSystem.CheckIfOrderContainsPizzas();

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void main_menu_options_should_be_returned_as_string_for_separate_printing_to_console()
        {
            // Arrage
            var expected = string.Format(
                "Var vänlig välj vad du vill köpa i listan med siffror." +
                "{0}1. Pizza{0}2. Dryck", Environment.NewLine);

            // Act
            var actual = _orderSystem.DisplayMainMenuOptions();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void initiating_a_new_order_should_reset_order_system()
        {
            // Arrange
            _menuInstance.ClearMenu();
            _menuInstance.GenerateMenuItems();
            _orderSystem.CustomerOrder = new Order();
            _orderSystem.CustomerOrder.CustomerName = "Luigi";

            var expected = _orderSystem.CustomerOrder.CustomerName == "Luigi";
            _orderSystem.InitiateNewOrder();

            // Act
            var actual = _orderSystem.CustomerOrder.CustomerName == "";

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void test_the_kebab_creation()
        {
            // Arrange
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Kebab", Price = 0 }
            };

            var expected = new Pizza("Kebabpizza", ingredients, 105)
                               .Ingredients[0].Name;

            // Act
            var actual = _pizzaFactory.CreateKebabPizza()
                                .Ingredients[2].Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void drink_factory_should_return_a_coke_when_requested()
        {
            // Arrange
            var expected = "Coca Cola";

            // Act
            var actual = _drinkFactory.CreateCocaCola();

            // Assert
            Assert.AreEqual(expected, actual.Name);
        }

        [TestMethod]
        public void adding_extra_topping_through_factory_and_builder_should_add_additional_topping()
        {
            // Arrange
            var extraIngredient = new Ingredient { Name = "Ham", Price = 10 };
            var pizza = _pizzaFactory.CreateHawaii();
            pizza.Ingredients.Add(extraIngredient);
            var expected = pizza.Ingredients.Count;

            var initialPizza = _pizzaFactory.CreateHawaii();
            var pizzaWithExtraTopping = _pizzaFactory.AddToppingToPizza(initialPizza, extraIngredient);

            // Act
            var actual = pizza.Ingredients.Count;

            // Assert
            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void adding_extra_topping_should_recreate_pizza_as_new_pizza_with_the_additional_topping()
        {
            // Arrange
            var extraIngredient = new Ingredient { Name = "Ham", Price = 10 };
            var expected = _pizzaFactory.CreateHawaii();
            expected.Ingredients.Add(extraIngredient);

            var initialPizza = _pizzaFactory.CreateHawaii();
            var pizzaWithExtraTopping = _pizzaFactory.AddToppingToPizza(initialPizza, extraIngredient);

            // Act
            var actual = pizzaWithExtraTopping;

            // Assert
            Assert.AreNotSame(initialPizza, actual);
        }

        [TestMethod]
        public void inspecting_an_orders_total_price_should_return_correct_amount()
        {
            // Arrange
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

            // Act
            var actual = order.TotalPrice;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}