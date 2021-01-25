using PizzaStorage.Models;
using System.Collections.Generic;
using System.Linq;

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
    }
}
