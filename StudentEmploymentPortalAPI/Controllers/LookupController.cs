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

         [HttpGet("LookupData")]
        public IActionResult GetLookupData() 
        {
            return Ok(_lookupRepository.GetLookupData());
        }
    }
}
