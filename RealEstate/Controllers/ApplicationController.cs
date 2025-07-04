using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Application.Services;
using RealEstate.API.Domain;

namespace RealEstate.API.Controllers
{
    [Route("api/application")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationService _applicationService;

        public ApplicationController(ApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public IActionResult AddApplication([FromBody] UserApplication application)
        {
            var result = _applicationService.AddApplication(application);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetApplications()
        {
            var applications = _applicationService.GetApplications();
            return Ok(applications);
        }
    }
}
