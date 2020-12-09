using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLab3
{
    public class Menu
    {
        private static Menu _instance = null;
        public static Menu Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Menu();
                }

                return _instance;
            }
        }

        public List<MenuItems> PizzaMenu { get; set; } = new List<MenuItems>();
        public List<MenuItems> DrinksMenu { get; set; } = new List<MenuItems>();
        public List<MenuItems> ExtraIngredientsTenCrowns { get; set; } = new List<MenuItems>();
        public List<MenuItems> ExtraIngredientsFifteenCrowns { get; set; } = new List<MenuItems>();
        public List<MenuItems> ExtraIngredientsTwentyCrowns { get; set; } = new List<MenuItems>();

        private Menu()
        {
        }

        public void GenerateMenuItems()
        {
            var drinksCocaCola = new MenuItems { Name = "Coca Cola", Price = 20 };
            var drinksFanta = new MenuItems { Name = "Fanta", Price = 20 };
            var drinksSprite = new MenuItems { Name = "Sprite", Price = 25 };

            DrinksMenu.Add(drinksCocaCola);
            DrinksMenu.Add(drinksFanta);
            DrinksMenu.Add(drinksSprite);

            var extraTomatoSauce = new MenuItems { Name = "Tomatsås", Price = 0 };
            var extraCheese = new MenuItems { Name = "Ost", Price = 0 };
            var extraFeferoni = new MenuItems { Name = "Feferoni", Price = 0 };
            var extraLettuce = new MenuItems { Name = "Isbergssallad", Price = 0 };
            var extraTomato = new MenuItems { Name = "Tomat", Price = 0 };

            var extraHam = new MenuItems { Name = "Skinka", Price = 10 };
            var extraPineapple = new MenuItems { Name = "Ananas", Price = 10 };
            var extraMushrooms = new MenuItems { Name = "Champinjoner", Price = 10 };
            var extraOnion = new MenuItems { Name = "Lök", Price = 10 };
            var extraKebabSauce = new MenuItems { Name = "Kebabsås", Price = 10 };

            var extraShrimps = new MenuItems { Name = "Räkor", Price = 15 };
            var extraClams = new MenuItems { Name = "Musslor", Price = 15 };
            var extraArtichoke = new MenuItems { Name = "Kronärtskocka", Price = 15 };

            var extraKebab = new MenuItems { Name = "Kebab", Price = 20 };
            var extraCoriander = new MenuItems { Name = "Koriander", Price = 20 };

            ExtraIngredientsTenCrowns.Add(extraHam);
            ExtraIngredientsTenCrowns.Add(extraPineapple);
            ExtraIngredientsTenCrowns.Add(extraMushrooms);
            ExtraIngredientsTenCrowns.Add(extraOnion);
            ExtraIngredientsTenCrowns.Add(extraKebabSauce);

            ExtraIngredientsFifteenCrowns.Add(extraShrimps);
            ExtraIngredientsFifteenCrowns.Add(extraClams);
            ExtraIngredientsFifteenCrowns.Add(extraArtichoke);

            ExtraIngredientsTwentyCrowns.Add(extraKebab);
            ExtraIngredientsTwentyCrowns.Add(extraCoriander);

            var pizzaMargerita = new MenuItems { Name = "Margerita", Ingredients = new List<MenuItems> { extraTomatoSauce, extraCheese }, Price = 85 };
            var pizzaHawaii = new MenuItems { Name = "Hawaii", Ingredients = new List<MenuItems> { extraTomatoSauce, extraCheese, extraHam, extraPineapple }, Price = 95 };

            var pizzaKebabpizza = new MenuItems
            {
                Name = "Kebabpizza",
                Ingredients = new List<MenuItems> 
                { 
                    extraTomatoSauce, extraCheese,
                    extraKebab, extraMushrooms, 
                    extraOnion, extraFeferoni, 
                    extraLettuce, extraTomato, extraKebabSauce,
                },
                Price = 105
            };

            var pizzaQuattroStagioni = new MenuItems
            {
                Name = "Quattro Stagioni",
                Ingredients = new List<MenuItems> 
                {
                    extraTomatoSauce, extraCheese,
                    extraHam, extraShrimps, extraClams,
                },
                Price = 115
            };

            PizzaMenu.Add(pizzaMargerita);
            PizzaMenu.Add(pizzaHawaii);
            PizzaMenu.Add(pizzaKebabpizza);
            PizzaMenu.Add(pizzaQuattroStagioni);
        }

        public void ClearMenu()
        {
            _instance.PizzaMenu.Clear();
            _instance.DrinksMenu.Clear();
            _instance.ExtraIngredientsTenCrowns.Clear();
            _instance.ExtraIngredientsFifteenCrowns.Clear();
            _instance.ExtraIngredientsTwentyCrowns.Clear();
        }
    }
}