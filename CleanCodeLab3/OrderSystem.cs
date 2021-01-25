using CleanCodeLab3.Models;
using CleanCodeLab3.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static CleanCodeLab3.Models.Order;

namespace CleanCodeLab3
{
    public class OrderSystem
    {
        public readonly Menu PizzeriaMenu;
        private readonly Helpers _helpers;
        private readonly PizzaService _pizzaService;
        private readonly DrinkService _drinkService;
        public Order CustomerOrder { get; set; }
        static HttpClient client = new HttpClient();

        public OrderSystem()
        {
            PizzeriaMenu = Menu.Instance;
            _helpers = new Helpers();
            _pizzaService = new PizzaService(this);
            _drinkService = new DrinkService(this);
        }

        public void Run()
        {
            InitiateNewOrder();
            PrintIntroductionAndMenu();

            var customerChoice = _helpers.GetCustomerSelection(2);
            RunSelectedProcedure(customerChoice);
            FinalizeOrder();
        }


        public void InitiateNewOrder()
        {
            //Console.Clear();
            ClearAllLists();
            PizzeriaMenu.GenerateMenuItems();
            CustomerOrder = new Order();
        }

        public void PrintIntroductionAndMenu()
        {
            var message = "";
            message = GreetCustomer();
            _helpers.PrintToConsole(message);

            message = DisplayMainMenuOptions();
            _helpers.PrintToConsole(message);
        }

        public string GreetCustomer()
        {
            var greeting = string.Format("Hej!{0}", Environment.NewLine);

            return greeting;
        }

        public string DisplayMainMenuOptions()
        {
            var message = string.Format(
            "Var vänlig välj vad du vill köpa i listan med siffror." +
            "{0}1. Pizza{0}2. Dryck",
            Environment.NewLine);

            return message;
        }

        public void RunSelectedProcedure(int customerChoice)
        {
            if (customerChoice == 1)
            {
                _pizzaService.RunAddPizzaProcedure();
            }
            else
            {
                _drinkService.RunAddDrinkProcedure();
            }
        }

        public void AskCustomerIfTheyWantToAddAnythingToOrder()
        {
            Console.Clear();

            _helpers.PrintToConsole(DisplayCustomerOrder());
            bool isOrderContainingPizzas = CheckIfOrderContainsPizzas();

            if (isOrderContainingPizzas)
            {
                HandleIsPizzaOrdered();
            }
            else
            {
                HandleIsOnlyDrinkOrdered();
            }
        }

