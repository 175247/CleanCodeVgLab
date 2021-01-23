using PizzaStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStorage.Repository
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        Ingredient GetSpecificIngredient(string ingredientName);
        IEnumerable<Ingredient> GetAllIngredients();
    }
}
