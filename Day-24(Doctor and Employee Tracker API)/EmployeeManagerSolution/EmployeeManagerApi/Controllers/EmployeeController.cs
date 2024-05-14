using EmployeeManagerApi.CustomExceptions;
using EmployeeManagerApi.Interface;
using EmployeeManagerApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagerApi.Controllers
{
    
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeebl;

        public EmployeeController(EmployeeService employeebl) { 

            _employeebl=employeebl;

        }
        [Route("api/getaAllEmployee")]
        [HttpGet]
        public async Task<ActionResult<IList<Employee>>> Get()
        {
            try
            {
                var employees = await _employeebl.GetEmployees();
                return Ok(employees.ToList());
            }
            catch (Exception nefe)
            {
                return NotFound(nefe.Message);
            }
        }
        [Route("api/UpdateEmployee")]
        [HttpPut]
        public async Task<ActionResult<Employee>> updateEmployee(int id,string phone)
        {
            try
            {
                Employee employee =await  _employeebl.UpdateEmployeePhone(id, phone);
                return Ok(employee);

            }
            catch(Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }
        [Route("api/getbyphone")]
        [HttpGet]
        public async Task<ActionResult<Employee>> getByPhone(string phone)
        {
            try
            {
             Employee employee= ( await _employeebl.GetEmployees()).FirstOrDefault(e=>e.Phone==phone);
             return Ok(employee);


            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
