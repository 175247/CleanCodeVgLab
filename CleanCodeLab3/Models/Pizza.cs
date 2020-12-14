using CleanCodeLab3.Interfaces;
using System.Collections.Generic;

namespace CleanCodeLab3.Models
{
    public class Pizza : IOrderable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public Pizza(string name, List<Ingredient> ingredients, double price)
        {
            Name = name;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
