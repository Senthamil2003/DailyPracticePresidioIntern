using DoctorClinicManagerWebApi.Interface;
using DoctorClinicManagerWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorClinicManagerWebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorbl;

        public DoctorController(IDoctorService doctorbl) {
            _doctorbl = doctorbl;
        }
        [Route("/GetAllDoctor")]
        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> GetAllDoctor()
        {
            try
            {
              return Ok(await _doctorbl.GetAllDoctors());

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);  
            }
        }

        [Route("/GetAllDoctorBySpecialization")]
        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> GetAllDoctorBySpecialization(string specialization)
        {
            try
            {
                return Ok(await _doctorbl.GetDoctorsByspeciality(specialization));

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Route("/updateExperience")]
        [HttpPut]
        public async Task<ActionResult<Doctor>> UpdateExperience(int id,int Experience)
        {
            try
            {
                return Ok(await _doctorbl.UpdateDocotrExperience(id,Experience));

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }



    }
}
