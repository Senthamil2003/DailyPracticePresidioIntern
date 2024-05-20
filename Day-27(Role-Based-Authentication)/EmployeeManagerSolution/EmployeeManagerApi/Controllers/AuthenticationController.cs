using EmployeeManagerApi.Interface;
using EmployeeManagerApi.Model;
using EmployeeManagerApi.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagerApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _userbl;
        private readonly ILogger<UserController> _logger;

        public AuthenticationController(IAuthenticationService userbl,ILogger<UserController> logger) {
            _userbl=userbl;
            _logger=logger;
        }
  
        [HttpPost("Login")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Employee>> Login(LoginDTO userLoginDTO)
        {
            try
            {
                var result = await _userbl.Login(userLoginDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {

                _logger.LogCritical("=-----------------------------User is not-------------------------------------"+ex.Message);
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
        [HttpPost("Register")]
        [ProducesResponseType(typeof(SuccessRegisterDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SuccessRegisterDTO>> Register(EmployeeUserDTO userDTO)
        {
            try
            {
                SuccessRegisterDTO result = await _userbl.Register(userDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }

    }
}
