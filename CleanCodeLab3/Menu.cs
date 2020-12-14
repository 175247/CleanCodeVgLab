using CleanCodeLab3.Models;
using CleanCodeLab3.Utilities;
using System.Collections.Generic;

namespace CleanCodeLab3
{
    public class Menu
    {
        private static Menu _instance = null;
        public static Menu Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Menu();
                }

                return _instance;
            }
        }

        public List<Pizza> PizzaMenu { get; } = new List<Pizza>();
        public List<Drink> DrinksMenu { get; } = new List<Drink>();
        public List<Ingredient> ExtraIngredients { get; } = new List<Ingredient>();

        private Menu()
        {
        }

        public void GenerateMenuItems()
        {
            DrinksMenu.Add(new Drink { Name = "Coca Cola", Price = 20 });
            DrinksMenu.Add(new Drink { Name = "Fanta", Price = 20 });
            DrinksMenu.Add(new Drink { Name = "Sprite", Price = 25 });

            ExtraIngredients.Add(new Ingredient { Name = "Skinka", Price = 10 });
            ExtraIngredients.Add(new Ingredient { Name = "Ananas", Price = 10 });
            ExtraIngredients.Add(new Ingredient { Name = "Champinjoner", Price = 10 });
            ExtraIngredients.Add(new Ingredient { Name = "Lök", Price = 10 });
            ExtraIngredients.Add(new Ingredient { Name = "Kebabsås", Price = 10 });

            ExtraIngredients.Add(new Ingredient { Name = "Räkor", Price = 15 });
            ExtraIngredients.Add(new Ingredient { Name = "Musslor", Price = 15 });
            ExtraIngredients.Add(new Ingredient { Name = "Kronärtskocka", Price = 15 });

            ExtraIngredients.Add(new Ingredient { Name = "Kebab", Price = 20 });
            ExtraIngredients.Add(new Ingredient { Name = "Koriander", Price = 20 });

            var _pizzaFactory = new PizzaFactory();

            PizzaMenu.Add(_pizzaFactory.CreateMargerita());
            PizzaMenu.Add(_pizzaFactory.CreateHawaii());
            PizzaMenu.Add(_pizzaFactory.CreateKebabPizza());
            PizzaMenu.Add(_pizzaFactory.CreateQuattroStagioni());
        }

        public void ClearMenu()
        {
            _instance.PizzaMenu.Clear();
            _instance.DrinksMenu.Clear();
            _instance.ExtraIngredients.Clear();
        }
    }
}