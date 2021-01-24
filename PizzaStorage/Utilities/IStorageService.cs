using PizzaStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStorage.Utilities
{
    public interface IStorageService
    {
        public Dictionary<string, double> PriceList { get; set; }

        Ingredient ConvertToIngredient(object value);
        void ReduceAmountInStock(Ingredient ingredient);
        void ReceiveMassDelivery();
        void RestockSingleIngredient(int id);
        bool ReduceOrderedIngredients(List<Ingredient> ingredientsList);
        List<Ingredient> ConvertToIngredientList(object requestContent);
    }
}
