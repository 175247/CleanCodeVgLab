using PizzaStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStorage.Repository
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientDbContext context { get; }

        public IngredientRepository(IngredientDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return context.Ingredients.ToList();
        }

        public Ingredient GetSpecificIngredient(string ingredientName)
        {
            return (Ingredient)context.Ingredients.Where(i => i.Name == ingredientName).Take(1);
        }
    }
}
