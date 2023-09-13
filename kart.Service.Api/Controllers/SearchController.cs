using kart.Service.Buisness;
using Microsoft.AspNetCore.Mvc;

namespace kart.Service.Api.Controllers
{
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _service;

        public SearchController(ISearchService service)
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
    }
}
