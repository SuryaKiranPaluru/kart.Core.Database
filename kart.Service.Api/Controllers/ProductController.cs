using FluentValidation;
using kart.Core.Dto.RequestModel;
using kart.Service.Buisness;
using Microsoft.AspNetCore.Mvc;

namespace kart.Service.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly IValidator<ProductRequestModel> _productRequestValidator;
        private readonly IProductService _service;

        public ProductController(IProductService service, IValidator<ProductRequestModel> productRequestValidator)
        {
            _service = service;
            _productRequestValidator = productRequestValidator;
        }

        [HttpPost]
        [Route("AddNewProduct/")]

        public IActionResult AddNewProduct([FromBody] ProductRequestModel product)
        {
            var validationResults = this._productRequestValidator.Validate(product) ?? new FluentValidation.Results.ValidationResult();
            if (!validationResults.IsValid)
            {
                var errorMessage = string.Empty;
                foreach (var failure in validationResults.Errors)
                {
                    errorMessage += $"Property: {failure.PropertyName} Error Code: {failure.ErrorMessage}\n";
                }
                return BadRequest(errorMessage);
            }
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
