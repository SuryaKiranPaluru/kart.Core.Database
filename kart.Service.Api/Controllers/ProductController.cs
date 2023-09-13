using kart.Core.Dto.RequestModel;
using kart.Service.Buisness;
using Microsoft.AspNetCore.Mvc;

namespace kart.Service.Api.Controllers
{

    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddNewProduct/")]

        public IActionResult AddNewProduct([FromBody] ProductRequestModel product)
        {
            _service.AddNewProduct(product);
            return (Ok("Product Added Successfully"));
        }

        [HttpDelete]
        [Route("DeleteProduct/")]

        public IActionResult DeleteProduct(int productId)
        {
            _service.DeleteProduct(productId);
            return (Ok("Product Deleted Successfully"));
        }

        [HttpPut]
        [Route("ModifyProduct/")]

        public IActionResult ModifyProduct(int productId, string itemToModify, string value)
        {
            _service.ModifyProduct(productId, itemToModify, value);
            return (Ok("Product Modified Successfully"));
        }
    }
}
