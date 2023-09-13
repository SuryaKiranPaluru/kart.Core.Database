using kart.Core.Dto.RequestModel;
using kart.Service.Buisness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kart.Service.Api.Controllers
{
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddProductToCart/")]
        [Authorize(Roles = "Customer")]

        public IActionResult AddProductToCart([FromBody] CartRequestModel product)
        {
            _service.AddProductToCart(product);
            return Ok("Product Added Successfully");
        }


        [HttpDelete]
        [Route("RemoveProductFromCart/")]
        [Authorize(Roles = "Customer")]

        public IActionResult DeleteProductFromCart(int productId)
        {
            _service.RemoveProductFromCart(productId);
            return Ok("Product Deleted Successfully");
        }

        [HttpPut]
        [Route("ModifyProductFromCart/")]
        [Authorize(Roles = "Customer")]

        public IActionResult ModifyProductFromCart(int productid, int quantity)
        {
            _service.ModifyProductInCart(productid, quantity);
            return Ok("Cart Item Modified....");
        }

        [HttpGet]
        [Route("GetItemsFromCart/")]
        //[Authorize(Roles = "Customer")]

        public IActionResult ViewItemsInCart(int sessionnId)
        {
            return Ok(_service.ViewItemsInCart(sessionnId));
        }
    }
}
