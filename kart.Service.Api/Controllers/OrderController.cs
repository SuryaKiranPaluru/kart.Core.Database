using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using kart.Service.Buisness;
using kart.Service.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kart.Service.Api.Controllers
{



    public class OrderController : ControllerBase
    {

        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }


        [HttpPost]
        [Route("PlaceOrder/")]

        public IActionResult PlaceOrder([FromBody] OrderRequestModel order)
        {
            _service.PlaceOrder(order);
            return (Ok("Your Order Placed Successfully"));
        }

    }
}
