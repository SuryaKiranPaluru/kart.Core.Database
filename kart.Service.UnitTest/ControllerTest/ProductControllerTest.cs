using FluentValidation;
using kart.Core.Dto.RequestModel;
using kart.Service.Api.Controllers;
using kart.Service.Buisness;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace kart.Service.UnitTest.ControllerTest
{
    [TestClass]
    public class ProductControllerTest
    {

        public ProductController productController;
        public Mock<IProductService> mockProductService;
        public IValidator<ProductRequestModel> validator;

        public ProductControllerTest()
        {
            mockProductService = new Mock<IProductService>();
            productController = new ProductController(mockProductService.Object, validator);

        }

        [TestMethod]
        public void AddNewProduct_should_add_new_product_to_database()
        {
            ProductRequestModel productRequestModel = new ProductRequestModel
            {
                ProductName = "product name",
                StockQuantity = 1,
                Price = 100,
                ProductDesc = "test",
                UserId = 1,
                Discount = 50,
                CategoryId = 1,
            };

            mockProductService.Setup(x => x.AddNewProduct(productRequestModel));
            var result = productController.AddNewProduct(productRequestModel);
            var actual = result as BadRequestObjectResult;
            Assert.AreEqual(400, actual.StatusCode);
        }

        [TestMethod]
        public void ModifyProduct_should_modify_product_in_database()
        {
            int prodId = 510;
            string itemToModify = "Prod Name";
            string value = "changed name";

            mockProductService.Setup(x => x.ModifyProduct(prodId, itemToModify, value));
            var result = productController.ModifyProduct(prodId, itemToModify, value);
            var actual = result as OkObjectResult;
            Assert.AreEqual(200, actual.StatusCode);
        }

        [TestMethod]

        public void DeleteProduct_should_delete_product_in_database()
        {
            int prodId = 510;

            mockProductService.Setup(x => x.DeleteProduct(prodId));
            var result = productController.DeleteProduct(prodId);
            var actual = result as OkObjectResult;
            Assert.AreEqual(200, actual.StatusCode);
        }
    }
}