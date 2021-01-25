using PizzaStorage.Models;
using System.Collections.Generic;

namespace PizzaStorage.Repository
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        IEnumerable<Ingredient> GetAllIngredients();
    }
}