        public bool CheckIfOrderContainsPizzas()
        {
            if (CustomerOrder.Pizzas.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void HandleIsPizzaOrdered()
        {
            _helpers.PrintToConsole(string.Format("{0}Tryck:{0}1. Om du vill lägga till en pizza{0}2. Om du vill lägga till en dricka.{0}3. Om du vill lägga till toppings", Environment.NewLine));

            var userChoice = _helpers.GetCustomerSelection(3);

            switch (userChoice)
            {
                case 1:
                    _pizzaService.RunAddPizzaProcedure();
                    break;

                case 2:
                    _drinkService.RunAddDrinkProcedure();
                    break;

                case 3:
                    _pizzaService.EditPizza();
                    break;
            }

            FinalizeOrder();
        }

        public void HandleIsOnlyDrinkOrdered()
        {
            _helpers.PrintToConsole(string.Format("{0}Tryck:{0}1. Om du vill lägga till en pizza{0}2. Om du vill lägga till en dricka.", Environment.NewLine));

            var userChoice = _helpers.GetCustomerSelection(2);

            switch (userChoice)
            {
                case 1:
                    _pizzaService.RunAddPizzaProcedure();
                    break;

                case 2:
                    _drinkService.RunAddDrinkProcedure();
                    break;
            }

            FinalizeOrder();
        }

        public string DisplayCustomerOrder()
        {
            //Console.Clear();

            var message = string.Format("Det här är din nuvarande order:{0}{0}", Environment.NewLine);

            if (CustomerOrder.Pizzas.Count > 0)
            {
                message += string.Format("Pizzor:{0}--------------------", Environment.NewLine);

                for (int i = 0; i < CustomerOrder.Pizzas.Count; i++)
                {
                    message += string.Format("{0}{1}. {2}, {3}kr.{0}", Environment.NewLine, i + 1, CustomerOrder.Pizzas[i].Name, CustomerOrder.Pizzas[i].Price);

                    message += string.Format("Extra ingredienser:{0}", Environment.NewLine);

                    foreach (var ingredient in CustomerOrder.Pizzas[i].Ingredients)
                    {
                        if (ingredient.Price > 0)
                        {
                            message += string.Format("{0}, {1}kr.{2}", ingredient.Name, ingredient.Price, Environment.NewLine);
                        }
                    }
                }
            }

            if (CustomerOrder.Drinks.Count > 0)
            {
                message += string.Format("{0}Drycker:{0}--------------------{0}", Environment.NewLine);

                for (int j = 0; j < CustomerOrder.Drinks.Count; j++)
                {
                    message += string.Format("{0}. {1}, {2}kr.{3}", j + 1, CustomerOrder.Drinks[j].Name, CustomerOrder.Drinks[j].Price, Environment.NewLine);
                }

                message += Environment.NewLine;
            }

            message += string.Format("{0}Totalt pris blir: {1}kr. {0}", Environment.NewLine, CustomerOrder.TotalPrice);

            return message;
        }

        public string FinalizeOrder()
        {
            Console.Clear();

            _helpers.PrintToConsole(DisplayCustomerOrder());
            _helpers.PrintToConsole(string.Format("{0}Tryck 1 om du vill slutföra köpet.{0}Tryck 2 om du vill avbryta din order.{0}Tryck 3 om du vill ändra eller lägga till något.", Environment.NewLine));

            string message = "";

            var userChoice = _helpers.GetCustomerSelection(3);

            switch (userChoice)
            {
                case 1:
                    message = SetOrderToComplete().GetAwaiter().GetResult();
                    _helpers.PrintToConsole(message);
                    break;

                case 2:
                    SetOrderToCancelled();
                    break;

                case 3:
                    AskCustomerIfTheyWantToAddAnythingToOrder();
                    break;
            }

            return message;
        }

        public void AddPizzaToOrder(Pizza pizza)
        {
            CustomerOrder.Pizzas.Add(pizza);
        }

        public void RemovePizzaFromOrder(Pizza pizza)
        {
            CustomerOrder.Pizzas.Remove(pizza);
        }

        public void AddDrinkToOrder(Drink drink)
        {
            CustomerOrder.Drinks.Add(drink);
        }

        public void RemoveDrinkFromOrder(Drink drink)
        {
            CustomerOrder.Drinks.Remove(drink);
        }

        public async Task<string> SetOrderToComplete()
        {
            //Console.Clear();
            var message = "";
            var allIngredients = new List<Ingredient>();
            foreach (var pizza in CustomerOrder.Pizzas)
            {
                foreach (var ingredient in pizza.Ingredients)
                {
                    allIngredients.Add(ingredient);
                }
            }

            var requestUri = "http://localhost/api/storage/order";
            HttpContent requestContent = new StringContent(JsonConvert.SerializeObject(allIngredients), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(requestUri, requestContent);
            if (response.IsSuccessStatusCode)
            {
                CustomerOrder.Status = OrderStatus.Completed;
                message = "Tack för ditt köp och välkommen åter!";
            }
            else
            {
                message = "Inte tillräckligt med ingredienser, försök igen efter nästa leverans";
                SetOrderToCancelled();
            }
            return message;
        }

        public void SetOrderToCancelled()
        {
            //Console.Clear();
            _helpers.PrintToConsole("Ordern är avbruten.");
            Thread.Sleep(2000);
            CustomerOrder.Status = OrderStatus.Cancelled;
            //Run();
        }

        public void ClearAllLists()
        {
            PizzeriaMenu.PizzaMenu.Clear();
            PizzeriaMenu.DrinksMenu.Clear();
            PizzeriaMenu.ExtraIngredients.Clear();
        }
    }
}