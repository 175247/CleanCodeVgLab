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

        void ReduceAmountInStock(Ingredient ingredient);
        void ReceiveMassDelivery();
        void RestockSingleIngredient(int id);
        void ReduceOrderedIngredients(List<Ingredient> ingredientsList);
    }
}
