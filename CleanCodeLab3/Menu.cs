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

        public List<FoodsAndDrinks> PizzaMenu { get; set; } = new List<FoodsAndDrinks>();
        public List<FoodsAndDrinks> DrinksMenu { get; set; } = new List<FoodsAndDrinks>();
        public List<FoodsAndDrinks> ExtraIngredientsTenCrowns { get; set; } = new List<FoodsAndDrinks>();
        public List<FoodsAndDrinks> ExtraIngredientsFifteenCrowns { get; set; } = new List<FoodsAndDrinks>();
        public List<FoodsAndDrinks> ExtraIngredientsTwentyCrowns { get; set; } = new List<FoodsAndDrinks>();

        private Menu()
        {
        }

        public void GenerateMenuItems()
        {
            var pizzaMargerita = new FoodsAndDrinks("Margerita", new[] { "Ost", "Tomatsås" }, 85);
            var pizzaHawaii = new FoodsAndDrinks("Hawaii", new[] { "Ost", "Tomatsås", "Skinka", "Ananas" }, 95);

            var pizzaKebabpizza = new FoodsAndDrinks("Kebabpizza", new[]
            { "Ost", "Tomatsås", "Kebab", "Champinjoner",
              "Lök", "Feferoni", "Isbergssallad", "Tomat", "Kebabsås" }, 105);

            var pizzaQuattroStagioni = new FoodsAndDrinks("Quattro Stagioni", new[]
            { "Ost", "Tomatsås", "Skinka", "Räkor", "Musslor",
            "Champinjoner", "Kronärtskocka" }, 115);

            PizzaMenu.Add(pizzaMargerita);
            PizzaMenu.Add(pizzaHawaii);
            PizzaMenu.Add(pizzaKebabpizza);
            PizzaMenu.Add(pizzaQuattroStagioni);

            var drinksCocaCola = new FoodsAndDrinks("Coca Cola", new[] { "" }, 20);
            var drinksFanta = new FoodsAndDrinks("Fanta", new[] { "" }, 20);
            var drinksSprite = new FoodsAndDrinks("Sprite", new[] { "" }, 25);

            DrinksMenu.Add(drinksCocaCola);
            DrinksMenu.Add(drinksFanta);
            DrinksMenu.Add(drinksSprite);

            var extraHam = new FoodsAndDrinks("Skinka", new[] { "" }, 10);
            var extraPineapple = new FoodsAndDrinks("Ananas", new[] { "" }, 10);
            var extraMushrooms = new FoodsAndDrinks("Champinjoner", new[] { "" }, 10);
            var extraOnion = new FoodsAndDrinks("Lök", new[] { "" }, 10);
            var extraKebabSauce = new FoodsAndDrinks("Kebabsås", new[] { "" }, 10);

            var extraShrimps = new FoodsAndDrinks("Räkor", new[] { "" }, 15);
            var extraClams = new FoodsAndDrinks("Musslor", new[] { "" }, 15);
            var extraArtichoke = new FoodsAndDrinks("Kronärtskocka", new[] { "" }, 15);

            var extraKebab = new FoodsAndDrinks("Kebab", new[] { "" }, 20);
            var extraCoriander = new FoodsAndDrinks("Koriander", new[] { "" }, 20);

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
        }
    }
}