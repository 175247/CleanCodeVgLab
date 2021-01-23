using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStorage.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int InStock { get; set; }
    }
}
