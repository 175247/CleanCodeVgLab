using Newtonsoft.Json;
using PizzaStorage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStorage.Utilities
{
    public class RequestService : IRequestService
    {
        static HttpClient client = new HttpClient();
        public Pizza CreatePizza(IEnumerable<Ingredient> allIngredients)
        {
            var skinka = allIngredients.Where(n => n.Name == "Skinka").FirstOrDefault();
            var ananas = allIngredients.Where(n => n.Name == "Ananas").FirstOrDefault();

            var pizza = new Pizza
            {
                Name = "Margerita",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Id = skinka.Id, Name = "Skinka", Price = skinka.Price, AmountInStock = skinka.AmountInStock },
                    new Ingredient { Id = ananas.Id, Name = "Ananas", Price = ananas.Price, AmountInStock = ananas.AmountInStock },
                },
                Price = 85
            };

            return pizza;
        }

        public HttpContent CreateStringContent(Ingredient ingredient)
        {
            return new StringContent(JsonConvert.SerializeObject(ingredient), Encoding.UTF8, "application/json");
        }

        public HttpContent CreateStringContent(List<Ingredient> ingredientsList)
        {
            return new StringContent(JsonConvert.SerializeObject(ingredientsList), Encoding.UTF8, "application/json");
        }

        public async Task<HttpResponseMessage> HandleRequests(string endpoint, Ingredient ingredient)
        {
            var requestUri = string.Format("http://localhost/api/storage/{0}", endpoint);
            HttpContent requestContent = CreateStringContent(ingredient);
            var response = await client.PostAsync(requestUri, requestContent);
            return response;
        }

        public async Task<HttpResponseMessage> HandleRequests(string endpoint, List<Ingredient> ingredients)
        {
            var requestUri = string.Format("http://localhost/api/storage/{0}", endpoint);
            HttpContent requestContent = CreateStringContent(ingredients);
            var response = await client.PostAsync(requestUri, requestContent);
            return response;
        }
    }
}
