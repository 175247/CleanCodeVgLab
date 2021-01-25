using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaStorage.Models;
using PizzaStorage.Repository;
using PizzaStorage.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        [HttpPost]
        [Route("add")]
        public IActionResult RestockIngredient([FromBody]object requestContent)
        {
            var ingredient = _storageService.ConvertToIngredient(requestContent);
            if (ingredient.Id == 0)
            {
                return BadRequest();
            }

            if(_storageService.PriceList.ContainsKey(ingredient.Name) == false)
            {
                return BadRequest();
            }
            else
            {
                _storageService.RestockSingleIngredient(ingredient.Id);
                return Created("Restock", ingredient);
            }
        }

        [HttpGet]
        [Route("massdelivery")]
        public IActionResult MassDelivery()
        {
            _storageService.ReceiveMassDelivery();
            return Ok();
        }

        [HttpPost]
        [Route("remove")]
        public IActionResult ReduceIngredientInStorage([FromBody]object requestContent)
        {
            var ingredient = _storageService.ConvertToIngredient(requestContent);
            if (ingredient.AmountInStock <= 0)
            {
                return NotFound();
            }
            else
            {
                _storageService.ReduceAmountInStock(ingredient);
                return Ok();
            }
        }

        [HttpDelete]
        [Route("ResetTests")]
        public IActionResult ResetTests([FromQuery] string ingredientName, [FromQuery] string actionPerformed)
        {
            if (ingredientName == null
                || actionPerformed == null)
            {
                return BadRequest();
            }
            else
            {
                _storageService.ResetTests(ingredientName, actionPerformed);
                return Ok();
            }
        }

        [HttpPost]
        [Route("order")]
        public IActionResult FinalizeOrder([FromBody] object requestContent)
        {
            var ingredientsList = _storageService.ConvertToIngredientList(requestContent);

            if (ingredientsList.Count <= 0)
            {
                return BadRequest();
            }

            if (ingredientsList[0].Id == 0)
            {
                return BadRequest();
            }
            else
            {
                var isSuccess = _storageService.ReduceOrderedIngredients(ingredientsList);
                if (isSuccess == false)
                {
                    return NotFound();
                }
                else
                {
                    return Ok();
                }
            }
        }
    }
}
