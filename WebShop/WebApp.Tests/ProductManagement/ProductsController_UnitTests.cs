using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Controllers;
using WebApp.Models;
using WebApp.Repositories;
using Xunit;

namespace WebApp.Tests.ProductManagement
{
    public class ProductsController_UnitTests
    {
        [Fact]
        public async Task Index_Should_Return_ViewResult_With_A_List_Of_Products()
        {
            // Arrange
            var productRepository = new Mock<IProductRepository>();
            productRepository
                .Setup(x => x.GetProductsAsync())
                .ReturnsAsync(await ProductsFixtures.GetProductsAsync());

            var sut = new ProductsController(productRepository.Object);


            // Act
            var result = await sut.Index();


            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }
    }
}
