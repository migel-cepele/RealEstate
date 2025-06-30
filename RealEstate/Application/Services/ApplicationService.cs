using RealEstate.Application.Interfaces;
using RealEstate.Domain;
using RealEstate.Infrastructure.Repositories;
using RealEstate.Common;

namespace RealEstate.Application.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly ApplicationRepository _repository;

        public ApplicationService(ApplicationRepository repository)
        {
            _repository = repository;
        }

        public OperationResult AddApplication(UserApplication application)
        {
            try
            {
                _repository.AddApplication(application);
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
