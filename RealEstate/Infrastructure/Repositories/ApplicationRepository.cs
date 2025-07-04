using RealEstate.API.Domain;
using RealEstate.API.Infrastructure.Data;
using RealEstate.API.Application.Interfaces;

namespace RealEstate.API.Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;

        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddApplicationAsync(UserApplication application)
        {
            await _context.UserApplications.AddAsync(application);
            await _context.SaveChangesAsync();
        }

        public List<UserApplication> GetApplications()
        {
            return _context.UserApplications.ToList();
        }
    }
}
