using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
using ProductApp.Service;

namespace ProductApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        private readonly IRepository<int,Product> _product;

        public AdminController(IRepository<int,Product> product)
        {
            _product = product;

        }



        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProduct()
        {
            try
            {
                var result = (await _product.Get()).ToList();
                return Ok(result);
            }
            catch (Exception nefe)
            {
                return NotFound(new ErrorResponse(nefe.Message,404));
            }
        }


    }
}
