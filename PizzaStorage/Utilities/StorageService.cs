using Newtonsoft.Json;
using PizzaStorage.Models;
using PizzaStorage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStorage.Utilities
{
    public class StorageService : IStorageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public Dictionary<string, double> PriceList { get; set; }

        public StorageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            PriceList = new Dictionary<string, double>();
            PriceList.Add("Skinka", 10);
            PriceList.Add("Ananas", 10);
            PriceList.Add("Champinjoner", 10);
            PriceList.Add("Lök", 10);
            PriceList.Add("Kebabsås", 10);
            PriceList.Add("Räkor", 15);
            PriceList.Add("Musslor", 15);
            PriceList.Add("Kronärtskocka", 15);
            PriceList.Add("Kebab", 20);
            PriceList.Add("Koriander", 20);
        }

        public Ingredient ConvertToIngredient(object value)
        {
            var stringContent = value.ToString();
            var ingredient = JsonConvert.DeserializeObject<Ingredient>(stringContent);
            return ingredient;
        }

        public void ReduceAmountInStock(Ingredient ingredient)
        {
            ingredient = _unitOfWork.Ingredients.Get(ingredient.Id);
            ingredient.AmountInStock -= 1;
            _unitOfWork.Complete();
        }

        public void ReceiveMassDelivery()
        {
            var ingredients = _unitOfWork.Ingredients.GetAllIngredients();
            foreach (var ingredient in ingredients)
            {
                ingredient.AmountInStock += 10;
            }
            _unitOfWork.Complete();
        }

        public void RestockSingleIngredient(int id)
        {
            var ingredient = _unitOfWork.Ingredients.Get(id);
            ingredient.AmountInStock += 1;
            _unitOfWork.Complete();
        }

        public void ReduceOrderedIngredients(List<Ingredient> ingredientsList)
        {
            // Return bool if loops can't finish and reduce all stores properly
            // In such a case, the pizza shouldn't be able to finish or be ordered.
            var allIngredientsInDatabase = _unitOfWork.Ingredients.GetAllIngredients().ToList();
            foreach (var orderedIngredient in ingredientsList)
            {
                foreach (var ingredient in allIngredientsInDatabase)
                {
                    if (orderedIngredient.Name == ingredient.Name
                        && ingredient.AmountInStock <= 0)
                    {
                        break;
                    }
                    else
                    {
                        if (orderedIngredient.Name == ingredient.Name)
                        {
                            ingredient.AmountInStock -= 1;
                        }
                    }
                }
            }
            _unitOfWork.Complete();
        }
    }
}
