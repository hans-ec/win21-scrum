using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProduct _product;

        public HomeController(ILogger<HomeController> logger, IProduct product)
        {
            _logger = logger;
            _product = product;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel
            {
                NewArrivals = await _product.GetListAsync(3)
            };
            return View(viewModel);
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