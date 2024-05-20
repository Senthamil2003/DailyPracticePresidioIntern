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
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(IPizzaService pizzaservice,ILogger<PizzaController> logger) {
            _pizzaservice=pizzaservice;
            _logger= logger;
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
                _logger.LogCritical(ex.Message);
                return BadRequest(ex.Message);
            }
        }



    }
}
