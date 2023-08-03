using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentEmploymentPortalAPI.Interfaces;

namespace StudentEmploymentPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ILookupRepository _lookupRepository;

        public LookupController(ILookupRepository lookupRepository)
        {
            _lookupRepository = lookupRepository;
        }

        [HttpGet("Departments")]
        public IActionResult GetDepAndFac() 
        {
            return Ok(_lookupRepository.GetDepartmentWithFaculty());
        }

        [HttpGet("YearOfStudy")]
        public IActionResult GetYearOfStudy()
        {
            return Ok(_lookupRepository.GetYearOfStudy());
        }

        [HttpGet("Genders")]
        public IActionResult GetGender()
        {
            return Ok(_lookupRepository.GetGender());
        }

        [HttpGet("Races")]
        public IActionResult GetRace()
        {
            return Ok(_lookupRepository.GetRace());
        }

        [HttpGet("DriversLicense")]
        public IActionResult GetDriversLicense()
        {
            return Ok(_lookupRepository.GetDriversLicense());
        }
    }
}
