using RealEstate.Domain;
using RealEstate.Data;

namespace RealEstate.Infrastructure.Repositories
{
    public class ApplicationRepository
    {
        private readonly AppDbContext _context;

        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddApplication(UserApplication application)
        {
            _context.UserApplications.Add(application);
            _context.SaveChanges();
        }

        public List<UserApplication> GetApplications()
        {
            return _context.UserApplications.ToList();
        }
    }
}
