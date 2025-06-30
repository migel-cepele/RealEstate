using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Interfaces;
using RealEstate.Domain;

namespace RealEstate.Controllers
{
    [Route("api/application")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
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
