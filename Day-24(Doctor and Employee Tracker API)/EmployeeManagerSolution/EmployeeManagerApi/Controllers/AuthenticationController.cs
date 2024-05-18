using EmployeeManagerApi.Interface;
using EmployeeManagerApi.Model;
using EmployeeManagerApi.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagerApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _userbl;

        public AuthenticationController(IAuthenticationService userbl) {
            _userbl=userbl;
        }
  
        [HttpPut("Login")]
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
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
        [HttpPost("Register")]
        [ProducesResponseType(typeof(SuccessLogin), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SuccessLogin>> Register(EmployeeUserDTO userDTO)
        {
            try
            {
                SuccessLogin result = await _userbl.Register(userDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }

    }
}
