using PizzaStorage.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaStorage.Utilities
{
    public interface IRequestService
    {
        Pizza CreatePizza(IEnumerable<Ingredient> allIngredients);
        Task<HttpResponseMessage> HandleRequests(string endpoint, Ingredient ingredient);
        Task<HttpResponseMessage> HandleRequests(string endpoint, List<Ingredient> ingredients);
    }
}
