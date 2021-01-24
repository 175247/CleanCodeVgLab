using PizzaStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStorage.Repository
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        IEnumerable<string> CheckForMissingIngredients(IEnumerable<Ingredient> ingredientList);
        IEnumerable<Ingredient> GetAllIngredients();
    }
}
