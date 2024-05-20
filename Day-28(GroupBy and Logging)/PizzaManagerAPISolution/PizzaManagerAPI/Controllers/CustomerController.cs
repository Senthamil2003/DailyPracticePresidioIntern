using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaManagerAPI.Interface;
using PizzaManagerAPI.Model;
using PizzaManagerAPI.Model.DTO;

namespace PizzaManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customer;
        private readonly ILogger<PizzaController> _logger;

        public CustomerController(ICustomerService customerService,ILogger<PizzaController> logger)
        {
            _customer=customerService;
            _logger = logger;
        }
        [HttpPost("Login")]
        [ProducesResponseType(typeof(SuccessLogin), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<SuccessRegister>> Login(LoginDTO userLoginDTO)
        {
            try
            {
                var result = await _customer.Login(userLoginDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
        [HttpPost("Register")]
        [ProducesResponseType(typeof(SuccessRegister), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SuccessRegister>> Register(RegisterDTO userDTO)
        {
            try
            {
                SuccessRegister result = await _customer.Register(userDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }

    }
}
