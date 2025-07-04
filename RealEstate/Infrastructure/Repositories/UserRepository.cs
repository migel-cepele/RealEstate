using RealEstate.API.Domain;
using RealEstate.API.Infrastructure.Data;
using RealEstate.API.Application.Interfaces;

namespace RealEstate.API.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<User> GetAll() => _context.Users.ToList();
        public User? GetById(long id) => _context.Users.Find(id);
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public void Delete(long id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}