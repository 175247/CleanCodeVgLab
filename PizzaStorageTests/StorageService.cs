using Newtonsoft.Json;
using PizzaStorage.Models;
using PizzaStorage.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStorageTests
{
    public class StorageService
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

        public void Complete()
        {
            _unitOfWork.Complete();
        }

        public Ingredient ConvertToIngredient(object value)
        {
            var stringContent = value.ToString();
            var ingredient = JsonConvert.DeserializeObject<Ingredient>(stringContent);
            return ingredient;
        }

        public List<Ingredient> ConvertToIngredientList(object value)
        {
            var stringContent = value.ToString();
            var ingredientList = JsonConvert.DeserializeObject<List<Ingredient>>(stringContent);
            return ingredientList;
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return _unitOfWork.Ingredients.GetAllIngredients();
        }

        public Ingredient GetById(int id)
        {
            return _unitOfWork.Ingredients.Get(id);
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

        public Ingredient RestockSingleIngredient(int id)
        {
            var ingredient = _unitOfWork.Ingredients.Get(id);
            ingredient.AmountInStock += 1;
            _unitOfWork.Complete();
            return ingredient;
        }

        public bool ReduceOrderedIngredients(List<Ingredient> ingredientsList)
        {
            // Return bool if loops can't finish and reduce all stores properly
            // In such a case, the pizza shouldn't be able to finish or be ordered.
            bool isIngredientPresent = false;
            var allIngredientsInDatabase = _unitOfWork.Ingredients.GetAllIngredients().ToList();
            foreach (var orderedIngredient in ingredientsList)
            {
                foreach (var ingredient in allIngredientsInDatabase)
                {
                    if (orderedIngredient.Name == ingredient.Name
                        && ingredient.AmountInStock <= 0)
                    {
                        isIngredientPresent = false;
                        break;
                    }
                    else
                    {
                        if (orderedIngredient.Name == ingredient.Name)
                        {
                            ingredient.AmountInStock -= 1;
                            isIngredientPresent = true;
                        }
                    }
                }
            }
            if (isIngredientPresent == false)
            {
                return isIngredientPresent;
            }
            else
            {
                _unitOfWork.Complete();
                return isIngredientPresent;
            }
        }

        public void ResetTests(string ingredientName, string actionPerformed)
        {
            var allIngredients = _unitOfWork.Ingredients.GetAllIngredients();
            var ingredient = allIngredients.Where(n => n.Name == ingredientName).FirstOrDefault();
            if (actionPerformed == "addIngredients")
            {
                ingredient.AmountInStock -= 1;
            }
            else if (actionPerformed == "reduceIngredients")
            {
                ingredient.AmountInStock += 1;
            }
            else if (actionPerformed == "massDelivery")
            {
                foreach (var singleIngredient in allIngredients)
                {
                    singleIngredient.AmountInStock -= 10;
                }
            }
            else if (actionPerformed == "orderMargerita")
            {
                ingredient = allIngredients.Where(n => n.Name == "Skinka").FirstOrDefault();
                ingredient.AmountInStock += 1;
                
                ingredient = allIngredients.Where(n => n.Name == "Ananas").FirstOrDefault();
                ingredient.AmountInStock += 1;
            }
            _unitOfWork.Complete();
        }
    }
}
