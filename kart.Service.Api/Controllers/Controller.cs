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
            if (res == null) return Ok("Sorry no products found..");
            return Ok(res);

        }

        [HttpGet]
        [Route("GetProductByCategory/{categoryid}")]

        public IActionResult GetProductsByCategory(int categoryid)
        {
            var res = _service.GetProductsByCategory(categoryid);
            if (res == null) return Ok("Sorry no products found..");
            return Ok(res);

        }

        [HttpGet]
        [Route("GetAllProducts/")]

        public IActionResult GetAllProducts()
        {
            var res = _service.GetAllProducts();
            if (res == null) return Ok("Sorry no products found..");
            return Ok(res);

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
        [Authorize(Roles = "Customer")]
        
        public IActionResult ViewItemsInCart(int sessionnId) 
        {
            return Ok(_service.ViewItemsInCart(sessionnId));
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
