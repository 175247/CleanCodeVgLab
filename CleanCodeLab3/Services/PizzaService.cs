using CleanCodeLab3.Models;
using CleanCodeLab3.Utilities;
using System;

namespace CleanCodeLab3
{
    public class PizzaService
    {
        private readonly Helpers _helpers;
        private readonly PizzaFactory _pizzaFactory;
        private OrderSystem _orderSystem;

        public PizzaService(OrderSystem orderSystem)
        {
            _orderSystem = orderSystem;
            _helpers = new Helpers();
            _pizzaFactory = new PizzaFactory();
        }

        public void RunAddPizzaProcedure()
        {
            Pizza chosenPizza;
            int customerChoice = 0;
            bool isExtraIngredientDesired = false;

            _helpers.PrintToConsole(PrintPizzaOptions());

            customerChoice = _helpers.GetCustomerSelection(4);

            Console.Clear();

            chosenPizza = GetBasePizza(customerChoice);
            isExtraIngredientDesired = AskIfExtraIngredientIsWanted();
            chosenPizza = HandleExtraIngredientOrNot(chosenPizza, isExtraIngredientDesired);

            _orderSystem.AddPizzaToOrder(chosenPizza);
        }

        public string PrintPizzaOptions()
        {
            //Console.Clear();

            var pizzaMenu = _orderSystem.PizzeriaMenu.PizzaMenu;
            var message = string.Format("Pizzor:{0}--------------------{0}", Environment.NewLine);
            var index = 1;

            foreach (var pizza in pizzaMenu)
            {
                var ingredientsList = pizza.Ingredients;
                var ingredients = "";

                for (int i = 0; i < ingredientsList.Count; i++)
                {
                    ingredients += ingredientsList[i].Name + ", ";
                };

                message += string.Format("{0}. {1}: {2}{3}kr.{4}", index, pizza.Name, ingredients, pizza.Price, Environment.NewLine);

                index++;
            }

            return message;
        }

        public Pizza GetBasePizza(int customerChoice)
        {
            Pizza chosenPizza = null;

            switch (customerChoice)
            {
                case 1:
                    chosenPizza = _pizzaFactory.CreateMargerita();
                    break;

                case 2:
                    chosenPizza = _pizzaFactory.CreateHawaii();
                    break;

                case 3:
                    chosenPizza = _pizzaFactory.CreateKebabPizza();
                    break;

                case 4:
                    chosenPizza = _pizzaFactory.CreateQuattroStagioni();
                    break;

                default:
                    break;
            }

            return chosenPizza;
        }

        public bool AskIfExtraIngredientIsWanted()
        {
            _helpers.PrintToConsole(string.Format("Tryck 1 om du vill ha en extra ingrediens på pizzan.{0}Tryck 2 om du inte vill ha något extra på pizzan", Environment.NewLine));
            var customerChoice = _helpers.GetCustomerSelection(2);

            if (customerChoice == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Pizza HandleExtraIngredientOrNot(Pizza chosenPizza, bool isExtraIngredientDesiredOrNot)
        {
            if (isExtraIngredientDesiredOrNot)
            {
                var message = DisplayExtraIngredientsToCustomer();
                _helpers.PrintToConsole(message);

                var customerChoice = _helpers.GetCustomerSelection(10);
                var chosenExtraIngredient = GetCustomerIngredientChoice(customerChoice);
                chosenPizza = AddExtraIngredientToPizza(chosenPizza, chosenExtraIngredient);

                return chosenPizza;
            }
            else
            {
                return chosenPizza;
            }
        }

        public string DisplayExtraIngredientsToCustomer()
        {
            //Console.Clear();

            var message = string.Format("Vilka extra toppings vill du ha på din pizza?{0}", Environment.NewLine);

            for (int i = 0; i < _orderSystem.PizzeriaMenu.ExtraIngredients.Count; i++)
            {
                message += string.Format("{0}. {1}, {2}kr.{3}", i + 1, _orderSystem.PizzeriaMenu.ExtraIngredients[i].Name, _orderSystem.PizzeriaMenu.ExtraIngredients[i].Price, Environment.NewLine);
            }

            return message;
        }

        public Ingredient GetCustomerIngredientChoice(int customerChoice)
        {
            var ingredientChoice = customerChoice - 1;

            return _orderSystem.PizzeriaMenu.ExtraIngredients[ingredientChoice];
        }

        public Pizza AddExtraIngredientToPizza(Pizza pizza, Ingredient ingredient)
        {
            var edittedPizza = _pizzaFactory.AddToppingToPizza(pizza, ingredient);

            return edittedPizza;
        }

        public string DisplayPizzasAvailableToEdit()
        {
            //Console.Clear();
            var message = string.Format("Vilken pizza vill du lägga till toppings på?{0}", Environment.NewLine);

            for (int i = 0; i < _orderSystem.CustomerOrder.Pizzas.Count; i++)
            {
                message += string.Format("{0}. {1}{2}", i + 1, _orderSystem.CustomerOrder.Pizzas[i].Name, Environment.NewLine);
            }

            return message;
        }

        public void EditPizza()
        {
            var pizzaToEdit = SelectPizzaToEdit();

            _orderSystem.RemovePizzaFromOrder(pizzaToEdit);
            pizzaToEdit = HandleExtraIngredientOrNot(pizzaToEdit, true);
            _orderSystem.AddPizzaToOrder(pizzaToEdit);
        }

        public Pizza SelectPizzaToEdit()
        {
            _helpers.PrintToConsole(DisplayPizzasAvailableToEdit());
            var numberOfPizzasInOrder = _orderSystem.CustomerOrder.Pizzas.Count;
            var userInput = _helpers.GetCustomerSelection(numberOfPizzasInOrder);
            var pizzaToEditIndex = userInput - 1;
            var pizzaToEdit = _orderSystem.CustomerOrder.Pizzas[pizzaToEditIndex];
            return pizzaToEdit;
        }
    }
}
