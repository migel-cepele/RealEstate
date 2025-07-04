using RealEstate.API.Application.Interfaces;
using RealEstate.API.Domain;
using RealEstate.API.Application.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.API.Application.Services
{
    public class ApplicationService
    {
        private readonly IApplicationRepository _repository;

        public ApplicationService(IApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> AddApplicationAsync(UserApplication application)
        {
            try
            {
                await _repository.AddApplicationAsync(application);
                return OperationResult.Ok("Application submitted successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Failed to submit application.", ex.Message);
            }
        }

        public List<UserApplication> GetApplications()
        {
            return _repository.GetApplications();
        }
    }
}
