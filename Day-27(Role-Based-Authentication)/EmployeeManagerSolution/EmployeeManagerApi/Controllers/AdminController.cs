using EmployeeManagerApi.Interface;
using EmployeeManagerApi.Model;
using EmployeeManagerApi.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagerApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminservice;

        public AdminController(IAdminService adminservice) {
            _adminservice=adminservice;

        }
  
        [ProducesResponseType(typeof(SuccessActivation), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [Route("ActiveEmployee")]
        [HttpGet]
        public async Task<ActionResult<SuccessActivation>> ActiveEmployee(int id)
        {
            try
            {
                SuccessActivation success= await _adminservice.ActiveEmployee(id);
                return Ok(success);
            }
            catch (Exception nefe)
            {
                return NotFound(new ErrorModel(404, nefe.Message));
            }
        }
      
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [Route("GetActiveRequests")]
        [HttpGet]
        public async Task<ActionResult<IList<Request>>> GetAllActiveRequest()
        {
            try
            {
                IList<Request> success = await _adminservice.GetAllRequest();
                return Ok(success);
            }
            catch (Exception nefe)
            {
                return NotFound(new ErrorModel(404, nefe.Message));
            }
        }
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [Route("CloseRequest")]
        [HttpGet]
        public async Task<ActionResult<SuccessRequestClose>> CloseRequest(int RequestId)
        {
            try
            {
                SuccessRequestClose success = await _adminservice.CloseRequest(RequestId);
                return Ok(success);
            }
            catch (Exception nefe)
            {
                return NotFound(new ErrorModel(404, nefe.Message));
            }
        }
    }

}
