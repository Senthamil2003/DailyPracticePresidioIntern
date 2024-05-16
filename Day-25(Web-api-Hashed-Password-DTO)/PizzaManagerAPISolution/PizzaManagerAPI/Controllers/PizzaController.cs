using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaManagerAPI.Model.DTO;
using PizzaManagerAPI.Model;
using PizzaManagerAPI.Services;
using PizzaManagerAPI.Interface;
using Microsoft.AspNetCore.Authorization;

namespace PizzaManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaservice;

        public PizzaController(IPizzaService pizzaservice) {
            _pizzaservice=pizzaservice;
        }
        [Authorize]
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<Pizza>>> GetAllPizza()
        {
            try
            {
                return  Ok(await _pizzaservice.GetAllAvailablePizza());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
