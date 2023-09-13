using kart.Core.Dto.RequestModel;
using kart.Service.Api.Controllers;
using kart.Service.Buisness;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace kart.Service.UnitTest
{
    [TestClass]
    public class SearchControllerTest
    {

        public SearchController searchController;
        public Mock<ISearchService> mockSearchService;

        public SearchControllerTest()
        {
            mockSearchService = new Mock<ISearchService>();
            searchController = new SearchController(mockSearchService.Object);

        }

        [TestMethod]
        public void GetAllProducts_should_return_all_products_from_database()
        {


            mockSearchService.Setup(x => x.GetAllProducts());
            var result = searchController.GetAllProducts();
            var actual = result as OkObjectResult;
            Assert.AreEqual(200, actual.StatusCode);
        }

        [TestMethod]
        public void GetAllProducts_should_return_all_products_from_database()
        {


            mockSearchService.Setup(x => x.GetAllProducts());
            var result = searchController.GetAllProducts();
            var actual = result as OkObjectResult;
            Assert.AreEqual(200, actual.StatusCode);
        }

    }
}
