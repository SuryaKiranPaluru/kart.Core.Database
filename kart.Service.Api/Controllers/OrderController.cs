using FluentValidation;
using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using kart.Service.Buisness;
using kart.Service.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kart.Service.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class OrderController : ControllerBase
    {

        private readonly IOrderService _service;
        private readonly IValidator<OrderRequestModel> _orderRequestValidator;

        public OrderController(IOrderService service, IValidator<OrderRequestModel> orderRequestValidator)
        {
            _service = service;
            _orderRequestValidator = orderRequestValidator;
        }


        [HttpPost]
        [Route("PlaceOrder/")]

        public IActionResult PlaceOrder([FromBody] OrderRequestModel order)
        {
            var validationResults = this._orderRequestValidator.Validate(order) ?? new FluentValidation.Results.ValidationResult();
            if (!validationResults.IsValid)
            {
                var errorMessage = string.Empty;
                foreach (var failure in validationResults.Errors)
                {
                    errorMessage += $"Property: {failure.PropertyName} Error Code: {failure.ErrorMessage}\n";
                }
                return BadRequest(errorMessage);
            }

            _service.PlaceOrder(order);
            return (Ok("Your Order Placed Successfully"));
        }

    }
}
