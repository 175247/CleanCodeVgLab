using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLab3
{
    public class FoodsAndDrinks
    {
        public string Name { get; set; }
        public string[] Ingredients { get; set; }
        public double Price { get; set; }

        public FoodsAndDrinks()
        {
        }

        public FoodsAndDrinks(string name, string[] ingredients, double price)
        {
            Name = name;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
