using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using ProductStore.Controllers;
using ProductStore.Models;
using Xunit;

namespace ProductStoreTest
{
    public class ProductControllerTest
    {
        [Fact]
        public void ControllerTest()
        {

            var data = new Products[]
            {
                new Products {CategoryID = 1, ProductName = "Test", UnitPrice = 1200},
                new Products {CategoryID = 2, ProductName = "Test2", UnitPrice = 1201},
                new Products {CategoryID = 3, ProductName = "Test3", UnitPrice = 1202},
                new Products {CategoryID = 4, ProductName = "Test4", UnitPrice = 1203},
                new Products {CategoryID = 5, ProductName = "Test5", UnitPrice = 1204},
                new Products {CategoryID = 6, ProductName = "Test6", UnitPrice = 1205},
                new Products {CategoryID = 7, ProductName = "Test7", UnitPrice = 1206},
                new Products {CategoryID = 8, ProductName = "Test8", UnitPrice = 1207},
                new Products {CategoryID = 9, ProductName = "Test9", UnitPrice = 1208},
                new Products {CategoryID = 10, ProductName = "Test10", UnitPrice = 1209},
                new Products {CategoryID = 11, ProductName = "Test11", UnitPrice = 1210},
            };
            var mock = new Mock<IRepository>();
            mock.Setup(m => m.Product).Returns(data.AsQueryable());

            HomeController homeController = new HomeController(mock.Object);
            homeController.ItemsPerPage = 5;

            var result = homeController.Index().ViewData.Model as IEnumerable<Products>;

            var Products = result.ToArray();

            Assert.Equal("Test8", Products[7].ProductName);

        }
    }
}
