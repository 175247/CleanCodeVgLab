using Newtonsoft.Json;
using PizzaStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStorage.Utilities
{
    public class RequestService : IRequestService
    {
        public HttpContent CreateStringContent(Ingredient ingredient)
        {
            return new StringContent(JsonConvert.SerializeObject(ingredient), Encoding.UTF8, "application/json");
        }
    }
}
