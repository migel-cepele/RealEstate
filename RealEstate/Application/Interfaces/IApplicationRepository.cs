using RealEstate.API.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.API.Application.Interfaces
{
    public interface IApplicationRepository
    {
        Task AddApplicationAsync(UserApplication application);
        List<UserApplication> GetApplications();
    }
}
