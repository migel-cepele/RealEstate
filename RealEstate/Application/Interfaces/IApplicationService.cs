using RealEstate.Domain;
using RealEstate.Common;

namespace RealEstate.Application.Interfaces
{
    public interface IApplicationService
    {
        OperationResult AddApplication(UserApplication application);
        List<UserApplication> GetApplications();
    }
}
