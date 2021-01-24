using PizzaStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaStorage.Utilities
{
    public interface IRequestService
    {
        HttpContent CreateStringContent(Ingredient ingredient);
        HttpContent CreateStringContent(List<Ingredient> ingredientsList);
    }
}
