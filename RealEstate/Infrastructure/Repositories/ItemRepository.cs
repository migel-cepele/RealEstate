using RealEstate.API.Domain;
using RealEstate.API.Infrastructure.Data;
using RealEstate.API.Application.Interfaces;
using RealEstate.API.Application.Common;

namespace RealEstate.API.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Item> GetAll() => _context.Items.ToList();
        public Item? GetById(long id) => _context.Items.Find(id);
        public void Add(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }
        public void Update(Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }
        public void Delete(long id)
        {
            var item = _context.Items.Find(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }

        public PaginationResult<Item> Filter(int pageNumber, int pageSize, Dictionary<string, string> keyValues)
        {
            throw new NotImplementedException();
        }
    }
}