using EmployeeManagerApi.CustomExceptions;
using EmployeeManagerApi.Interface;
using EmployeeManagerApi.Model;
using EmployeeManagerApi.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagerApi.Controllers
{
    [Authorize(Roles ="User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userbl;

        public UserController(IUserService employeebl) { 

            _userbl=employeebl;

        }
        
        [ProducesResponseType(typeof(SuccessRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [Route("api/User/RaiseRequest")]
        [HttpPost]
        public async Task<ActionResult<SuccessRequest>> RaiseRequest(RaiseRequestDTO request)
        {
            try
            {
                var requestresult = await _userbl.RaiseRequest(request);
                return Ok(requestresult);
            }
            catch (Exception nefe)
            {
                return NotFound(new ErrorModel(404, nefe.Message));
            }
        }
        [ProducesResponseType(typeof(IList<RequestListDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [Route("api/User/GetMyRequest")]
        [HttpPost]
        public async Task<ActionResult<IList<RequestListDTO>>> GetMyRequest(ViewRequestDTO request)
        {
            try
            {
                var requestresult = await _userbl.GetMyRequests(request);
                return Ok(requestresult);
            }
            catch (Exception nefe)
            {
                return NotFound(new ErrorModel(404, nefe.Message));
            }
        }


    }
}
