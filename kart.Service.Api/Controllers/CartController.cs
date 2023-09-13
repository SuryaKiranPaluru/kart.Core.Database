using FluentValidation;
using kart.Core.Dto.RequestModel;
using kart.Service.Buisness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kart.Service.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CartController : ControllerBase
    {
        
        private readonly ICartService _service;
        private readonly IValidator<CartRequestModel> _validator;

        public CartController(ICartService service, IValidator<CartRequestModel> validator)
        {
            _service = service;
            _validator = validator;

        }

        [HttpPost]
        [Route("AddProductToCart/")]
        [Authorize(Roles = "Customer")]

        public IActionResult AddProductToCart([FromBody] CartRequestModel product)
        {
            var validationResults = this._validator.Validate(product) ?? new FluentValidation.Results.ValidationResult();
            if (!validationResults.IsValid)
            {
                var errorMessage = string.Empty;
                foreach (var failure in validationResults.Errors)
                {
                    errorMessage += $"Property: {failure.PropertyName} Error Code: {failure.ErrorMessage}\n";
                }
                return BadRequest(errorMessage);
            }
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
        [Authorize(Roles = "Customer")]

        public IActionResult ViewItemsInCart(int sessionnId)
        {
            return Ok(_service.ViewItemsInCart(sessionnId));
        }
    }
}
