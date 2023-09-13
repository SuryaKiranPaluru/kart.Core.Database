using kart.Core.Dto.RequestModel;
using kart.Service.Api.Controllers;
using kart.Service.Buisness;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace kart.Service.UnitTest.ControllerTest
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
        public void GetProductsByTitle_should_return_all_products_with_matched_titles_from_database()
        {
            string title = "Nike";

            mockSearchService.Setup(x => x.GetProductsByTitle(title));
            var result = searchController.GetProductsByTitle(title);
            var actual = result as OkObjectResult;
            Assert.AreEqual(200, actual.StatusCode);
        }

        [TestMethod]
        public void GetProductsByCategory_should_return_all_products_with_matched_category_from_database()
        {
            int category = 1;

            mockSearchService.Setup(x => x.GetProductsByCategory(category));
            var result = searchController.GetProductsByCategory(category);
            var actual = result as OkObjectResult;
            Assert.AreEqual(200, actual.StatusCode);
        }

    }
}
