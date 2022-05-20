using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            ShoppingCart shoppingCart;
            try { shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Session.GetString("ShoppingCart")); }
            catch { shoppingCart = new ShoppingCart(); }

            var viewModel = new HomeViewModel
            {
                NewArrivals = await _productRepository.GetAsync(),
                ShoppingCart = shoppingCart
            };

            return View(viewModel);
        }










        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}