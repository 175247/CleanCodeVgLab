using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PizzaStorage.Models;
using PizzaStorage.Repository;
using PizzaStorage.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStorage.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRequestService _requestService;
        static HttpClient client = new HttpClient();

        public HomeController(IUnitOfWork unitOfWork, IRequestService requestService)
        {
            _unitOfWork = unitOfWork;
            _requestService = requestService;
        }

        public IActionResult Index()
        {
            var allIngredients = _unitOfWork.Ingredients.GetAllIngredients();
            _unitOfWork.Complete();
            return View(allIngredients);
        }

        public async Task<IActionResult> RestockIngredient(Ingredient ingredient)
        {
            var requestUri = "http://localhost/api/storage/add";
            HttpContent requestContent = _requestService.CreateStringContent(ingredient);
            await client.PostAsync(requestUri, requestContent);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ReduceIngredientInStorage(Ingredient ingredient)
        {
            var requestUri = "http://localhost/api/storage/remove";
            HttpContent requestContent = _requestService.CreateStringContent(ingredient);
            await client.PostAsync(requestUri, requestContent);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MassDelivery()
        {
            var requestUri = "http://localhost/api/storage/massdelivery";
            await client.GetAsync(requestUri);
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
