using RealEstate.Domain;
using RealEstate.Data;

namespace RealEstate.Infrastructure.Repositories
{
    public class HouseRepository
    {
        private readonly AppDbContext _context;

        public HouseRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<House> GetHouses()
        {
            return _context.Houses.ToList();
        }

        public void AddHouse(House house)
        {
            _context.Houses.Add(house);
            _context.SaveChanges();
        }

        public House? GetHouseById(int id)
        {
            return _context.Houses.FirstOrDefault(h => h.Id == id);
        }
    }
}
