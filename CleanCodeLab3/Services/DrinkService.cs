using CleanCodeLab3.Interfaces;
using CleanCodeLab3.Models;
using CleanCodeLab3.Utilities;
using System;

namespace CleanCodeLab3
{
    public class DrinkService
    {
        private readonly Helpers _helpers;
        private readonly IDrinkFactory _drinkFactory;
        private OrderSystem _orderSystem;

        public DrinkService(OrderSystem orderSystem)
        {
            _orderSystem = orderSystem;
            _helpers = new Helpers();
            _drinkFactory = new DrinkFactory();
        }

        public void RunAddDrinkProcedure()
        {
            _helpers.PrintToConsole(PrintDrinksOptions());

            var customerChoice = _helpers.GetCustomerSelection(3);
            var chosenDrink = GetDrink(customerChoice);

            _orderSystem.AddDrinkToOrder(chosenDrink);
        }

        public string PrintDrinksOptions()
        {
            //Console.Clear();

            var drinksMenu = _orderSystem.PizzeriaMenu.DrinksMenu;

            var message = string.Format("Drycker:{0}--------------------{0}", Environment.NewLine);

            for (int i = 0; i < drinksMenu.Count; i++)
            {
                message += string.Format("{0}. {1}, {2}kr.{3}", i + 1, drinksMenu[i].Name, drinksMenu[i].Price, Environment.NewLine);
            }

            return message;
        }

        public Drink GetDrink(int customerChoice)
        {
            Drink chosenDrink = null;

            switch (customerChoice)
            {
                case 1:
                    chosenDrink = _drinkFactory.CreateCocaCola();
                    break;

                case 2:
                    chosenDrink = _drinkFactory.CreateFanta();
                    break;

                case 3:
                    chosenDrink = _drinkFactory.CreateSprite();
                    break;
            }

            return chosenDrink;
        }
    }
}
