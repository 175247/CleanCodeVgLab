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
            this.context = context;
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return context.Ingredients.ToList();
        }

        public IEnumerable<string> CheckForMissingIngredients(IEnumerable<Ingredient> ingredientList)
        {
            var missingIngredients = new List<string>();
            foreach (var ingredient in ingredientList)
            {
                var retrievedIngredient = Get(ingredient.Id);
                if (retrievedIngredient.AmountInStock <= 0)
                {
                    missingIngredients.Add(retrievedIngredient.Name);
                }
            }

            return missingIngredients;
        }
    }
}
