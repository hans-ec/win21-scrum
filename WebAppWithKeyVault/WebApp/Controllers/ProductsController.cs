using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProduct _product;

        public ProductsController(IProduct product)
        {
            _product = product;
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var shoppingCart = new ShoppingCart();
            var session = HttpContext.Session.GetString("ShoppingCart");

            if(id != 0)
            {
                if (!string.IsNullOrEmpty(session))
                {
                    shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(session);
                    int index = shoppingCart.Items.FindIndex(x => x.Product.Id == id);

                    if (index != -1)
                        shoppingCart.Items[index].Quantity += 1;
                    else
                        shoppingCart.Items.Add(new CartItem { Product = await _product.GetAsync(id) });
                }
                else
                {
                    shoppingCart.Items.Add(new CartItem { Product = await _product.GetAsync(id) });
                }

            }

            HttpContext.Session.SetString("ShoppingCart", JsonConvert.SerializeObject(shoppingCart));
            return new OkObjectResult(HttpContext.Session.GetString("ShoppingCart"));
        }
    }
}
