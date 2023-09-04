using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using kart.Service.Buisness;
using kart.Service.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kart.Service.Api.Controllers
{
    
    
    public class Controller : ControllerBase
    {

        private readonly IkartService _service;

        public Controller(IkartService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetProductByTitle/{title}")]

        public IActionResult GetProductsByTitle(string title)
        {
            var res = _service.GetProductsByTitle(title);
            return Ok(res);

        }

        [HttpGet]
        [Route("GetProductByCategory/{categoryid}")]

        public IActionResult GetProductsByCategory(int categoryid)
        {
            var res = _service.GetProductsByCategory(categoryid);
            return Ok(res);

        }

        [HttpGet]
        [Route("GetAllProducts/")]

        public IActionResult GetAllProducts()
        {
            var res = _service.GetAllProducts();
            return Ok(res);

        }

        [HttpPost]
        [Route("AddProductToCart/")]

        public IActionResult AddProductToCart([FromBody] CartRequestModel product)
        {
            _service.AddProductToCart(product);
            return Ok("Product Added");
        }





    }
}
