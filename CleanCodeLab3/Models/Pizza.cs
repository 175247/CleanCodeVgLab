using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeLab3.Models
{
    public class Pizza
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public List<Ingredient> Ingredients { get; private set; }

        public Pizza(string name, double price, List<Ingredient> ingredients)
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
        }
    }
}
