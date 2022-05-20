using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Tests.ProductManagement
{
    public static class ProductsFixtures
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Rawlink Helmet skate black Small", Price = 199 },
            new Product { Id = 2, Name = "NULLSegway Ninebot by Segway Max G30LD II", Price = 6990 },
            new Product { Id = 3, Name = "Xiaomi Mi Electric Scooter 1S", Price = 4290 }
        };

        public static async Task<List<Product>> GetProductsAsync()
        {
            await Task.Delay(300);
            return _products;
        }
    }
}
