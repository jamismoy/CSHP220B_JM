using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.Models;
using HelloWorld.Controllers;
using Moq;
using System.Linq;

namespace HelloWorld.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void TestMethodWithFakeClass()
        {
            // Arrange
            var controller = new HomeController(new FakeProductRepository());

            // Act
            var result = controller.Products();

            // Assert
            var products = (Product[])((System.Web.Mvc.ViewResultBase)(result)).Model;
            Assert.AreEqual(4, products.Length, "Length is invalid");
        }

        [TestMethod]
        public void TestMethodWithMoq()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
                .SetupGet(t => t.Products)
                .Returns(() =>
                {
                    return new Product[]{
                new Product{Name="Baseball"},
                new Product{Name="Football"}
                    };
                });

            // Arrange
            var controller = new HomeController(mockProductRepository.Object);

            // Act
            var result = controller.Products();

            // Assert
            var products = (Product[])((System.Web.Mvc.ViewResultBase)(result)).Model;
            Assert.AreEqual(5, products.Length, "Length is invalid");

            Assert.AreEqual(3, products.Where(x => x.Price > 10).Count(),
                "Err 3 products !> 10");

            Assert.AreEqual(2, products.Where(x => x.Price < 10).Count(),
              "Err 2 products !< 10");
        }
    }
}