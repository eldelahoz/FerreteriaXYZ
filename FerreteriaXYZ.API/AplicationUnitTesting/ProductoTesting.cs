using FerreteriaXYZ.API.Controllers;
using FerreteriaXYZ.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AplicationUnitTesting
{
    public class ProductoTesting
    {
        private readonly ProductoController _controller;

        public ProductoTesting()
        {
            _controller = new ProductoController();
        }
        [Fact]
        public void Get_Ok()
        {
            var result = _controller.Get();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_() { }
    }
}