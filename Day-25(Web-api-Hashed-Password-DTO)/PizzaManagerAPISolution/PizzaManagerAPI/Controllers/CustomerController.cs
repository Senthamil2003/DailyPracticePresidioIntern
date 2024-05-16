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

        public CustomerController(ICustomerService customerService)
        {
            _customer=customerService;
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
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }

    }
}
