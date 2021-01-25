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
            return View(allIngredients);
        }

        public async Task<IActionResult> RestockIngredient(int id)
        {
            var ingredient = _unitOfWork.Ingredients.Get(id);
            await _requestService.HandleRequests("add", ingredient);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ReduceIngredientInStorage(int id)
        {
            var ingredient = _unitOfWork.Ingredients.Get(id);
            await _requestService.HandleRequests("remove", ingredient);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MassDelivery()
        {
            var requestUri = "http://localhost/api/storage/massdelivery";
            await client.GetAsync(requestUri);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> OrderPizza()
        {
            var allIngredients = _unitOfWork.Ingredients.GetAllIngredients().ToList();
            var pizza = _requestService.CreatePizza(allIngredients);
            var response = await _requestService.HandleRequests("order", pizza.Ingredients);
            if (response.IsSuccessStatusCode == false)
            {
                TempData["status"] = "Ledsen kompis, ingen pizza till dig. Försök igen om kanske 15 minuter en kvart.";
            }
            else
            {
                TempData["status"] = "Tack för ditt köp! Din pizza kommer om ett ögonblick.";
            }
            return RedirectToAction("Index");
        }

        public IActionResult FullReset()
        {
            var allIngredients = _unitOfWork.Ingredients.GetAllIngredients();
            foreach (var ingredient in allIngredients)
            {
                ingredient.AmountInStock = 10;
            }
            _unitOfWork.Complete();
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
