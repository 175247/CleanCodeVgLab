using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLab3.Models
{
    public class Order
    {
        private double _totalPrice => CalculateTotalPrice();

        public string CustomerName { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public List<Drink> Drinks { get; set; }
        public double TotalPrice { get => _totalPrice; }

        public Order()
        {
        }

        public Order(string customerName, Pizza pizza, Drink drink)
        {
            CustomerName = customerName;
            Pizzas = new List<Pizza>();
            Drinks = new List<Drink>();
        }

        private double CalculateTotalPrice()
        {
            double pizzaPrice = GetPizzaPrices();
            double drinksPrice = GetDrinkPrices();
            double orderPrice = pizzaPrice + drinksPrice;
            
            return orderPrice;
        }

        private double GetPizzaPrices()
        {
            double pizzaPrice = 0;
            
            foreach (var pizza in Pizzas)
            {
                pizzaPrice += pizza.Price;
                foreach (var extraIngredient in pizza.Ingredients)
                {
                    pizzaPrice += extraIngredient.Price;
                }
            }

            return pizzaPrice;
        }

        private double GetDrinkPrices()
        {
            double drinksPrice = 0;
            foreach (var drink in Drinks)
            {
                drinksPrice += drink.Price;
            }

            return drinksPrice;
        }
    }
}
