using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaStorage.Models;
using PizzaStorage.Repository;
using PizzaStorage.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStorage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StorageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorageService _storageService;

        public StorageController(IUnitOfWork unitOfWork, IStorageService storageService)
        {
            _unitOfWork = unitOfWork;
            _storageService = storageService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllIngredients()
        {
            var ingredients = _unitOfWork.Ingredients.GetAll().ToList();
            if (ingredients.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(ingredients);
            }
        }

        [HttpGet]
        [Route("checkstorage")]
        public IActionResult GetIngredientStockStatus(List<Ingredient> ingredientsList)
        {
            var missingIngredients = _unitOfWork.Ingredients.CheckForMissingIngredients(ingredientsList).ToList();
            if (missingIngredients.Count > 0)
            {
                return NotFound(missingIngredients);
            }
            else
            {
                return Ok();
            }
        }

        //[HttpPut]
        [HttpGet]
        [Route("add")]
        public IActionResult RestockIngredient([FromQuery] Ingredient ingredient)
        {
            if(_storageService.PriceList.ContainsKey(ingredient.Name) == false)
            {
                return BadRequest();
            }
            else
            {
                _storageService.RestockSingleIngredient(ingredient.Id);
                return RedirectToAction("Index", "Home");
                //return Created("Restock", ingredient);
            }
        }

        //[HttpPut]
        [HttpGet]
        [Route("massdelivery")]
        public IActionResult MassDelivery()
        {
            _storageService.ReceiveMassDelivery();
            return RedirectToAction("Index", "Home");
            //return Ok();
        }

        //[HttpDelete]
        [HttpGet]
        [Route("remove")]
        public IActionResult ReduceIngredientInStorage([FromQuery] Ingredient ingredient)
        {
            ingredient = _unitOfWork.Ingredients.Get(ingredient.Id);
            if (ingredient.AmountInStock <= 0)
            {
                return NotFound();
            }
            else
            {
                _storageService.ReduceAmountInStock(ingredient);
                return RedirectToAction("Index", "Home");
                //return Ok();
            }
        }

        //[HttpDelete]
        [HttpGet]
        [Route("order")]
        public IActionResult FinalizeOrder(List<Ingredient> ingredientsList)
        {
            if (ingredientsList.Count <= 0)
            {
                return BadRequest();
            }
            else
            {
                _storageService.ReduceOrderedIngredients(ingredientsList);
                return Ok();
            }
        }
    }
}
