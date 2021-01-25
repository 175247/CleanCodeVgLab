using System.Collections.Generic;

namespace PizzaStorage.Models
{
    public class Pizza
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
